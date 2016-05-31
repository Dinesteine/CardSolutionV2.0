namespace P2P.WellKnown.S2C
{
    using System;     
    /// <summary>
    /// 服务器发送到客户端消息基类
    /// </summary>
    [Serializable]
    public abstract class SCMessage : MessageBase
    {
        protected SCMessage()
        {
        }
    }
}

