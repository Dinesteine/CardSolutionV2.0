using CardSolutionHost.Core;
using CardSolutionHost.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CardSolutionHost.BLL
{
    public class UdpMsgTimerService : IUdpMsgTimerService
    {
        const int times = 1000 * 60 * 15;
        private Timer timer;
        AutoResetEvent initautoEvent;
        volatile bool opstate = false;
        object lockobj = new object();
        public void Start()
        {
            lock (lockobj)
            {
                if (opstate) return;
                initautoEvent = new AutoResetEvent(false);
                opstate = true;
            }
            timer = new Timer(new TimerCallback(timerCall), initautoEvent, 0, 0);
        }

        private void timerCall(object state)
        {
            timer.Dispose();
            timer = null;
            AutoResetEvent autoEvent = (AutoResetEvent)state;
            Thread thread = new Thread(new ThreadStart(() =>
            {
                var udpmsgservice = ServiceLoader.LoadService<IUdpMsgService>();
                udpmsgservice.SendToEveryBody();
                Thread.Sleep(times);
                autoEvent.Set();
            }));
            thread.IsBackground = true;
            thread.Start();
            autoEvent.WaitOne();
            if (opstate)
                timer = new System.Threading.Timer(new TimerCallback(timerCall), autoEvent, 0, 0);
        }

        public void Stop()
        {
            lock (lockobj)
            {
                if (!opstate) return;
                if (initautoEvent != null)
                    initautoEvent.Set();
                opstate = false;
            }
        }
    }
}
