namespace CardSolutionHost
{
    partial class MenJinSet
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nHour = new System.Windows.Forms.NumericUpDown();
            this.nMin = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nCheckTimes = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCheckTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(152, 111);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "关闭";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(49, 111);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "每天重启时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "定时刷新时间间隔";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "分钟";
            // 
            // nHour
            // 
            this.nHour.Location = new System.Drawing.Point(119, 21);
            this.nHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nHour.Name = "nHour";
            this.nHour.Size = new System.Drawing.Size(41, 21);
            this.nHour.TabIndex = 8;
            // 
            // nMin
            // 
            this.nMin.Location = new System.Drawing.Point(184, 21);
            this.nMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nMin.Name = "nMin";
            this.nMin.Size = new System.Drawing.Size(41, 21);
            this.nMin.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "时";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "分";
            // 
            // nCheckTimes
            // 
            this.nCheckTimes.Location = new System.Drawing.Point(119, 63);
            this.nCheckTimes.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nCheckTimes.Name = "nCheckTimes";
            this.nCheckTimes.Size = new System.Drawing.Size(95, 21);
            this.nCheckTimes.TabIndex = 12;
            this.nCheckTimes.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // MenJinSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 144);
            this.Controls.Add(this.nCheckTimes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nMin);
            this.Controls.Add(this.nHour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenJinSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "门禁刷新重启设置";
            this.Text = "门禁刷新重启设置";
            this.Load += new System.EventHandler(this.MenJinSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCheckTimes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown nHour;
        public System.Windows.Forms.NumericUpDown nMin;
        public System.Windows.Forms.NumericUpDown nCheckTimes;
    }
}