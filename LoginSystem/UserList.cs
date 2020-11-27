using System;
using System.Collections.Generic;
using System.Text;
using LoginSystem.Models;
using System.Linq;

namespace LoginSystem
{
    public class UserList
    {
        protected List<User> users;

        public UserList()
        {
            users = new List<User>();
        }
        /*
        public User login(string login, string password);
        //public User getUser(string login, string password);
        public bool addUser(User user);
        public void removeUser(string login);
        public void removeUser(User user);
        */

    }
}
