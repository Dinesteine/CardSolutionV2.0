using CardSolutionHost.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardSolutionHost.Control;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace CardSolutionHost
{
    public class Runner : IMenJinRunner
    {
        public AppContainer Host { get; private set; }

        public string IP { get; private set; }

        public int Port { get; private set; }

        public string RunnerName { get; set; }

        public RunnerState RunnerState { get; private set; }
        APIForm apiform;

        public void Run(ref bool CanPing)
        {
            try
            {
                if (apiform != null)
                {
                    apiform.Close();
                    apiform.Dispose();
                    apiform = null;
                }
                var pingreply = new Ping().Send(IP);
                if (pingreply.Status == IPStatus.Success)
                    CanPing = true;
                else
                {
                    CanPing = false;
                    RunnerState = RunnerState.Failed;
                    return;
                }
                ManualResetEvent manualresetevent = new ManualResetEvent(false);
                Thread thread = new Thread(new ThreadStart(() =>
                {
                    apiform = new APIForm(manualresetevent);
                    if (apiform.Connect_Net(IP, Port))
                    {
                        if (apiform.RegEvent(1, 65535))
                        {
                            RunnerState = RunnerState.Success;
                        }
                        else
                        {
                            RunnerState = RunnerState.Failed;
                            manualresetevent.Set();
                            return;
                        }
                    }
                    else
                    {
                        RunnerState = RunnerState.Failed;
                        manualresetevent.Set();
                        return;
                    }
                    Application.Run(apiform);
                }));
                thread.IsBackground = true;
                thread.Start();
                manualresetevent.Reset();
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                RunnerState = RunnerState.Failed;
                Logger.Writer.Write(ex);
            }
        }
        public Runner(AppContainer Host, string IP, int Port)
        {
            this.Host = Host;
            this.IP = IP;
            this.Port = Port;
        }
    }
}
