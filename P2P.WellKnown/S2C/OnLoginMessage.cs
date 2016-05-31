using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P2P.WellKnown.S2C
{
    /// <summary>
    /// 用户登录消息
    /// </summary>
    [Serializable]
    public class OnLoginMessage : SCMessage
    {
        private UserCollection userList;
        public OnLoginMessage(UserCollection users)
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
    /// <summary>
    /// 好友登录消息
    /// </summary>
    [Serializable]
    public class OnFriendLoginMessage : SCMessage
    {
        private User user;
        public OnFriendLoginMessage(User user)
        {
            this.user = user;
        }
        public User User
        {
            get
            {
                return this.user;
            }
        }
    }
}
