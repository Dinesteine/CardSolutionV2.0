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
        public List<IMenJinRunner> Runners { get; private set; }
        object lockobj = new object();
        string ctlName = "appContainer";
        volatile int opCode = 0;
        public int OPCode
        {
            get
            {
                return opCode;
            }
            set
            {
                lock (lockobj)
                {
                    try
                    {
                        if (value == 0)
                        {
                            ServiceLoader.LoadService<IMenJinHost>().CanRefresh = true;
                            ServiceLoader.LoadService<IMenJinHost>().CanReStart = true;
                        }
                        else
                        {
                            ServiceLoader.LoadService<IMenJinHost>().CanRefresh = false;
                            ServiceLoader.LoadService<IMenJinHost>().CanReStart = false;
                        }
                        if (value < 0)
                            opCode = 0;
                    }
                    catch (Exception ex)
                    {
                        Logger.Writer.Write(ex);
                    }
                    opCode = value;
                }
            }
        }
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
                    RunRefreshMachine();
                    while (opCode != 0)
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
                    if (opCode != 0) return;
                    for (int i = 0; i < 35; i++)
                    {
                        string key = string.Format("{0}{1}", ctlName, (i + 1));
                        var ctl = this.Controls[key] as Control.AppContainer;
                        if (ctl.Runner != null)
                            this.opCode++;
                    }
                    this.OPCode = this.opCode;
                }
                catch (Exception ex)
                {
                    this.opCode = 0;
                    Logger.Writer.Write(ex);
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
                this.OPCode--;
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
                        if (opCode != 0) return;
                        machines = new MenJinService().GetEnableMachinesEntitys().OrderBy(t => t.MachineNumber).ToList();
                        this.OPCode = machines.Count;
                    }
                    catch (Exception ex)
                    {
                        opCode = 0;
                        Logger.Writer.Write(ex);
                    }
                }
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
                IMenJinRunner runner;
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
                this.OPCode--;
            }
        }

        private IMenJinRunner CreateRunner(MachinesEntity machine)
        {
            for (int i = 0; i < 35; i++)
            {
                string key = string.Format("{0}{1}", ctlName, (i + 1));
                var ctl = this.Controls[key] as Control.AppContainer;
                if (ctl.Runner == null)
                {
                    ctl.Runner = ServiceLoader.LoadService<IMenJinRunner>(
                        new ParameterOverride("Host", ctl),
                        new ParameterOverride("IP", machine.IP),
                        new ParameterOverride("Port", machine.Port)
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
