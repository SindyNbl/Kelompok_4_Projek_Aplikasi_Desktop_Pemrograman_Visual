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
    public partial class FormDataBuku : Form
    {
        public FormDataBuku()
        {
            InitializeComponent();
        }

        private void FormDataBuku_Load(object sender, EventArgs e)
        {
            loadDataBuku();
        }


        private void loadDataBuku()
        {
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

        private void ChildFormClosing(object sender, FormClosingEventArgs e)
        {
            loadDataBuku();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FormDataBuku databuku = new FormDataBuku();
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            textBoxid_buku.Text = Convert.ToString(selectedRow.Cells["id_buku"].Value);
            textBoxKodeBuku.Text = Convert.ToString(selectedRow.Cells["KodeBuku"].Value);
            textBoxJudul.Text = Convert.ToString(selectedRow.Cells["JudulBuku"].Value);
            textBoxPenulis.Text = Convert.ToString(selectedRow.Cells["PenulisBuku"].Value);
            textBoxPenerbit.Text = Convert.ToString(selectedRow.Cells["PenerbitBuku"].Value);
            textBoxTahunTerbit.Text = Convert.ToString(selectedRow.Cells["TahunTerbit"].Value);
            textBoxLetakBuku.Text = Convert.ToString(selectedRow.Cells["letakBuku"].Value);
        }
        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
        void Createbuku(string id_buku, string kodebuku, string judulbuku, string penulisbuku, string penerbitbuku, string tahunterbit, string letakbuku)
        {

            string connectionString = "server = localhost; database = apkperpus; uid = root; password =; ";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO tb_buku (id_buku, KodeBuku, JudulBuku, PenulisBuku, PenerbitBuku, TahunTerbit, letakbuku) VALUES (@Id, @kode, @judul, @penulis, @penerbit, @tahun, @letak)";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id_buku);
                    command.Parameters.AddWithValue("@kode", kodebuku);
                    command.Parameters.AddWithValue("@judul", judulbuku);
                    command.Parameters.AddWithValue("@penulis", penulisbuku);
                    command.Parameters.AddWithValue("@penerbit", penerbitbuku);
                    command.Parameters.AddWithValue("@tahun", tahunterbit);
                    command.Parameters.AddWithValue("@letak", letakbuku);




                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("buku berhasil ditambahkan.");
                    }
                    else
                    {
                        MessageBox.Show("Gagal menambahkan barang.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                }
            }
        }
        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            string id_buku = textBoxid_buku.Text;
            string kodebuku = textBoxKodeBuku.Text;
            string judulbuku = textBoxJudul.Text;
            string penulisbuku = textBoxPenulis.Text;
            string penerbitbuku = textBoxPenerbit.Text;
            string tahunterbit = textBoxTahunTerbit.Text;
            string letakbuku = textBoxLetakBuku.Text;


            Createbuku(id_buku, kodebuku, judulbuku, penulisbuku, penerbitbuku, tahunterbit, letakbuku);
            RefreshDataGridView();
        }
        private void RefreshDataGridView()
        {
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
        private void buttonHapus_Click(object sender, EventArgs e)
        {
            DataBuku databuku = new DataBuku();
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            databuku.JudulBuku = textBoxJudul.Text;
            String id = textBoxid_buku.Text;
            if (id != null)
            {
                databuku.id_buku = 1 * Convert.ToInt32(id);
            }
            else { databuku.id_buku = 1; }
            databuku.id_buku = Convert.ToInt32(textBoxid_buku.Text);
            DialogResult result = MessageBox.Show("Yakin hapus data barang " + databuku.JudulBuku + databuku.id_buku + " ?", "Hapus Data Barang", buttons);
            //String response = databarang.Update();
            if (result == DialogResult.Yes)
            {
                string response;

                response = databuku.Delete();
                if (response == null) MessageBox.Show("Sukses");
                else MessageBox.Show(response);
                textBoxKodeBuku.Text = "";
                textBoxJudul.Text = "";
                textBoxPenulis.Text = "";
                textBoxPenerbit.Text = "";
                textBoxTahunTerbit.Text = "";
                textBoxLetakBuku.Text = "";
                loadDataBuku();
            }

            else
            {
                //MessageBox.Show("Hapus data barang gagal. Error: " + response);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Menampilkan data yang dipilih di TextBox
                
            }
        }

        private void buttonHapus_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                int id_buku = Convert.ToInt32(dataGridView1.Rows[selectedIndex].Cells["id_buku"].Value);

                // Menghapus baris dari DataGridView
                dataGridView1.Rows.RemoveAt(selectedIndex);

                // Menghubungkan ke database dan menjalankan pernyataan DELETE
                string connectionString = "server = localhost; database = apkperpus; uid = root; password =; ";
               
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM tb_buku WHERE id_buku = @Id_buku";

                    MySqlCommand command = new MySqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@Id_buku", id_buku);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Data berhasil dihapus.");
            }
            else
            {
                MessageBox.Show("Pilih baris data terlebih dahulu.");
            }

        }
    }
}
