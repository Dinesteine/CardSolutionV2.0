using CardSolutionHost.BLL;
using CardSolutionHost.Entitys;
using CardSolutionHost.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Threading;
using System.Windows.Forms;
using zkemkeeper;

namespace CardSolutionHost.Control
{
    public partial class AppContainer : UserControl
    {
        AppDomain domain;
        MachinesEntity _Machine;
        CZKEMClass api;
        public MachinesEntity Machine
        {
            get { return _Machine; }
            set
            {
                if (_Machine == value) return;
                if (value == null)
                {
                    SetText(string.Empty);
                    SetVisible(false);
                }
                else
                {
                    SetText(value.MachineAlias);
                    SetVisible(true);
                }
                _Machine = value;
            }
        }
        public AppContainer()
        {
            InitializeComponent();
        }
        private void AppContainer_Load(object sender, EventArgs e)
        {
        }
        public void RunStartMachine(ref bool CanPing)
        {
            try
            {
                if (Machine == null)
                    return;
                RunnerState = RunnerState.Connecting;
                var pingreply = new Ping().Send(Machine.IP, 2000);
                if (pingreply.Status == IPStatus.Success)
                    CanPing = true;
                else
                {
                    CanPing = false;
                    RunnerState = RunnerState.Failed;
                    return;
                }
                ManualResetEvent manualresetevent = new ManualResetEvent(false);
                Thread thread = new Thread((_manualresetevent) =>
                {
                    try
                    {
                        domain = AppDomain.CreateDomain(string.Format("CardSolution{0}", Machine.IP), AppDomain.CurrentDomain.Evidence, AppDomain.CurrentDomain.BaseDirectory, AppDomain.CurrentDomain.RelativeSearchPath, false);
                        try
                        {
                            ManualResetEvent tempmanualresetevent = (ManualResetEvent)_manualresetevent;
                            api = (CZKEMClass)domain.CreateInstanceAndUnwrap(typeof(CZKEMClass).Assembly.FullName,
                                     typeof(CZKEMClass).FullName);
                            api.OnHIDNum += Api_OnHIDNum;
                            if (api.Connect_Net(Machine.IP, Machine.Port))
                            {
                                if (api.RegEvent(1, 65535))
                                {
                                    RunnerState = RunnerState.Success;
                                    manualresetevent.Set();
                                    Application.Run();
                                }
                                else
                                {
                                    RunnerState = RunnerState.Failed;
                                    manualresetevent.Set();
                                }
                            }
                            else
                            {
                                RunnerState = RunnerState.Failed;
                                manualresetevent.Set();
                            }
                        }
                        catch (Exception ex)
                        {
                            RunnerState = RunnerState.Failed;
                            manualresetevent.Set();
                            throw ex;
                        }
                        finally
                        {
                            AppDomain.Unload(domain);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Writer.Write(ex);
                    }
                });
                thread.IsBackground = true;
                thread.Start(manualresetevent);
                manualresetevent.WaitOne();
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Logger.Writer.Write(ex);
            }
        }
        public void RunRefreshMachine(ref bool CanPing)
        {
            try
            {
                if (Machine == null)
                    return;
                RunnerState = RunnerState.Connecting;
                var pingreply = new Ping().Send(Machine.IP, 2000);
                if (pingreply.Status == IPStatus.Success)
                    CanPing = true;
                else
                {
                    CanPing = false;
                    RunnerState = RunnerState.Failed;
                    return;
                }
                string ip = null;
                if (api.GetDeviceIP(Machine.MachineNumber, ref ip))
                {
                    RunnerState = RunnerState.Success;
                }
                else
                {
                    RunnerState = RunnerState.Failed;
                    AppDomain.Unload(domain);
                    RunStartMachine(ref CanPing);
                }

            }
            catch (Exception ex)
            {
                Logger.Writer.Write(ex);
            }
        }
        public void RunStopMachine()
        {
            try
            {
                if (domain != null)
                {
                    lock (this)
                    {
                        if (domain != null)
                            AppDomain.Unload(domain);
                        Machine = null;
                        RunnerState = RunnerState.Init;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Writer.Write(ex);
            }
        }

        private void Api_OnHIDNum(int CardNumber)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    string strCardNo = CardNumber.ToString();
                    if (CardNumber < 0)
                    {
                        string str = CardNumber.ToString("x8").PadLeft(8);
                        strCardNo = long.Parse(str, System.Globalization.NumberStyles.HexNumber).ToString();
                    }
                    if (strCardNo.Length < 3) return;
                    short errorFlag = new MenJinService().GetOpenResult(strCardNo, Machine.IP);
                    if (errorFlag == 1)
                    {
                        api.PlayVoiceByIndex(10);
                    }
                    else if (errorFlag == 2)
                    {
                        api.PlayVoiceByIndex(10);
                        api.ACUnlock(Machine.MachineNumber, 200);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Writer.Write(ex);
                }
            });
            thread.IsBackground = true;
            thread.Start();
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
        public void SetVisible(bool IsVisible)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    SetVisible(IsVisible);
                }));
            }
            else
            {
                this.Visible = IsVisible;
            }
        }
        public void SetImage(RunnerState _status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    SetImage(_status);
                }));
            }
            else
            {
                switch (_status)
                {
                    case RunnerState.Init:
                        this.pictureBox1.Image = this.picInit.Image;
                        break;
                    case RunnerState.Connecting:
                        this.pictureBox1.Image = this.picConnecting.Image;
                        break;
                    case RunnerState.Success:
                        this.pictureBox1.Image = this.picSuccess.Image;
                        break;
                    case RunnerState.Failed:
                        this.pictureBox1.Image = this.picFailure.Image;
                        break;
                }
            }
        }
        public void SetText(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    SetText(text);
                }));
            }
            else
            {
                this.label1.Text = text;
                this.label1.Left = this.pictureBox1.Left + (this.pictureBox1.Width / 2) - (this.label1.Width / 2);
            }
        }
    }
}
