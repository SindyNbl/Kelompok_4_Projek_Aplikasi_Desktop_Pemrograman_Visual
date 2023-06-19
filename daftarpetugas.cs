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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace aplikasidekstopperpustakaan
{
    public partial class DaftarPetugas : Form
    {
        public DaftarPetugas()
        {
            InitializeComponent();
        }
        void CreatePetugas(string id_petugas, string username, string password)
        {
            string connectionString = "Server=localhost;Database=apkperpus;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO tb_petugas (id_Petugas,usernamePetugas, passwordPetugas) VALUES (@id, @username, @password)";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id_petugas);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("petugas berhasil ditambahkan.");
                    }
                    else
                    {
                        MessageBox.Show("Gagal menambahkan admin.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                }
            }
        }
        private void RefreshDataGridView()
        {
            string connectionString = "Server=localhost;Database=apkperpus;Uid=root;Pwd=;";
            string query = "SELECT * FROM tb_petugas";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
        private void buttonSimpan_Click(object sender, EventArgs e)
        {
           
            string id_petugas = textBoxid.Text;
            string username = textBoxuser.Text;
            string password = textBoxpassword.Text;

            CreatePetugas( id_petugas, username, password);
            RefreshDataGridView();
        }

        private void DaftarPetugas_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=apkperpus;Uid=root;Pwd=;";
            string query = "SELECT * FROM tb_petugas";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Mendapatkan nilai dari sel yang diubah
            DataGridViewCell editedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string newValue = editedCell.Value.ToString();

            // Mendapatkan ID admin dari kolom pertama (kolom ID)
            int IdPetugas = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_Petugas"].Value);

            // Update data di database
            string connectionString = "Server=localhost;Database=apkperpus;Uid=root;Pwd=;";
            string updateQuery = $"UPDATE tb_petugas SET {editedCell.OwningColumn.Name} = @newValue WHERE id_Petugas = @IdPetugas";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@newValue", newValue);
                command.Parameters.AddWithValue("@IdPetugas", IdPetugas);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data berhasil diperbarui.");
                }
                else
                {
                    MessageBox.Show("Gagal memperbarui data.");
                }
            }

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                // Mengambil nilai dari TextBox
                string id_Petugas =textBoxid_edit.Text;
                string username = textBoxuser_edit.Text;
                string password = textBoxpassword_edit.Text;

                // Memperbarui data di DataGridView
                dataGridView1.Rows[selectedIndex].Cells["id_petugas"].Value = id_Petugas;
                dataGridView1.Rows[selectedIndex].Cells["usernamePetugas"].Value = username;
                dataGridView1.Rows[selectedIndex].Cells["passwordpetugas"].Value = password;
                

                // Mengosongkan TextBox setelah memperbarui data
                textBoxid_edit.Text = "";
                textBoxuser_edit.Text = "";
                textBoxpassword_edit.Text = "";
                string connectionString = "Server=localhost;Database=apkperpus;Uid=root;Pwd=;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE tb_petugas SET id_Petugas = @id, usernamePetugas = @username, "
                        + "passwordPetugas = @password WHERE id_Petugas = @id";

                    MySqlCommand command = new MySqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@id", id_Petugas);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@id_selected", dataGridView1.Rows[selectedIndex].Cells["id_Petugas"].Value);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Data berhasil diperbarui.");
            }
            else
            {
                MessageBox.Show("Pilih baris data terlebih dahulu.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Menampilkan data yang dipilih di TextBox
                textBoxid_edit.Text = row.Cells["id_Petugas"].Value.ToString();
                textBoxuser_edit.Text = row.Cells["usernamePetugas"].Value.ToString();
                textBoxpassword_edit.Text = row.Cells["passwordPetugas"].Value.ToString();
            }
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                int id_petugas = Convert.ToInt32(dataGridView1.Rows[selectedIndex].Cells["id_Petugas"].Value);

                // Menghapus baris dari DataGridView
                dataGridView1.Rows.RemoveAt(selectedIndex);

                // Menghubungkan ke database dan menjalankan pernyataan DELETE
                string connectionString = "server = localhost; database = apkperpus; uid = root; password =; ";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM tb_petugas WHERE id_Petugas = @Id_petugas";

                    MySqlCommand command = new MySqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@Id_petugas", id_petugas);

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
