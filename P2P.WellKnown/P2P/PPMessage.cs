namespace P2P.WellKnown.P2P
{
    using System;
    /// <summary>
    /// 点对点消息基类
    /// </summary>
    [Serializable]
    public abstract class PPMessage : MessageBase
    {
        protected PPMessage()
        {
        }
    }
}

