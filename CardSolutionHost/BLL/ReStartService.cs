using CardSolutionHost.Core;
using CardSolutionHost.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CardSolutionHost.BLL
{
    public class ReStartService : IReStartService
    {
        object lockobj = new object();

        public void Start()
        {
            Thread thread = new Thread(Run);
            thread.IsBackground = true;
            thread.Start();
        }

        public void Stop()
        {
            statecode = -1;
            while (statecode != 0)
            {
                break;
            }
        }
        volatile int statecode = 0;
        volatile bool HasHandle = false;
        private void Run()
        {
            statecode = 1;
            while (statecode == 1)
            {
                if (statecode == -1)
                {
                    statecode = 0;
                    break;
                }
                bool handle = false;
                lock (lockobj)
                {
                    if (HasHandle) continue;
                    if (SystemConfig.MenJinReStartTime == DateTime.Now.ToString("HH:mm"))
                    {
                        handle = true;
                        HasHandle = true;
                    }
                }
                if (handle)
                {
                    Application.Restart();
                }
            }
        }
    }
}
