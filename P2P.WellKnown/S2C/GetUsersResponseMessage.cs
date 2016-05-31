namespace P2P.WellKnown.S2C
{
    using System;
    /// <summary>
    /// 请求用户列表应答消息
    /// </summary>
    [Serializable]
    public class GetUsersResponseMessage : SCMessage
    {
        private UserCollection userList;

        public GetUsersResponseMessage(UserCollection users)
        {
            this.userList = users;
        }

        public UserCollection UserList
        {
            get
            {
                return this.userList;
            }
        }
    }
}

