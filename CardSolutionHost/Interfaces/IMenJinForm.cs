using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zkemkeeper;

namespace CardSolutionHost.Interfaces
{
    public interface IRunner
    {
        string RunnerName { get; set; }
        string IP { get; }
        int Port { get; }
        Control.AppContainer Host { get; }
        void Run();
    }
    public interface IMenJinControler
    {
        List<IRunner> Runners { get; }
    }
    public interface IMainform
    {

    }
    public enum RunnerState
    {
        Init,
        Connecting,
        Success,
        Failed
    }
}
