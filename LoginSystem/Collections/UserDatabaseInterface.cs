using System;
using System.Collections.Generic;
using System.Text;
using LoginSystem.Models;

namespace LoginSystem.Collections
{
    public interface UserDatabaseInterface
    {
        User getUser(string login);
        bool addUser(User user);
        void updateUser();
        void deleteUser(User user);
    }
}
