namespace P2P.WellKnown.C2S
{
    using System;
    /// <summary>
    /// 用户登录消息
    /// </summary>
    [Serializable]
    public class LoginMessage : CSMessage
    {
        private string password;

        public LoginMessage(string userName, string password) : base(userName)
        {
            this.password = password;
        }

        public string Password
        {
            get
            {
                return this.password;
            }
        }
    }
}

