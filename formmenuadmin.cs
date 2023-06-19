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
    public partial class FormMenuAdmin : Form
    {
        public FormMenuAdmin()
        {
            InitializeComponent();
        }

        private void buttonDaftarBuku_Click(object sender, EventArgs e)
        {
            FormDataBuku frmMenu = new FormDataBuku();
            frmMenu.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormHome frmMenu = new FormHome();
            frmMenu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DaftarPetugas formpetugas= new DaftarPetugas();
            formpetugas.Show();
        }
    }
}
