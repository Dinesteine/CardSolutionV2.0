using P2P.WellKnown;
using System;
using System.Runtime.CompilerServices;
namespace P2P.WellKnown.C2S
{
    [Serializable]
    public class NewsMessage : MessageBase
    {
        public NewsMessage(string Id, string Theme)
        {
            this.Id = Id;
            this.Theme = Theme;
        }

        public string Id { get; set; }

        public string Theme { get; set; }
    }
}

