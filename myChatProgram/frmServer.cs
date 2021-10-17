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
    public partial class frmServer : Form
    {
        frmMyChatProgram mychat = new frmMyChatProgram();
        public frmServer()
        {
            InitializeComponent();
        }

        public string servPort = null;
 
        private void btnServerStart_Click(object sender, EventArgs e)
        {
            servPort = tbServerPort.Text;
            this.Close();
        }
        public string serverPort()
        {
            return servPort;
        }
    }
}
