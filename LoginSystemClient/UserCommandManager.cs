using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TcpServerLibrary;

namespace LoginSystemClient
{
    public class UserCommandManager : UserCommandManagerInterface
    {
        TcpClient tcpClient;
        StreamManager sm;
        public string Error { get; private set; }
        public UserCommandManager(TcpClient tcpclient) {
            tcpClient = tcpclient;
            sm = new StreamManager(tcpClient.GetStream());
        }
        ~UserCommandManager()
        {
            sm = null;
            tcpClient.Close();
        }
        public UserCommandManager(string hostname, int port):this(new TcpClient(hostname,port)) {}
        private string sendCommand(string command)
        {
            sm.Data = command;
            return sm.Data;
        }
        private bool checkCommandAnswer(string answer, string correctanswer)
        {
            if (answer == correctanswer) { Error = ""; return true; }
            Error = answer;
            return false;
        }
        public bool Login(string login, string password)
        {
            return checkCommandAnswer(sendCommand(CommandBuilder.Login(login, password)), "loged");
        }

        public bool Register(string login, string password, string role, string question, string answer)
        {
            return checkCommandAnswer(sendCommand(CommandBuilder.Register(login, password, question, answer)), "created");
        }

        public string Recovery(string login)
        {
            string result = sendCommand(CommandBuilder.Recovery(login));
            if(result == "notuserexisterror") { Error = result; return ""; }
            Error = "";
            return result;
        }

        public string Answer(string login, string answer)
        {
            string result = sendCommand(CommandBuilder.Answer(login, answer));
            if (result == "notuserexisterror" || result == "answerlimiterror" || result == "badanswererror") { Error = result; return ""; }
            Error = "";
            return result;
        }

        public bool ChangePassword(string newpassword)
        {
            return checkCommandAnswer(sendCommand(CommandBuilder.ChangePassword(newpassword)), "passwordchanged");
        }

        public bool ChangeQuestion(string question, string answer)
        {
            return checkCommandAnswer(sendCommand(CommandBuilder.ChangeQuestion(question, answer)), "questionchanged");
        }

        public bool SendMessage(string login, string content)
        {
            return checkCommandAnswer(sendCommand(CommandBuilder.SendMessage(login,content)), "sent");
        }

        public string ReadMessage()
        {
            string result = sendCommand(CommandBuilder.ReadMessage());
            if (result == "notmessages") { Error = result; return ""; }
            Error = "";
            return result;
        }

        public bool ChangeRole(string login, string role)
        {
            return checkCommandAnswer(sendCommand(CommandBuilder.ChangeRole(login, role)), "relechanged");
        }

        public bool DeleteUser(string login)
        {
            return checkCommandAnswer(sendCommand(CommandBuilder.DeleteUser(login)), "deleted");
        }

        public bool Exit()
        {
            return checkCommandAnswer(sendCommand(CommandBuilder.Exit()), "exit");
        }
        public bool Logout()
        {
            return checkCommandAnswer(sendCommand(CommandBuilder.Logout()), "logout");
        }
    }
}
