using P2P.WellKnown;
using System;
namespace P2P.WellKnown.C2S
{ 
    /// <summary>
    /// 客户端发送到服务器的消息基类
    /// </summary>
    [Serializable]
    public abstract class CSMessage : MessageBase
    {
        private string userName;

        protected CSMessage(string anUserName)
        {
            this.userName = anUserName;
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }
        }
    }
}

