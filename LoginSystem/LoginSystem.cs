using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using TcpServerLibrary;
using LoginSystem.Models;

namespace LoginSystem
{
    public class LoginSystem : StreamManager
    {
        public enum Status { EXIT, STAY, NEXT}
        static UserList userList = null;
        protected User user = null;
        public LoginSystem(NetworkStream ns, int buffer_size = 1024) : base(ns, buffer_size)
        {
            if (userList == null)
            {
                userList.addUser(new User("admin", "Qwerty123", User.UserRole.Admin) { recovery_questions = new KeyValuePair<string, string>("2+2=","4") });
                userList.addUser(new User("user", "Qwerty123", User.UserRole.Normal) { recovery_questions = new KeyValuePair<string, string>("2+3=","5") });
                userList.addUser(new User("quest", "Qwerty123", User.UserRole.Guest) { recovery_questions = new KeyValuePair<string, string>("3+3=","6") });
            }
        }
        private bool addUser(string login, string password, string role, string question, string answer)
        {
            User.UserRole userRole = User.UserRole.Guest;
            switch (role)
            {
                case "Admin": userRole = User.UserRole.Admin; break;
                case "Normal": userRole = User.UserRole.Normal; break;
            }
            User u = new User(login, password, userRole) { recovery_questions = new KeyValuePair<string, string>(question, answer) };
            return userList.addUser(u);
        }
        public Status loginPanel(string command)
        {
            string[] array = command.Split(';');
            switch (array[0])
            {
                case "exit": { Data = "Exit"; return Status.EXIT;  } break;
                case "login": {
                        if (array.Length == 3) { 
                            user = userList.getUser(array[1], array[2]);
                            Data = "Loged";
                            return Status.NEXT;
                        } else
                        {
                            Data = "BadArgumentCountError";
                        }
                    }break;
                case "new": {
                        try
                        {
                            Data = (addUser(array[1], array[2], array[3], array[4], array[5]))? "Created":"NotCreatedError";                            
                        }catch(ArgumentException)
                        {
                            Data = "SimplePasswordError";
                        }
                    }break;
            }
            return Status.STAY;
        }
        public Status userPanel(string command)
        {
            string[] array = command.Split(';');
            switch (array[0])
            {
                case "changepassword": {
                        if (user.Role == User.UserRole.Guest)
                        {
                            Data = "NotPermissionError"; break;
                        }
                        if (user.changePassword(array[1]))
                        {
                            Data = "PasswordChanged";
                        }
                        else
                        {
                            Data = "SimplePasswordError";
                        }
                    }break;
                case "changequestion": {
                        if (user.Role == User.UserRole.Guest)
                        {
                            Data = "NotPermissionError";
                        }
                        user.recovery_questions = new KeyValuePair<string, string>(array[1], array[2]);
                        Data = "GuestionChanged";
                    }
                    break;
                case "changerole": {
                        if (user.Role != User.UserRole.Admin)
                        {
                            Data = "NotPermissionError"; break;
                        }
                        /*userList.getUser(array[1])?.Role = array[2] switch
                        {
                            "Admin" => User.UserRole.Admin,
                            "Quest" => User.UserRole.Guest,
                            "Normal" => User.UserRole.Normal,
                        };*/
                        User u = userList.getUser(array[1]);
                        if (u == null) { Data = "NotUserExistError";break; }
                        switch (array[2])
                        {
                            case "Admin": userList.getUser(array[1]).Role = User.UserRole.Admin; break;
                            case "Quest": userList.getUser(array[1]).Role = User.UserRole.Guest; break;
                            case "Normal": userList.getUser(array[1]).Role = User.UserRole.Normal; break;
                        }
                        Data = "RoleChanged";
                    }break;
                case "new": {
                        if (user.Role != User.UserRole.Admin)
                        {
                            Data = "NotPermissionError"; break;
                        }
                        try
                        {
                            Data = (addUser(array[1], array[2], array[3], array[4], array[5])) ? "Created" : "NotCreatedError";
                        }
                        catch (ArgumentException)
                        {
                            Data = "SimplePasswordError";
                        }
                    }
                    break;
                case "delete": {
                        if (user.Role != User.UserRole.Admin)
                        {
                            Data = "NotPermissionError"; break;
                        }
                        if (userList.getUser(array[1])!=null)
                        {
                            userList.removeUser(array[1]);
                            Data = (userList.getUser(array[1]) == null) ? "Deleted" : "NotDeletedError";
                        }
                        else
                        {
                            Data = "UserNotExistError";
                        }
                        
                    }
                    break;
                case "logout": { user = null;Data = "Logout"; return Status.NEXT; }break;
            }
            return Status.STAY;
        }

        public static void messageParser(NetworkStream ns)
        {
            LoginSystem sm = new LoginSystem(ns);
            bool isLoginPanel = true;
            Status status = Status.STAY;
            string message;
            do
            {
                message = sm.Data;
                status = (isLoginPanel) ? sm.loginPanel(message) : sm.userPanel(message);
                isLoginPanel = (status != Status.NEXT);
            } while (status != Status.EXIT);
        }
    }
}
