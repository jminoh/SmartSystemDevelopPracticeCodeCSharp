using myLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatting
{
    public partial class frmChat : Form
    {
        public frmChat()
        {
            InitializeComponent();
        }
        /// <summary>
        /// delegate와 Invoke 대리호출 함수 대체하는
        /// Timer 이용법 예시
        /// 전역변수 strText를 이용해서 쓰레드 함수에서 기록한 내용을
        /// Timer가 TextBox에 출력
        /// </summary>
        //string strText = "";
        //void AddText(string str)        
        //{
        //    strText += str;
        //}

        //private void timer1_Tick(object sender, EventArgs e)        // 일정시간 간격으로 TextBox에 출력
        //{
        //    tbChat.Text += strText;
        //    strText = "";
        //}

        delegate void CB1(string s);
        void AddText(string str)
        {
            if(tbChat.InvokeRequired)
            {
                CB1 cb = new CB1(AddText);
                object[] obj = { str };
                Invoke(cb, obj);
                //Invoke(cb, new object[] { str });     // 위 두 줄 한줄로 줄인 것
            }
            else
            {                                       // else에는 원래 해야 하는 것
                tbChat.Text += str;
            }
        }
        void AddList(string str)            // argument type이 똑같기 때문(string 하나)에, delegate 다시 만들 필요 없음
        {
            if(statusStrip1.InvokeRequired)             // sbConnectList에선 죽어라 찾아도 안 나옴(Sub Component라서), Invoke는 Main Component에서 발생함
            {
                CB1 cb = new CB1(AddList);              
                Invoke(cb, new object[] { str });       // object Array
            }
            else
            {
                sbConnectList.DropDownItems.Add(str);
            }
        }
        class TcpEx
        {
            public TcpClient tp;
            public string id;
            public TcpEx(TcpClient t, string s)
            {
                tp = t;
                id = s;
            }
        };

        SqlDB sqldb = new SqlDB(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\snows\source\repos\SmartSystemDevelopPracticeCodeCSharp\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");

        Socket sock = null;
        TcpListener listen = null;          // Session 만들어짐(TCPClient)
        List<TcpEx> tcp = new List<TcpEx>();               // Session   // TcpClient type의 제네릭 List Object 선언
        // TcpClient[] tcp = new TcpClient[10];

        Thread threadServer = null;         // 외부 요청 처리
        Thread threadRead = null;         // Port에서 값을 읽어서 처리

        bool OperationMode = false; // false: Server Mode, true: Client Mode     
        string sUID = "Noname";
        string sPWD = "";
        string ConnectIP = "127.0.0.1";     // 내가 외부로 접속할 IP, Server면 의미 X, Client로 접속할 때
        int ConnectPort = 9000;
        int ServerPort = 9000;              // Port Address 초기화
        iniFile ini = new iniFile(@".\chat.ini");      // 파일명 넣어주면 됨. Local, \기호는 두 개 써줘야, 하나만 쓰고 싶으면 맨 앞에 @(""안의 Escape sequence 무시해줌)
        
        private void frmChat_Load(object sender, EventArgs e)
        {
            //string test = "\u003abcdefgh\u0002";
            //byte[] bTest = Encoding.Default.GetBytes(test);
            int X = int.Parse(ini.GetString("Location", "X", "0"));    // 프로그램 시작 위치(기본위치) 설정 // Local에서 this는 뺄 수 있음 // Location은 포인트 변수(직접사용 불가)
            int Y = int.Parse(ini.GetString("Location", "Y", "0"));
            Location = new Point(X, Y);
            int SX = int.Parse(ini.GetString("Size", "X", "300"));
            int SY = int.Parse(ini.GetString("Size", "Y", "500"));
            int DIST = int.Parse(ini.GetString("Size", "DIST", "350"));                     // 스플릿 컨테이너 SplitterDistance
            Size = new Size(SX, SY);
            splitContainer1.SplitterDistance = DIST;

            //string s = ini.GetString("Operation", "ServerPort", "9000");       // Default 9000, 바꾸면 ini file에도 저장
            ServerPort = int.Parse(ini.GetString("Operation", "ServerPort", "9000"));       // Default 9000, 바꾸면 ini file에도 저장
            ConnectPort = int.Parse(ini.GetString("Operation", "ConnectPort", "9000"));     // 셋다 closing에 붙여 넣어야 함
            ConnectIP = ini.GetString("Operation", "ConnectIP", "127.0.0.1");
            sUID = ini.GetString("Operation", "UID", "Noname");
            sPWD = ini.GetString("Operation", "PWD", "");                                   // 실제 적용 시 암호화 처리 후 저장
        }

        /// <summary>
        /// 프로그램의 시작과 동시에 서버 포트를 오픈하고 리스너를 시작
        /// Session Thread와 Read Thread를 시작
        /// </summary>
        void InitServer()
        {
            if (listen != null) listen.Stop();          // 기존에 수행되고 있는 리스너 중지
            listen = new TcpListener(ServerPort);        // TcpListener에 서버 포트
            listen.Start();

            if (threadServer != null) threadServer.Abort();
            threadServer = new Thread(ServerProcess);
            threadServer.Start();                           // 재실행

            if (threadRead != null) threadRead.Abort();
            threadRead = new Thread(ReadProcess);
            threadRead.Start();                             // 재실행

            sbConnectList.DropDownItems.Add("모두에게");
            //timer1.Start();
        }

        void CloseServer()
        {
            //timer1.Stop();
            if (listen != null) listen.Stop();          // 기존에 수행되고 있는 리스너 중지
            if (threadServer != null) threadServer.Abort();
            if (threadRead != null) threadRead.Abort();
        }

        bool IsAlive(Socket sck)                        // true: Alive, false: Dead                 //////////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
        {
            if (sck == null) return false;
            if (sck.Connected == false) return false;

            bool b1 = sck.Poll(1000, SelectMode.SelectRead);    // Socket 상태 확인 위해 똑똑(Polling)  // false(0): 정상, true(1, 정확히는 0 이외의 값): 문제
            bool b2 = sck.Available == 0;                        // buffer에 읽을 data가 있냐  // true: 정상, false: 비정상
            if (b1 || !b2) return false;
            // 여기까진 오류(끊어진 상황) Check
            try // 송신과정에서의 오류를 모니터링해서, 리턴값으로
            {
                sck.Send(new byte[1], 0, SocketFlags.OutOfBand);  //  0개의 byte 던짐(실제 날아가는 데이터 X)
                return true;
            }
            catch
            {
                return false;                                       // 날아가는 거 없는데 문제 생기면, 문제 있는 거 
            }
        }

        void ServerProcess()            // 초기화 Process
        {
            byte[] buf = new byte[100];        // 상대방 확인 절차, 많은 바이트 필요 X
            while (true)
            {
                if (listen.Pending())                    // Client로부터 접속요청 있는가?
                {
                    TcpClient tp = listen.AcceptTcpClient();        // AcceptTcpClient(): Blocking 함수
                    tp.Client.Send(Encoding.Default.GetBytes($"REQ{tp.Client.RemoteEndPoint.ToString()}"));     // Accept후 REQ 보내줌
                    int n = tp.Client.Receive(buf);         // Receive도 Blocking 함수. data 안 들어오면 무한 대기      // Client에서 보내준 data 받음
                    string sId = Encoding.Default.GetString(buf, 0, n).Split(':')[1];       // NAM: name    // GetString 매개변수 중 0(Override)
                    string sPw = Encoding.Default.GetString(buf, 0, n).Split(':')[2];
                    string ret = sqldb.GetString($"select name from users where name = '{sId}'");
                    string pret = sqldb.GetString($"select passwd from users where name = '{sId}'");

                    frmNetConfig dlg = new frmNetConfig();
                    if(sId != ret)
                    {
                        tp.Client.Send(Encoding.Default.GetBytes($"REJECT:올바른 사용자가 아닙니다"));
                        tp.Close();
                    }
                    else if ((sId == ret) && (sPw != pret))
                    {
                        tp.Client.Send(Encoding.Default.GetBytes($"REJECT:올바른 사용자가 아닙니다"));
                        tp.Close();
                    }
                    else
                    {
                        //tp.Client.Send(Encoding.Default.GetBytes($"ACCEPT:접속이 허가되었습니다"));
                        //tcp.Add(new TcpEx(tp, sId));         // Add: List Object의 method    // List에 정보 저장
                        ////sbConnectList.DropDownItems.Add(sId);
                        //AddList(sId);                               // Status Bar에 접속자 리스트  // 크로스 스레드 에러 막기 위해 
                        //AddText($"{sId}({tp.Client.RemoteEndPoint.ToString()}) 로부터 접속되었습니다.\r\n");  // 화면 상에 접속 내용 표출

                        //======================================================= 무명메소드
                        //delegate void CB1(string str);
                        //if (statusStrip1.InvokeRequired)            
                        //{
                        //    CB1 cb = new CB1(AddList);
                        //    Invoke(cb, new object[] { str });       //
                        //}
                        //else
                        //{
                        //    sbConnectList.DropDownItems.Add(str);
                        //}
                        tp.Client.Send(Encoding.Default.GetBytes($"ACCEPT:접속이 허가되었습니다"));
                        tcp.Add(new TcpEx(tp, sId));
                        AddText($"{sId}({tp.Client.RemoteEndPoint.ToString()}) 로부터 접속되었습니다.\r\n");
                        if (InvokeRequired)
                        {
                            Invoke(new MethodInvoker(delegate () { sbConnectList.DropDownItems.Add(sId); }));    // 무명 메소드 처리
                        }
                    }
                }
                Thread.Sleep(100);
            }
        }

        void ReadProcess()
        {
            byte[] buf = new byte[1024];    // 1K byte  // 정의해서 사용하면 좋음 MAX_BUF_SIZE = 1024처럼
            while (true)
            {
                for(int i = 0; i < tcp.Count; i++)  // List Object의 크기
                {
                    if (tcp[i].tp.Available > 0)           // List Object의 [] Operator를 이용해서 배열처럼 관리   // 데이터 읽어올 것 있다면?
                    {
                        //NetworkStream ns = tcp[i].GetStream();
                        //ns.Read();                                // 값 가져오기, byte[]로(NetworkStream으로 값 가져오려면 byte[]이용해야)
                        int n = tcp[i].tp.Client.Receive(buf);                 // flag지정은 권장 X, Receive는 받아온 문자수를 돌려주지만 Null(\0)은 안 붙여줌
                        AddText(Encoding.Default.GetString(buf, 0, n));   //strText = Encoding.Default.GetString(buf);  -> delegate로 수정하면 이것도 수정해야
                    }                                                       // GetString에서 출력할 개수를 지정함(n) or 그만큼 출력하고 Null 붙여줌
                }
                Thread.Sleep(100);
            }
        }


        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseServer();
            if (threadClient != null) threadClient.Abort();

            ini.GetString("Operation", "ServerPort", $"{ServerPort}");          // 마지막 접속 정보 ini File에 저장
            ini.GetString("Operation", "ConnectPort", $"{ConnectPort}");    
            ini.GetString("Operation", "ConnectIP", ConnectIP);
            ini.GetString("Operation", "UID", sUID);
            ini.GetString("Operation", "PWD", sPWD);

            ini.WriteString("Location", "X", $"{Location.X}");    
            ini.WriteString("Location", "Y", $"{Location.Y}");
            ini.WriteString("Size", "X", $"{Size.Width}");
            ini.WriteString("Size", "Y", $"{Size.Height}");
            ini.WriteString("Size", "DIST", $"{splitContainer1.SplitterDistance}");     
        }

        private void pmnuConnect_Click(object sender, EventArgs e)
        {
            if (sock != null)
            {
                if (MessageBox.Show("연결을 다시 수립하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No) return;
                if (threadClient != null) threadClient.Abort();
                sock.Close();
            }
            byte[] buf = new byte[100];
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(ConnectIP, ConnectPort);                                   // Socket 정보로 Connect 수행(연걸 수립)

            // Server로부터 ACK대신에
            int n = sock.Receive(buf);                                              // REQ: 연결 수립 통보 / myIP 수신
            string myIp = Encoding.Default.GetString(buf, 0, n).Split(':')[1];      // Server로부터 Accept 받음(내 IP주소 되돌려 받음)   // 나의 위치를 알기 위함임.
            AddText($"Return Message : {myIp}\r\n");
            sock.Send(Encoding.Default.GetBytes($"NAM:{sUID}:{sPWD}"));                    // Server에 내 이름이랑 비밀번호 보내줌********************8
            string a = sPWD;

            n = sock.Receive(buf);                                                  // 최종 수락/거부 통보
            string sRet = Encoding.Default.GetString(buf, 0, n).Split(':')[0];      // Server로부터 Accept 받음(내 IP주소 되돌려 받음)
            if(sRet == "REJECT")
            {
                AddText("서버로부터 접속이 거부되었습니다.\r\n");
                return;                                                             // thread 수행 X, 탈출
            }
            AddText("서버와 접속되었습니다.\r\n");
            threadClient = new Thread(ClientProcess);                               // REJECT가 아니라면
            threadClient.Start();
            tbTalk.Text = "";
        }

        Thread threadClient = null;
        void ClientProcess()
        {
            byte[] buf = new byte[1024];
            while (true)
            {
                if (IsAlive(sock) && sock.Available > 0)      // socket이 살아있다면 + socket에 읽어올 것이 있다면
                {
                    int n = sock.Receive(buf);
                    AddText(Encoding.Default.GetString(buf, 0, n));     // 0번째부터 n번째까지
                }
                Thread.Sleep(100);
            }
        }

        private void tbTalk_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(OperationMode == false)                  // Server Mode  // false면 Server, true면 Client
                {
                    for(int i = 0; i < tcp.Count; i++)      // tcp: List<TcpEx>의 list   -> List: 일종의 배열 Object
                    {
                        if (sbConnectList.Text == "모두에게" || tcp[i].id == sbConnectList.Text)    // Server Pross 에서 i번째 배열요소 // id: 클라이언트가 등록한 이름
                        {
                            TcpClient tp = tcp[i].tp;
                            if (IsAlive(tp.Client))                                          // 살아있다면 전송해라
                            { 
                                tp.Client.Send(Encoding.Default.GetBytes(tbTalk.Text));
                            }
                        }
                    }
                    tbTalk.Text = "";
                }
                else   // Client Mode
                {
                    if(sock != null)
                    {
                        if (IsAlive(sock))                                                  // 살아있다면 전송해라
                        {
                            sock.Send(Encoding.Default.GetBytes(tbTalk.Text));
                            tbTalk.Text = "";
                        }
                        else
                        {
                            AddText("Server와의 연결이 끊어졌습니다.");
                            sock.Close();                                                   // 정상 종료
                            sock = null;
                        }
                    }
                }
            }
        }

        private void pmnuServerStart_Click(object sender, EventArgs e)
        {
            InitServer();
            AddText($"Server가 [{ServerPort}] Port에서 시작되었습니다.\r\n");
        }

        private void pmnuNetworkConfig_Click(object sender, EventArgs e)
        {
            frmNetConfig dlg = new frmNetConfig(ServerPort, ConnectPort, ConnectIP, sUID, sPWD, OperationMode);      // 값 안 주면, Default값으로
            if (dlg.ShowDialog() == DialogResult.OK)    // Show() X, ShowDialog
            {
                ServerPort = int.Parse(dlg.tbServerPort.Text);              // Component Public으로 바꿔줘서 접근 가능
                ConnectPort = int.Parse(dlg.tbConnectPort.Text);
                ConnectIP = dlg.tbConnectIP.Text;
                sUID = dlg.tbUID.Text;
                sPWD = dlg.tbPWD.Text;
                OperationMode = dlg.rbClient.Checked;
            }
        }

        private void sbConnectList_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            sbConnectList.Text = e.ClickedItem.Text;
        }
    }
}
