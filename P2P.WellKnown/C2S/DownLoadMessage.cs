using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P2P.WellKnown.C2S
{
    [Serializable]
    public class DownLoadMessage : MessageBase
    {
        public DownLoadMessage(string UserName, string FileName, int Port)
        {
            this.UserName = UserName;
            this.FileName = FileName;
            this.Port = Port;
        }

        public int Port { get; set; }

        public string UserName { get; set; }

        public string FileName { get; set; }
    }
}
