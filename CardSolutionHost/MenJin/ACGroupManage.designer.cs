namespace CardSolutionHost.MenJin
{
    partial class ACGroupManage
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
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.GroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeZone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeZone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeZone3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.holidayvaild = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.verifystyle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(256, 362);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 12;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(142, 362);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(30, 362);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(810, 354);
            this.dataGridView.TabIndex = 8;
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
            this.btnCancle.Location = new System.Drawing.Point(707, 362);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 11;
            this.btnCancle.Text = "关闭";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // ACGroupManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 387);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnCancle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ACGroupManage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "组";
            this.Text = "组";
            this.Load += new System.EventHandler(this.ACGroupManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeZone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeZone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeZone3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn holidayvaild;
        private System.Windows.Forms.DataGridViewTextBoxColumn verifystyle;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}