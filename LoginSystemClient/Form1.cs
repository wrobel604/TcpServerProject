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
        FormsManager formsManager;
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                TcpClient tcpClient = new TcpClient(IpTextBox.Text, (int)PortNumberBox.Value);
                this.Hide();
                formsManager = new FormsManager(new UserCommandManager(tcpClient));
                formsManager.Run();
                tcpClient.Close();
                this.Close();
            }catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
