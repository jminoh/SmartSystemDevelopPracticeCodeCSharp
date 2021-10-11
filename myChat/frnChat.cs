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

namespace myChat
{
    public partial class frmChat : Form
    {
        public frmChat()
        {
            InitializeComponent();
        }
        delegate void cbAddText(string str, int i);
        void AddText(string str, int i)
        {
            if(tbServer.InvokeRequired || tbClient.InvokeRequired)
            {
                cbAddText cb = new cbAddText(AddText);
                object[] obj = { str, i };
                Invoke(cb, obj);
            }
            else
            {
                if (i == 1)
                    tbServer.Text += str;
                else if (i == 2)
                    tbClient.Text += str;
            }
        }
        Socket sock = null;
        TcpClient tcp = null;
        TcpListener listen = null;
        Thread threadServer = null;     // Connect 요구 처리 Thread
        Thread threadRead = null;       // 입력 문자열 처리 Thread
        private void btnServerStart_Click(object sender, EventArgs e)
        {
            if(listen != null)          // null 이면 정상 수행, 
            {
                if (MessageBox.Show("Server를 다시 시작하시겠습니까?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    listen.Stop();
                    if (threadServer != null) threadServer.Abort();
                    if (threadRead != null) threadRead.Abort();
                }
            }
            listen = new TcpListener(int.Parse(tbServerPort.Text));
            listen.Start();
            AddText($"서버가 [{tbServerPort.Text}]에서 시작되었습니다.\r\n", 1);

            threadServer = new Thread(ServerProcess);
            threadServer.Start();
            threadRead = new Thread(ReadProcess);
        }

        void ServerProcess()            // Connect 요구 처리 Thread
        {
            while(true)
            {
                if (listen.Pending())
                {
                    if (tcp != null)
                    {
                        tcp.Close();
                        threadRead.Abort();
                    }
                    tcp = listen.AcceptTcpClient(); // 세션 수립
                    string sLabel = tcp.Client.RemoteEndPoint.ToString();       // Client IP Address: Port(Session)
                    AddText($"Client [{sLabel}] 로부터 접속되었습니다.\r\n", 1);      //tcp.Client는 Socket,
                    sbLable1.Text = sLabel;

                    threadRead = new Thread(ReadProcess);
                    threadRead.Start();
                }
                Thread.Sleep(100);
            }
        }

        void ReadProcess()
        {
            NetworkStream ns = tcp.GetStream();
            byte[] bArr = new byte[512];
            while (true)
            {
                if (ns.DataAvailable)
                {
                    int n = ns.Read(bArr, 0, 512);
                    AddText(Encoding.Default.GetString(bArr, 0, n), 1);
                }
                Thread.Sleep(100);
            }
        }

        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (threadServer != null) threadServer.Abort();
            if (threadRead != null) threadRead.Abort();
            if (threadClientRead != null) threadClientRead.Abort();
        }

        Thread threadClientRead = null;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (sock != null)
                if (sock.Connected)
                {
                    if(MessageBox.Show("재연결하시겠습니까?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        sock.Close();
                        threadClientRead.Abort();
                    }
                }
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);       // InterNetwork: Ethernet IPv4    // Socket 수립
                sock.Connect(tbConnectIP.Text, int.Parse(tbConnectPort.Text));      // Connection 수립 요청 - 대기(Blocking Mode)
                AddText($"Server [{tbConnectIP.Text}:{tbConnectPort.Text}] Connected OK.", 2);
                threadClientRead = new Thread(ClientReadProcess);
                threadClientRead.Start();
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        void ClientReadProcess()
        {
            byte[] bArr = new byte[512];
            while(true)
            {
                if(sock.Available > 0)      // 읽어올 data 있으면
                {
                    int n = sock.Receive(bArr);              // Receive할 때 byte[] 필요
                    AddText($"{Encoding.Default.GetString(bArr, 0, n)}", 2);     // byte이기 때문에 Encoding
                }
                Thread.Sleep(100);
            }
        }

        private void pmnuSendClientText_Click(object sender, EventArgs e)
        {
            string str = (tbClient.SelectedText.Length == 0) ? tbClient.Text : tbClient.SelectedText;
            byte[] bArr = Encoding.Default.GetBytes(str);
            sock.Send(bArr);
        }
    }
}
