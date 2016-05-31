using P2P.WellKnown.S2C;
using System;

namespace P2P.WellKnown.C2S
{
    public delegate void LoginEventHandler(object sender, LoginEventArgs e);
    public class LoginEventArgs : EventArgs
    {
        private UserCollection userlist;
        public LoginEventArgs(UserCollection userlist)
        {
            this.userlist = userlist;
        }

        public UserCollection UserList
        {
            get { return userlist; }
        }
    }

    public delegate void FriendLoginEventHandler(object sender, FriendLoginEventArgs e);
    public class FriendLoginEventArgs : EventArgs
    {
        private User user;
        public FriendLoginEventArgs(User user)
        {
            this.user = user;
        }

        public User User
        {
            get { return user; }
        }
    }
}
