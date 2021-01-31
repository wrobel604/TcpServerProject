using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginSystemClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpServerLibrary;
using System.IO;
using LoginSystem.Models;

namespace LoginSystemClient.Tests
{
    [TestClass()]
    public class UserCommandManagerTests
    {
        Task runServer()
        {
            return new Task(() =>
            {
                TcpServer tcpServer = new TcpServer("127.0.0.1", 5555);
                string userPath = "test_users.xml", messagePath = "test_message.xml";

                HashSet<User> users = new HashSet<User>();
                users.Add(new User("admin", "Qwerty123", User.UserRole.Admin, "2+2=", "4"));
                users.Add(new User("user", "Qwerty123", User.UserRole.Normal, "2+3=", "5"));
                users.Add(new User("guest", "Qwerty123", User.UserRole.Guest, "3+3=", "6"));
                LoginSystem.Collections.UserXmlList.createUserXMLFile(userPath, users);

                List<Message> messages = new List<Message>();
                messages.Add(new Message("admin", "user", "Hello, I'm Admin"));
                messages.Add(new Message("admin", "quest", "Hello, I'm Admin"));
                messages.Add(new Message("user", "admin", "Hello, I can't change password"));
                LoginSystem.Collections.UserXmlListWithMessages.createMessageXMLFile(messagePath, messages);

                LoginSystem.LoginSystem.UserDB = new LoginSystem.Collections.UserXmlListWithMessages(userPath, messagePath);
                tcpServer.ServerMessageParserFunction = LoginSystem.LoginSystem.messageParser;
                tcpServer.Listening();
            });
        }

        [TestMethod()]
        public void LoginTest()
        {
            Task server = runServer();
            server.Start();
            UserCommandManager userCommandManager = new UserCommandManager("127.0.0.1", 5555);
            Assert.IsFalse(userCommandManager.Login("n", "n"));
            Assert.IsTrue(userCommandManager.Login("user", "Qwerty123"));
            userCommandManager.Exit();
            server.Wait();
        }

        [TestMethod()]
        public void RegisterTest()
        {
            Task server = runServer();
            server.Start();
            UserCommandManager userCommandManager = new UserCommandManager("127.0.0.1", 5555);
            Assert.IsFalse(userCommandManager.Register("Ala", "s","Normal","A","A"));
            Assert.IsFalse(userCommandManager.Login("Ala", "zaq1@WSX"));
            Assert.IsTrue(userCommandManager.Register("Ala", "zaq1@WSX","Normal","A","A"));
            Assert.IsTrue(userCommandManager.Login("Ala", "zaq1@WSX"));
            userCommandManager.Exit();
            server.Wait();
        }

        [TestMethod()]
        public void ChangePasswordTest()
        {
            Task server = runServer();
            server.Start();
            UserCommandManager userCommandManager = new UserCommandManager("127.0.0.1", 5555);
            string newpassword = "Password123";
            Assert.IsTrue(userCommandManager.Login("user", "Qwerty123"), userCommandManager.Error);
            Assert.IsTrue(userCommandManager.ChangePassword(newpassword));
            Assert.IsTrue(userCommandManager.Logout(), userCommandManager.Error);
            Assert.IsTrue(userCommandManager.Login("user", newpassword));
            userCommandManager.Exit();
            server.Wait();
        }

        [TestMethod()]
        public void RecoveryAndChangeQuestionTest()
        {
            Task server = runServer();
            server.Start();
            UserCommandManager userCommandManager = new UserCommandManager("127.0.0.1", 5555);
            string newquestion = "Ala ma ...", newanswer = "kota";
            Assert.IsTrue(userCommandManager.Login("user", "Qwerty123"));
            Assert.IsTrue(userCommandManager.ChangeQuestion(newquestion, newanswer));
            Assert.IsTrue(userCommandManager.Logout());
            string question = userCommandManager.Recovery("user");
            Assert.IsTrue(userCommandManager.Error == "");
            string password = userCommandManager.Answer("user", "kota");
            Assert.IsTrue(userCommandManager.Error == "");
            Assert.IsTrue(userCommandManager.Login("user", password), password);
            userCommandManager.Exit();
            server.Wait();
        }

        [TestMethod()]
        public void MessageTest()
        {
            Task server = runServer();
            server.Start();
            UserCommandManager userCommandManager = new UserCommandManager("127.0.0.1", 5555);
            Assert.IsTrue(userCommandManager.Login("user", "Qwerty123"));
            Assert.IsTrue(userCommandManager.SendMessage("guest", "Test"));
            Assert.IsTrue(userCommandManager.Logout());
            Assert.IsTrue(userCommandManager.Login("guest", "Qwerty123"));
            string messages = userCommandManager.ReadMessage().Trim();
            Assert.IsTrue(userCommandManager.Error == "");
            string[] data = messages.Split(';');
            Assert.IsTrue(data.Length == 4);
            userCommandManager.Exit();
            server.Wait();
        }

        [TestMethod()]
        public void ExitTest()
        {
            Task server = runServer();
            server.Start();
            UserCommandManager userCommandManager = new UserCommandManager("127.0.0.1", 5555);
            Assert.IsTrue(userCommandManager.Exit());
            server.Wait();
        }

        [TestMethod()]
        public void LogoutTest()
        {
            Task server = runServer();
            server.Start();
            UserCommandManager userCommandManager = new UserCommandManager("127.0.0.1", 5555);
            Assert.IsTrue(userCommandManager.Login("admin", "Qwerty123"));
            Assert.IsTrue(userCommandManager.Logout());
            userCommandManager.Exit();
            server.Wait();
        }
    }
}