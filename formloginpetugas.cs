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
    public partial class FormLoginPetugas : Form
    {
        public FormLoginPetugas()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            petugas petugas = new petugas();
            petugas.usernamePetugas = textBoxUsername.Text;
            petugas.passwordPetugas = textBoxPassword.Text;
            if (petugas.validasi())
            {
                FormMenuPetugas frmMenu = new FormMenuPetugas();
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

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
