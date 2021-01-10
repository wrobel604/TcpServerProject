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
        public static string Register(string login, string password, string question, string answer) => $"new;{login};{password};{question};{answer}";
        public static string Question(string login) => $"recovery;{login}";
        public static string Answer(string answer) => answer;
        public static string ChangePassword(string password) => $"changepassword;{password}";
        public static string ChangeQuestion(string question, string answer) => $"changequestion;{question};{answer}";
        public static string ChangeRole(string login, string role) => $"changerole;{login};{role}";
        public static string RegisterAsAdmin(string login, string role) => $"changerole;{login};{role}";

        public static string Exit() => "exit";

    }
}
