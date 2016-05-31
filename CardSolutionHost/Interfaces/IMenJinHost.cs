using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zkemkeeper;

namespace CardSolutionHost.Interfaces
{

    public interface IMenJinHost
    {
        bool CanReStart { get; set; }
        bool CanRefresh { get; set; }
    }
}
