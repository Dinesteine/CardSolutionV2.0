﻿using CardSolutionHost.Core;
using CardSolutionHost.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CardSolutionHost
{
    public partial class MainForm : WeifenLuo.WinFormsUI.Docking.DockContent, IMainform
    {
        public MainForm()
        {
            InitializeComponent();
        }
        bool loaded = false;
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (loaded) return;
                NavigationWorkForm navigationForm = null;
                foreach (DockContent frm in this.dockPanel.Contents)
                {
                    if (frm is NavigationWorkForm)
                    {
                        frm.Activate();     //激活子窗体
                        return;
                    }
                }
                navigationForm = ServiceLoader.LoadService<IMenJinControler>() as NavigationWorkForm;
                navigationForm.ShowHint = DockState.Document;
                navigationForm.Show(dockPanel);
                loaded = true;
            }
            catch (Exception)
            {
                MessageBox.Show("程序发生了不可预知的错误需要退出");
                Environment.Exit(-1);
            }
        }
        private void toolStripUpLoad_Click(object sender, EventArgs e)
        {
            //CardSolutionHost.MenJin.MenJinLog frm = new CardSolutionHost.MenJin.MenJinLog();
            //frm.ShowDialog();
        }

        private void toolStripACTimeZones_Click(object sender, EventArgs e)
        {
            //MenJin.ACTimeZonesManage frm = new CardSolutionHost.MenJin.ACTimeZonesManage();
            //frm.ShowDialog();
        }

        private void toolStripACGroup_Click(object sender, EventArgs e)
        {
            //MenJin.ACGroupManage frm = new CardSolutionHost.MenJin.ACGroupManage();
            //frm.ShowDialog();
        }

        private void toolStripacholiday_Click(object sender, EventArgs e)
        {
            //MenJin.acholidayManage frm = new CardSolutionHost.MenJin.acholidayManage();
            //frm.ShowDialog();
        }

        private void toolStripACUnlockComb_Click(object sender, EventArgs e)
        {
            //MenJin.ACUnlockCombManage frm = new CardSolutionHost.MenJin.ACUnlockCombManage();
            //frm.ShowDialog();
        }

        private void toolStripUserACPrivilege_Click(object sender, EventArgs e)
        {
            //CardSolutionHost.MenJin.AttenPosition frm = new CardSolutionHost.MenJin.AttenPosition();
            //frm.ShowDialog();
        }

        private void toolStripExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出？", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            Application.Exit();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出？", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            Application.Exit();
        }

        private void 数据库连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseSet frmDataBaseSet = new DataBaseSet();
            frmDataBaseSet.StartPosition = FormStartPosition.CenterParent;
            frmDataBaseSet.ShowDialog();
        }

        public void toolStripRefreshServer_Click(object sender, EventArgs e)
        {
            try
            {
                //ServiceLoader.LoadService<IMenJinControler>().RefreshMachine();
            }
            catch (Exception ex)
            {
                Logger.Writer.Write(ex);
            }
        }

        public void toolStripStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                //ServiceLoader.LoadService<IMenJinControler>().ReloadMachine();
            }
            catch (Exception ex)
            {
                Logger.Writer.Write(ex);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("是否确认退出？", "", MessageBoxButtons.YesNo) == DialogResult.No)
            //    e.Cancel = true;
            //注意判断关闭事件Reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;    //取消"关闭窗口"事件
                this.WindowState = FormWindowState.Minimized;    //使关闭时窗口向右下角缩小的效果
                notifyIcon.Visible = true;
                //this.ShowInTaskbar = true;  //显示在系统任务栏
                this.Hide();
                return;
            }
        }

        private void toolStripStatusSet_Click(object sender, EventArgs e)
        {
            MenJinSet frmMenJinSet = new MenJinSet();
            var dia = frmMenJinSet.ShowDialog();
            try
            {
                if (dia == DialogResult.OK)
                {
                    //ServiceLoader.LoadService<IMenJinControler>().ReloadMachine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMachineShowSet_Click(object sender, EventArgs e)
        {
            MenJin.MachineManage frmMachineManage = new MenJin.MachineManage();
            var dia = frmMachineManage.ShowDialog();
            try
            {
                if (dia == DialogResult.OK)
                {
                    //ServiceLoader.LoadService<IMenJinControler>().ReloadMachine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.ShowInTaskbar = true;  //显示在系统任务栏
            this.WindowState = FormWindowState.Normal;  //还原窗体
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            //this.ShowInTaskbar = false;  //不显示在系统任务栏
            notifyIcon.Visible = true;  //托盘图标可见
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.ShowInTaskbar = true;  //显示在系统任务栏
            this.WindowState = FormWindowState.Normal;  //还原窗体
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出？", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            Application.Exit();
        }
    }
}
