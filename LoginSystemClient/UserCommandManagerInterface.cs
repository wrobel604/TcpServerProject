using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemClient
{
    public interface UserCommandManagerInterface
    {
        bool Login(string login, string password);
        bool Register(string login, string password, string role, string question, string answer);
        string Recovery(string login);
        string Answer(string login, string answer);
        //Funkcje zalogowanego użytkownika
        bool ChangePassword(string newpassword);
        bool ChangeQuestion(string question, string answer);
        bool SendMessage(string login, string content);
        string ReadMessage();
        //Funkcje admina
        bool ChangeRole(string login, string role);
        bool DeleteUser(string login);

        bool Logout();
        bool Exit();
    }
}
