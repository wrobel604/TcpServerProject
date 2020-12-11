using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSystemClient
{
    public partial class LoginForm : Form
    {
        TcpServerLibrary.StreamManager streamManager;
        public LoginForm(TcpClient client)
        {
            InitializeComponent();
            streamManager = new TcpServerLibrary.StreamManager(client.GetStream());
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            streamManager.Data = $"login;{LoginInput.Text};{PasswordInput.Text}";
            string answer = streamManager.Data;

            switch (answer)
            {
                case "Loged": {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }break;
                case "LoginError": { MessageBox.Show("Błędne dane logowania"); }break;
                default: { MessageBox.Show("Nieznany błąd"); }break;
            }
        }

        private void RecoveryLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LoginInput.Text.Length == 0)
            {
                MessageBox.Show("Podaj login, po czym naciśnij ponownie link");
            }
            else
            {
                streamManager.Data = $"recovery;{LoginInput.Text}";
                RecoveryForm recoveryForm = new RecoveryForm(streamManager.Data);
                if (recoveryForm.ShowDialog() == DialogResult.OK)
                {
                    streamManager.Data = recoveryForm.answer;
                    MessageBox.Show("Hasło: "+streamManager.Data);
                }
            }
        }
    }
}
