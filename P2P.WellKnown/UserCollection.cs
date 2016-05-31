namespace P2P.WellKnown
{
    using System;
    using System.Collections;
    using System.Reflection;

    [Serializable]
    public class UserCollection : CollectionBase
    {
        public void Add(User user)
        {
            base.InnerList.Add(user);
        }

        public User Find(string userName)
        {
            foreach (User user in this)
            {
                if (string.Compare(userName, user.UserName, true) == 0)
                {
                    return user;
                }
            }
            return null;
        }
        public User Find(string userName, string ip)
        {
            foreach (User user in this)
            {
                if (string.Compare(userName, user.UserName, true) == 0)
                {
                    return user;
                }
            }
            return null;
        }

        public void Remove(User user)
        {
            base.InnerList.Remove(user);
        }

        public User this[int index]
        {
            get
            {
                return (User)base.InnerList[index];
            }
        }

        public bool Contain(User user)
        {
            foreach (User item in this)
            {
                if ((user.NetPoint.Address.ToString() == item.NetPoint.Address.ToString())
                    && (user.NetPoint.Port == item.NetPoint.Port)
                    && (user.UserName == item.UserName))
                    return true;
            }
            return false;
        }
    }
}

