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
    public partial class RegisterUserForm : Form
    {
        TcpServerLibrary.StreamManager streamManager;
        public RegisterUserForm(TcpClient client)
        {
            InitializeComponent();
            streamManager = new TcpServerLibrary.StreamManager(client.GetStream());
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {

        }
    }
}
