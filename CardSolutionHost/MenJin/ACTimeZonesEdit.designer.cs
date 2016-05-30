namespace CardSolutionHost.MenJin
{
    partial class ACTimeZonesEdit
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpSunEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpSunStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpMonEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpMonStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpTuesEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpTuesStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtpWedEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpWedStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtpThursEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpThursStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dtpFriEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpFriStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dtpSatEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpSatStart = new System.Windows.Forms.DateTimePicker();
            this.chkholidayvaild = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择时间段";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(118, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(60, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "描述";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(251, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 21);
            this.textBox1.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(143, 126);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(276, 126);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 5;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpSunEnd);
            this.groupBox1.Controls.Add(this.dtpSunStart);
            this.groupBox1.Location = new System.Drawing.Point(9, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(66, 64);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "星期日";
            // 
            // dtpSunEnd
            // 
            this.dtpSunEnd.CustomFormat = "HH:mm";
            this.dtpSunEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSunEnd.Location = new System.Drawing.Point(4, 39);
            this.dtpSunEnd.Name = "dtpSunEnd";
            this.dtpSunEnd.Size = new System.Drawing.Size(58, 21);
            this.dtpSunEnd.TabIndex = 1;
            // 
            // dtpSunStart
            // 
            this.dtpSunStart.CustomFormat = "HH:mm";
            this.dtpSunStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSunStart.Location = new System.Drawing.Point(4, 14);
            this.dtpSunStart.Name = "dtpSunStart";
            this.dtpSunStart.Size = new System.Drawing.Size(58, 21);
            this.dtpSunStart.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpMonEnd);
            this.groupBox2.Controls.Add(this.dtpMonStart);
            this.groupBox2.Location = new System.Drawing.Point(87, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(66, 64);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "星期一";
            // 
            // dtpMonEnd
            // 
            this.dtpMonEnd.CustomFormat = "HH:mm";
            this.dtpMonEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonEnd.Location = new System.Drawing.Point(4, 39);
            this.dtpMonEnd.Name = "dtpMonEnd";
            this.dtpMonEnd.Size = new System.Drawing.Size(58, 21);
            this.dtpMonEnd.TabIndex = 1;
            // 
            // dtpMonStart
            // 
            this.dtpMonStart.CustomFormat = "HH:mm";
            this.dtpMonStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonStart.Location = new System.Drawing.Point(4, 14);
            this.dtpMonStart.Name = "dtpMonStart";
            this.dtpMonStart.Size = new System.Drawing.Size(58, 21);
            this.dtpMonStart.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpTuesEnd);
            this.groupBox3.Controls.Add(this.dtpTuesStart);
            this.groupBox3.Location = new System.Drawing.Point(165, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(66, 64);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "星期二";
            // 
            // dtpTuesEnd
            // 
            this.dtpTuesEnd.CustomFormat = "HH:mm";
            this.dtpTuesEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuesEnd.Location = new System.Drawing.Point(4, 39);
            this.dtpTuesEnd.Name = "dtpTuesEnd";
            this.dtpTuesEnd.Size = new System.Drawing.Size(58, 21);
            this.dtpTuesEnd.TabIndex = 1;
            // 
            // dtpTuesStart
            // 
            this.dtpTuesStart.CustomFormat = "HH:mm";
            this.dtpTuesStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuesStart.Location = new System.Drawing.Point(4, 14);
            this.dtpTuesStart.Name = "dtpTuesStart";
            this.dtpTuesStart.Size = new System.Drawing.Size(58, 21);
            this.dtpTuesStart.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtpWedEnd);
            this.groupBox4.Controls.Add(this.dtpWedStart);
            this.groupBox4.Location = new System.Drawing.Point(243, 49);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(66, 64);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "星期三";
            // 
            // dtpWedEnd
            // 
            this.dtpWedEnd.CustomFormat = "HH:mm";
            this.dtpWedEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWedEnd.Location = new System.Drawing.Point(4, 39);
            this.dtpWedEnd.Name = "dtpWedEnd";
            this.dtpWedEnd.Size = new System.Drawing.Size(58, 21);
            this.dtpWedEnd.TabIndex = 1;
            // 
            // dtpWedStart
            // 
            this.dtpWedStart.CustomFormat = "HH:mm";
            this.dtpWedStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWedStart.Location = new System.Drawing.Point(4, 14);
            this.dtpWedStart.Name = "dtpWedStart";
            this.dtpWedStart.Size = new System.Drawing.Size(58, 21);
            this.dtpWedStart.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtpThursEnd);
            this.groupBox5.Controls.Add(this.dtpThursStart);
            this.groupBox5.Location = new System.Drawing.Point(321, 49);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(66, 64);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "星期四";
            // 
            // dtpThursEnd
            // 
            this.dtpThursEnd.CustomFormat = "HH:mm";
            this.dtpThursEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThursEnd.Location = new System.Drawing.Point(4, 39);
            this.dtpThursEnd.Name = "dtpThursEnd";
            this.dtpThursEnd.Size = new System.Drawing.Size(58, 21);
            this.dtpThursEnd.TabIndex = 1;
            // 
            // dtpThursStart
            // 
            this.dtpThursStart.CustomFormat = "HH:mm";
            this.dtpThursStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThursStart.Location = new System.Drawing.Point(4, 14);
            this.dtpThursStart.Name = "dtpThursStart";
            this.dtpThursStart.Size = new System.Drawing.Size(58, 21);
            this.dtpThursStart.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dtpFriEnd);
            this.groupBox6.Controls.Add(this.dtpFriStart);
            this.groupBox6.Location = new System.Drawing.Point(399, 49);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(66, 64);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "星期五";
            // 
            // dtpFriEnd
            // 
            this.dtpFriEnd.CustomFormat = "HH:mm";
            this.dtpFriEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFriEnd.Location = new System.Drawing.Point(4, 39);
            this.dtpFriEnd.Name = "dtpFriEnd";
            this.dtpFriEnd.Size = new System.Drawing.Size(58, 21);
            this.dtpFriEnd.TabIndex = 1;
            // 
            // dtpFriStart
            // 
            this.dtpFriStart.CustomFormat = "HH:mm";
            this.dtpFriStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFriStart.Location = new System.Drawing.Point(4, 14);
            this.dtpFriStart.Name = "dtpFriStart";
            this.dtpFriStart.Size = new System.Drawing.Size(58, 21);
            this.dtpFriStart.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dtpSatEnd);
            this.groupBox7.Controls.Add(this.dtpSatStart);
            this.groupBox7.Location = new System.Drawing.Point(477, 49);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(66, 64);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "星期六";
            // 
            // dtpSatEnd
            // 
            this.dtpSatEnd.CustomFormat = "HH:mm";
            this.dtpSatEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSatEnd.Location = new System.Drawing.Point(4, 39);
            this.dtpSatEnd.Name = "dtpSatEnd";
            this.dtpSatEnd.Size = new System.Drawing.Size(58, 21);
            this.dtpSatEnd.TabIndex = 1;
            // 
            // dtpSatStart
            // 
            this.dtpSatStart.CustomFormat = "HH:mm";
            this.dtpSatStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSatStart.Location = new System.Drawing.Point(4, 14);
            this.dtpSatStart.Name = "dtpSatStart";
            this.dtpSatStart.Size = new System.Drawing.Size(58, 21);
            this.dtpSatStart.TabIndex = 0;
            // 
            // chkholidayvaild
            // 
            this.chkholidayvaild.AutoSize = true;
            this.chkholidayvaild.Location = new System.Drawing.Point(414, 14);
            this.chkholidayvaild.Name = "chkholidayvaild";
            this.chkholidayvaild.Size = new System.Drawing.Size(84, 16);
            this.chkholidayvaild.TabIndex = 13;
            this.chkholidayvaild.Text = "节假日有效";
            this.chkholidayvaild.UseVisualStyleBackColor = true;
            // 
            // ACTimeZonesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 155);
            this.Controls.Add(this.chkholidayvaild);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ACTimeZonesEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "时间段设置";
            this.Text = "时间段设置";
            this.Load += new System.EventHandler(this.ACTimeZonesEdit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dtpSunStart;
        private System.Windows.Forms.DateTimePicker dtpSunEnd;
        private System.Windows.Forms.DateTimePicker dtpMonEnd;
        private System.Windows.Forms.DateTimePicker dtpMonStart;
        private System.Windows.Forms.DateTimePicker dtpTuesEnd;
        private System.Windows.Forms.DateTimePicker dtpTuesStart;
        private System.Windows.Forms.DateTimePicker dtpWedEnd;
        private System.Windows.Forms.DateTimePicker dtpWedStart;
        private System.Windows.Forms.DateTimePicker dtpThursEnd;
        private System.Windows.Forms.DateTimePicker dtpThursStart;
        private System.Windows.Forms.DateTimePicker dtpFriEnd;
        private System.Windows.Forms.DateTimePicker dtpFriStart;
        private System.Windows.Forms.DateTimePicker dtpSatEnd;
        private System.Windows.Forms.DateTimePicker dtpSatStart;
        private System.Windows.Forms.CheckBox chkholidayvaild;
    }
}