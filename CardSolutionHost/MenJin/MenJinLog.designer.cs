namespace CardSolutionHost.MenJin
{
    partial class MenJinLog
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.chkACTimeZone = new System.Windows.Forms.CheckBox();
            this.chkGroup = new System.Windows.Forms.CheckBox();
            this.chkACUnlockComb = new System.Windows.Forms.CheckBox();
            this.chkUserACPrivilege = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkMJFK = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMachine = new CardSolutionHost.Control.MyDataGridView();
            this.IsSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MachineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMachine)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(3, 17);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(930, 424);
            this.listBox1.TabIndex = 0;
            // 
            // chkACTimeZone
            // 
            this.chkACTimeZone.AutoSize = true;
            this.chkACTimeZone.Checked = true;
            this.chkACTimeZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkACTimeZone.Location = new System.Drawing.Point(36, 36);
            this.chkACTimeZone.Name = "chkACTimeZone";
            this.chkACTimeZone.Size = new System.Drawing.Size(60, 16);
            this.chkACTimeZone.TabIndex = 20;
            this.chkACTimeZone.Text = "时间段";
            this.chkACTimeZone.UseVisualStyleBackColor = true;
            // 
            // chkGroup
            // 
            this.chkGroup.AutoSize = true;
            this.chkGroup.Checked = true;
            this.chkGroup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGroup.Location = new System.Drawing.Point(36, 106);
            this.chkGroup.Name = "chkGroup";
            this.chkGroup.Size = new System.Drawing.Size(36, 16);
            this.chkGroup.TabIndex = 20;
            this.chkGroup.Text = "组";
            this.chkGroup.UseVisualStyleBackColor = true;
            // 
            // chkACUnlockComb
            // 
            this.chkACUnlockComb.AutoSize = true;
            this.chkACUnlockComb.Checked = true;
            this.chkACUnlockComb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkACUnlockComb.Location = new System.Drawing.Point(36, 71);
            this.chkACUnlockComb.Name = "chkACUnlockComb";
            this.chkACUnlockComb.Size = new System.Drawing.Size(72, 16);
            this.chkACUnlockComb.TabIndex = 20;
            this.chkACUnlockComb.Text = "开锁组合";
            this.chkACUnlockComb.UseVisualStyleBackColor = true;
            // 
            // chkUserACPrivilege
            // 
            this.chkUserACPrivilege.AutoSize = true;
            this.chkUserACPrivilege.Checked = true;
            this.chkUserACPrivilege.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserACPrivilege.Location = new System.Drawing.Point(36, 141);
            this.chkUserACPrivilege.Name = "chkUserACPrivilege";
            this.chkUserACPrivilege.Size = new System.Drawing.Size(72, 16);
            this.chkUserACPrivilege.TabIndex = 20;
            this.chkUserACPrivilege.Text = "门禁权限";
            this.chkUserACPrivilege.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkMJFK);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.chkGroup);
            this.groupBox1.Controls.Add(this.chkUserACPrivilege);
            this.groupBox1.Controls.Add(this.chkACTimeZone);
            this.groupBox1.Controls.Add(this.chkACUnlockComb);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(936, 209);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "上传选项";
            // 
            // chkMJFK
            // 
            this.chkMJFK.AutoSize = true;
            this.chkMJFK.Location = new System.Drawing.Point(799, 124);
            this.chkMJFK.Name = "chkMJFK";
            this.chkMJFK.Size = new System.Drawing.Size(96, 16);
            this.chkMJFK.TabIndex = 23;
            this.chkMJFK.Text = "覆盖门禁权限";
            this.chkMJFK.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(783, 155);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(147, 51);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "开始上传";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvMachine);
            this.groupBox2.Location = new System.Drawing.Point(126, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(651, 197);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "考勤机选择";
            // 
            // dgvMachine
            // 
            this.dgvMachine.AllowUserToAddRows = false;
            this.dgvMachine.AllowUserToDeleteRows = false;
            this.dgvMachine.AllowUserToResizeRows = false;
            this.dgvMachine.BackgroundColor = System.Drawing.Color.White;
            this.dgvMachine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMachine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsSelected,
            this.MachineNumber,
            this.MachineAlias,
            this.IP});
            this.dgvMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMachine.Location = new System.Drawing.Point(3, 17);
            this.dgvMachine.Name = "dgvMachine";
            this.dgvMachine.ReadOnly = true;
            this.dgvMachine.RowTemplate.Height = 23;
            this.dgvMachine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMachine.Size = new System.Drawing.Size(645, 177);
            this.dgvMachine.TabIndex = 19;
            this.dgvMachine.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMachine_CellDoubleClick);
            this.dgvMachine.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMachine_CellContentClick);
            // 
            // IsSelected
            // 
            this.IsSelected.DataPropertyName = "IsSelected";
            this.IsSelected.HeaderText = "选择";
            this.IsSelected.Name = "IsSelected";
            this.IsSelected.ReadOnly = true;
            this.IsSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsSelected.Width = 60;
            // 
            // MachineNumber
            // 
            this.MachineNumber.DataPropertyName = "MachineNumber";
            this.MachineNumber.HeaderText = "编号";
            this.MachineNumber.Name = "MachineNumber";
            this.MachineNumber.ReadOnly = true;
            this.MachineNumber.Width = 70;
            // 
            // MachineAlias
            // 
            this.MachineAlias.DataPropertyName = "MachineAlias";
            this.MachineAlias.HeaderText = "名称";
            this.MachineAlias.Name = "MachineAlias";
            this.MachineAlias.ReadOnly = true;
            this.MachineAlias.Width = 220;
            // 
            // IP
            // 
            this.IP.DataPropertyName = "IP";
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            this.IP.Width = 120;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 212);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(936, 444);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "上传信息";
            // 
            // MenJinLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 656);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenJinLog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "门禁权限上传";
            this.Text = "门禁权限上传";
            this.Load += new System.EventHandler(this.MenJinLog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMachine)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private CardSolutionHost.Control.MyDataGridView dgvMachine;
        private System.Windows.Forms.CheckBox chkACTimeZone;
        private System.Windows.Forms.CheckBox chkGroup;
        private System.Windows.Forms.CheckBox chkACUnlockComb;
        private System.Windows.Forms.CheckBox chkUserACPrivilege;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.CheckBox chkMJFK;
    }
}