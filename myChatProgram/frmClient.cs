using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myChatProgram
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }
        public string cliePort = null;
        public string clieIP = null;
        private void btnConnection_Click(object sender, EventArgs e)
        {
            cliePort = tbConnectionPort.Text;
            clieIP = tbConnectionIP.Text;
            this.Close();
        }
        public string clientPort()
        {
            return cliePort;
        }
        public string clientIP()
        {
            return clieIP;
        }
    }
}
