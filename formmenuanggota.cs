using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace aplikasidekstopperpustakaan
{
    public partial class FormMenuAnggota : Form
    {
        public FormMenuAnggota()
        {
            InitializeComponent();
        }

        private void FormMenuAnggota_Load(object sender, EventArgs e)
        {
            //loadFormMenuAnggota();
            string connectionString = "server = localhost; database = apkperpus; uid = root; password =; ";
            string query = "SELECT * FROM tb_buku";
            
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        
    }
}
