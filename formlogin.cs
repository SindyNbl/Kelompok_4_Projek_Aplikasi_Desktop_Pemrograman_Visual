using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplikasidekstopperpustakaan
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.usernameLogin = textBoxUsername.Text;
            user.passwordLogin = textBoxPassword.Text;
            if (user.validasi())
            {
                FormMenuAdmin frmMenu = new FormMenuAdmin();
                frmMenu.Show();
                this.Hide();
            }
 else
            {
                MessageBox.Show("User gagal login");
                textBoxUsername.Text = "";
                textBoxPassword.Text = "";
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelUsername_Click(object sender, EventArgs e)
        {

        }

        private void labelPassword_Click(object sender, EventArgs e)
        {
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
