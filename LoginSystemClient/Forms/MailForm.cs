using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSystemClient.Forms
{
    public partial class MailForm : Form
    {
        UserCommandManager userCommand;
        List<LoginSystem.Models.Message> messageList;
        public MailForm( UserCommandManager commandManager)
        {
            InitializeComponent();
            userCommand = commandManager;
            fillMessageView();
        }

        private void wylogujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void wyjdźToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            userCommand = null;
            DialogResult = DialogResult.Abort;
        }
        private void sendMail(string content="", string receiver="")
        {
            SendMailForm sendMailForm = new SendMailForm();
            sendMailForm.ReceiverTextBox.Text = receiver;
            sendMailForm.ContentTextBox.Text = content;
            if (sendMailForm.ShowDialog() == DialogResult.OK)
            {
                bool result = userCommand.SendMessage(sendMailForm.ReceiverTextBox.Text, sendMailForm.ContentTextBox.Text);
                if (result) { MessageBox.Show("Wiadomość wysłana"); }
                else
                {
                    if (userCommand.Error == "notuserexisterror") { MessageBox.Show("Adresat nie istnieje"); } else { MessageBox.Show("Nie udało się wysłać wiadomości"); }
                }
            }
        }

        private void napiszWiadomośćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sendMail();
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            ListViewItem item = (MessageList.SelectedItems.Count > 0) ? MessageList.SelectedItems[0] : null;
            if (item != null)
            {
                sendMail("", item.Text);
            }
        }

        private void NextSendButton_Click(object sender, EventArgs e)
        {
            sendMail(MessageTextBox.Text);
        }

        private void zmieńHasłoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeForm changeForm = new ChangeForm();
            changeForm.label1.Text = "Nowe hasło";
            changeForm.label2.Text = "Powtórz hasło";
            changeForm.Input1.UseSystemPasswordChar = true;
            changeForm.Input2.UseSystemPasswordChar = true;
            if(changeForm.ShowDialog() == DialogResult.OK)
            {
                if (changeForm.Input1.Text == changeForm.Input2.Text && changeForm.Input1.Text != "")
                {
                    if (userCommand.ChangePassword(changeForm.Input1.Text))
                    {
                        MessageBox.Show("Hasło zmienione");
                    }
                    else
                    {
                        MessageBox.Show("Hasło jest zbyt proste");
                    }
                }
                else { MessageBox.Show("Hasła nie są identyczne"); }
            }
        }

        private void zmieńPytanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeForm changeForm = new ChangeForm();
            changeForm.label1.Text = "Nowe pytanie";
            changeForm.label2.Text = "Odpowiedź";
            changeForm.Input1.UseSystemPasswordChar = false;
            changeForm.Input2.UseSystemPasswordChar = false;
            if(changeForm.ShowDialog() == DialogResult.OK)
            {
                if (changeForm.Input1.Text != "" && changeForm.Input2.Text != "")
                {
                    if (userCommand.ChangeQuestion(changeForm.Input1.Text, changeForm.Input2.Text))
                    {
                        MessageBox.Show("Pytanie i odpowiedź zmienione");
                    }
                }
            }
        }

        private void odświeżToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fillMessageView();
        }

        private void fillMessageView()
        {
            MessageList.Items.Clear();
            messageParser();
            MessageTextBox.Text = "";
            foreach(var m in messageList.Select(x => x.Sender).Distinct())
            {
                ListViewItem item = new ListViewItem(m);
                MessageList.Items.Add(item);
            }
        }
        private void messageParser()
        {
            string messages = userCommand.ReadMessage().Trim();
            if(userCommand.Error == "")
            {
                string[] msg_array = messages.Split('\n');
                messageList = new List<LoginSystem.Models.Message>(msg_array.Length);
                foreach (string msg in msg_array)
                {
                    string[] data = msg.Split(';');
                    LoginSystem.Models.Message message = new LoginSystem.Models.Message(data[0], data[1], data[3]);
                    message.DateTime = DateTime.Parse(data[2]);
                    messageList.Add(message);
                }
            }
        }

        private void MessageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageTextBox.Text = "";
            ListViewItem item = (MessageList.SelectedItems.Count > 0) ? MessageList.SelectedItems[0] : null;
            if (item != null)
            {
                var messages = messageList.Where(x => x.Sender == item.Text);
                foreach(var message in messages)
                {
                    MessageTextBox.Text += $"Data: {message.DateTime.ToString()}{Environment.NewLine}{Environment.NewLine}{message.Content}{Environment.NewLine}{Environment.NewLine}";
                }
            }
        }
    }
}
