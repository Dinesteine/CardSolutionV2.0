namespace CardSolutionHost
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭所有窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.除此之外全部关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripReStartServer = new System.Windows.Forms.ToolStripButton();
            this.toolStripRefreshServer = new System.Windows.Forms.ToolStripButton();
            this.toolStripACTimeZones = new System.Windows.Forms.ToolStripButton();
            this.toolStripacholiday = new System.Windows.Forms.ToolStripButton();
            this.toolStripACGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripACUnlockComb = new System.Windows.Forms.ToolStripButton();
            this.toolStripMachineShowSet = new System.Windows.Forms.ToolStripButton();
            this.toolStripUserACPrivilege = new System.Windows.Forms.ToolStripButton();
            this.toolStripUpLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripStatusSet = new System.Windows.Forms.ToolStripButton();
            this.toolStripExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripComputerName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusloginName = new System.Windows.Forms.ToolStripStatusLabel();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip.BackgroundImage")));
            this.menuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统ToolStripMenuItem,
            this.窗口ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(739, 21);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出系统ToolStripMenuItem,
            this.数据库连接ToolStripMenuItem});
            this.系统ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(42, 17);
            this.系统ToolStripMenuItem.Text = "系统";
            // 
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.退出系统ToolStripMenuItem.Text = "退出系统";
            this.退出系统ToolStripMenuItem.Click += new System.EventHandler(this.退出系统ToolStripMenuItem_Click);
            // 
            // 数据库连接ToolStripMenuItem
            // 
            this.数据库连接ToolStripMenuItem.Name = "数据库连接ToolStripMenuItem";
            this.数据库连接ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.数据库连接ToolStripMenuItem.Text = "数据库连接";
            this.数据库连接ToolStripMenuItem.Click += new System.EventHandler(this.数据库连接ToolStripMenuItem_Click);
            // 
            // 窗口ToolStripMenuItem
            // 
            this.窗口ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关闭所有窗口ToolStripMenuItem,
            this.除此之外全部关闭ToolStripMenuItem});
            this.窗口ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.窗口ToolStripMenuItem.Name = "窗口ToolStripMenuItem";
            this.窗口ToolStripMenuItem.Size = new System.Drawing.Size(42, 17);
            this.窗口ToolStripMenuItem.Text = "窗口";
            // 
            // 关闭所有窗口ToolStripMenuItem
            // 
            this.关闭所有窗口ToolStripMenuItem.Name = "关闭所有窗口ToolStripMenuItem";
            this.关闭所有窗口ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.关闭所有窗口ToolStripMenuItem.Text = "关闭所有窗口";
            // 
            // 除此之外全部关闭ToolStripMenuItem
            // 
            this.除此之外全部关闭ToolStripMenuItem.Name = "除此之外全部关闭ToolStripMenuItem";
            this.除此之外全部关闭ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.除此之外全部关闭ToolStripMenuItem.Text = "除此之外全部关闭";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem,
            this.帮助ToolStripMenuItem1});
            this.帮助ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(42, 17);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 帮助ToolStripMenuItem1
            // 
            this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
            this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.帮助ToolStripMenuItem1.Text = "帮助";
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripReStartServer,
            this.toolStripRefreshServer,
            this.toolStripACTimeZones,
            this.toolStripacholiday,
            this.toolStripACGroup,
            this.toolStripACUnlockComb,
            this.toolStripMachineShowSet,
            this.toolStripUserACPrivilege,
            this.toolStripUpLoad,
            this.toolStripStatusSet,
            this.toolStripExit});
            this.toolStrip.Location = new System.Drawing.Point(0, 21);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(739, 43);
            this.toolStrip.TabIndex = 2;
            // 
            // toolStripReStartServer
            // 
            this.toolStripReStartServer.Image = ((System.Drawing.Image)(resources.GetObject("toolStripReStartServer.Image")));
            this.toolStripReStartServer.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripReStartServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripReStartServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripReStartServer.Name = "toolStripReStartServer";
            this.toolStripReStartServer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripReStartServer.Size = new System.Drawing.Size(94, 40);
            this.toolStripReStartServer.Text = "重启门禁服务";
            this.toolStripReStartServer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripReStartServer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripReStartServer.Click += new System.EventHandler(this.toolStripStartServer_Click);
            // 
            // toolStripRefreshServer
            // 
            this.toolStripRefreshServer.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRefreshServer.Image")));
            this.toolStripRefreshServer.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripRefreshServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripRefreshServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRefreshServer.Name = "toolStripRefreshServer";
            this.toolStripRefreshServer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripRefreshServer.Size = new System.Drawing.Size(94, 40);
            this.toolStripRefreshServer.Text = "刷新门禁服务";
            this.toolStripRefreshServer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripRefreshServer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripRefreshServer.Click += new System.EventHandler(this.toolStripRefreshServer_Click);
            // 
            // toolStripACTimeZones
            // 
            this.toolStripACTimeZones.Image = ((System.Drawing.Image)(resources.GetObject("toolStripACTimeZones.Image")));
            this.toolStripACTimeZones.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripACTimeZones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripACTimeZones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripACTimeZones.Name = "toolStripACTimeZones";
            this.toolStripACTimeZones.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripACTimeZones.Size = new System.Drawing.Size(58, 40);
            this.toolStripACTimeZones.Text = "时间段";
            this.toolStripACTimeZones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripACTimeZones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripACTimeZones.Click += new System.EventHandler(this.toolStripACTimeZones_Click);
            // 
            // toolStripacholiday
            // 
            this.toolStripacholiday.Image = ((System.Drawing.Image)(resources.GetObject("toolStripacholiday.Image")));
            this.toolStripacholiday.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripacholiday.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripacholiday.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripacholiday.Name = "toolStripacholiday";
            this.toolStripacholiday.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripacholiday.Size = new System.Drawing.Size(58, 40);
            this.toolStripacholiday.Text = "节假日";
            this.toolStripacholiday.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripacholiday.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripacholiday.Visible = false;
            this.toolStripacholiday.Click += new System.EventHandler(this.toolStripacholiday_Click);
            // 
            // toolStripACGroup
            // 
            this.toolStripACGroup.Image = ((System.Drawing.Image)(resources.GetObject("toolStripACGroup.Image")));
            this.toolStripACGroup.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripACGroup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripACGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripACGroup.Name = "toolStripACGroup";
            this.toolStripACGroup.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripACGroup.Size = new System.Drawing.Size(34, 40);
            this.toolStripACGroup.Text = "组";
            this.toolStripACGroup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripACGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripACGroup.Visible = false;
            this.toolStripACGroup.Click += new System.EventHandler(this.toolStripACGroup_Click);
            // 
            // toolStripACUnlockComb
            // 
            this.toolStripACUnlockComb.Image = ((System.Drawing.Image)(resources.GetObject("toolStripACUnlockComb.Image")));
            this.toolStripACUnlockComb.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripACUnlockComb.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripACUnlockComb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripACUnlockComb.Name = "toolStripACUnlockComb";
            this.toolStripACUnlockComb.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripACUnlockComb.Size = new System.Drawing.Size(70, 40);
            this.toolStripACUnlockComb.Text = "开锁组合";
            this.toolStripACUnlockComb.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripACUnlockComb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripACUnlockComb.Click += new System.EventHandler(this.toolStripACUnlockComb_Click);
            // 
            // toolStripMachineShowSet
            // 
            this.toolStripMachineShowSet.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMachineShowSet.Image")));
            this.toolStripMachineShowSet.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripMachineShowSet.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMachineShowSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMachineShowSet.Name = "toolStripMachineShowSet";
            this.toolStripMachineShowSet.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripMachineShowSet.Size = new System.Drawing.Size(94, 40);
            this.toolStripMachineShowSet.Text = "门禁显示设置";
            this.toolStripMachineShowSet.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripMachineShowSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripMachineShowSet.Click += new System.EventHandler(this.toolStripMachineShowSet_Click);
            // 
            // toolStripUserACPrivilege
            // 
            this.toolStripUserACPrivilege.Image = ((System.Drawing.Image)(resources.GetObject("toolStripUserACPrivilege.Image")));
            this.toolStripUserACPrivilege.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripUserACPrivilege.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripUserACPrivilege.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripUserACPrivilege.Name = "toolStripUserACPrivilege";
            this.toolStripUserACPrivilege.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripUserACPrivilege.Size = new System.Drawing.Size(70, 40);
            this.toolStripUserACPrivilege.Text = "门禁权限";
            this.toolStripUserACPrivilege.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripUserACPrivilege.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripUserACPrivilege.Click += new System.EventHandler(this.toolStripUserACPrivilege_Click);
            // 
            // toolStripUpLoad
            // 
            this.toolStripUpLoad.Image = ((System.Drawing.Image)(resources.GetObject("toolStripUpLoad.Image")));
            this.toolStripUpLoad.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripUpLoad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripUpLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripUpLoad.Name = "toolStripUpLoad";
            this.toolStripUpLoad.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripUpLoad.Size = new System.Drawing.Size(70, 40);
            this.toolStripUpLoad.Text = "上传设置";
            this.toolStripUpLoad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripUpLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripUpLoad.Click += new System.EventHandler(this.toolStripUpLoad_Click);
            // 
            // toolStripStatusSet
            // 
            this.toolStripStatusSet.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusSet.Image")));
            this.toolStripStatusSet.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripStatusSet.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStatusSet.Name = "toolStripStatusSet";
            this.toolStripStatusSet.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripStatusSet.Size = new System.Drawing.Size(118, 37);
            this.toolStripStatusSet.Text = "门禁刷新重启设置";
            this.toolStripStatusSet.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripStatusSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripStatusSet.Click += new System.EventHandler(this.toolStripStatusSet_Click);
            // 
            // toolStripExit
            // 
            this.toolStripExit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripExit.Image")));
            this.toolStripExit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExit.Name = "toolStripExit";
            this.toolStripExit.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripExit.Size = new System.Drawing.Size(46, 37);
            this.toolStripExit.Text = "退出";
            this.toolStripExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripExit.Click += new System.EventHandler(this.toolStripExit_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDate,
            this.toolStripStatusLabel5,
            this.toolStripComputerName,
            this.toolStripStatusLabel2,
            this.toolStripStatusloginName});
            this.statusStrip.Location = new System.Drawing.Point(0, 514);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(739, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripDate
            // 
            this.toolStripDate.Name = "toolStripDate";
            this.toolStripDate.Size = new System.Drawing.Size(56, 17);
            this.toolStripDate.Text = "日期公历";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel5.Text = "|";
            // 
            // toolStripComputerName
            // 
            this.toolStripComputerName.Name = "toolStripComputerName";
            this.toolStripComputerName.Size = new System.Drawing.Size(68, 17);
            this.toolStripComputerName.Text = "主机名称：";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusloginName
            // 
            this.toolStripStatusloginName.Name = "toolStripStatusloginName";
            this.toolStripStatusloginName.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusloginName.Text = "当前用户：";
            // 
            // dockPanel
            // 
            this.dockPanel.ActiveAutoHideContent = null;
            this.dockPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dockPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DockLeftPortion = 0.15D;
            this.dockPanel.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dockPanel.Location = new System.Drawing.Point(0, 64);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(739, 450);
            this.dockPanel.TabIndex = 8;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 536);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.TabText = "苏州康力骨科器械有限公司一卡通管理系统服务端";
            this.Text = "苏州康力骨科器械有限公司一卡通管理系统服务端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭所有窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 除此之外全部关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
        public System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripUpLoad;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripDate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripComputerName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusloginName;
        public WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ToolStripButton toolStripACGroup;
        private System.Windows.Forms.ToolStripButton toolStripACTimeZones;
        private System.Windows.Forms.ToolStripButton toolStripACUnlockComb;
        private System.Windows.Forms.ToolStripButton toolStripUserACPrivilege;
        private System.Windows.Forms.ToolStripButton toolStripacholiday;
        private System.Windows.Forms.ToolStripButton toolStripExit;
        private System.Windows.Forms.ToolStripMenuItem 数据库连接ToolStripMenuItem;
        public System.Windows.Forms.ToolStripButton toolStripRefreshServer;
        public System.Windows.Forms.ToolStripButton toolStripReStartServer;
        private System.Windows.Forms.ToolStripButton toolStripStatusSet;
        private System.Windows.Forms.ToolStripButton toolStripMachineShowSet;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
    }
}