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
    public partial class RecoveryForm : Form
    {
        public string answer { get => Answer.Text; }
        public RecoveryForm(string question)
        {
            InitializeComponent();
            Question.Text = question;
        }

        private void Send_Click(object sender, EventArgs e)
        {
            if (answer.Length == 0)
            {
                MessageBox.Show("Nie podano odpowiedzi");
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
