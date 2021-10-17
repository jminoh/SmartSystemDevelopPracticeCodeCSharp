
namespace Chatting
{
    partial class frmNetConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.tvRemoteIP = new System.Windows.Forms.Label();
            this.tbConnectIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbConnectPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPWD = new System.Windows.Forms.TextBox();
            this.rbServer = new System.Windows.Forms.RadioButton();
            this.rbClient = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server Port";
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(115, 21);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(128, 25);
            this.tbServerPort.TabIndex = 2;
            // 
            // tvRemoteIP
            // 
            this.tvRemoteIP.AutoSize = true;
            this.tvRemoteIP.Location = new System.Drawing.Point(34, 55);
            this.tvRemoteIP.Name = "tvRemoteIP";
            this.tvRemoteIP.Size = new System.Drawing.Size(80, 15);
            this.tvRemoteIP.TabIndex = 1;
            this.tvRemoteIP.Text = "Connect IP";
            // 
            // tbConnectIP
            // 
            this.tbConnectIP.Location = new System.Drawing.Point(115, 52);
            this.tbConnectIP.Name = "tbConnectIP";
            this.tbConnectIP.Size = new System.Drawing.Size(128, 25);
            this.tbConnectIP.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Connect Port";
            // 
            // tbConnectPort
            // 
            this.tbConnectPort.Location = new System.Drawing.Point(115, 83);
            this.tbConnectPort.Name = "tbConnectPort";
            this.tbConnectPort.Size = new System.Drawing.Size(128, 25);
            this.tbConnectPort.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "User ID";
            // 
            // tbUID
            // 
            this.tbUID.Location = new System.Drawing.Point(115, 114);
            this.tbUID.Name = "tbUID";
            this.tbUID.Size = new System.Drawing.Size(128, 25);
            this.tbUID.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Password";
            // 
            // tbPWD
            // 
            this.tbPWD.Location = new System.Drawing.Point(115, 145);
            this.tbPWD.Name = "tbPWD";
            this.tbPWD.Size = new System.Drawing.Size(128, 25);
            this.tbPWD.TabIndex = 2;
            // 
            // rbServer
            // 
            this.rbServer.AutoSize = true;
            this.rbServer.Checked = true;
            this.rbServer.Location = new System.Drawing.Point(115, 176);
            this.rbServer.Name = "rbServer";
            this.rbServer.Size = new System.Drawing.Size(112, 19);
            this.rbServer.TabIndex = 3;
            this.rbServer.TabStop = true;
            this.rbServer.Text = "Server Mode";
            this.rbServer.UseVisualStyleBackColor = true;
            // 
            // rbClient
            // 
            this.rbClient.AutoSize = true;
            this.rbClient.Location = new System.Drawing.Point(115, 201);
            this.rbClient.Name = "rbClient";
            this.rbClient.Size = new System.Drawing.Size(106, 19);
            this.rbClient.TabIndex = 3;
            this.rbClient.Text = "Client Mode";
            this.rbClient.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(57, 235);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(168, 235);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmNetConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 272);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rbClient);
            this.Controls.Add(this.rbServer);
            this.Controls.Add(this.tbPWD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbUID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbConnectPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbConnectIP);
            this.Controls.Add(this.tvRemoteIP);
            this.Controls.Add(this.tbServerPort);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNetConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Network Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.Label tvRemoteIP;
        public System.Windows.Forms.TextBox tbConnectIP;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tbConnectPort;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tbUID;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox tbPWD;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.RadioButton rbServer;
        public System.Windows.Forms.RadioButton rbClient;
    }
}