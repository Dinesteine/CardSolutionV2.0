namespace CardSolutionHost.MenJin
{
    partial class ACUnlockCombManage
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.UnlockCombID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(45, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
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
            this.UnlockCombID,
            this.NameDes,
            this.Group01,
            this.Group02,
            this.Group03,
            this.Group04,
            this.Group05});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 40);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(647, 372);
            this.dataGridView.TabIndex = 7;
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            // 
            // UnlockCombID
            // 
            this.UnlockCombID.DataPropertyName = "UnlockCombID";
            this.UnlockCombID.HeaderText = "开锁组合";
            this.UnlockCombID.Name = "UnlockCombID";
            this.UnlockCombID.ReadOnly = true;
            this.UnlockCombID.Width = 60;
            // 
            // NameDes
            // 
            this.NameDes.DataPropertyName = "Name";
            this.NameDes.HeaderText = "描述";
            this.NameDes.Name = "NameDes";
            this.NameDes.ReadOnly = true;
            this.NameDes.Width = 120;
            // 
            // Group01
            // 
            this.Group01.DataPropertyName = "Group01";
            this.Group01.HeaderText = "组1";
            this.Group01.Name = "Group01";
            this.Group01.ReadOnly = true;
            this.Group01.Width = 60;
            // 
            // Group02
            // 
            this.Group02.DataPropertyName = "Group02";
            this.Group02.HeaderText = "组2";
            this.Group02.Name = "Group02";
            this.Group02.ReadOnly = true;
            this.Group02.Width = 60;
            // 
            // Group03
            // 
            this.Group03.DataPropertyName = "Group03";
            this.Group03.HeaderText = "组3";
            this.Group03.Name = "Group03";
            this.Group03.ReadOnly = true;
            this.Group03.Width = 60;
            // 
            // Group04
            // 
            this.Group04.DataPropertyName = "Group04";
            this.Group04.HeaderText = "组4";
            this.Group04.Name = "Group04";
            this.Group04.ReadOnly = true;
            this.Group04.Width = 60;
            // 
            // Group05
            // 
            this.Group05.DataPropertyName = "Group05";
            this.Group05.HeaderText = "组5";
            this.Group05.Name = "Group05";
            this.Group05.ReadOnly = true;
            this.Group05.Width = 60;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(271, 6);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Visible = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(157, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // ACUnlockCombManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 412);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnEdit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ACUnlockCombManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "开锁组合";
            this.Text = "开锁组合";
            this.Load += new System.EventHandler(this.ACUnlockCombManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnlockCombID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group01;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group02;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group03;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group04;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group05;
    }
}