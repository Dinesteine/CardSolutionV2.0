namespace P2P.WellKnown.S2C
{
    using System;
    using System.Net;
    /// <summary>
    /// 转发请求Purch Hole消息
    /// </summary>
    [Serializable]
    public class SomeOneCallYouMessage : SCMessage
    {
        protected IPEndPoint remotePoint;

        public SomeOneCallYouMessage(IPEndPoint point)
        {
            this.remotePoint = point;
        }

        public IPEndPoint RemotePoint
        {
            get
            {
                return this.remotePoint;
            }
        }
    }
}

