namespace CardSolutionHost
{
    partial class DataBaseSet
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageDataConn = new System.Windows.Forms.TabPage();
            this.btnSaveConn = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPageDataConn.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageDataConn);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(374, 224);
            this.tabControl.TabIndex = 216;
            // 
            // tabPageDataConn
            // 
            this.tabPageDataConn.Controls.Add(this.btnSaveConn);
            this.tabPageDataConn.Controls.Add(this.txtPwd);
            this.tabPageDataConn.Controls.Add(this.label4);
            this.tabPageDataConn.Controls.Add(this.txtUId);
            this.tabPageDataConn.Controls.Add(this.label3);
            this.tabPageDataConn.Controls.Add(this.txtDataBase);
            this.tabPageDataConn.Controls.Add(this.label2);
            this.tabPageDataConn.Controls.Add(this.txtServer);
            this.tabPageDataConn.Controls.Add(this.label1);
            this.tabPageDataConn.Location = new System.Drawing.Point(4, 21);
            this.tabPageDataConn.Name = "tabPageDataConn";
            this.tabPageDataConn.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDataConn.Size = new System.Drawing.Size(366, 199);
            this.tabPageDataConn.TabIndex = 0;
            this.tabPageDataConn.Text = "一卡通系统设置";
            this.tabPageDataConn.UseVisualStyleBackColor = true;
            // 
            // btnSaveConn
            // 
            this.btnSaveConn.Location = new System.Drawing.Point(112, 146);
            this.btnSaveConn.Name = "btnSaveConn";
            this.btnSaveConn.Size = new System.Drawing.Size(145, 44);
            this.btnSaveConn.TabIndex = 8;
            this.btnSaveConn.Text = "保存";
            this.btnSaveConn.UseVisualStyleBackColor = true;
            this.btnSaveConn.Click += new System.EventHandler(this.btnSaveConn_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(81, 107);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(259, 21);
            this.txtPwd.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "密码";
            // 
            // txtUId
            // 
            this.txtUId.Location = new System.Drawing.Point(81, 77);
            this.txtUId.Name = "txtUId";
            this.txtUId.Size = new System.Drawing.Size(259, 21);
            this.txtUId.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户名";
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(81, 47);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(259, 21);
            this.txtDataBase.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据库名称";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(81, 17);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(259, 21);
            this.txtServer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器地址";
            // 
            // DataBaseSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 224);
            this.Controls.Add(this.tabControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataBaseSet";
            this.ShowInTaskbar = false;
            this.TabText = "一卡通系统设置";
            this.Text = "一卡通系统设置";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageDataConn.ResumeLayout(false);
            this.tabPageDataConn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageDataConn;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDataBase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveConn;
    }
}