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
    public class MenJinRunner : IMenJinRunner
    {
        public AppContainer Host { get; private set; }

        public string IP { get; private set; }

        public int Port { get; private set; }

        private string _RunnerName;
        public string RunnerName
        {
            get
            {
                return _RunnerName;
            }
            private set
            {
                this.SetText(value);
                _RunnerName = value;
            }
        }

        private RunnerState _RunnerState;
        public RunnerState RunnerState
        {
            get
            {
                return _RunnerState;
            }
            private set
            {
                this.SetImage(value);
                _RunnerState = value;
            }
        }
        APIForm apiform;
        public MenJinRunner(AppContainer Host, string IP, int Port, string RunnerName)
        {
            this.Host = Host;
            this.IP = IP;
            this.Port = Port;
            this.RunnerName = RunnerName;
        }
        public void Run(ref bool CanPing)
        {
            try
            {
                RunnerState = RunnerState.Connecting;
                this.SetVisible(true);
                this.CloseAPI();
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
                manualresetevent.WaitOne();
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                RunnerState = RunnerState.Failed;
                Logger.Writer.Write(ex);
            }
        }
        public void Stop()
        {
            SetVisible(false);
            SetImage(RunnerState.Init);
            SetText(string.Empty);
            CloseAPI();
        }

        #region 界面操作


        public void CloseAPI()
        {
            if (apiform != null)
            {
                if (apiform.InvokeRequired)
                {
                    apiform.Invoke(new MethodInvoker(() =>
                    {
                        CloseAPI();
                    }));
                }
                else
                {
                    apiform.Close();
                    apiform.Dispose();
                    apiform = null;
                }
            }
        }
        public void SetVisible(bool IsVisible)
        {
            if (Host.InvokeRequired)
            {
                Host.Invoke(new MethodInvoker(() =>
                {
                    SetVisible(IsVisible);
                }));
            }
            else
            {
                Host.Visible = IsVisible;
            }
        }
        public void SetImage(RunnerState _status)
        {
            if (Host.InvokeRequired)
            {
                Host.Invoke(new MethodInvoker(() =>
                {
                    SetImage(_status);
                }));
            }
            else
            {
                switch (_status)
                {
                    case RunnerState.Init:
                        Host.pictureBox1.Image = Host.picInit.Image;
                        break;
                    case RunnerState.Connecting:
                        Host.pictureBox1.Image = Host.picConnecting.Image;
                        break;
                    case RunnerState.Success:
                        Host.pictureBox1.Image = Host.picSuccess.Image;
                        break;
                    case RunnerState.Failed:
                        Host.pictureBox1.Image = Host.picFailure.Image;
                        break;
                }
            }
        }
        public void SetText(string text)
        {
            if (Host.InvokeRequired)
            {
                Host.Invoke(new MethodInvoker(() =>
                {
                    SetText(text);
                }));
            }
            else
            {
                Host.label1.Text = text;
                Host.label1.Left = Host.pictureBox1.Left + (Host.pictureBox1.Width / 2) - (Host.label1.Width / 2);
            }
        }
        #endregion
    }
}
