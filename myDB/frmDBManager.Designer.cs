
namespace myDB
{
    partial class frmDBManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDBManager));
            this.dbGrid = new System.Windows.Forms.DataGridView();
            this.PopupMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pmnuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.pmnuInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.pmnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.pmnuAlterColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.pmnuColumnInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.pmnuColumnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.pmnuRowAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.pmnuDeleteColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.pmnuDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMigration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMigrationImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMigrationExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpdateTable = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateTable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColumnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRowAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExecute = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextUtf8 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextAnsi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEcho = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEchoText = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEchoGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.tbMemo = new System.Windows.Forms.TextBox();
            this.PopupMenu2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pmnuExecute = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.sbLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbLabel2 = new System.Windows.Forms.ToolStripDropDownButton();
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
            this.dbGrid.Size = new System.Drawing.Size(863, 260);
            this.dbGrid.TabIndex = 0;
            // 
            // PopupMenu1
            // 
            this.PopupMenu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PopupMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pmnuUpdate,
            this.pmnuInsert,
            this.pmnuDelete,
            this.pmnuAlterColumn,
            this.toolStripMenuItem3,
            this.pmnuColumnInfo,
            this.pmnuColumnAdd,
            this.pmnuRowAdd,
            this.toolStripMenuItem4,
            this.pmnuDeleteColumn,
            this.pmnuDeleteRow});
            this.PopupMenu1.Name = "PopupMenu1";
            this.PopupMenu1.Size = new System.Drawing.Size(180, 232);
            // 
            // pmnuUpdate
            // 
            this.pmnuUpdate.Name = "pmnuUpdate";
            this.pmnuUpdate.Size = new System.Drawing.Size(179, 24);
            this.pmnuUpdate.Text = "DB Update";
            this.pmnuUpdate.Click += new System.EventHandler(this.pmnuUpdate_Click);
            // 
            // pmnuInsert
            // 
            this.pmnuInsert.Name = "pmnuInsert";
            this.pmnuInsert.Size = new System.Drawing.Size(179, 24);
            this.pmnuInsert.Text = "DB Insert";
            this.pmnuInsert.Click += new System.EventHandler(this.pmnuInsert_Click);
            // 
            // pmnuDelete
            // 
            this.pmnuDelete.Name = "pmnuDelete";
            this.pmnuDelete.Size = new System.Drawing.Size(179, 24);
            this.pmnuDelete.Text = "DB Delete";
            this.pmnuDelete.Click += new System.EventHandler(this.pmnuDelete_Click);
            // 
            // pmnuAlterColumn
            // 
            this.pmnuAlterColumn.Name = "pmnuAlterColumn";
            this.pmnuAlterColumn.Size = new System.Drawing.Size(179, 24);
            this.pmnuAlterColumn.Text = "ALTER Column";
            this.pmnuAlterColumn.Click += new System.EventHandler(this.pmnuAlterColumn_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(176, 6);
            // 
            // pmnuColumnInfo
            // 
            this.pmnuColumnInfo.Name = "pmnuColumnInfo";
            this.pmnuColumnInfo.Size = new System.Drawing.Size(179, 24);
            this.pmnuColumnInfo.Text = "Column 정보";
            this.pmnuColumnInfo.Click += new System.EventHandler(this.pmnuColumnInfo_Click);
            // 
            // pmnuColumnAdd
            // 
            this.pmnuColumnAdd.Name = "pmnuColumnAdd";
            this.pmnuColumnAdd.Size = new System.Drawing.Size(179, 24);
            this.pmnuColumnAdd.Text = "Column 추가";
            this.pmnuColumnAdd.Click += new System.EventHandler(this.pmnuColumnAdd_Click);
            // 
            // pmnuRowAdd
            // 
            this.pmnuRowAdd.Name = "pmnuRowAdd";
            this.pmnuRowAdd.Size = new System.Drawing.Size(179, 24);
            this.pmnuRowAdd.Text = "Row 추가";
            this.pmnuRowAdd.Click += new System.EventHandler(this.pmnuRowAdd_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(176, 6);
            // 
            // pmnuDeleteColumn
            // 
            this.pmnuDeleteColumn.Name = "pmnuDeleteColumn";
            this.pmnuDeleteColumn.Size = new System.Drawing.Size(179, 24);
            this.pmnuDeleteColumn.Text = "Column 삭제";
            this.pmnuDeleteColumn.Click += new System.EventHandler(this.pmnuDeleteColumn_Click);
            // 
            // pmnuDeleteRow
            // 
            this.pmnuDeleteRow.Name = "pmnuDeleteRow";
            this.pmnuDeleteRow.Size = new System.Drawing.Size(179, 24);
            this.pmnuDeleteRow.Text = "Row 삭제";
            this.pmnuDeleteRow.Click += new System.EventHandler(this.pmnuDeleteRow_Click);
            // 
            // menuMain
            // 
            this.menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.sQLToolStripMenuItem,
            this.configToolStripMenuItem});
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
            this.mnuUpdateTable,
            this.mnuCreateTable,
            this.toolStripMenuItem5,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.newToolStripMenuItem.Text = "New";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuMigration
            // 
            this.mnuMigration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMigrationImport,
            this.mnuMigrationExport});
            this.mnuMigration.Name = "mnuMigration";
            this.mnuMigration.Size = new System.Drawing.Size(201, 26);
            this.mnuMigration.Text = "Migration...(.csv)";
            // 
            // mnuMigrationImport
            // 
            this.mnuMigrationImport.Name = "mnuMigrationImport";
            this.mnuMigrationImport.Size = new System.Drawing.Size(137, 26);
            this.mnuMigrationImport.Text = "Import";
            this.mnuMigrationImport.Click += new System.EventHandler(this.mnuMigrationImport_Click);
            // 
            // mnuMigrationExport
            // 
            this.mnuMigrationExport.Name = "mnuMigrationExport";
            this.mnuMigrationExport.Size = new System.Drawing.Size(137, 26);
            this.mnuMigrationExport.Text = "Export";
            this.mnuMigrationExport.Click += new System.EventHandler(this.mnuMigrationExport_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(201, 26);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuUpdateTable
            // 
            this.mnuUpdateTable.Name = "mnuUpdateTable";
            this.mnuUpdateTable.Size = new System.Drawing.Size(201, 26);
            this.mnuUpdateTable.Text = "Update Table";
            // 
            // mnuCreateTable
            // 
            this.mnuCreateTable.Name = "mnuCreateTable";
            this.mnuCreateTable.Size = new System.Drawing.Size(201, 26);
            this.mnuCreateTable.Text = "Create Table";
            this.mnuCreateTable.Click += new System.EventHandler(this.mnuCreateTable_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(201, 26);
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
            this.mnuExecute});
            this.sQLToolStripMenuItem.Name = "sQLToolStripMenuItem";
            this.sQLToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.sQLToolStripMenuItem.Text = "SQL";
            // 
            // mnuExecute
            // 
            this.mnuExecute.Name = "mnuExecute";
            this.mnuExecute.Size = new System.Drawing.Size(144, 26);
            this.mnuExecute.Text = "Execute";
            this.mnuExecute.Click += new System.EventHandler(this.mnuExecute_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textFileToolStripMenuItem,
            this.mnuEcho});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // textFileToolStripMenuItem
            // 
            this.textFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTextUtf8,
            this.mnuTextAnsi});
            this.textFileToolStripMenuItem.Name = "textFileToolStripMenuItem";
            this.textFileToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.textFileToolStripMenuItem.Text = "Text File";
            // 
            // mnuTextUtf8
            // 
            this.mnuTextUtf8.Checked = true;
            this.mnuTextUtf8.CheckOnClick = true;
            this.mnuTextUtf8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuTextUtf8.Name = "mnuTextUtf8";
            this.mnuTextUtf8.Size = new System.Drawing.Size(132, 26);
            this.mnuTextUtf8.Text = "UTF-8";
            this.mnuTextUtf8.Click += new System.EventHandler(this.mnuTextUtf8_Click);
            // 
            // mnuTextAnsi
            // 
            this.mnuTextAnsi.CheckOnClick = true;
            this.mnuTextAnsi.Name = "mnuTextAnsi";
            this.mnuTextAnsi.Size = new System.Drawing.Size(132, 26);
            this.mnuTextAnsi.Text = "ANSI";
            this.mnuTextAnsi.Click += new System.EventHandler(this.mnuTextAnsi_Click);
            // 
            // mnuEcho
            // 
            this.mnuEcho.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEchoText,
            this.mnuEchoGrid});
            this.mnuEcho.Name = "mnuEcho";
            this.mnuEcho.Size = new System.Drawing.Size(178, 26);
            this.mnuEcho.Text = "Echo Option";
            // 
            // mnuEchoText
            // 
            this.mnuEchoText.CheckOnClick = true;
            this.mnuEchoText.Name = "mnuEchoText";
            this.mnuEchoText.Size = new System.Drawing.Size(121, 26);
            this.mnuEchoText.Text = "Text";
            this.mnuEchoText.Click += new System.EventHandler(this.mnuEchoText_Click);
            // 
            // mnuEchoGrid
            // 
            this.mnuEchoGrid.Checked = true;
            this.mnuEchoGrid.CheckOnClick = true;
            this.mnuEchoGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuEchoGrid.Name = "mnuEchoGrid";
            this.mnuEchoGrid.Size = new System.Drawing.Size(121, 26);
            this.mnuEchoGrid.Text = "Grid";
            this.mnuEchoGrid.Click += new System.EventHandler(this.mnuEchoGrid_Click);
            // 
            // tbMemo
            // 
            this.tbMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMemo.ContextMenuStrip = this.PopupMenu2;
            this.tbMemo.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbMemo.Location = new System.Drawing.Point(0, 3);
            this.tbMemo.Multiline = true;
            this.tbMemo.Name = "tbMemo";
            this.tbMemo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMemo.Size = new System.Drawing.Size(869, 120);
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
            this.splitContainer1.SplitterDistance = 126;
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
            // frmDBManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 455);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "frmDBManager";
            this.Text = "myDBManager ver 2.1";
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
        private System.Windows.Forms.ToolStripMenuItem mnuUpdateTable;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateTable;
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
        private System.Windows.Forms.ToolStripMenuItem mnuExecute;
        private System.Windows.Forms.ToolStripMenuItem pmnuUpdate;
        private System.Windows.Forms.ToolStripMenuItem pmnuInsert;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem pmnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem pmnuDeleteColumn;
        private System.Windows.Forms.ToolStripMenuItem pmnuDeleteRow;
        private System.Windows.Forms.ToolStripMenuItem mnuMigrationImport;
        private System.Windows.Forms.ToolStripMenuItem mnuMigrationExport;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuTextUtf8;
        private System.Windows.Forms.ToolStripMenuItem mnuTextAnsi;
        private System.Windows.Forms.ToolStripMenuItem pmnuColumnInfo;
        private System.Windows.Forms.ToolStripMenuItem mnuEcho;
        private System.Windows.Forms.ToolStripMenuItem mnuEchoText;
        private System.Windows.Forms.ToolStripMenuItem mnuEchoGrid;
        private System.Windows.Forms.ToolStripMenuItem pmnuAlterColumn;
    }
}

