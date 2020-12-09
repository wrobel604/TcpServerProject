using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginSystem.Models.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void changePasswordTest()
        {
            User user = new User("user", "Qwerty123");
            Assert.IsFalse(user.changePassword("1234"));
            Assert.IsFalse(user.changePassword("abcdefgh"));
            Assert.IsFalse(user.changePassword("12345678"));
            Assert.IsFalse(user.changePassword("QWERTYUI"));
            Assert.IsTrue(user.changePassword("QWER1234"));
            Assert.IsTrue(user.changePassword("Qwer1234"));
        }

        [TestMethod()]
        public void EqualsTest()
        {
            User user1 = new User("user1", "Qwerty123");
            User user2 = new User("user2", "Qwerty123");
            User user3 = new User("user1", "Qwerty123");
            Assert.AreEqual(user1, user3);
            Assert.AreNotEqual(user1, user2);
        }

        [TestMethod()]
        public void getPasswordTest()
        {
            User user = new User("user", "Qwerty123");
            user.recovery_questions = new KeyValuePair<string, string>("2+2=", "4");
            Assert.IsTrue(user.checkPassword(user.getPassword("4")));
            Assert.IsFalse(user.checkPassword(user.getPassword("5")));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            User user1 = new User("user1", "Qwerty123");
            User user2 = new User("user2", "Qwerty123");
            User user3 = new User("user1", "Qwerty123");
            Assert.AreEqual(user1.GetHashCode(), user3.GetHashCode());
            Assert.AreNotEqual(user1.GetHashCode(), user2.GetHashCode());
        }
    }
}