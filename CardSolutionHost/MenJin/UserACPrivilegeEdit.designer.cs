namespace CardSolutionHost.MenJin
{
    partial class UserACPrivilegeEdit
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.EmpNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACGroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsUseGroup = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TimeZone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeZone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeZone3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verifystyle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmpNo,
            this.EmpName,
            this.ACGroupID,
            this.IsUseGroup,
            this.TimeZone1,
            this.TimeZone2,
            this.TimeZone3,
            this.MachineAlias,
            this.verifystyle});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 39);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(871, 412);
            this.dataGridView.TabIndex = 8;
            this.dataGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellMouseLeave);
            this.dataGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseMove);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
            // 
            // EmpNo
            // 
            this.EmpNo.DataPropertyName = "EmpNo";
            this.EmpNo.HeaderText = "编号";
            this.EmpNo.Name = "EmpNo";
            this.EmpNo.ReadOnly = true;
            this.EmpNo.Width = 60;
            // 
            // EmpName
            // 
            this.EmpName.DataPropertyName = "EmpName";
            this.EmpName.HeaderText = "姓名";
            this.EmpName.Name = "EmpName";
            this.EmpName.ReadOnly = true;
            // 
            // ACGroupID
            // 
            this.ACGroupID.DataPropertyName = "ACGroupID";
            this.ACGroupID.HeaderText = "组";
            this.ACGroupID.Name = "ACGroupID";
            this.ACGroupID.ReadOnly = true;
            this.ACGroupID.Width = 60;
            // 
            // IsUseGroup
            // 
            this.IsUseGroup.DataPropertyName = "IsUseGroup";
            this.IsUseGroup.HeaderText = "是否使用组";
            this.IsUseGroup.Name = "IsUseGroup";
            this.IsUseGroup.ReadOnly = true;
            this.IsUseGroup.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsUseGroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TimeZone1
            // 
            this.TimeZone1.DataPropertyName = "TimeZone1";
            this.TimeZone1.HeaderText = "时间段1";
            this.TimeZone1.Name = "TimeZone1";
            this.TimeZone1.ReadOnly = true;
            this.TimeZone1.Width = 80;
            // 
            // TimeZone2
            // 
            this.TimeZone2.DataPropertyName = "TimeZone2";
            this.TimeZone2.HeaderText = "时间段2";
            this.TimeZone2.Name = "TimeZone2";
            this.TimeZone2.ReadOnly = true;
            this.TimeZone2.Width = 80;
            // 
            // TimeZone3
            // 
            this.TimeZone3.DataPropertyName = "TimeZone3";
            this.TimeZone3.HeaderText = "时间段3";
            this.TimeZone3.Name = "TimeZone3";
            this.TimeZone3.ReadOnly = true;
            this.TimeZone3.Width = 80;
            // 
            // MachineAlias
            // 
            this.MachineAlias.DataPropertyName = "MachineAlias";
            this.MachineAlias.HeaderText = "门(门禁机)";
            this.MachineAlias.Name = "MachineAlias";
            this.MachineAlias.ReadOnly = true;
            // 
            // verifystyle
            // 
            this.verifystyle.DataPropertyName = "verifystyle";
            this.verifystyle.HeaderText = "验证方式";
            this.verifystyle.Name = "verifystyle";
            this.verifystyle.ReadOnly = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(5, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(107, 33);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "编辑权限";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(396, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 90);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // UserACPrivilegeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 451);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dataGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserACPrivilegeEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "门禁权限设置";
            this.Text = "门禁权限设置";
            this.Load += new System.EventHandler(this.UserACPrivilegeEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACGroupID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsUseGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeZone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeZone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeZone3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn verifystyle;
        private System.Windows.Forms.Label label1;
    }
}