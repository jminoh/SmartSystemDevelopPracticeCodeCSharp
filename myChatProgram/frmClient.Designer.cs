
namespace myChatProgram
{
    partial class frmClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnection = new System.Windows.Forms.Button();
            this.tbConnectionPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbConnectionIP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(86, 133);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(127, 30);
            this.btnConnection.TabIndex = 5;
            this.btnConnection.Text = "Connection";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // tbConnectionPort
            // 
            this.tbConnectionPort.Location = new System.Drawing.Point(141, 87);
            this.tbConnectionPort.Name = "tbConnectionPort";
            this.tbConnectionPort.Size = new System.Drawing.Size(123, 25);
            this.tbConnectionPort.TabIndex = 4;
            this.tbConnectionPort.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Connection IP";
            // 
            // tbConnectionIP
            // 
            this.tbConnectionIP.Location = new System.Drawing.Point(141, 57);
            this.tbConnectionIP.Name = "tbConnectionIP";
            this.tbConnectionIP.Size = new System.Drawing.Size(123, 25);
            this.tbConnectionIP.TabIndex = 4;
            this.tbConnectionIP.Text = "9000";
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 202);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.tbConnectionIP);
            this.Controls.Add(this.tbConnectionPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmClient";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbConnectionPort;
        public System.Windows.Forms.TextBox tbConnectionIP;
    }
}