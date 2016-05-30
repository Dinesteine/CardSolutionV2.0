using Model_Service.MenJin;
using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using zkemkeeper;

namespace CardSolutionHost.Control
{
    public partial class AppContainer : UserControl
    {
        BLL_Service.MenJin.MachinesBLL bll;
        public enum 图片状态
        {
            初始化,
            连接中,
            成功,
            失败
        }
        public AppContainer()
        {
            InitializeComponent();
        }
        #region 界面操作
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
        public void SetImage(图片状态 _status)
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
                    case 图片状态.初始化:
                        this.pictureBox1.Image = this.picInit.Image;
                        break;
                    case 图片状态.连接中:
                        this.pictureBox1.Image = this.picConnecting.Image;
                        break;
                    case 图片状态.成功:
                        this.pictureBox1.Image = this.picSuccess.Image;
                        break;
                    case 图片状态.失败:
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
        #endregion
        Machine _machine;
        CZKEMClass _api = null;
        //APIForm apiForm = null;
        public void ReloadMachine(Machine machine, ref int count)
        {
            if (count > 2) return;
            if (machine == null) { this.SetVisible(false); return; }
            _machine = machine;
            var threadreload = new Thread(new ParameterizedThreadStart((obj) =>
             {
                 this.SetImage(Control.AppContainer.图片状态.连接中);
                 CZKEMClass api = new CZKEMClass();
                 try
                 {
                     //this.Invoke(new Action(() =>
                     //{
                     //    if (apiForm != null)
                     //    {
                     //        apiForm.Close();
                     //        apiForm.Dispose();
                     //    }
                     //    apiForm = null;
                     //    apiForm = new APIForm();
                     //}));
                     if (_api != null)
                     {
                         _api.OnHIDNum -= CZKEMClass_OnHIDNum;
                         _api.Disconnect();
                     }
                     this.SetVisible(true);
                     this.SetText(machine.MachineAlias);
                     api.OnHIDNum -= CZKEMClass_OnHIDNum;
                     api.Disconnect();
                     bool result = api.Connect_Net(machine.IP, machine.Port);
                     if (result)
                     {
                         if (api.RegEvent(1, 65535))
                             result = true;
                         else
                             result = false;
                     }
                     if (result)
                     {
                         api.OnHIDNum -= CZKEMClass_OnHIDNum;
                         api.OnHIDNum += CZKEMClass_OnHIDNum;
                         this.SetImage(图片状态.成功);
                         _api = api;
                         Application.Run();
                     }
                     else
                     {
                         api.OnHIDNum -= CZKEMClass_OnHIDNum;
                         api.Disconnect();
                         this.SetImage(图片状态.失败);
                         int totalcount = (int)obj;
                         totalcount = totalcount + 1;
                         ReloadMachine(machine, ref totalcount);
                     }
                 }
                 catch (Exception ex)
                 {
                     try
                     {
                         if (Program.isDebug)
                             Program.log.Error(ex);
                         api.OnHIDNum -= CZKEMClass_OnHIDNum;
                         api.Disconnect();
                         this.SetImage(图片状态.失败);
                         int totalcount = (int)obj;
                         totalcount = totalcount + 1;
                         ReloadMachine(machine, ref totalcount);
                     }
                     catch (Exception exx)
                     {
                         if (Program.isDebug)
                             Program.log.Error(exx);
                     }
                     this.SetImage(图片状态.失败);
                 }
             }));
            threadreload.IsBackground = true;
            threadreload.Start(count);
        }
        public void RefreshMachine()
        {
            var threadrefresh = new Thread(new ThreadStart(() =>
             {
                 this.SetImage(Control.AppContainer.图片状态.连接中);
                 try
                 {
                     if (_machine == null) { this.SetVisible(false); return; }
                     if (_api == null) { this.SetImage(Control.AppContainer.图片状态.失败); return; }
                     this.SetVisible(true);
                     this.SetText(_machine.MachineAlias);
                     var replay = new Ping().Send(_machine.IP);
                     if (replay.Status == IPStatus.Success)
                     {
                         int num1 = 1;
                         bool result = _api.GetDeviceStatus(1, 1, num1);
                         if (result)
                         {
                             this.SetImage(图片状态.成功);
                         }
                         else
                         {
                             int count = 0;
                             ReloadMachine(_machine, ref count);
                         }
                     }
                     else
                     {
                         this.SetImage(图片状态.失败);
                     }
                 }
                 catch (Exception ex)
                 {
                     try
                     {
                         if (Program.isDebug)
                             Program.log.Error(ex);
                         _api.OnHIDNum -= CZKEMClass_OnHIDNum;
                         _api.Disconnect();
                     }
                     catch (Exception exx)
                     {
                         if (Program.isDebug)
                             Program.log.Error(exx);
                     }
                     this.SetImage(图片状态.失败);
                 }
             }));
            threadrefresh.IsBackground = true;
            threadrefresh.Start();
        }
        public void Stop()
        {
            try
            {
                //this.Invoke(new Action(() =>
                //{
                //    if (apiForm != null)
                //    {
                //        apiForm.Close();
                //        apiForm.Dispose();
                //    }
                //}));
                if (_api != null)
                {
                    _api.OnHIDNum -= CZKEMClass_OnHIDNum;
                    _api.Disconnect();
                }
                _api = null;
                _machine = null;
                this.SetVisible(false);
            }
            catch (Exception ex)
            {
                if (Program.isDebug)
                    Program.log.Error(ex);
            }
        }
        private void CZKEMClass_OnHIDNum(int CardNumber)
        {
            try
            {
                if (_api == null) return;
                string strCardNo = CardNumber.ToString();
                if (CardNumber < 0)
                {
                    string str = CardNumber.ToString("x8").PadLeft(8);
                    strCardNo = long.Parse(str, System.Globalization.NumberStyles.HexNumber).ToString();
                }
                short errorFlag = bll.GetOpenResult(strCardNo, _machine.IP);
                if (errorFlag == 1)
                {
                    _api.PlayVoiceByIndex(10);
                }
                else if (errorFlag == 2)
                {
                    _api.PlayVoiceByIndex(10);
                    _api.ACUnlock(_machine.MachineNumber, 200);
                    //if (Program.isDebug)
                    //    Program.log.Info(strCardNo);
                }
            }
            catch (Exception ex)
            {
                if (Program.isDebug)
                    Program.log.Error(ex);
            }
        }

        private void AppContainer_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                bll = new BLL_Service.MenJin.MachinesBLL();
        }
    }
}
