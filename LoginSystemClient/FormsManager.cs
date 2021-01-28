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
        public event Action Exit;
        UserCommandManager userCommandManager;
        LoginForm loginForm;
        MailForm mailForm;
        RecoveryForm recoveryForm;
        RegisterUserForm registerUserForm;
        SendMailForm sendMailForm;
        List<LoginSystem.Models.Message> messageList;

        private void messageParser(string messages)
        {
            string[] msg = messages.Split('\n');
            messageList = new List<LoginSystem.Models.Message>(msg.Length);
            mailForm.MessageList.Items.Clear();
            foreach(string message in msg.Where(x => x!=""))
            {
                string[] msginfo = message.Split(';');
                LoginSystem.Models.Message m = new LoginSystem.Models.Message(msginfo[0], msginfo[1], msginfo[3]);
                m.DateTime = DateTime.Parse(msginfo[2]);
                messageList.Add(m);
                ListViewItem item = new ListViewItem(m.Sender);
                item.SubItems.Add(m.DateTime.ToString());
                mailForm.MessageList.Items.Add(item);
            }
        }
        private void initLoginForm()
        {
            loginForm = new LoginForm();
            loginForm.LoginButton.Click += LoginButton_Click;
            loginForm.RecoveryLink.Click += RecoveryLink_Click;
            loginForm.RegisterButton.Click += (sender, e) => { loginForm.Hide();initRegisterUserForm(); registerUserForm.Show(); };
            loginForm.FormClosing += (sender, e) => { Exit(); };
        }

        private void initRecoveryForm()
        {
            recoveryForm = new RecoveryForm();
            recoveryForm.Send.Click += SendAnswer;
            recoveryForm.FormClosed += RegisterUserForm_FormClosed;
        }
        private ChangeForm changePassword()
        {
            ChangeForm changeForm = new ChangeForm();
            changeForm.label1.Text = "Nowe hasło";
            changeForm.label2.Text = "Powtórz hasło";
            changeForm.Input1.UseSystemPasswordChar = true;
            changeForm.AcceptButton.Click += (sender, e) => {
                if (changeForm.Input1.Text == changeForm.Input2.Text && changeForm.Input1.Text!="")
                {
                    if (userCommandManager.ChangePassword(changeForm.Input1.Text))
                    {
                        changeForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hasło jest zbyt proste");
                    }
                }
            };
            return changeForm;
        }
        private ChangeForm changeQuestion()
        {
            ChangeForm changeForm = new ChangeForm();
            changeForm.label1.Text = "Nowe pytanie";
            changeForm.label2.Text = "Odpowiedź";
            changeForm.AcceptButton.Click += (sender, e) => {
                if (changeForm.Input1.Text!="" && changeForm.Input2.Text!="")
                {
                    if (userCommandManager.ChangeQuestion(changeForm.Input1.Text, changeForm.Input2.Text))
                    {
                        changeForm.Close();
                    }
                }
            };
            return changeForm;
        }

        private void initMailForms()
        {
            mailForm = new MailForm();
            sendMailForm = new SendMailForm();
            string msg = userCommandManager.ReadMessage();
            if(userCommandManager.Error == "") { messageParser(msg); }
            

            mailForm.AnswerButton.Click += (sender, e) => { sendMailForm.ReceiverTextBox.Text = (mailForm.MessageList.SelectedItems.Count > 0) ? mailForm.MessageList.SelectedItems[0].Text : ""; CreateMessage(sender, e); };
            mailForm.NextSendButton.Click += (sender,e) => { sendMailForm.ContentTextBox.Text = mailForm.MessageTextBox.Text;CreateMessage(sender, e); };
            
            mailForm.napiszWiadomośćToolStripMenuItem.Click += CreateMessage;
            mailForm.zmieńHasłoToolStripMenuItem.Click += (sender, e) => { changePassword().Show(); };
            mailForm.zmieńPytanieToolStripMenuItem.Click += (sender, e) => { changeQuestion().Show(); };
            mailForm.odświeżToolStripMenuItem.Click += (sender, e) => {
                string messages = userCommandManager.ReadMessage();
                if (userCommandManager.Error == "") { messageParser(messages); }
            };
            mailForm.wylogujToolStripMenuItem.Click += Wyloguj;
            mailForm.wyjdźToolStripMenuItem.Click += (sender, e) => { Exit(); };

            mailForm.FormClosed += (sender, e) => { Exit();  };

            sendMailForm.SendButton.Click += SendButton_Click;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if(userCommandManager.SendMessage(sendMailForm.ReceiverTextBox.Text, sendMailForm.ContentTextBox.Text))
            {

            }
        }

        private void Wyloguj(object sender, EventArgs e)
        {
            if (userCommandManager.Logout())
            {
                mailForm.Close();
                sendMailForm.Close();
            }
        }

        private void CreateMessage(object sender, EventArgs e)
        {
            sendMailForm.Show();
        }

        private void initRegisterUserForm()
        {
            registerUserForm = new RegisterUserForm();
            registerUserForm.RegisterButton.Click += RegisterButton_Click;
            registerUserForm.FormClosed += RegisterUserForm_FormClosed;
        }

        private void RegisterUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Show();
        }

        private void RecoveryLink_Click(object sender, EventArgs e)
        {
            if (loginForm.LoginInputTextBox.Text == "")
            {
                MessageBox.Show("Podaj najpierw login użytkownika w oknie logowania");
            }
            else
            {
                string result = userCommandManager.Recovery(loginForm.LoginInputTextBox.Text);
                if (userCommandManager.Error == "")
                {
                    initRecoveryForm();
                    loginForm.Hide();
                    recoveryForm.Question.Text = result;
                    recoveryForm.Show();
                }
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (registerUserForm.PasswordInput.Text != registerUserForm.PasswordRepeatInput.Text) {
                MessageBox.Show("Hasła nie są identyczne");
            }
            else
            {
                if(userCommandManager.Register(registerUserForm.LoginInput.Text, registerUserForm.PasswordInput.Text, LoginSystem.Models.User.UserRole.Normal.ToString(), registerUserForm.QuestionInput.Text, registerUserForm.AnswerInput.Text))
                {
                    MessageBox.Show("Utworzono użytkownika");
                    initMailForms();
                    loginForm.LoginInputTextBox.Text = registerUserForm.LoginInput.Text;
                    loginForm.PasswordInputTextBox.Text = registerUserForm.PasswordInput.Text;
                    registerUserForm.Hide();
                    LoginButton_Click(loginForm, null);
                }
                else
                {
                    MessageBox.Show("Nie udało się stworzyć użytkownika\n"+userCommandManager.Error);
                }
            }
        }

        private void SendAnswer(object sender, EventArgs e)
        {
            string result = userCommandManager.Answer(loginForm.LoginInputTextBox.Text, recoveryForm.Answer.Text);
            if (userCommandManager.Error == "")
            {
                recoveryForm.Hide();
                loginForm.PasswordInputTextBox.Text = result;
                LoginButton_Click(loginForm, null);
            }
        }
        public FormsManager(UserCommandManager usercommandmanager)
        {
            Exit += FormsManager_Exit;
            userCommandManager = usercommandmanager;
            initLoginForm();
            loginForm.Show();
        }

        private void FormsManager_Exit()
        {
            userCommandManager.Exit();

            if (loginForm != null) { loginForm.Close(); }
            if (mailForm != null) { mailForm.Close(); }
            if (recoveryForm != null) { recoveryForm.Close(); }
            if (registerUserForm != null) { registerUserForm.Close(); }
            if (sendMailForm != null) { sendMailForm.Close(); }

        }

        public FormsManager(System.Net.Sockets.TcpClient tcpclient):this(new UserCommandManager(tcpclient))
        {
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (userCommandManager.Login(loginForm.LoginInputTextBox.Text, loginForm.PasswordInputTextBox.Text))
            {
                initMailForms();
                loginForm.Hide();
                mailForm.Show();
            }
            else
            {
                switch (userCommandManager.Error)
                {
                    case "notuserexisterror": { MessageBox.Show("Podany użytkownik nie istnieje"); break; }
                    case "badpassworderror": { MessageBox.Show("Błędne hasło"); break; }
                    //Ten przypadek nie powinien wystąpić w kliencie
                    case "userisloggederror": { MessageBox.Show("Użytkownik jest zalogowany"); break; }
                    default:
                        {
                            MessageBox.Show("Nieznany błąd"); break;
                        }
                }
            }
        }

    }
}
