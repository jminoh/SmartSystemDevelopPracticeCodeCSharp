
namespace myNotepad
{
    partial class Form2
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbSpeed = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbParity = new System.Windows.Forms.ComboBox();
            this.rbCOM1 = new System.Windows.Forms.RadioButton();
            this.rbCOM2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbDatabit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbStopbit = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(33, 223);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(103, 36);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(189, 223);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 36);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 10F);
            this.label2.Location = new System.Drawing.Point(43, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Speed";
            // 
            // cbbSpeed
            // 
            this.cbbSpeed.FormattingEnabled = true;
            this.cbbSpeed.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "115200"});
            this.cbbSpeed.Location = new System.Drawing.Point(103, 89);
            this.cbbSpeed.Name = "cbbSpeed";
            this.cbbSpeed.Size = new System.Drawing.Size(140, 23);
            this.cbbSpeed.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 10F);
            this.label3.Location = new System.Drawing.Point(49, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Parity";
            // 
            // cbbParity
            // 
            this.cbbParity.FormattingEnabled = true;
            this.cbbParity.Items.AddRange(new object[] {
            "   none",
            "   odd",
            "   even"});
            this.cbbParity.Location = new System.Drawing.Point(103, 118);
            this.cbbParity.Name = "cbbParity";
            this.cbbParity.Size = new System.Drawing.Size(140, 23);
            this.cbbParity.TabIndex = 2;
            // 
            // rbCOM1
            // 
            this.rbCOM1.AutoSize = true;
            this.rbCOM1.Checked = true;
            this.rbCOM1.Location = new System.Drawing.Point(26, 24);
            this.rbCOM1.Name = "rbCOM1";
            this.rbCOM1.Size = new System.Drawing.Size(70, 19);
            this.rbCOM1.TabIndex = 3;
            this.rbCOM1.TabStop = true;
            this.rbCOM1.Text = "COM1";
            this.rbCOM1.UseVisualStyleBackColor = true;
            // 
            // rbCOM2
            // 
            this.rbCOM2.AutoSize = true;
            this.rbCOM2.Location = new System.Drawing.Point(132, 24);
            this.rbCOM2.Name = "rbCOM2";
            this.rbCOM2.Size = new System.Drawing.Size(70, 19);
            this.rbCOM2.TabIndex = 3;
            this.rbCOM2.Text = "COM2";
            this.rbCOM2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCOM2);
            this.groupBox1.Controls.Add(this.rbCOM1);
            this.groupBox1.Location = new System.Drawing.Point(46, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 54);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ComPort";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 10F);
            this.label4.Location = new System.Drawing.Point(38, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "DataBit";
            // 
            // cbbDatabit
            // 
            this.cbbDatabit.FormattingEnabled = true;
            this.cbbDatabit.Items.AddRange(new object[] {
            "8",
            "7"});
            this.cbbDatabit.Location = new System.Drawing.Point(103, 147);
            this.cbbDatabit.Name = "cbbDatabit";
            this.cbbDatabit.Size = new System.Drawing.Size(140, 23);
            this.cbbDatabit.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 10F);
            this.label5.Location = new System.Drawing.Point(37, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "StopBit";
            // 
            // cbbStopbit
            // 
            this.cbbStopbit.FormattingEnabled = true;
            this.cbbStopbit.Location = new System.Drawing.Point(103, 176);
            this.cbbStopbit.Name = "cbbStopbit";
            this.cbbStopbit.Size = new System.Drawing.Size(140, 23);
            this.cbbStopbit.TabIndex = 2;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 284);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbbStopbit);
            this.Controls.Add(this.cbbDatabit);
            this.Controls.Add(this.cbbParity);
            this.Controls.Add(this.cbbSpeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ComPort Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbbSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cbbParity;
        public System.Windows.Forms.RadioButton rbCOM1;
        public System.Windows.Forms.RadioButton rbCOM2;
        public System.Windows.Forms.ComboBox cbbDatabit;
        public System.Windows.Forms.ComboBox cbbStopbit;
    }
}