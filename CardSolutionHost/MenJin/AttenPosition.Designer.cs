namespace CardSolutionHost.MenJin
{

    partial class AttenPosition
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttenPosition));
            this.dgvUserR = new CardSolutionHost.Control.MyDataGridView();
            this.EmpNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeGroup = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnKQ = new System.Windows.Forms.Button();
            this.btnJZ = new System.Windows.Forms.Button();
            this.btnYX = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserR)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUserR
            // 
            this.dgvUserR.AllowUserToAddRows = false;
            this.dgvUserR.AllowUserToDeleteRows = false;
            this.dgvUserR.AllowUserToOrderColumns = true;
            this.dgvUserR.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgvUserR.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserR.BackgroundColor = System.Drawing.Color.White;
            this.dgvUserR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUserR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserR.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmpNo,
            this.EmpName});
            this.dgvUserR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUserR.EnableHeadersVisualStyles = false;
            this.dgvUserR.Font = new System.Drawing.Font("宋体", 9F);
            this.dgvUserR.Location = new System.Drawing.Point(0, 0);
            this.dgvUserR.MultiSelect = false;
            this.dgvUserR.Name = "dgvUserR";
            this.dgvUserR.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserR.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUserR.RowTemplate.Height = 23;
            this.dgvUserR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserR.Size = new System.Drawing.Size(686, 573);
            this.dgvUserR.TabIndex = 65;
            this.dgvUserR.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserR_CellDoubleClick);
            this.dgvUserR.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvUserR_CellFormatting);
            // 
            // EmpNo
            // 
            this.EmpNo.DataPropertyName = "EmpNo";
            this.EmpNo.HeaderText = "编号";
            this.EmpNo.Name = "EmpNo";
            this.EmpNo.ReadOnly = true;
            // 
            // EmpName
            // 
            this.EmpName.DataPropertyName = "EmpName";
            this.EmpName.HeaderText = "姓名";
            this.EmpName.Name = "EmpName";
            this.EmpName.ReadOnly = true;
            this.EmpName.Width = 120;
            // 
            // treeGroup
            // 
            this.treeGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeGroup.Location = new System.Drawing.Point(0, 0);
            this.treeGroup.Name = "treeGroup";
            this.treeGroup.Size = new System.Drawing.Size(228, 573);
            this.treeGroup.TabIndex = 140;
            this.treeGroup.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeGroup_NodeMouseClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeGroup);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvUserR);
            this.splitContainer1.Size = new System.Drawing.Size(918, 573);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 141;
            // 
            // btnKQ
            // 
            this.btnKQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKQ.Location = new System.Drawing.Point(924, 250);
            this.btnKQ.Name = "btnKQ";
            this.btnKQ.Size = new System.Drawing.Size(75, 36);
            this.btnKQ.TabIndex = 142;
            this.btnKQ.Text = "考勤";
            this.btnKQ.UseVisualStyleBackColor = true;
            this.btnKQ.Click += new System.EventHandler(this.btnKQ_Click);
            // 
            // btnJZ
            // 
            this.btnJZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJZ.Location = new System.Drawing.Point(924, 323);
            this.btnJZ.Name = "btnJZ";
            this.btnJZ.Size = new System.Drawing.Size(75, 36);
            this.btnJZ.TabIndex = 143;
            this.btnJZ.Text = "禁止";
            this.btnJZ.UseVisualStyleBackColor = true;
            this.btnJZ.Click += new System.EventHandler(this.btnJZ_Click);
            // 
            // btnYX
            // 
            this.btnYX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYX.Location = new System.Drawing.Point(924, 177);
            this.btnYX.Name = "btnYX";
            this.btnYX.Size = new System.Drawing.Size(75, 36);
            this.btnYX.TabIndex = 144;
            this.btnYX.Text = "允许";
            this.btnYX.UseVisualStyleBackColor = true;
            this.btnYX.Click += new System.EventHandler(this.btnYX_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "book.png");
            // 
            // AttenPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 573);
            this.Controls.Add(this.btnYX);
            this.Controls.Add(this.btnJZ);
            this.Controls.Add(this.btnKQ);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AttenPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "考勤位置设置";
            this.Text = "考勤位置设置";
            this.Load += new System.EventHandler(this.AttenPosition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserR)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal CardSolutionHost.Control.MyDataGridView dgvUserR;
        private System.Windows.Forms.TreeView treeGroup;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpName;
        private System.Windows.Forms.Button btnKQ;
        private System.Windows.Forms.Button btnJZ;
        private System.Windows.Forms.Button btnYX;
        private System.Windows.Forms.ImageList imageList1;
    }
}