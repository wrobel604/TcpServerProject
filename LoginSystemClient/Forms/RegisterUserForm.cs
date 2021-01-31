using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSystemClient
{
    public partial class RegisterUserForm : Form
    {
        public RegisterUserForm()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void PasswordRepeatInput_TextChanged(object sender, EventArgs e)
        {
            if (PasswordInput.Text == PasswordRepeatInput.Text)
            {
                PasswordInput.BackColor = Color.LightGreen;
                PasswordRepeatInput.BackColor = Color.LightGreen;
            }
            else
            {
                PasswordInput.BackColor = Color.White;
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (PasswordInput.Text != PasswordRepeatInput.Text) { MessageBox.Show("Hasła nie są takie same"); } else
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
