namespace P2P.WellKnown.C2S
{
    using System;
    /// <summary>
    /// 请求用户列表消息
    /// </summary>
    [Serializable]
    public class GetUsersMessage : CSMessage
    {
        public GetUsersMessage(string userName) : base(userName)
        {
        }
    }
}

