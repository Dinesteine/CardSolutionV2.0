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
using System.Text.RegularExpressions;
using CardSolutionHost.Control;

namespace CardSolutionHost
{
    public partial class NavigationWorkForm : WeifenLuo.WinFormsUI.Docking.DockContent, IMenJinControler
    {
        object lockobj = new object();
        string ctlName = "appContainer";
        private volatile int _OPCode;


        bool loaded = false;
        public NavigationWorkForm()
        {
            InitializeComponent();
            this.Shown += NavigationWorkForm_Shown;
        }
        private void NavigationWorkForm_Load(object sender, EventArgs e)
        {

        }

        private void NavigationWorkForm_Shown(object sender, EventArgs e)
        {
            if (loaded) return;
            loaded = true;
            Thread thread1 = new Thread(RunReloadMachine);
            thread1.IsBackground = true;
            thread1.Start();
            Thread thread = new Thread(RunRefreshMachinePerMinutes);
            thread.IsBackground = true;
            thread.Start();
        }

        public void RunRefreshMachinePerMinutes()
        {
            Thread.Sleep(5000);
            while (true)
            {
                try
                {
                    Thread.Sleep(SystemConfig.MenJinRefreshMinutes * 60 * 1000);
                    RunRefreshMachine();
                    while (_OPCode != 0)
                    {
                        Thread.Sleep(100);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Writer.Write(ex);
                }
            }
        }
        #region 刷新
        public void RunRefreshMachine()
        {
            lock (lockobj)
            {
                try
                {
                    if (_OPCode != 0) return;
                    CanRun(false);
                    for (int i = 0; i < 35; i++)
                    {
                        string key = string.Format("{0}{1}", ctlName, (i + 1));
                        var ctl = this.Controls[key] as AppContainer;
                        if (ctl.Machine != null)
                        {
                            Interlocked.Increment(ref this._OPCode);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Writer.Write(ex);
                    this._OPCode = 0;
                    CanRun(true);
                }
            }
            for (int i = 0; i < 35; i++)
            {
                string key = string.Format("{0}{1}", ctlName, (i + 1));
                var ctl = this.Controls[key] as Control.AppContainer;
                if (ctl.Machine != null)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(RefreshMachine));
                    thread.IsBackground = true;
                    thread.Start(ctl);
                }
            }
        }
        public void RefreshMachine(object para)
        {
            try
            {
                AppContainer ctl = (AppContainer)para;
                for (int i = 0; i < 3; i++)
                {
                    bool CanPing = false;
                    ctl.RunRefreshMachine(ref CanPing);
                    if (ctl.RunnerState == RunnerState.Success)
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Writer.Write(ex);
            }
            finally
            {
                int opcode = Interlocked.Decrement(ref this._OPCode);
                if (opcode == 0)
                {
                    CanRun(true);
                }
            }
        }
        #endregion
        #region 重启
        public void RunReloadMachine()
        {
            try
            {
                List<MachinesEntity> machines = null;
                if (_OPCode == 0)
                {
                    lock (lockobj)
                    {
                        try
                        {
                            if (_OPCode != 0) return;
                            CanRun(false);
                            machines = new MenJinService().GetEnableMachinesEntitys().OrderBy(t => t.MachineNumber).ToList();
                            this._OPCode = machines.Count;
                        }
                        catch (Exception ex)
                        {
                            this._OPCode = 0;
                            throw ex;
                        }
                        if (this._OPCode == 0)
                            return;
                    }
                }
                else
                    return;
                for (int i = 0; i < 35; i++)
                {
                    string key = string.Format("{0}{1}", ctlName, (i + 1));
                    var ctl = this.Controls[key] as AppContainer;
                    ctl.RunStopMachine();
                }
                int machinescount = machines.Count;
                for (int i = 0; i < 35; i++)
                {
                    string key = string.Format("{0}{1}", ctlName, (i + 1));
                    var ctl = this.Controls[key] as AppContainer;
                    if (i <= (machinescount - 1))
                    {
                        ctl.Machine = machines[i];
                        Thread thread = new Thread(new ParameterizedThreadStart(StartMachine));
                        thread.IsBackground = true;
                        thread.Start(ctl);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Writer.Write(ex);
                RunReloadMachine();
            }
        }
        private void StartMachine(object para)
        {
            try
            {
                AppContainer ctl = (AppContainer)para;
                for (int i = 0; i < 3; i++)
                {
                    bool CanPing = false;
                    ctl.RunStartMachine(ref CanPing);
                    if (ctl.RunnerState == RunnerState.Success)
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Writer.Write(ex);
            }
            finally
            {
                int opcode = Interlocked.Decrement(ref this._OPCode);
                if (opcode == 0)
                {
                    CanRun(true);
                }
            }
        }
        #endregion
        public void CanRun(bool canRun)
        {
            ServiceLoader.LoadService<IMenJinHost>().CanRefresh = canRun;
            ServiceLoader.LoadService<IMenJinHost>().CanReStart = canRun;
        }
    }
}
