using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginSystemClient.Forms;

namespace LoginSystemClient
{
    public class FormsManager
    {
        UserCommandManager userCommand;

        public FormsManager(UserCommandManager usercommandmanager) {
            userCommand = usercommandmanager;
        }

        public void Run()
        {
            bool exit = false;//false - LoginForm, true = exit
            while (!exit)
            {
                LoginForm loginForm = new LoginForm();
                DialogResult result = loginForm.ShowDialog();
                switch (result)
                {
                    //Logowanie
                    case DialogResult.OK:
                        {
                            exit = Login(loginForm.LoginInputTextBox.Text, loginForm.PasswordInputTextBox.Text);
                            break;
                        }
                    //Wyjście
                    case DialogResult.Cancel: { loginForm.Close(); exit = true;break; }
                    //Przywrócenie konta
                    case DialogResult.Retry:
                        {
                            if (loginForm.LoginInputTextBox.Text == "") { MessageBox.Show("Podaj nazwę użytkownika w polu Login"); }
                            else
                            {
                                string question = userCommand.Recovery(loginForm.LoginInputTextBox.Text);
                                if (userCommand.Error != "") { MessageBox.Show("Podany użytkownik nie istnieje"); }
                                else
                                {
                                    RecoveryForm recoveryForm = new RecoveryForm();
                                    recoveryForm.Question.Text = question;
                                    DialogResult res = recoveryForm.ShowDialog();
                                    if (res == DialogResult.OK)
                                    {
                                        recoveryForm.Close();
                                        string password = userCommand.Answer(loginForm.LoginInputTextBox.Text, recoveryForm.Answer.Text);
                                        if (userCommand.Error == "") { exit = Login(loginForm.LoginInputTextBox.Text, password); }
                                    }
                                }
                            }

                            break;
                        }
                    //Rejestracja
                    case DialogResult.Yes: {
                            RegisterUserForm registerUserForm = new RegisterUserForm();
                            if(registerUserForm.ShowDialog() == DialogResult.OK)
                            {
                                bool res = userCommand.Register(registerUserForm.LoginInput.Text, registerUserForm.PasswordInput.Text, "Normal", registerUserForm.QuestionInput.Text, registerUserForm.AnswerInput.Text);
                                if (res)
                                {
                                    exit = Login(registerUserForm.LoginInput.Text, registerUserForm.PasswordInput.Text);
                                }
                                else
                                {
                                    switch (userCommand.Error)
                                    {
                                        case "userexisterror": { MessageBox.Show("Użytkownik o podanej nazwie już istnieje"); break; }
                                        case "simplepassworderror": { MessageBox.Show("Hasło jest zbyt proste (minimum 8 znaków i conajmniej po jednej dużej literze i cyfrze"); break; }
                                        default: { MessageBox.Show("Nie udało się dodać użytkownika"); break; }
                                    }
                                }
                            }
                            break; }
                }
            }
        }

        protected bool Login(string login, string password)
        {
            bool result = userCommand.Login(login, password);
            if (result)
            {
                return MailBoxFunction();
            }
            else
            {
                switch (userCommand.Error)
                {
                    case "notuserexisterror": { MessageBox.Show("Użytkownik nie istnieje"); break; }
                    case "badpassworderror": { MessageBox.Show("Błędne hasło"); break; }
                    case "loginerror": { MessageBox.Show("Błąd serwera"); break; }
                }
            }
            return false;
        }
        //true - wyjście, false - wylogowanie
        protected bool MailBoxFunction()
        {
            MailForm mailForm = new MailForm(userCommand);
            return (mailForm.ShowDialog() == DialogResult.Abort);
        }
    }
}
