namespace P2P.WellKnown.C2S
{
    using System;
    /// <summary>
    /// 用户登出消息
    /// </summary>
    [Serializable]
    public class LogoutMessage : CSMessage
    {
        public LogoutMessage(string userName) : base(userName)
        {
        }
    }
}

