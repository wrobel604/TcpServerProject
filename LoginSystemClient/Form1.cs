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
    public partial class Form1 : Form
    {
        TcpClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void Login(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient("127.0.0.1", 5555);
                this.Hide();
                LoginForm lf = new LoginForm(client);
                DialogResult dialogResult = lf.ShowDialog();
                if (dialogResult != DialogResult.OK)
                {
                    this.Close();
                }
            }catch(SocketException)
            {
                MessageBox.Show("Nie można nawiązać połączenia z serwerem");
                this.Close();
            }
            
        }
    }
}
