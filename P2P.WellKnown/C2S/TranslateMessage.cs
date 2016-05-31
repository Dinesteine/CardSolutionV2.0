namespace P2P.WellKnown.C2S
{
    using System;
    /// <summary>
    /// 请求Purch Hole消息
    /// </summary>
    [Serializable]
    public class TranslateMessage : CSMessage
    {
        protected string toUserName;

        public TranslateMessage(string userName, string toUserName) : base(userName)
        {
            this.toUserName = toUserName;
        }

        public string ToUserName
        {
            get
            {
                return this.toUserName;
            }
        }
    }
}

