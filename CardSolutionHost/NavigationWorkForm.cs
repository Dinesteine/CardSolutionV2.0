using Model_Service.MenJin;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using zkemkeeper;
using System.Windows.Forms;

namespace CardSolutionHost
{
    public partial class NavigationWorkForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        #region 字段
        BLL_Service.MenJin.MachinesBLL bll = new BLL_Service.MenJin.MachinesBLL();
        string ctlName = "appContainer";
        Thread threadReStart;
        #endregion
        #region 构造函数
        public NavigationWorkForm()
        {
            InitializeComponent();
        }
        #endregion
        void 定时刷新()
        {
            int i = 1;
            while (true)
            {
                try
                {
                    if (i % 5 == 0)
                        ReloadMachine();
                    else
                        RefreshMachine();
                    Thread.Sleep(Program.CheckTimes);
                    i++;
                }
                catch (Exception ex)
                {
                    if (Program.isDebug)
                        Program.log.Error(ex.Message);
                }
            }
        }

        internal void ReloadMachine()
        {
            try
            {
                var result = bll.GetList(" and Enabled = 1 ").OrderBy(t => t.MachineNumber).ToList();
                for (int i = 0; i < 35; i++)
                {
                    string key = string.Format("{0}{1}", ctlName, (i + 1));
                    var ctl = this.Controls[key] as Control.AppContainer;
                    if (i >= result.Count)
                        ctl.Stop();
                    else
                    {
                        int count = 0;
                        ctl.ReloadMachine(result[i], ref count);
                    }
                }
            }
            catch (Exception ex)
            {
                if (Program.isDebug)
                    Program.log.Error(ex.Message);
            }
        }
        internal void RefreshMachine()
        {
            for (int i = 0; i < 35; i++)
            {
                string key = string.Format("{0}{1}", ctlName, (i + 1));
                var ctl = this.Controls[key] as Control.AppContainer;
                ctl.RefreshMachine();
            }
        }

        #region 事件
        private void NavigationWorkForm_Load(object sender, EventArgs e)
        {
            Thread startThead = new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(1000 * 15);
                for (int i = 0; i < 3; i++)
                {
                    if (InternalReloadMachine())
                        break;
                    Thread.Sleep(10 * 1000);
                }
                threadReStart = new Thread(new ThreadStart(定时刷新));
                threadReStart.IsBackground = true;
                threadReStart.Start();
            }));
            startThead.IsBackground = true;
            startThead.Start();
        }

        internal bool InternalReloadMachine()
        {
            bool loaddata = false;
            System.Collections.Generic.IList<Model_Service.MenJin.Machine> result = null;
            try
            {
                result = bll.GetList(" and Enabled = 1 ").OrderBy(t => t.MachineNumber).ToList();
                loaddata = true;
            }
            catch (Exception)
            {
                loaddata = false;
            }

            if (loaddata)
            {
                try
                {
                    for (int i = 0; i < 35; i++)
                    {
                        string key = string.Format("{0}{1}", ctlName, (i + 1));
                        var ctl = this.Controls[key] as Control.AppContainer;
                        if (i >= result.Count)
                            ctl.Stop();
                        else
                        {
                            int count = 0;
                            ctl.ReloadMachine(result[i], ref count);
                        }
                    }
                }
                catch (Exception)
                {
                    loaddata = false;
                }
            }
            return loaddata;
        }
        #endregion

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control.AppContainer appContainer = ((ContextMenuStrip)((ToolStripMenuItem)sender).GetCurrentParent()).SourceControl as Control.AppContainer;
            appContainer.RefreshMachine();
        }
    }
}
