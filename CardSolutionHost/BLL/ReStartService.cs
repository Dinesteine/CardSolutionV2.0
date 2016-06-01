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
            try
            {
                var entity = new ConfigService().GetConfigByConfigName("LastMenJinReStartTime");
                if (entity != null)
                {
                    if (entity.ConfigValue == DateTime.Now.ToString("yyyy-MM-dd HH:mm"))
                        HasHandle = true;
                }
            }
            catch (Exception)
            {
            }
            lock (lockobj)
            {
                if (statecode != 0) return;
                statecode = 1;
            }
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
                    if (SystemConfig.MenJinReStartTime == DateTime.Now.ToString("HH:mm"))
                    {
                        if (HasHandle) continue;
                        handle = true;
                        HasHandle = true;
                    }
                    else
                    {
                        HasHandle = false;
                    }
                }
                if (handle)
                {
                    var configservice = new ConfigService();
                    var entity = configservice.GetConfigByConfigName("LastMenJinReStartTime");
                    entity.ConfigValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    configservice.SaveEntity(entity);
                    Application.Restart();
                }
            }
        }
    }
}
