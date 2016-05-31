
using System;
using System.Collections;
using System.Reflection;
using P2P.WellKnown.C2S;
namespace P2P.WellKnown
{
    [Serializable]
    public class NewsCollection : CollectionBase
    {
        public void Add(NewsMessage msg)
        {
            base.InnerList.Add(msg);
        }

        public NewsMessage Find(string Id)
        {
            foreach (NewsMessage message in this)
            {
                if (string.Compare(Id, message.Id, true) == 0)
                {
                    return message;
                }
            }
            return null;
        }

        public void Remove(NewsMessage msg)
        {
            base.InnerList.Remove(msg);
        }

        public NewsMessage this[int index]
        {
            get
            {
                return (NewsMessage)base.InnerList[index];
            }
        }
    }
}

