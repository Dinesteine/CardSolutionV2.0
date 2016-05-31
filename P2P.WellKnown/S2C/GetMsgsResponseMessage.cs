using P2P.WellKnown;
using System;
using System.Runtime.CompilerServices;
namespace P2P.WellKnown.S2C
{
    [Serializable]
    public class GetMsgsResponseMessage : SCMessage
    {
        public GetMsgsResponseMessage(NewsCollection msgList)
        {
            this.MsgList = msgList;
        }

        public NewsCollection MsgList { get; set; }
    }
}

