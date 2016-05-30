using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using zkemkeeper;
using System.Windows.Forms;
using CardSolutionHost.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using CardSolutionHost.Core;
using CardSolutionHost.BLL;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using CardSolutionHost.Entitys;

namespace CardSolutionHost
{
    public partial class NavigationWorkForm : WeifenLuo.WinFormsUI.Docking.DockContent, IMenJinControler
    {
        public List<IRunner> Runners { get; private set; }
        object lockobj = new object();
        string ctlName = "appContainer";
        public NavigationWorkForm()
        {
            InitializeComponent();
            Runners = new List<IRunner>();
        }

        bool loaded = false;
        private void NavigationWorkForm_Load(object sender, EventArgs e)
        {
            if (loaded) return;
            loaded = true;
            RunReloadMachine();
        }

        //public void RunRefreshMachinePerMinutes()
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            RunRefreshMachine();
        //            Thread.Sleep(SystemConfig.MenJinRefreshMinutes * 60 * 1000);
        //        }
        //        catch (Exception ex)
        //        {
        //            Logger.Writer.Write(ex);
        //        }
        //    }
        //}
        #region 刷新
        //public void RunRefreshMachine()
        //{
        //    for (int i = 0; i < 35; i++)
        //    {
        //        var threadrefresh = new Thread(new ThreadStart(() =>
        //        {
        //            string key = string.Format("{0}{1}", ctlName, (i + 1));
        //            RefreshMachine(this.Controls[key] as Control.AppContainer);
        //        }));
        //        threadrefresh.IsBackground = true;
        //        threadrefresh.Start();
        //    }
        //}
        //public void RefreshMachine(IRunner Runner)
        //{
        //    Runner.RunnerState = RunnerState.Connecting;
        //    try
        //    {
        //        //if (_machine == null) { this.SetVisible(false); return; }
        //        //if (_api == null) { this.SetImage(Control.AppContainer.图片状态.失败); return; }
        //        //this.SetVisible(true);
        //        Runner.RunnerName = _machine.MachineAlias;
        //        this.SetText(_machine.MachineAlias);
        //        var replay = new Ping().Send(_machine.IP);
        //        if (replay.Status == IPStatus.Success)
        //        {
        //            int num1 = 1;
        //            bool result = _api.GetDeviceStatus(1, 1, num1);
        //            if (result)
        //            {
        //                this.SetImage(图片状态.成功);
        //            }
        //            else
        //            {
        //                int count = 0;
        //                ReloadMachine(_machine, ref count);
        //            }
        //        }
        //        else
        //        {
        //            this.SetImage(图片状态.失败);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        try
        //        {
        //            if (Program.isDebug)
        //                Program.log.Error(ex);
        //            _api.OnHIDNum -= CZKEMClass_OnHIDNum;
        //            _api.Disconnect();
        //        }
        //        catch (Exception exx)
        //        {
        //            if (Program.isDebug)
        //                Program.log.Error(exx);
        //        }
        //        this.SetImage(图片状态.失败);
        //    }
        //}
        #endregion
        #region 重启
        public void RunReloadMachine()
        {
            try
            {
                var machines = new MenJinService().GetEnableMachinesEntitys().OrderBy(t => t.MachineNumber).ToList();
                foreach (var machine in machines)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(ReloadMachine));
                    thread.IsBackground = true;
                    thread.Start(machine);
                }
            }
            catch (Exception)
            {
                //Logger.Writer.Write(ex);
                RunReloadMachine();
            }
        }

        private void ReloadMachine(object para)
        {
            try
            {
                MachinesEntity machine = (MachinesEntity)para;
                IRunner runner;
                lock (lockobj)
                {
                    runner = this.Runners.FirstOrDefault(t => t.IP == machine.IP);
                    if (runner == null)
                    {
                        runner = CreateRunner(machine);
                        if (runner == null)
                            throw new Exception("考勤机数量超出最大限制");
                        else
                            this.Runners.Add(runner);
                    }
                }
                runner.RunnerName = machine.MachineAlias;
                runner.Run();
            }
            catch (Exception ex)
            {
                Logger.Writer.Write(ex);
            }
        }

        private IRunner CreateRunner(MachinesEntity machine)
        {
            for (int i = 0; i < 35; i++)
            {
                string key = string.Format("{0}{1}", ctlName, (i + 1));
                var ctl = this.Controls[key] as Control.AppContainer;
                if (ctl.Runner == null)
                {
                    ctl.Runner = ServiceLoader.LoadService<IRunner>(
                        new ParameterOverride("Host", ctl),
                        new ParameterOverride("IP", machine.IP)
                        );
                    return ctl.Runner;
                }
            }
            return null;
        }
        #endregion

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Control.AppContainer appContainer = ((ContextMenuStrip)((ToolStripMenuItem)sender).GetCurrentParent()).SourceControl as Control.AppContainer;
            //appContainer.RefreshMachine();
        }
    }
}
