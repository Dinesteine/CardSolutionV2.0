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
        public CZKEMClass API { get; set; }
        public APIForm()
        {
            InitializeComponent();
            API = new CZKEMClass();
            API.OnHIDNum += API_OnHIDNum;
        }
        private void APIForm_Load(object sender, EventArgs e)
        {
        }

        private void APIForm_Shown(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        internal bool Connect_Net(string Ip, int Port)
        {
            return API.Connect_Net(Ip, Port);
        }

        internal bool RegEvent(int dwMachineNumber, int EventMask)
        {
            return API.RegEvent(dwMachineNumber, EventMask);
        }
        volatile int lastCardNumber = 0;
        private void API_OnHIDNum(int CardNumber)
        {
            lock (this)
            {
                try
                {
                    if (lastCardNumber == CardNumber) return;
                    lastCardNumber = CardNumber;
                    Logger.Writer.Write(string.Format("{0} 刷卡", CardNumber));
                }
                catch (Exception ex)
                {
                    Logger.Writer.Write(ex);
                }
                finally
                {
                    lastCardNumber = 0;
                }
            }
        }
    }
}
