using System;
using System.Collections.Generic;
using System.Text;

namespace LoginSystem.Models
{
    public class User
    {
        public enum UserRole
        {
            Normal, Admin, Guest
        }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public UserRole Role { get; set; }

        public User() : this("", "", UserRole.Normal, "", "") { }
        public User(string login, string password, UserRole role, string question, string answer)
        {
            Login = login;
            Password = password;
            Question = question;
            Answer = answer;
            Role = role;
        }
        public override bool Equals(object obj)
        {
            User user = (User)obj;
            return Login == user.Login;
        }
        public override int GetHashCode()
        {
            return Login.GetHashCode();
        }

    }
}
