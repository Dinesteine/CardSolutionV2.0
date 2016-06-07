﻿using CardSolutionHost.Interfaces;
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
using CardSolutionHost.BLL;

namespace CardSolutionHost
{
    public class MenJinRunner : IMenJinRunner
    {
        public AppContainer Host { get; private set; }

        public string IP { get; private set; }

        public int Port { get; private set; }

        public int MachineNumber { get; private set; }

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
        public MenJinRunner(AppContainer Host, int MachineNumber, string IP, int Port, string RunnerName)
        {
            this.MachineNumber = MachineNumber;
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
                    try
                    {
                        apiform = new APIForm(manualresetevent);
                        apiform.OnHIDNum += Apiform_OnHIDNum;
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
                    }
                    catch (Exception ex)
                    {
                        RunnerState = RunnerState.Failed;
                        manualresetevent.Set();
                        Logger.Writer.Write(ex);
                    }
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
        private void Apiform_OnHIDNum(int CardNumber)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    //Logger.Writer.Write(CardNumber.ToString());
                    string strCardNo = CardNumber.ToString();
                    if (CardNumber < 0)
                    {
                        string str = CardNumber.ToString("x8").PadLeft(8);
                        strCardNo = long.Parse(str, System.Globalization.NumberStyles.HexNumber).ToString();
                    }
                    if (strCardNo.Length < 3) return;
                    short errorFlag = new MenJinService().GetOpenResult(strCardNo, this.IP);
                    if (errorFlag == 1)
                    {
                        apiform.PlayVoiceByIndex(10);
                    }
                    else if (errorFlag == 2)
                    {
                        apiform.PlayVoiceByIndex(10);
                        apiform.ACUnlock(MachineNumber, 200);
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

        public void Stop()
        {
            this.IP = null;
            this.Port = 0;
            this.MachineNumber = 0;
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
