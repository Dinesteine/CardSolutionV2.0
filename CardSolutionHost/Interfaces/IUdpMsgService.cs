using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardSolutionHost.Interfaces
{
    public interface IUdpMsgService
    {
        void Start();
        void Stop();
        void SendToEveryBody();
    }
}
