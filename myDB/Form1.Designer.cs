
namespace myDB
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dbGrid = new System.Windows.Forms.DataGridView();
            this.PopupMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pmnuColumnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.pmnuRowAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.pmnuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMigration = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColumnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRowAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbMemo = new System.Windows.Forms.TextBox();
            this.PopupMenu2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pmnuExecute = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.sbLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbLabel2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.pmnuInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).BeginInit();
            this.PopupMenu1.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.PopupMenu2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dbGrid
            // 
            this.dbGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGrid.ContextMenuStrip = this.PopupMenu1;
            this.dbGrid.Location = new System.Drawing.Point(3, 3);
            this.dbGrid.Name = "dbGrid";
            this.dbGrid.RowHeadersWidth = 51;
            this.dbGrid.RowTemplate.Height = 27;
            this.dbGrid.Size = new System.Drawing.Size(863, 207);
            this.dbGrid.TabIndex = 0;
            // 
            // PopupMenu1
            // 
            this.PopupMenu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PopupMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pmnuUpdate,
            this.pmnuInsert,
            this.toolStripMenuItem3,
            this.pmnuColumnAdd,
            this.pmnuRowAdd});
            this.PopupMenu1.Name = "PopupMenu1";
            this.PopupMenu1.Size = new System.Drawing.Size(211, 134);
            // 
            // pmnuColumnAdd
            // 
            this.pmnuColumnAdd.Name = "pmnuColumnAdd";
            this.pmnuColumnAdd.Size = new System.Drawing.Size(210, 24);
            this.pmnuColumnAdd.Text = "Column 추가";
            this.pmnuColumnAdd.Click += new System.EventHandler(this.pmnuColumnAdd_Click);
            // 
            // pmnuRowAdd
            // 
            this.pmnuRowAdd.Name = "pmnuRowAdd";
            this.pmnuRowAdd.Size = new System.Drawing.Size(210, 24);
            this.pmnuRowAdd.Text = "Row 추가";
            this.pmnuRowAdd.Click += new System.EventHandler(this.pmnuRowAdd_Click);
            // 
            // pmnuUpdate
            // 
            this.pmnuUpdate.Name = "pmnuUpdate";
            this.pmnuUpdate.Size = new System.Drawing.Size(210, 24);
            this.pmnuUpdate.Text = "DB Update";
            this.pmnuUpdate.Click += new System.EventHandler(this.pmnuUpdate_Click);
            // 
            // menuMain
            // 
            this.menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.sQLToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(869, 28);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripMenuItem2,
            this.mnuMigration,
            this.toolStripMenuItem1,
            this.mnuOpen,
            this.mnuSave,
            this.mnuSaveas,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.newToolStripMenuItem.Text = "New";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuMigration
            // 
            this.mnuMigration.Name = "mnuMigration";
            this.mnuMigration.Size = new System.Drawing.Size(168, 26);
            this.mnuMigration.Text = "Migration...";
            this.mnuMigration.Click += new System.EventHandler(this.mnuMigration_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(168, 26);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(168, 26);
            this.mnuSave.Text = "Save";
            // 
            // mnuSaveas
            // 
            this.mnuSaveas.Name = "mnuSaveas";
            this.mnuSaveas.Size = new System.Drawing.Size(168, 26);
            this.mnuSaveas.Text = "Save As...";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(168, 26);
            this.mnuExit.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuColumnAdd,
            this.mnuRowAdd});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // mnuColumnAdd
            // 
            this.mnuColumnAdd.Name = "mnuColumnAdd";
            this.mnuColumnAdd.Size = new System.Drawing.Size(181, 26);
            this.mnuColumnAdd.Text = "Column 추가";
            this.mnuColumnAdd.Click += new System.EventHandler(this.mnuColumnAdd_Click);
            // 
            // mnuRowAdd
            // 
            this.mnuRowAdd.Name = "mnuRowAdd";
            this.mnuRowAdd.Size = new System.Drawing.Size(181, 26);
            this.mnuRowAdd.Text = "Row 추가";
            this.mnuRowAdd.Click += new System.EventHandler(this.mnuRowAdd_Click);
            // 
            // sQLToolStripMenuItem
            // 
            this.sQLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeToolStripMenuItem});
            this.sQLToolStripMenuItem.Name = "sQLToolStripMenuItem";
            this.sQLToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.sQLToolStripMenuItem.Text = "SQL";
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.executeToolStripMenuItem.Text = "Execute";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.executeToolStripMenuItem_Click);
            // 
            // tbMemo
            // 
            this.tbMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMemo.ContextMenuStrip = this.PopupMenu2;
            this.tbMemo.Location = new System.Drawing.Point(0, 3);
            this.tbMemo.Multiline = true;
            this.tbMemo.Name = "tbMemo";
            this.tbMemo.Size = new System.Drawing.Size(869, 173);
            this.tbMemo.TabIndex = 3;
            this.tbMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMemo_KeyDown);
            // 
            // PopupMenu2
            // 
            this.PopupMenu2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PopupMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pmnuExecute});
            this.PopupMenu2.Name = "PopupMenu2";
            this.PopupMenu2.Size = new System.Drawing.Size(131, 28);
            // 
            // pmnuExecute
            // 
            this.pmnuExecute.Name = "pmnuExecute";
            this.pmnuExecute.Size = new System.Drawing.Size(130, 24);
            this.pmnuExecute.Text = "Execute";
            this.pmnuExecute.Click += new System.EventHandler(this.pmnuExecute_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.ValidateNames = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 34);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbMemo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dbGrid);
            this.splitContainer1.Size = new System.Drawing.Size(869, 396);
            this.splitContainer1.SplitterDistance = 179;
            this.splitContainer1.TabIndex = 4;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbLabel1,
            this.sbLabel2});
            this.statusStrip.Location = new System.Drawing.Point(0, 429);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(869, 26);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip";
            // 
            // sbLabel1
            // 
            this.sbLabel1.Name = "sbLabel1";
            this.sbLabel1.Size = new System.Drawing.Size(68, 20);
            this.sbLabel1.Text = "sbLabel1";
            // 
            // sbLabel2
            // 
            this.sbLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbLabel2.Image = ((System.Drawing.Image)(resources.GetObject("sbLabel2.Image")));
            this.sbLabel2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbLabel2.Name = "sbLabel2";
            this.sbLabel2.Size = new System.Drawing.Size(82, 24);
            this.sbLabel2.Text = "sbLabel2";
            this.sbLabel2.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.sbLabel2_DropDownItemClicked);
            // 
            // pmnuInsert
            // 
            this.pmnuInsert.Name = "pmnuInsert";
            this.pmnuInsert.Size = new System.Drawing.Size(210, 24);
            this.pmnuInsert.Text = "DB Insert";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(207, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 455);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).EndInit();
            this.PopupMenu1.ResumeLayout(false);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.PopupMenu2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dbGrid;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuMigration;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveas;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.TextBox tbMemo;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuColumnAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuRowAdd;
        private System.Windows.Forms.ContextMenuStrip PopupMenu1;
        private System.Windows.Forms.ToolStripMenuItem pmnuColumnAdd;
        private System.Windows.Forms.ToolStripMenuItem pmnuRowAdd;
        private System.Windows.Forms.ContextMenuStrip PopupMenu2;
        private System.Windows.Forms.ToolStripMenuItem pmnuExecute;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel sbLabel1;
        private System.Windows.Forms.ToolStripDropDownButton sbLabel2;
        private System.Windows.Forms.ToolStripMenuItem sQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pmnuUpdate;
        private System.Windows.Forms.ToolStripMenuItem pmnuInsert;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    }
}

