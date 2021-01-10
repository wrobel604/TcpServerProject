using LoginSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LoginSystem
{
    public class UserList
    {
        protected HashSet<User> userslist;
        

        public UserList(){
            userslist = new HashSet<User>();
        }
        public UserList(params User[] users) {
            userslist = new HashSet<User>(users);
        }
        public User getUser(string login)
        {
            IEnumerable<User> users = userslist.Where(x => x.Login == login);
            return (users.Count() > 0) ? users.First() : null;
        }
        public User getUser(string login, string password)
        {
            IEnumerable<User> users = userslist.Where(x => x.Login == login && x.checkPassword(password) );
            return (users.Count() > 0) ? users.First() : null;
        }
        public bool addUser(User user)
        {
            return userslist.Add(user);
        }
        public void removeUser(string login)
        {
            userslist.Remove(getUser(login));
        }
    }
}
