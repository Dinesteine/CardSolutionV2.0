using CardSolutionHost.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardSolutionHost.Control;

namespace CardSolutionHost
{
    public class Runner : IMenJinRunner
    {
        public AppContainer Host
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string IP
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Port
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string RunnerName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public RunnerState RunnerState
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Run(ref bool CanPing)
        {
            throw new NotImplementedException();
        }
    }
}
