
namespace WindowsFormsApp1
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
            this.tbTest = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbKind = new System.Windows.Forms.ComboBox();
            this.cbbType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTrans = new System.Windows.Forms.Button();
            this.cbbMenu = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbDiv = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbTest
            // 
            this.tbTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTest.Location = new System.Drawing.Point(0, 197);
            this.tbTest.Multiline = true;
            this.tbTest.Name = "tbTest";
            this.tbTest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbTest.Size = new System.Drawing.Size(738, 351);
            this.tbTest.TabIndex = 0;
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.OldLace;
            this.btnTest.Font = new System.Drawing.Font("휴먼매직체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTest.ForeColor = System.Drawing.Color.Crimson;
            this.btnTest.Image = global::WindowsFormsApp1.Properties.Resources.chunsik;
            this.btnTest.Location = new System.Drawing.Point(0, 98);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(144, 78);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(238, 151);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(108, 25);
            this.tbInput.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("함초롬바탕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(162, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("함초롬바탕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(378, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "종류";
            // 
            // cbbKind
            // 
            this.cbbKind.FormattingEnabled = true;
            this.cbbKind.Items.AddRange(new object[] {
            "1. int",
            "2. double",
            "3. string"});
            this.cbbKind.Location = new System.Drawing.Point(457, 153);
            this.cbbKind.Name = "cbbKind";
            this.cbbKind.Size = new System.Drawing.Size(112, 23);
            this.cbbKind.TabIndex = 5;
            // 
            // cbbType
            // 
            this.cbbType.FormattingEnabled = true;
            this.cbbType.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbbType.Location = new System.Drawing.Point(457, 120);
            this.cbbType.Name = "cbbType";
            this.cbbType.Size = new System.Drawing.Size(113, 23);
            this.cbbType.TabIndex = 6;
            this.cbbType.SelectedIndexChanged += new System.EventHandler(this.cbbType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("휴먼아미체", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(355, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "Diversion";
            // 
            // btnTrans
            // 
            this.btnTrans.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnTrans.Location = new System.Drawing.Point(597, 151);
            this.btnTrans.Name = "btnTrans";
            this.btnTrans.Size = new System.Drawing.Size(55, 29);
            this.btnTrans.TabIndex = 8;
            this.btnTrans.Text = "변환";
            this.btnTrans.UseVisualStyleBackColor = true;
            this.btnTrans.Click += new System.EventHandler(this.btnTrans_Click);
            // 
            // cbbMenu
            // 
            this.cbbMenu.FormattingEnabled = true;
            this.cbbMenu.Items.AddRange(new object[] {
            "New",
            "Open",
            "Save",
            "Save AS",
            "Exit"});
            this.cbbMenu.Location = new System.Drawing.Point(7, 30);
            this.cbbMenu.Name = "cbbMenu";
            this.cbbMenu.Size = new System.Drawing.Size(103, 23);
            this.cbbMenu.TabIndex = 9;
            this.cbbMenu.SelectedIndexChanged += new System.EventHandler(this.cbbMenu_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(4, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "메뉴";
            // 
            // cbbDiv
            // 
            this.cbbDiv.FormattingEnabled = true;
            this.cbbDiv.Items.AddRange(new object[] {
            "소문자에서 대문자로 변환",
            "대문자에서 소문자로 변환",
            "16진수로 변환",
            "Return"});
            this.cbbDiv.Location = new System.Drawing.Point(134, 30);
            this.cbbDiv.Name = "cbbDiv";
            this.cbbDiv.Size = new System.Drawing.Size(184, 23);
            this.cbbDiv.TabIndex = 9;
            this.cbbDiv.SelectedIndexChanged += new System.EventHandler(this.cbbDiv_SelectedIndexChanged);
            this.cbbDiv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbDiv_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(131, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "변환";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 545);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbbDiv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbbMenu);
            this.Controls.Add(this.btnTrans);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbbType);
            this.Controls.Add(this.cbbKind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.tbTest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTest;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbKind;
        private System.Windows.Forms.ComboBox cbbType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTrans;
        private System.Windows.Forms.ComboBox cbbMenu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbDiv;
        private System.Windows.Forms.Label label5;
    }
}

