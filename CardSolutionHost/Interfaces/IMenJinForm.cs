﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zkemkeeper;

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
    public interface IMenJinControler
    {
        void RunRefreshMachine();
        void RunReloadMachine();
        List<IMenJinRunner> Runners { get; }
    }
    public interface IMenJinHost
    {
        bool CanReStart { get; set; }
        bool CanRefresh { get; set; }
    }
    public enum RunnerState
    {
        Init,
        Connecting,
        Success,
        Failed
    }
}
