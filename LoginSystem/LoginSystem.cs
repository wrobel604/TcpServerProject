using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using TcpServerLibrary;
using LoginSystem.Models;
using LoginSystem.Collections;

namespace LoginSystem
{
    public class LoginSystem : StreamManager
    {
        public static UserXmlListWithMessages UserDB = null;
        protected User user = null;
        int answerLimit;
        static private string BadArgumentCount = "badargumentcount";
        static private string NotUserExistError = "notuserexisterror";
        static private string SimplePasswordError = "notuserexisterror";
        static private string NotLogInUserError = "notloginusererror";
        static private string NotPermissionError = "notpermissionerror";
        public LoginSystem(NetworkStream ns, int buffer_size = 1024) : base(ns, buffer_size)
        {
            answerLimit = 3;
        }
        private bool isCorrectPassword(string password)
        {
            PasswordRule passwordRule = new PasswordRule();
            return passwordRule.check_pass(password);
        }
        //login;user;password
        protected string login(string login, string password)
        {
            if (user != null) return "userisloggederror";
            User result = UserDB.getUser(login);
            if (result == null) { return NotUserExistError; }
            if (result.Password != password) { return "badpassworderror"; }
            user = result;
            if (user == null) { return "loginerror"; }
            return "loged";
        }
        //new;login;password;role;question;answer
        protected string newuser(string[] array)
        {
            if (array.Length >= 5)
            {
                if (UserDB.getUser(array[0]) != null) { return "userexisterror"; }
                if (isCorrectPassword(array[1])) { return SimplePasswordError; }
                try
                {
                    UserDB.addUser(new User(array[0], array[1], (User.UserRole)Enum.Parse(typeof(User.UserRole), array[2]), array[3], array[4]));
                }
                catch (Exception)
                {
                    return "incorrectroleerror";
                }
                if (UserDB.getUser(array[0]) == null) { return "notcreatederror"; }
                return "created";
            }
            return BadArgumentCount;
        }
        //recovery;login
        protected string recovery(string login)
        {
            User u = UserDB.getUser(login);
            return (u == null) ? NotUserExistError : u.Question;
        }
        //answer;login;answer
        protected string answer(string login, string answer)
        {
            if (answerLimit <= 0) { return "answerlimiterror"; }
            User u = UserDB.getUser(login);
            if (u == null) { return NotUserExistError; }
            if (u.Answer == answer)
            {
                return u.Password;
            }
            else
            {
                --answerLimit;
                return "badanswererror";
            }
        }

        //changepassword;newpassword
        protected string changepassword(string newpassword)
        {
            if (user == null) { return NotLogInUserError; }
            string oldPassword = user.Password;
            if (!isCorrectPassword(newpassword)) { return SimplePasswordError; }
            user.Password = newpassword;
            UserDB.updateUser();
            return "passwordchanged";
        }
        //changequestion;newquestion;newanswer
        protected string changequestion(string question, string answer)
        {
            if (user == null) { return NotLogInUserError; }
            user.Question = question;
            user.Answer = answer;
            UserDB.updateUser();
            return "questionchanged";
        }
        //sendmessage;receiver;content
        protected string sendmessage(string receiver, string content)
        {
            if (user == null) { return NotLogInUserError; }
            User u = UserDB.getUser(receiver);
            if (u == null) { return NotUserExistError; }
            Message message = new Message(user, u, content);
            if (UserDB.addMessage(message))
            {
                return "sent";
            }
            return "notsenterror";
        }
        //readmessage
        protected string readmessage()
        {
            if (user == null) { return NotLogInUserError; }
            List<Message> list = null;
            list = UserDB.getMessages(user.Login);
            if (list == null) { return "notmessages"; }
            if (list.Count == 0) { return "notmessages"; }
            string result = "";
            foreach (Message message in list)
            {
                result += message + "\n";
            }
            return result;
        }
        //changerole;login;role
        protected string changerole(string login, string role)
        {
            if (user == null) { return NotLogInUserError; }
            if (user.Role != User.UserRole.Admin) { return NotPermissionError; }
            User u = UserDB.getUser(login);
            if (u == null) { return NotUserExistError; }
            try
            {
                u.Role = (User.UserRole)Enum.Parse(typeof(User.UserRole), role);
            }
            catch (Exception)
            {
                return "incorrectroleerror";
            }
            UserDB.updateUser();
            return "relechanged";
        }
        //delete;login
        protected string delete(string login)
        {
            if (user == null) { return NotLogInUserError; }
            if (user.Role != User.UserRole.Admin) { return NotPermissionError; }
            User u = UserDB.getUser(login);
            if (u != null)
            {
                UserDB.deleteUser(u);
            }
            return "deleted";
        }
        protected bool commandPanel(string message)
        {
            string[] array = message.Split(';');
            if (array.Length > 0)
            {
                switch (array[0])
                {
                    case "exit": { Data = "exit"; return false; }
                    case "login": { Data = (array.Length >= 3) ? login(array[1], array[2]) : BadArgumentCount; } break;
                    case "new": { Data = newuser(array.Skip(1).ToArray()); } break;
                    case "recovery": { Data = (array.Length >= 2) ? recovery(array[1]) : BadArgumentCount; } break;
                    case "answer": { Data = (array.Length >= 3) ? answer(array[1], array[2]) : BadArgumentCount; } break;
                    //Funkcje zalogowanego użytkownika
                    case "changepassword": { Data = (array.Length >= 2) ? changepassword(array[1]) : BadArgumentCount; } break;
                    case "changequestion": { Data = (array.Length >= 3) ? changequestion(array[1], array[2]) : BadArgumentCount; } break;
                    case "logout": { user = null; Data = "logout"; } break;
                    case "sendmessage": { Data = (array.Length >= 3) ? sendmessage(array[1], array[2]) : BadArgumentCount; } break;
                    case "readmessage": { Data = readmessage(); } break;
                    //Funkcje admina
                    case "changerole": { Data = (array.Length >= 3) ? changerole(array[1], array[2]) : BadArgumentCount; } break;
                    case "delete": { Data = (array.Length >= 2) ? delete(array[1]) : BadArgumentCount; } break;

                    default: Data = "unknowncommanderror"; break;
                }
            }
            return true;
        }
        public static void messageParser(NetworkStream ns)
        {
            LoginSystem sm = new LoginSystem(ns);
            string message;
            do
            {
                try
                {
                    message = sm.Data.Trim();
                }
                catch (Exception e)
                {
                    sm.Data = e.Message;
                    message = "";
                }

            } while (sm.commandPanel(message));
        }
    }
}
