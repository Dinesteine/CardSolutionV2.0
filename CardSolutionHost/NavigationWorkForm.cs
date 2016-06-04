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
 
namespace CardSolutionHost
{
    public partial class NavigationWorkForm : WeifenLuo.WinFormsUI.Docking.DockContent, IMenJinControler
    {
        public List<IMenJinRunner> Runners { get; private set; }
        object lockobj = new object();
        string ctlName = "appContainer";
        private volatile int _OPCode;

        public NavigationWorkForm()
        {
            InitializeComponent();
            Runners = new List<IMenJinRunner>();
        }

        bool loaded = false;
        private void NavigationWorkForm_Load(object sender, EventArgs e)
        {
            if (loaded) return;
            loaded = true;
            RunReloadMachine();
            Thread thread = new Thread(RunRefreshMachinePerMinutes);
            thread.IsBackground = true;
            thread.Start();
        }

        public void RunRefreshMachinePerMinutes()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(SystemConfig.MenJinRefreshMinutes * 60 * 1000);
                    //Thread.Sleep(20 * 1000);
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
                        var ctl = this.Controls[key] as Control.AppContainer;
                        if (ctl.Runner != null)
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
                if (ctl.Runner != null)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(RefreshMachine));
                    thread.IsBackground = true;
                    thread.Start(ctl.Runner);
                }
            }
        }
        public void RefreshMachine(object para)
        {
            try
            {
                IMenJinRunner runner = (IMenJinRunner)para;
                for (int i = 0; i < 3; i++)
                {
                    bool CanPing = false;
                    runner.Run(ref CanPing);
                    if (runner.RunnerState == RunnerState.Success)
                        break;
                    if (!CanPing)
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
                        Logger.Writer.Write(ex);
                    }
                }
                lock (lockobj)
                {
                    foreach (var runner in this.Runners)
                    {
                        runner.Stop();
                    }
                    this.Runners.Clear();
                }
                if (_OPCode <= 0)
                {
                    CanRun(true);
                    return;
                }
                for (int i = 0; i < 35; i++)
                {
                    string key = string.Format("{0}{1}", ctlName, (i + 1));
                    var ctl = this.Controls[key] as Control.AppContainer;
                    ctl.Runner = null;
                }

                Thread threadtemp = new Thread(new ThreadStart(() =>
                {
                    foreach (var machine in machines)
                    {
                        var autoEvent = new AutoResetEvent(false);
                        Thread thread = new Thread(new ParameterizedThreadStart(ReloadMachine));
                        thread.IsBackground = true;
                        thread.Start(new object[] { machine, autoEvent });
                        autoEvent.WaitOne();
                    }
                }));
                threadtemp.IsBackground = true;
                threadtemp.Start();
            }
            catch (Exception ex)
            {
                Logger.Writer.Write(ex);
                RunReloadMachine();
            }
        }
        private void ReloadMachine(object para)
        {
            try
            {
                object[] objs = para as object[];
                MachinesEntity machine = (MachinesEntity)objs[0];
                IMenJinRunner runner;
                try
                {
                    lock (lockobj)
                    {
                        runner = this.Runners.FirstOrDefault(t => t.IP == machine.IP);
                        if (runner == null)
                        {
                            runner = CreateRunner(machine);
                            this.Runners.Add(runner);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    AutoResetEvent autoEvent = (AutoResetEvent)objs[1];
                    if (autoEvent != null)
                        autoEvent.Set();
                }
                for (int i = 0; i < 3; i++)
                {
                    bool CanPing = false;
                    runner.Run(ref CanPing);
                    if (runner.RunnerState == RunnerState.Success)
                        break;
                    if (!CanPing)
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
        private IMenJinRunner CreateRunner(MachinesEntity machine)
        {
            if (!Regex.IsMatch(machine.IP, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$"))
                throw new Exception("IP地址格式错误");
            for (int i = 0; i < 35; i++)
            {
                string key = string.Format("{0}{1}", ctlName, (i + 1));
                var ctl = this.Controls[key] as Control.AppContainer;
                if (ctl.Runner == null)
                {
                    ctl.Runner = ServiceLoader.LoadService<IMenJinRunner>(
                        new ParameterOverride("Host", ctl),
                        new ParameterOverride("MachineNumber", machine.MachineNumber),
                        new ParameterOverride("IP", machine.IP),
                        new ParameterOverride("Port", machine.Port),
                        new ParameterOverride("RunnerName", machine.MachineAlias)
                        );
                    return ctl.Runner;
                }
            }
            throw new Exception("考勤机数量超出最大限制");
        }
    }
}
