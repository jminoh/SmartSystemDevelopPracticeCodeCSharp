
namespace Chatting
{
    partial class frmChat
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChat));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbConnectList = new System.Windows.Forms.ToolStripDropDownButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbChat = new System.Windows.Forms.TextBox();
            this.tbTalk = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pmnuServerStart = new System.Windows.Forms.ToolStripMenuItem();
            this.pmnuConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.pmnuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.pmnuNetworkConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbConnectList});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(432, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbConnectList
            // 
            this.sbConnectList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbConnectList.Image = ((System.Drawing.Image)(resources.GetObject("sbConnectList.Image")));
            this.sbConnectList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbConnectList.Name = "sbConnectList";
            this.sbConnectList.Size = new System.Drawing.Size(118, 24);
            this.sbConnectList.Text = "접속자 리스트";
            this.sbConnectList.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.sbConnectList_DropDownItemClicked);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbChat);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbTalk);
            this.splitContainer1.Size = new System.Drawing.Size(432, 431);
            this.splitContainer1.SplitterDistance = 312;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // tbChat
            // 
            this.tbChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbChat.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tbChat.Location = new System.Drawing.Point(3, 3);
            this.tbChat.Multiline = true;
            this.tbChat.Name = "tbChat";
            this.tbChat.ReadOnly = true;
            this.tbChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbChat.Size = new System.Drawing.Size(426, 305);
            this.tbChat.TabIndex = 0;
            // 
            // tbTalk
            // 
            this.tbTalk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTalk.ContextMenuStrip = this.contextMenuStrip1;
            this.tbTalk.Location = new System.Drawing.Point(1, 3);
            this.tbTalk.Multiline = true;
            this.tbTalk.Name = "tbTalk";
            this.tbTalk.Size = new System.Drawing.Size(428, 95);
            this.tbTalk.TabIndex = 0;
            this.tbTalk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTalk_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pmnuServerStart,
            this.pmnuConnect,
            this.pmnuConfig});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 76);
            // 
            // pmnuServerStart
            // 
            this.pmnuServerStart.Name = "pmnuServerStart";
            this.pmnuServerStart.Size = new System.Drawing.Size(155, 24);
            this.pmnuServerStart.Text = "Server Start";
            this.pmnuServerStart.Click += new System.EventHandler(this.pmnuServerStart_Click);
            // 
            // pmnuConnect
            // 
            this.pmnuConnect.Name = "pmnuConnect";
            this.pmnuConnect.Size = new System.Drawing.Size(155, 24);
            this.pmnuConnect.Text = "Connect";
            this.pmnuConnect.Click += new System.EventHandler(this.pmnuConnect_Click);
            // 
            // pmnuConfig
            // 
            this.pmnuConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pmnuNetworkConfig});
            this.pmnuConfig.Name = "pmnuConfig";
            this.pmnuConfig.Size = new System.Drawing.Size(155, 24);
            this.pmnuConfig.Text = "Config";
            // 
            // pmnuNetworkConfig
            // 
            this.pmnuNetworkConfig.Name = "pmnuNetworkConfig";
            this.pmnuNetworkConfig.Size = new System.Drawing.Size(149, 26);
            this.pmnuNetworkConfig.Text = "Network";
            this.pmnuNetworkConfig.Click += new System.EventHandler(this.pmnuNetworkConfig_Click);
            // 
            // frmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 457);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmChat";
            this.Text = "Chatting ver 1.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChat_FormClosing);
            this.Load += new System.EventHandler(this.frmChat_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tbChat;
        private System.Windows.Forms.TextBox tbTalk;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pmnuConnect;
        private System.Windows.Forms.ToolStripMenuItem pmnuConfig;
        private System.Windows.Forms.ToolStripMenuItem pmnuNetworkConfig;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem pmnuServerStart;
        private System.Windows.Forms.ToolStripDropDownButton sbConnectList;
    }
}

