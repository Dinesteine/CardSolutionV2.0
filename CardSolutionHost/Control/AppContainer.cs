using CardSolutionHost.Entitys;
using CardSolutionHost.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using zkemkeeper;

namespace CardSolutionHost.Control
{
    public partial class AppContainer : UserControl
    {
        public IRunner Runner { get; set; }
        public AppContainer()
        {
            InitializeComponent();
        }
        private void AppContainer_Load(object sender, EventArgs e)
        {
        }
    }
    public class Runner : IRunner
    {
        CZKEMClass API { get; set; }
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
            set
            {
                this.SetText(value);
                _RunnerName = value;
            }
        }
        RunnerState _RunnerState;
        public RunnerState RunnerState
        {
            get
            {
                return _RunnerState;
            }
            set
            {
                this.SetImage(value);
                _RunnerState = value;
            }
        }
        public Runner(AppContainer Host, string IP, int Port)
        {
            this.Host = Host;
            this.IP = IP;
            this.Port = Port;
            API = new CZKEMClass();
            API.OnHIDNum += API_OnHIDNum;
        }

        public void Run()
        {
            try
            {
                this.RunnerState = RunnerState.Connecting;
                API.Disconnect();
                bool result = API.Connect_Net(IP, Port);
                if (result)
                {
                    if (API.RegEvent(1, 65535))
                        result = true;
                    else
                        result = false;
                }
                if (result)
                {
                    RunnerState = RunnerState.Success;
                    //Application.Run();
                }
                else
                {
                    API.Disconnect();
                    RunnerState = RunnerState.Failed;
                }
                this.RunnerState = RunnerState.Success;
            }
            catch (Exception ex)
            {
                API.Disconnect();
                this.RunnerState = RunnerState.Failed;
                Logger.Writer.Write(ex);
            }
        }
        #region 界面操作
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
        private void API_OnHIDNum(int CardNumber)
        {
            Logger.Writer.Write(string.Format("{0} 刷卡", CardNumber));
        }
    }
}
