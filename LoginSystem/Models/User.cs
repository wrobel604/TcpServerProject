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
        protected string login, password;
        public UserRole Role;
        public KeyValuePair<string, string> recovery_question;//Pary klucz-pytanie, wartość-odpowiedź

        public string Login { get => login; }
        public string Question { get => recovery_question.Key; }

        public User(string login, string password, UserRole role = UserRole.Normal)
        {
            this.login = login;
            this.Role = role;
            if (!changePassword(password))
            {
                throw new ArgumentException("Password is too simple");
            }
        }

        public override bool Equals(object obj)
        {
            User user = (User)obj;
            return login == user.login;
        }
        public override int GetHashCode()
        {
            return Login.GetHashCode();
        }


        public bool checkPassword(string password)
        {
            return this.password == password;
        }
        public bool changePassword(string new_password)
        {
            PasswordRule rule = new PasswordRule();
            if (rule.check_pass(new_password))
            {
                password = new_password;
                return true;
            }
            return false;
        }
        public string getPassword(string answer)
        {
            return (recovery_question.Value == answer) ? password : "";
        }

    }
}
