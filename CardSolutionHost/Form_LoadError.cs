using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CardSolutionHost
{
    public partial class Form_LoadError : Form
    {
        const string infoText = "系统启动失败，{0}秒之后重新启动";
        volatile int sec = 8;
        public Form_LoadError()
        {
            InitializeComponent();
            this.label1.Text = string.Format(infoText, sec);
        }

        private void Form_LoadError_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(Run);
            thread.IsBackground = true;
            thread.Start();
        }
        bool isCancel = false;
        private void Run()
        {
            while (!isCancel)
            {
                Thread.Sleep(1000);
                int tempsec = Interlocked.Decrement(ref sec);
                SetText(tempsec);
                if (tempsec == 0)
                    Application.Restart();
            }
        }
        void SetText(int tempsec)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.SetText(tempsec);
                }));
            }
            else
            {
                this.label1.Text = string.Format(infoText, tempsec);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            isCancel = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
