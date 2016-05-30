namespace CardSolutionHost.MenJin
{
    partial class ACGroupSelect
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
            this.GroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeZone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeZone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeZone3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.holidayvaild = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.verifystyle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
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
            this.GroupID,
            this.NameDes,
            this.TimeZone1,
            this.TimeZone2,
            this.TimeZone3,
            this.holidayvaild,
            this.verifystyle});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(810, 354);
            this.dataGridView.TabIndex = 13;
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            // 
            // GroupID
            // 
            this.GroupID.DataPropertyName = "GroupID";
            this.GroupID.HeaderText = "组";
            this.GroupID.Name = "GroupID";
            this.GroupID.ReadOnly = true;
            this.GroupID.Width = 60;
            // 
            // NameDes
            // 
            this.NameDes.DataPropertyName = "Name";
            this.NameDes.HeaderText = "描述";
            this.NameDes.Name = "NameDes";
            this.NameDes.ReadOnly = true;
            this.NameDes.Width = 120;
            // 
            // TimeZone1
            // 
            this.TimeZone1.DataPropertyName = "TimeZone1";
            this.TimeZone1.HeaderText = "时间段1";
            this.TimeZone1.Name = "TimeZone1";
            this.TimeZone1.ReadOnly = true;
            // 
            // TimeZone2
            // 
            this.TimeZone2.DataPropertyName = "TimeZone2";
            this.TimeZone2.HeaderText = "时间段2";
            this.TimeZone2.Name = "TimeZone2";
            this.TimeZone2.ReadOnly = true;
            // 
            // TimeZone3
            // 
            this.TimeZone3.DataPropertyName = "TimeZone3";
            this.TimeZone3.HeaderText = "时间段3";
            this.TimeZone3.Name = "TimeZone3";
            this.TimeZone3.ReadOnly = true;
            // 
            // holidayvaild
            // 
            this.holidayvaild.DataPropertyName = "holidayvaild";
            this.holidayvaild.HeaderText = "节假日有效";
            this.holidayvaild.Name = "holidayvaild";
            this.holidayvaild.ReadOnly = true;
            this.holidayvaild.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.holidayvaild.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.holidayvaild.Width = 90;
            // 
            // verifystyle
            // 
            this.verifystyle.DataPropertyName = "verifystyle";
            this.verifystyle.HeaderText = "验证方式";
            this.verifystyle.Name = "verifystyle";
            this.verifystyle.ReadOnly = true;
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.Location = new System.Drawing.Point(723, 360);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 16;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(610, 360);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ACGroupSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 387);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dataGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ACGroupSelect";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "组设置";
            this.Text = "组设置";
            this.Load += new System.EventHandler(this.ACGroupSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn GroupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeZone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeZone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeZone3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn holidayvaild;
        private System.Windows.Forms.DataGridViewTextBoxColumn verifystyle;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.DataGridView dataGridView;
    }
}