namespace CardSolutionHost.MenJin
{
    partial class ACTimeZonesManage
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.TimeZoneID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Holidayvaild = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SunStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SunEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuesStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuesEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WedStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WedEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThursStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThursEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FriStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FriEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SatStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SatEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(45, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(157, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(271, 12);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeZoneID,
            this.NameDes,
            this.Holidayvaild,
            this.SunStart,
            this.SunEnd,
            this.MonStart,
            this.MonEnd,
            this.TuesStart,
            this.TuesEnd,
            this.WedStart,
            this.WedEnd,
            this.ThursStart,
            this.ThursEnd,
            this.FriStart,
            this.FriEnd,
            this.SatStart,
            this.SatEnd});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 41);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(1184, 476);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            // 
            // TimeZoneID
            // 
            this.TimeZoneID.DataPropertyName = "TimeZoneID";
            this.TimeZoneID.HeaderText = "编号";
            this.TimeZoneID.Name = "TimeZoneID";
            this.TimeZoneID.ReadOnly = true;
            this.TimeZoneID.Width = 60;
            // 
            // NameDes
            // 
            this.NameDes.DataPropertyName = "Name";
            this.NameDes.HeaderText = "描述";
            this.NameDes.Name = "NameDes";
            this.NameDes.ReadOnly = true;
            this.NameDes.Width = 120;
            // 
            // Holidayvaild
            // 
            this.Holidayvaild.DataPropertyName = "Holidayvaild";
            this.Holidayvaild.HeaderText = "节假日有效";
            this.Holidayvaild.Name = "Holidayvaild";
            this.Holidayvaild.ReadOnly = true;
            this.Holidayvaild.Width = 80;
            // 
            // SunStart
            // 
            this.SunStart.DataPropertyName = "SunStart";
            this.SunStart.HeaderText = "周日开始";
            this.SunStart.Name = "SunStart";
            this.SunStart.ReadOnly = true;
            this.SunStart.Width = 60;
            // 
            // SunEnd
            // 
            this.SunEnd.DataPropertyName = "SunEnd";
            this.SunEnd.HeaderText = "周日结束";
            this.SunEnd.Name = "SunEnd";
            this.SunEnd.ReadOnly = true;
            this.SunEnd.Width = 60;
            // 
            // MonStart
            // 
            this.MonStart.DataPropertyName = "MonStart";
            this.MonStart.HeaderText = "周一开始";
            this.MonStart.Name = "MonStart";
            this.MonStart.ReadOnly = true;
            this.MonStart.Width = 60;
            // 
            // MonEnd
            // 
            this.MonEnd.DataPropertyName = "MonEnd";
            this.MonEnd.HeaderText = "周一结束";
            this.MonEnd.Name = "MonEnd";
            this.MonEnd.ReadOnly = true;
            this.MonEnd.Width = 60;
            // 
            // TuesStart
            // 
            this.TuesStart.DataPropertyName = "TuesStart";
            this.TuesStart.HeaderText = "周二开始";
            this.TuesStart.Name = "TuesStart";
            this.TuesStart.ReadOnly = true;
            this.TuesStart.Width = 60;
            // 
            // TuesEnd
            // 
            this.TuesEnd.DataPropertyName = "TuesEnd";
            this.TuesEnd.HeaderText = "周二结束";
            this.TuesEnd.Name = "TuesEnd";
            this.TuesEnd.ReadOnly = true;
            this.TuesEnd.Width = 60;
            // 
            // WedStart
            // 
            this.WedStart.DataPropertyName = "WedStart";
            this.WedStart.HeaderText = "周三开始";
            this.WedStart.Name = "WedStart";
            this.WedStart.ReadOnly = true;
            this.WedStart.Width = 60;
            // 
            // WedEnd
            // 
            this.WedEnd.DataPropertyName = "WedEnd";
            this.WedEnd.HeaderText = "周三结束";
            this.WedEnd.Name = "WedEnd";
            this.WedEnd.ReadOnly = true;
            this.WedEnd.Width = 60;
            // 
            // ThursStart
            // 
            this.ThursStart.DataPropertyName = "ThursStart";
            this.ThursStart.HeaderText = "周四开始";
            this.ThursStart.Name = "ThursStart";
            this.ThursStart.ReadOnly = true;
            this.ThursStart.Width = 60;
            // 
            // ThursEnd
            // 
            this.ThursEnd.DataPropertyName = "ThursEnd";
            this.ThursEnd.HeaderText = "周四结束";
            this.ThursEnd.Name = "ThursEnd";
            this.ThursEnd.ReadOnly = true;
            this.ThursEnd.Width = 60;
            // 
            // FriStart
            // 
            this.FriStart.DataPropertyName = "FriStart";
            this.FriStart.HeaderText = "周五开始";
            this.FriStart.Name = "FriStart";
            this.FriStart.ReadOnly = true;
            this.FriStart.Width = 60;
            // 
            // FriEnd
            // 
            this.FriEnd.DataPropertyName = "FriEnd";
            this.FriEnd.HeaderText = "周五结束";
            this.FriEnd.Name = "FriEnd";
            this.FriEnd.ReadOnly = true;
            this.FriEnd.Width = 60;
            // 
            // SatStart
            // 
            this.SatStart.DataPropertyName = "SatStart";
            this.SatStart.HeaderText = "周六开始";
            this.SatStart.Name = "SatStart";
            this.SatStart.ReadOnly = true;
            this.SatStart.Width = 60;
            // 
            // SatEnd
            // 
            this.SatEnd.DataPropertyName = "SatEnd";
            this.SatEnd.HeaderText = "周六结束";
            this.SatEnd.Name = "SatEnd";
            this.SatEnd.ReadOnly = true;
            this.SatEnd.Width = 60;
            // 
            // ACTimeZonesManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 517);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Name = "ACTimeZonesManage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "门禁时间段设置";
            this.Text = "门禁时间段设置";
            this.Load += new System.EventHandler(this.ACTimeZonesManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeZoneID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Holidayvaild;
        private System.Windows.Forms.DataGridViewTextBoxColumn SunStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn SunEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuesStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuesEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn WedStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn WedEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThursStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThursEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn FriStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn FriEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn SatStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn SatEnd;
    }
}