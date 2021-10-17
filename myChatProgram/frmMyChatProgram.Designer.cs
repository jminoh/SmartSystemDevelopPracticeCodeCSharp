
namespace myChatProgram
{
    partial class frmMyChatProgram
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMyChatProgram));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServerSet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClientSet = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbClient = new System.Windows.Forms.ToolStripDropDownButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbCommunication = new System.Windows.Forms.TextBox();
            this.btnTransport = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(462, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuServerSet,
            this.mnuClientSet});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // mnuServerSet
            // 
            this.mnuServerSet.Name = "mnuServerSet";
            this.mnuServerSet.Size = new System.Drawing.Size(133, 26);
            this.mnuServerSet.Text = "Server";
            this.mnuServerSet.Click += new System.EventHandler(this.mnuServerSet_Click);
            // 
            // mnuClientSet
            // 
            this.mnuClientSet.Name = "mnuClientSet";
            this.mnuClientSet.Size = new System.Drawing.Size(133, 26);
            this.mnuClientSet.Text = "Client";
            this.mnuClientSet.Click += new System.EventHandler(this.mnuClientSet_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbServer,
            this.sbClient});
            this.statusStrip1.Location = new System.Drawing.Point(0, 531);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(462, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbServer
            // 
            this.sbServer.Name = "sbServer";
            this.sbServer.Size = new System.Drawing.Size(65, 20);
            this.sbServer.Text = "sbServer";
            // 
            // sbClient
            // 
            this.sbClient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbClient.Image = ((System.Drawing.Image)(resources.GetObject("sbClient.Image")));
            this.sbClient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbClient.Name = "sbClient";
            this.sbClient.Size = new System.Drawing.Size(63, 24);
            this.sbClient.Text = "Client";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(7, 29);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbCommunication);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnTransport);
            this.splitContainer1.Panel2.Controls.Add(this.tbMessage);
            this.splitContainer1.Size = new System.Drawing.Size(443, 506);
            this.splitContainer1.SplitterDistance = 391;
            this.splitContainer1.TabIndex = 2;
            // 
            // tbCommunication
            // 
            this.tbCommunication.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCommunication.Location = new System.Drawing.Point(1, 2);
            this.tbCommunication.Multiline = true;
            this.tbCommunication.Name = "tbCommunication";
            this.tbCommunication.Size = new System.Drawing.Size(441, 390);
            this.tbCommunication.TabIndex = 0;
            // 
            // btnTransport
            // 
            this.btnTransport.Location = new System.Drawing.Point(382, 6);
            this.btnTransport.Name = "btnTransport";
            this.btnTransport.Size = new System.Drawing.Size(59, 101);
            this.btnTransport.TabIndex = 1;
            this.btnTransport.Text = "전송";
            this.btnTransport.UseVisualStyleBackColor = true;
            this.btnTransport.Click += new System.EventHandler(this.btnTransport_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMessage.Location = new System.Drawing.Point(3, 3);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(374, 107);
            this.tbMessage.TabIndex = 0;
            this.tbMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMessage_KeyDown);
            // 
            // frmMyChatProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 557);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMyChatProgram";
            this.Text = "myChatProgram";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMyChatProgram_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tbCommunication;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.ToolStripMenuItem mnuServerSet;
        private System.Windows.Forms.ToolStripMenuItem mnuClientSet;
        private System.Windows.Forms.ToolStripStatusLabel sbServer;
        private System.Windows.Forms.Button btnTransport;
        private System.Windows.Forms.ToolStripDropDownButton sbClient;
    }
}

