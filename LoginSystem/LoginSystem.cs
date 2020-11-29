using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using TcpServerLibrary;
using LoginSystem.Models;

namespace LoginSystem
{
    public class LoginSystem : StreamManager
    //public class LoginSystem
    {
        public static List<User> users = null;
        private User user;
        int Buffer_size = 1024;
        int logged_id = -1; // 0 - admin, 1+ inni użytkownicy

        public LoginSystem(NetworkStream ns) : base(ns)
        {
            if (users == null)
            {
                users = new List<User>();
                users.Add(new User {
                    login = "Admin",
                    password = "User1Pass",
                    recovery_questions = new KeyValuePair<string, string>("What is your mother's maiden name?", "Jonh"),
                    role = "Admin"
                });
                users.Add(new User
                {
                    login = "User1",
                    password = "AdminPass",
                    recovery_questions = new KeyValuePair<string, string>("What is the name of your first pet?", "Bork"),
                    role = "User"
                });
                users.Add(new User
                {
                    login = "Guest1",
                    password = "Guest1Pass",
                    recovery_questions = new KeyValuePair<string, string>("What is the name of the town where you were born?", "New York"),
                    role = "Guest"
                });
            }
        }

        public string get_string(byte[] buffer, int message_size) //funckja zwracajaca string o właściwym rozmiarze
        {
            byte[] buffer_2 = new byte[message_size];
            Array.Copy(buffer, buffer_2, message_size);
            return Encoding.UTF8.GetString(buffer_2);
        }   
         //logins.Where(x=> x==name).Count()>0
        public int login_id(string name)    //funkcja sprawdzajaca na którym miejscu w tabeli loginów znajduje się podany login
        {
            for (int j = 0; j < users.Count; j++)
            {
                if (name == users[j].login)
                {
                    return j;
                }
            }
            return -1;
        }

        public void login(NetworkStream stream)  //funkcja do logowania za pomocą loginu i hasła
        {
            byte[] buffer = new byte[Buffer_size];
            stream.Write(Encoding.Unicode.GetBytes("Wprowadz login: " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Wprowadz login: " + Environment.NewLine).Length);
            int message_size = stream.Read(buffer, 0, Buffer_size);
            string name = get_string(buffer, message_size);
            logged_id = login_id(name);
            if (logged_id == -1)
            {
                stream.Write(Encoding.Unicode.GetBytes("Login Niepoprawny " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Login Niepoprawny " + Environment.NewLine).Length);
            }
            else
            {
                stream.Write(Encoding.Unicode.GetBytes("Wprowadz haslo: " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Wprowadz haslo: " + Environment.NewLine).Length);
                byte[] buffer_pass = new byte[Buffer_size];
                int message_size_pass = stream.Read(buffer_pass, 0, Buffer_size);
                string pass=get_string(buffer_pass,message_size_pass);
                if(users[logged_id].password == pass)
                {
                    //stream.Write(Encoding.Unicode.GetBytes("Haslo poprawne, Witaj " + Encoding.ASCII.GetString(nazwa_uzytkownika_bez_0) + " " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Haslo poprawne, Witaj " + Encoding.ASCII.GetString(nazwa_uzytkownika_bez_0) + " " + Environment.NewLine).Length);
                }
                else
                {
                    //stream.Write(Encoding.Unicode.GetBytes("Haslo niepoprawne" + Encoding.ASCII.GetString(nazwa_uzytkownika_bez_0) + " " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Haslo niepoprawne" + Encoding.ASCII.GetString(nazwa_uzytkownika_bez_0) + " " + Environment.NewLine).Length);
                    logged_id = -1;
                }
            }
        }

        public bool check_pass(string pass)//funkcja sprawdzająca poprawnosc hasla
        {
            bool is_upper = false;
            bool is_number = false;
            if (pass.Length < 8)
            {
                return false;
            }


            for (int i = 0; i < pass.Length; i++)
            {
                if (Char.IsUpper(pass[i]))
                {
                    is_upper = true;
                }
                if (Char.IsDigit(pass[i]))
                {
                    is_number = true;
                }
            }
            if (is_number && is_upper)
            {
                return true;
            }
            return false;


        }
        public void new_user(NetworkStream stream) //funkcja do tworzenia nowego użytkownika
        {
            stream.Write(Encoding.Unicode.GetBytes("Wprowadz nazwe nowego uzytkownika: " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Wprowadz nazwe nowego uzytkownika: " + Environment.NewLine).Length);
            byte[] buffer_new_name = new byte[Buffer_size];
            int message_size_new_name = stream.Read(buffer_new_name, 0, Buffer_size);
            bool pass_ok = false;
            byte[] buffer_new_pass = new byte[Buffer_size];
            int message_size_new_pass = 0;
            while (pass_ok == false)
            {
                stream.Write(Encoding.Unicode.GetBytes("Wprowadz haslo nowego uzytkownika: " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Wprowadz haslo nowego uzytkownika: " + Environment.NewLine).Length);
                message_size_new_pass = stream.Read(buffer_new_pass, 0, Buffer_size);
                if (check_pass(get_string(buffer_new_pass, message_size_new_pass)))
                {
                    pass_ok = true;
                }
                else
                {
                    stream.Write(Encoding.Unicode.GetBytes("Haslo powinno spelniac nastepujace wymagania: \n -co najmniej jedna duza litera \n -co najmniej jedna cyfra \n -dlugosc hasla nie powinna byc krotsza niz 8 znakow" + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Haslo powinno spelniac nastepujace wymagania: \n - co najmniej jedna duza litera \n - co najmniej jedna cyfra \n - dlugosc hasla nie powinna byc krotsza niz 8 znakow" + Environment.NewLine).Length);
                }
                
            }
            stream.Write(Encoding.Unicode.GetBytes("Wprowadz pytanie pomocnicze do hasla nowego uzytkownika: " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Wprowadz pytanie pomocnicze do hasla nowego uzytkownika: " + Environment.NewLine).Length);
            byte[] buffer_new_question = new byte[Buffer_size];
            int message_size_new_question = stream.Read(buffer_new_question, 0, Buffer_size);

            stream.Write(Encoding.Unicode.GetBytes("Wprowadz odpowiedźddo pytania pomocniczego: " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Wprowadz odpowiedźddo pytania pomocniczego: " + Environment.NewLine).Length);
            byte[] buffer_new_answer = new byte[Buffer_size];
            int message_size_new_answer = stream.Read(buffer_new_question, 0, Buffer_size);

            stream.Write(Encoding.Unicode.GetBytes("Wprowadz role nowego uzytkownika: " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Wprowadz role nowego uzytkownika: " + Environment.NewLine).Length);
            byte[] buffer_new_role = new byte[Buffer_size];
            int message_size_new_role = stream.Read(buffer_new_role, 0, Buffer_size);
            users.Add(new User
            {
                login = get_string(buffer_new_name, message_size_new_name),
                password = get_string(buffer_new_pass, message_size_new_pass),
                recovery_questions = new KeyValuePair<string, string>(get_string(buffer_new_question, message_size_new_question), get_string(buffer_new_answer, message_size_new_answer)),
                role = get_string(buffer_new_role, message_size_new_role)
            });
        }
        public void change_password(NetworkStream stream)//funkcja umozliwiajaca uzytkownikomi zmiane hasla po zalogowaniu
        {
            stream.Write(Encoding.Unicode.GetBytes("Podaj aktualne haslo" + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Podaj aktualne haslo" + Environment.NewLine).Length);
            byte[] buffer_old_pass = new byte[Buffer_size];
            int message_size_old_pass = stream.Read(buffer_old_pass, 0, Buffer_size);
            bool pass_ok = false;
            byte[] buffer_new_pass = new byte[Buffer_size];
            int message_size_new_pass = stream.Read(buffer_new_pass, 0, Buffer_size);
            List<string> passwords = new List<string>();
            for(int i = 0; i < users.Count; i++)
            {
                passwords.Add(users[i].password);
            }

            if (passwords.Contains(get_string(buffer_old_pass, message_size_old_pass)))
            {
                while (pass_ok == false)
                {
                    stream.Write(Encoding.Unicode.GetBytes("Podaj nowe haslo" + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Podaj nowe haslo" + Environment.NewLine).Length);
                    buffer_new_pass = new byte[Buffer_size];
                    message_size_new_pass = stream.Read(buffer_new_pass, 0, Buffer_size);
                    if (check_pass(get_string(buffer_new_pass, message_size_new_pass)))
                    {
                        pass_ok = true;
                    }
                    else
                    {
                        stream.Write(Encoding.Unicode.GetBytes("Haslo powinno spelniac nastepujace wymagania: \n -co najmniej jedna duza litera \n -co najmniej jedna cyfra \n -dlugosc hasla nie powinna byc krotsza niz 8 znakow" + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Haslo powinno spelniac nastepujace wymagania: \n - co najmniej jedna duza litera \n - co najmniej jedna cyfra \n - dlugosc hasla nie powinna byc krotsza niz 8 znakow" + Environment.NewLine).Length);
                    }
                }
            users[users.FindIndex(x=>x.password.Equals(get_string(buffer_old_pass, message_size_old_pass)))].password = get_string(buffer_new_pass, message_size_new_pass);
            //passwords[passwords.FindIndex(x => x.Equals(get_string(buffer_old_pass, message_size_old_pass)))] = get_string(buffer_new_pass, message_size_new_pass);
            }
            else
            {
                stream.Write(Encoding.Unicode.GetBytes("Podano bledne haslo" + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Podano bledne haslo" + Environment.NewLine).Length);
            }

        }

        public void remove_user(NetworkStream stream)
        {
            if(logged_id != 0)
            {
                stream.Write(Encoding.Unicode.GetBytes("Nie masz odpowiednich uprawnień" + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Nie masz odpowiednich uprawnień" + Environment.NewLine).Length);
            }
            else
            {
                stream.Write(Encoding.Unicode.GetBytes("Jakiego użytkownika usunąć (podaj login)?" + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Jakiego użytkownika usunąć?" + Environment.NewLine).Length);
                byte[] buffer_user_to_remove = new byte[Buffer_size];
                int message_size_users_login_to_remove = stream.Read(buffer_user_to_remove, 0, Buffer_size);
                int id = login_id(get_string(buffer_user_to_remove, message_size_users_login_to_remove));
                users.RemoveAt(id);
                /*logins.RemoveAt(id);
                passwords.RemoveAt(id);
                recovery_questions.RemoveAt(id);
                recovery_answers.RemoveAt(id);*/
            }
        }

        public void remain_password(NetworkStream stream)
        {
            byte[] buffer = new byte[Buffer_size];
            stream.Write(Encoding.Unicode.GetBytes("Wprowadz login: " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Wprowadz login: " + Environment.NewLine).Length);
            int message_size = stream.Read(buffer, 0, Buffer_size);
            string name = get_string(buffer, message_size);
            logged_id = login_id(name);

            List<string> passwords = new List<string>();
            for (int i = 0; i < users.Count; i++)
            {
                passwords.Add(users[i].password);
            }

            List<string> recovery_questions = new List<string>();
            for (int i = 0; i < users.Count; i++)
            {
                recovery_questions.Add(users[i].recovery_questions.Key);
            }

            List<string> recovery_answers = new List<string>();
            for (int i = 0; i < users.Count; i++)
            {
                recovery_answers.Add(users[i].recovery_questions.Value);
            }

            if (logged_id == -1)
            {
                stream.Write(Encoding.Unicode.GetBytes("Login Niepoprawny " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Login Niepoprawny " + Environment.NewLine).Length);
            }
            else
            {
                stream.Write(Encoding.Unicode.GetBytes(recovery_questions[login_id(name)] + Environment.NewLine), 0, Encoding.Unicode.GetBytes(recovery_questions[login_id(name)] + Environment.NewLine).Length);
                byte[] buffer_answ = new byte[Buffer_size];
                stream.Write(Encoding.Unicode.GetBytes("Wprowadz odpowiedz: " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Wprowadz odpowiedz: " + Environment.NewLine).Length);
                int message_size_answ = stream.Read(buffer, 0, Buffer_size);
                string answer = get_string(buffer, message_size);
                if(answer == recovery_answers[login_id(name)])
                {
                    stream.Write(Encoding.Unicode.GetBytes("Haslo to: " + passwords[login_id(name)] + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Haslo to: " + passwords[login_id(name)] + Environment.NewLine).Length);
                }
                else
                {
                    stream.Write(Encoding.Unicode.GetBytes("Błędna odpowiedz: " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Błędna odpowiedz: " + Environment.NewLine).Length);
                }

            }
        }

        void menu(NetworkStream ns)
        {
            while (true)
            {
                if (logged_id == -1)
                {
                    ns.Write(Encoding.Unicode.GetBytes("1.Logowanie " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("1.Logowanie " + Environment.NewLine).Length);
                    ns.Write(Encoding.Unicode.GetBytes("2.Nowy uzytkownik " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("2.Nowy uzytkownik " + Environment.NewLine).Length);
                    ns.Write(Encoding.Unicode.GetBytes("3.Przypomnij haslo " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("3.Przypomnij haslo " + Environment.NewLine).Length);
                    byte[] buffer = new byte[Buffer_size];
                    int message_size = ns.Read(buffer, 0, Buffer_size);
                    string buffer2 = get_string(buffer, message_size);
                    if (buffer2 == "1")
                    {
                        login(ns);
                    }
                    else if (buffer2 == "2")
                    {
                        new_user(ns);
                    }
                    else if (buffer2 == "3")
                    {
                        remain_password(ns);
                    }
                }
                else if (logged_id == 0)
                {
                    ns.Write(Encoding.Unicode.GetBytes("1.Zmien haslo " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("1.Zmien haslo " + Environment.NewLine).Length);
                    ns.Write(Encoding.Unicode.GetBytes("2.Usun uzytkownika " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("2.U " + Environment.NewLine).Length);
                    byte[] buffer = new byte[Buffer_size];
                    int message_size = ns.Read(buffer, 0, Buffer_size);
                    string buffer2 = get_string(buffer, message_size);
                    if (buffer2 == "1")
                    {
                        change_password(ns);
                    }
                    else if (buffer2 == "2")
                    {
                        remove_user(ns);
                    }
                }
                else
                {
                    ns.Write(Encoding.Unicode.GetBytes("1.Zmien haslo " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("1.Zmien haslo " + Environment.NewLine).Length);
                    byte[] buffer = new byte[Buffer_size];
                    int message_size = ns.Read(buffer, 0, Buffer_size);
                    string buffer2 = get_string(buffer, message_size);
                    if (buffer2 == "1")
                    {
                        change_password(ns);
                    }
                }
            }
        }
        public static void messageParser(NetworkStream ns)
        {
            //StreamManager sm = new StreamManager(ns);
            LoginSystem sm = new LoginSystem(ns);
            while (true)
            {
                /*string message = sm.Data;
                if(message==null || message.Length == 0) { return; } else
                {
                    message = message.Trim();
                }*/
                //tutaj mozna wstawic kod obslugujacy wiadomosc
                //odpowiedz mozna wyslac przez sm.Data = "odpowiedz"



                sm.menu(ns);  //a żeby to zadziałało to nie może być statyczna

            }
        }
       

    }
}
