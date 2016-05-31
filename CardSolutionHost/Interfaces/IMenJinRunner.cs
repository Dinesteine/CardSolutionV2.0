using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardSolutionHost.Interfaces
{

    public interface IMenJinRunner
    {
        string RunnerName { get; }
        string IP { get; }
        int Port { get; }
        Control.AppContainer Host { get; }
        void Run(ref bool CanPing);
        RunnerState RunnerState { get; }
        void Stop();
    }
    public enum RunnerState
    {
        Init,
        Connecting,
        Success,
        Failed
    }
}
