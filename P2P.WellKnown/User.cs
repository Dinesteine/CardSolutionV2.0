namespace P2P.WellKnown
{
    using System;
    using System.Net;

    [Serializable]
    public class User
    {
        protected IPEndPoint netPoint;
        protected string userName;

        public User(string strUserName, IPEndPoint ipNetPoint)
        {
            this.userName = strUserName;
            this.netPoint = ipNetPoint;
        }

        public IPEndPoint NetPoint
        {
            get
            {
                return this.netPoint;
            }
            set
            {
                this.netPoint = value;
            }
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

