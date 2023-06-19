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
    public partial class Peminjaman : Form
    {
        public Peminjaman()
        {
            InitializeComponent();
        }
        void CreatePinjam(string id_pinjam, string tanggal, string total, string kode_buku, string judul, string pengarang, string id_anggota, string nama_anggota)
        {
            string connectionString = "Server=localhost;Database=apkperpus;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO peminjaman (id_pinjam, tanggal_pinjam, total_pinjam, kode_buku, judul_buku, pengarang_buku, id_anggota, nama_anggota) VALUES (@id, @tanggal, @total, @kode, @judul, @pengarang, @id_anggota, @nama_anggota)";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id_pinjam);
                    command.Parameters.AddWithValue("@tanggal", tanggal);
                    command.Parameters.AddWithValue("@total", total);
                    command.Parameters.AddWithValue("@kode", kode_buku);
                    command.Parameters.AddWithValue("@judul", judul);
                    command.Parameters.AddWithValue("@pengarang", pengarang);
                    command.Parameters.AddWithValue("@id_anggota", id_anggota);
                    command.Parameters.AddWithValue("@nama_anggota", nama_anggota);



                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("peminjaman berhasil ditambahkan.");
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

        private void btn_simpan_Click(object sender, EventArgs e)
        {
            string id_pinjam = textBox_id.Text;
            string tanggal = date.Text;
            string total = numeric.Text;
            string kode_buku = textBox_kode.Text;
            string judul = textBox_judul.Text;
            string pengarang = textBox_pengarang.Text;
            string id_anggota = textBox_idanggota.Text;
            string nama_anggota = textBox_namaanggota.Text;


            CreatePinjam( id_pinjam, tanggal, total, kode_buku,  judul,  pengarang,  id_anggota,  nama_anggota);
        }

        private void Batal_Click(object sender, EventArgs e)
        {
            textBox_id.Text = "";
            date.Text = DateTime.Now.ToString();
            numeric.Text = "0";
            textBox_kode.Text = "";
            textBox_judul.Text = "";
            textBox_pengarang.Text = "";
            textBox_idanggota.Text = "";
            textBox_namaanggota.Text = "";
        }
    }
}
