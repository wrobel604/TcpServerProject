using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginSystem.Models;

namespace LoginSystemClient
{
    public static class CommandBuilder
    {
        public static string Login(string login, string password) => $"login;{login};{password}";
        public static string Register(string login, string password, string question, string answer) => $"new;{login};{password};Normal;{question};{answer}";
        public static string Recovery(string login) => $"recovery;{login}";
        public static string Answer(string login, string answer) => $"answer;{login};{answer}";
        //Funkcje zalogowanego użytkownika
        public static string ChangePassword(string password) => $"changepassword;{password}";
        public static string ChangeQuestion(string question, string answer) => $"changequestion;{question};{answer}";
        public static string SendMessage(string login, string content) => $"sendmessage;{login};{content}";
        public static string ReadMessage() => $"readmessage";
        //Funkcje admina
        public static string ChangeRole(string login, string role) => $"changerole;{login};{role}";
        public static string DeleteUser(string login) => $"delete;{login}";

        public static string Exit() => "exit";
        public static string Logout() => "logout";

    }
}
