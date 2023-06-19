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
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLogin frmMenu = new FormLogin();
            frmMenu.Show();
        }

        private void buttonPetugas_Click(object sender, EventArgs e)
        {
            FormLoginPetugas frmMenu = new FormLoginPetugas();
            frmMenu.Show();
        }

        private void buttonAnggota_Click(object sender, EventArgs e)
        {
            FormMenuAnggota frmMenu = new FormMenuAnggota();
            frmMenu.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
