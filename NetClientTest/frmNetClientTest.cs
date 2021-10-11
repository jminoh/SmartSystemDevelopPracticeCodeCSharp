using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetClientTest
{
    public partial class frmNetClientTest : Form
    {
        public frmNetClientTest()
        {
            InitializeComponent();
        }

        Socket sock = null;                                         //
        
        private void btnConnect_Click(object sender, EventArgs e)   // Connect IP와 Port정보를 이용해, Port에 접속 요청 날리기
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);    //  SocketType.Stream: TCP
            sock.Connect(tbConnectIP.Text, int.Parse(tbConnectPort.Text));           // Host명과 IP   // Server 열리지 않은 상태라면 Pending상태 들어감
            tbClient.Text += "Connection OK.\r\n";
        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            sock.Close();
            tbClient.Text += "Connection Closed.\r\n";
        }

        private void pmnuSendText_Click(object sender, EventArgs e)
        {
            if(sock != null)
            {
                string str;
                if (tbClient.SelectedText == "") str = tbClient.Text;
                else str = tbClient.SelectedText;
                sock.Send(Encoding.Default.GetBytes(str));                 // string은 char 문자열, Send는 Low Level Function(byte 단위) => Default 문자체계(ANSI)로 변환
            }
        }
    }
}
