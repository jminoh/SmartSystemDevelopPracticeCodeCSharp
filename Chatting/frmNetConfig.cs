using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatting
{
    public partial class frmNetConfig : Form
    {
        public frmNetConfig(int sp = 9000, int cp = 9000, string cip="", string uid="", string pwd="", bool isClient=true)
        {         // ServerPort, ClientPort, ClientPort, UID, PWD   // default 설정
            InitializeComponent();
            tbServerPort.Text = $"{sp}";
            tbConnectPort.Text = $"{cp}";
            tbConnectIP.Text = cip;
            tbUID.Text = uid;
            tbPWD.Text = pwd;
            if (isClient) rbClient.Checked = true; else rbServer.Checked = true;
        }
    }
}
