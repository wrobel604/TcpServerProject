using System;
using System.IO;
using TcpServerLibrary;
using LoginSystem;
using System.Collections.Generic;
using LoginSystem.Models;

namespace LoginSystemTest
{
    class Program
    {
        static void Main(string[] args)
        {

            string host = "127.0.0.1";
            if (args.Length > 0) { host = args[0]; }
            int port = 5555;
            if (args.Length > 1) { port = int.Parse(args[1]); }
            try
            {
                TcpServer tcpServer = new TcpServer(host, port);
                Console.WriteLine($"Uruchomiono serwer na adresie {host}:{port}");
                string userPath = "users.xml", messagePath = "message.xml";
                if (!File.Exists(userPath))
                {
                    HashSet<User> users = new HashSet<User>();
                    users.Add(new User("admin", "Qwerty123", User.UserRole.Admin, "2+2=", "4"));
                    users.Add(new User("user", "Qwerty123", User.UserRole.Normal, "2+3=", "5"));
                    users.Add(new User("quest", "Qwerty123", User.UserRole.Guest, "3+3=", "6"));
                    LoginSystem.Collections.UserXmlList.createUserXMLFile(userPath, users);
                }
                if (!File.Exists(messagePath))
                {
                    List<Message> messages = new List<Message>();
                    messages.Add(new Message("admin", "user", "Hello, I'm Admin"));
                    messages.Add(new Message("admin", "quest", "Hello, I'm Admin"));
                    messages.Add(new Message("user", "admin", "Hello, I can't change password"));
                    LoginSystem.Collections.UserXmlListWithMessages.createMessageXMLFile(messagePath, messages);
                }
                LoginSystem.LoginSystem.UserDB = new LoginSystem.Collections.UserXmlListWithMessages(userPath, messagePath);
                tcpServer.ServerMessageParserFunction = LoginSystem.LoginSystem.messageParser;//Zeby to zadziałało to messageParser musi być statyczna
                tcpServer.Listening();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
