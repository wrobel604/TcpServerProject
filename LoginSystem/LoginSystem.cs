using System;

namespace LoginSystem
{
    public class LoginSystem
    {
        int Buffer_size = 1024;
        List<string> logins = new string[] { "Admin", "User1", "User2", "User3", "Guest1", "Guest2", "Guest3" };
        List<string> passwords = new string[] { "AdminPass", "User1Pass", "User2Pass", "User3Pass", "Guest1Pass", "Guest2Pass", "Guest3Pass" };
        List<string> recovery_questions = new string[]
        {
            "What is your mother's maiden name?",
            "What is the name of your first pet?",
            "What was your first car?",
            "What elementary school did you attend?",
            "What is the name of the town where you were born?",
            "Who was your childhood hero?",
            "Where was your best family vacation as a kid?"
        };
        List<string> roles = new string[] { "Admin", "User", "User", "User", "Guest", "Guest", "Guest" };
        int logged_id = -1; // 0 - admin, 1+ inni użytkownicy

        public string get_string(byte[] buffer, int message_size) //funckja zwracajaca string o właściwym rozmiarze
        {
            byte[] buffer_2 = new byte[message_size];
            Array.Copy(buffer, buffer_2, message_size);
            return Encoding.UTF8.GetString(buffer_2);
        }   

        public int login_id(string name)    //funkcja sprawdzajaca na którym miejscu w tabeli loginów znajduje się podany login
        {
            for (int j = 0; j < logins.Length; j++)
            {
                if (name == logins[j])
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
                if(passwords[logged_id] == pass)
                {
                    stream.Write(Encoding.Unicode.GetBytes("Haslo poprawne, Witaj " + Encoding.ASCII.GetString(nazwa_uzytkownika_bez_0) + " " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Haslo poprawne, Witaj " + Encoding.ASCII.GetString(nazwa_uzytkownika_bez_0) + " " + Environment.NewLine).Length);
                }
                else
                {
                    stream.Write(Encoding.Unicode.GetBytes("Haslo niepoprawne" + Encoding.ASCII.GetString(nazwa_uzytkownika_bez_0) + " " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Haslo niepoprawne" + Encoding.ASCII.GetString(nazwa_uzytkownika_bez_0) + " " + Environment.NewLine).Length);
                    logged_id = -1;
                }
            }
        }

        public void new_user(NetworkStream stream) //funkcja do tworzenia nowego użytkownika
        {
            stream.Write(Encoding.Unicode.GetBytes("Wprowadz nazwe nowego uzytkownika: " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Wprowadz nazwe nowego uzytkownika: " + Environment.NewLine).Length);
            byte[] buffer_new_name = new byte[Buffer_size];
            int message_size_new_name = stream.Read(buffer_new_name, 0, Buffer_size);
            logins.add(get_string(buffer_new_name,message_size_new_name));

            stream.Write(Encoding.Unicode.GetBytes("Wprowadz haslo nowego uzytkownika: " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Wprowadz haslo nowego uzytkownika: " + Environment.NewLine).Length);
            byte[] buffer_new_pass= new byte[Buffer_size];
            int message_size_new_pass = stream.Read(buffer_new_pass, 0, Buffer_size);
            passwords.add(get_string(buffer_new_pass,message_size_new_pass));

            stream.Write(Encoding.Unicode.GetBytes("Wprowadz pytanie pomocnicze do hasla nowego uzytkownika: " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Wprowadz pytanie pomocnicze do hasla nowego uzytkownika: " + Environment.NewLine).Length);
            byte[] buffer_new_question = new byte[Buffer_size];
            int message_size_new_question = stream.Read(buffer_new_question, 0, Buffer_size);
            recovery_questions.add(get_string(buffer_new_question,message_size_new_question));

            stream.Write(Encoding.Unicode.GetBytes("Wprowadz role nowego uzytkownika: " + Environment.NewLine), 0, Encoding.Unicode.GetBytes("Wprowadz role nowego uzytkownika: " + Environment.NewLine).Length);
            byte[] buffer_new_role = new byte[Buffer_size];
            int message_size_new_role = stream.Read(buffer_new_role, 0, Buffer_size);
            roles.add(get_string(buffer_new_role,message_size_new_role));
        }

        public static byte[] messageParser(byte[] data, int size)
        {
            byte[] result = null;

            return result;
        }

    }
}
