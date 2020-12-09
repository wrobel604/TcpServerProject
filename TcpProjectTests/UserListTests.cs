using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSystem;
using System;
using System.Collections.Generic;
using System.Text;
using LoginSystem.Models;

namespace LoginSystem.Tests
{
    [TestClass()]
    public class UserListTests
    {
        [TestMethod()]
        public void getUserTest()
        {
            User user1 = new User("user", "Qwerty123");
            UserList userList = new UserList(user1);
            Assert.AreEqual(user1, userList.getUser(user1.Login));
            Assert.AreEqual(null, userList.getUser("user2"));
        }
        [TestMethod()]
        public void addUserTest()
        {
            User user1 = new User("user", "Qwerty123");
            User user2 = new User("user", "Qwerty123");
            User user3 = new User("user2", "Qwerty123");
            UserList userList = new UserList(user1);
            Assert.IsFalse(userList.addUser(user2));
            Assert.IsTrue(userList.addUser(user3));
        }

        [TestMethod()]
        public void removeUserTest()
        {
            User user1 = new User("user", "Qwerty123");
            UserList userList = new UserList(user1);
            Assert.AreEqual(user1, userList.getUser(user1.Login));
            userList.removeUser(user1.Login);
            Assert.AreEqual(null, userList.getUser(user1.Login));
        }
    }
}