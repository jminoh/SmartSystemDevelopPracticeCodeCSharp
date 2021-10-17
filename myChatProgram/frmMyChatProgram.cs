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

namespace myChatProgram
{
    public partial class frmMyChatProgram : Form
    {
        public frmMyChatProgram()
        {
            InitializeComponent();
        }
        delegate void cbAddText(string str, int i);
        void AddText(string str, int i)
        {
            if (tbCommunication.InvokeRequired || statusStrip1.InvokeRequired)
            {
                cbAddText cb = new cbAddText(AddText);
                object[] obj = { str, i };
                Invoke(cb, obj);
            }
            else
            {
                if (i == 1)
                    tbCommunication.Text += str;
                else if (i == 2)
                    sbClient.DropDownItems.Add(str);
            }
        }

        Socket sock = null;
        TcpListener listen = null;
        TcpClient[] tcp = new TcpClient[10];
        Thread threadServer = null;
        Thread threadRead = null;
        Thread threadClientRead = null;
        int CurrentClientNum = 0;
        string serverPort = null;
        string clientPort = null;
        string clientIP = null;


        private void mnuServerSet_Click(object sender, EventArgs e)
        {
            frmServer frmServ = new frmServer();
            frmServ.Show();
            serverPort = frmServ.tbServerPort.Text;
            ServerStart();
        }

        private void mnuClientSet_Click(object sender, EventArgs e)
        {
            frmClient frmCli = new frmClient();
            frmCli.Show();
            clientIP = frmCli.tbConnectionIP.Text;
            clientPort = frmCli.tbConnectionPort.Text;
        }

        private void ServerStart()
        {
            if (listen != null)
            {
                if (MessageBox.Show("Server 다시 시작?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    listen.Stop();
                    if (threadServer != null) threadServer.Abort();
                    if (threadRead != null) threadRead.Abort();
                }
            }
            listen = new TcpListener(int.Parse(serverPort));
            listen.Start();
            AddText($"서버 [{serverPort}] 시작\r\n", 1);

            threadServer = new Thread(ServerProcess);
            threadServer.Start();
        }
        void ServerProcess()
        {
            while (true)
            {
                if (listen.Pending())
                {
                    if (CurrentClientNum == 9) break;

                    tcp[CurrentClientNum] = listen.AcceptTcpClient();
                    string sLabel = tcp[CurrentClientNum].Client.RemoteEndPoint.ToString();
                    AddText($"Client [{sLabel}] 로부터 접속되었습니다.\r\n", 1);
                    AddText(sLabel, 3);
                    sbServer.Text = sLabel;

                    if (threadRead == null)
                    {
                        threadRead = new Thread(ReadProcess);
                        threadRead.Start();
                    }
                    CurrentClientNum++;
                }
                Thread.Sleep(100);
            }
        }

        void ReadProcess()
        {
            byte[] bArr = new byte[512];
            while (true)
            {
                for (int i = 0; i < CurrentClientNum; i++)
                {
                    NetworkStream ns = tcp[i].GetStream();
                    if (ns.DataAvailable)
                    {
                        int n = ns.Read(bArr, 0, 512);
                        AddText(Encoding.Default.GetString(bArr, 0, n), 1);
                    }
                }
                Thread.Sleep(100);
            }
        }

        private void ClientStart()
        {
            try
            {
                if (sock != null)
                    if (sock.Connected)
                    {
                        if (MessageBox.Show("재연결하시겠습니까?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            sock.Close();
                            threadClientRead.Abort();
                        }
                    }
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);       // InterNetwork: Ethernet IPv4    // Socket 수립
                sock.Connect(clientIP, int.Parse(clientPort));      // Connection 수립 요청 - 대기(Blocking Mode) // Connection도 Blocking 함수
                AddText($"Server [{clientIP}:{clientPort}] Connected OK.", 2);
                threadClientRead = new Thread(ClientReadProcess);
                threadClientRead.Start();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        void ClientReadProcess()
        {
            byte[] b = new byte[512];
            while (true)
            {

            }
        }

        private void frmMyChatProgram_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (threadServer != null) threadServer.Abort();
            if (threadRead != null) threadRead.Abort();
        }

        private void btnTransport_Click(object sender, EventArgs e)
        {
            sock.Send(Encoding.Default.GetBytes(tbMessage.Text));                           //////// 오류
            tbMessage.Text = "";
        }

        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                sock.Send(Encoding.Default.GetBytes(tbMessage.Text));
                tbMessage.Text = "";
            }
        }
    }
}
