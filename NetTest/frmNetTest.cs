using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetTest
{
    public partial class frmNetTest : Form
    {
        public frmNetTest()    
        {
            InitializeComponent();
        }

        delegate void CallBackAddText(string str);
        void AddText(string str)     // 문자열 str을 tbServer TextBox에 출력하는 함수, 출력만 하니까 return 필요 없음(void)
        {
            if(tbServer.InvokeRequired)                 // 대리 호출이 필요한가?
            {
                CallBackAddText cb = new CallBackAddText(AddText);
                object[] obj = { str };
                Invoke(cb, obj);                            // new object[] { str }라고 써도 됨(윗줄이랑 해당 줄 obj 빼고, obj 자리에)
            }
            else
            {
                tbServer.Text += str;
            }
        }

        Socket sock = null;
        TcpClient tcp = null;
        TcpListener listen = null;
        Thread threadServer = null;
        Thread threadRead = null;
        private void btnServerStart_Click(object sender, EventArgs e)
        {
            if(listen != null)
            {
                DialogResult ret = MessageBox.Show("현재의 연결이 끊어집니다.\r\n계속 하시겠습니까?", "",  MessageBoxButtons.YesNo);
                if (ret == DialogResult.No) return;
                listen.Stop();      // 현재 오픈되어 있는 리스너를 중지
                threadServer.Abort();
                if (threadRead != null && threadRead.IsAlive) threadRead.Abort(); 
                if (tcp != null) tcp.Close();
            }
            listen = new TcpListener(int.Parse(tbServerPort.Text));                      // Port 정보를 argument로 받음, Client로부터 접속요구 받음
            listen.Start();

            threadServer = new Thread(ServerProcess);
            threadServer.Start();
            
            threadRead = new Thread(ReadProcess);

            //tbServer.Text += $"Server port [{tbServerPort.Text}] started.\r\n";
            AddText($"Server port [{tbServerPort.Text}] started.\r\n");
            //timer1.Enabled = true;
            
        }
        void ServerProcess()                                                    // Thread 함수, Call Back 함수(직접적으로 호출 X, 타 객체에 의해 수행됨)
        {
            while (true)
            {
                if (listen.Pending())                                           // 현재 보류중인 요청이 있는가(외부로부터의 접속요청이 있는가)
                {
                    tcp = listen.AcceptTcpClient();                             // socket 반환    // Blocking Mode: 세션 수립
                    threadRead.Start();
                    break;                                                      // serverProcess는 버튼을 다시 눌렀기 떄문에, 다시 동작(ReadProcess는 X)
                }
                Thread.Sleep(100);          // 1000이 1초 // Thread X, Library
            }
        }

        void ReadProcess()                                                      // 
        {
            NetworkStream ns = tcp.GetStream();                                 // tcp 수립 이후(server Process 내) // tcp Stream 가져와서 data 있으면 계속 화면에 뿌려줌
            byte[] bArr = new byte[512];
            while (true)
            {
                if (ns.DataAvailable)
                {
                    int n = ns.Read(bArr, 0, 512);                              // int n: Read byte
                    AddText(Encoding.Default.GetString(bArr, 0, n));
                }
                Thread.Sleep(100);
            }
        }

        private void frmNetTest_FormClosing(object sender, FormClosingEventArgs e)  // Form 닫을 때, thread도 닫히게
        {
            if (threadServer != null) threadServer.Abort();                         // Abort() 즉시 종료 X
        }

        private void timer1_Tick(object sender, EventArgs e)                    // 설정된 시간 간격마다 호출됨
        {                                                                       // Read Process

        }

        
    }
}
