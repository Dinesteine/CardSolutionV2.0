using CardSolutionHost.BLL;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using zkemkeeper;

namespace CardSolutionHost
{
    public partial class APIForm : Form
    {
        ManualResetEvent manualresetevent;
        public CZKEMClass API { get; set; }
        public APIForm(ManualResetEvent manualresetevent)
        {
            InitializeComponent();
            this.manualresetevent = manualresetevent;
            API = new CZKEMClass();
            API.OnHIDNum += API_OnHIDNum;
            this.FormClosed += APIForm_FormClosed;
        }

        private void APIForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                API.OnHIDNum -= API_OnHIDNum;
                API.Disconnect();
                API = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                Logger.Writer.Write(ex);
            }
        }

        public event HIDNum OnHIDNum;
        public delegate void HIDNum(int CardNumber);
        private void APIForm_Shown(object sender, EventArgs e)
        {
            this.Visible = false;
            this.manualresetevent.Set();
        }
        private string IP;
        internal bool Connect_Net(string Ip, int Port)
        {
            this.IP = Ip;
            return API.Connect_Net(Ip, Port);
        }

        internal bool RegEvent(int dwMachineNumber, int EventMask)
        {
            return API.RegEvent(dwMachineNumber, EventMask);
        }
        internal bool PlayVoiceByIndex(int Index)
        {
            return API.PlayVoiceByIndex(Index);
        }
        internal bool ACUnlock(int dwMachineNumber, int Delay)
        {
            return API.ACUnlock(dwMachineNumber, Delay);
        }
        private void API_OnHIDNum(int CardNumber)
        {
            OnHIDNum?.Invoke(CardNumber);
        }
    }
}
