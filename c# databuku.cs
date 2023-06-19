using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikasidekstopperpustakaan
{
    class DataBuku : Connection 
    {
        protected static string constring = ConfigurationManager.ConnectionStrings["apkperpus"].ConnectionString;
        static MySqlConnection conn; //mengimport
        static MySqlCommand cmd;
        public int id_buku { get; set; }
        public int KodeBuku { get; set; }
        public String JudulBuku { get; set; }
        public String PenulisBuku { get; set; }
        public String PenerbitBuku { get; set; }
        public int TahunTerbit { get; set; }
        public String letakBuku { get; set; }

        public DataBuku() //di dalam konstruktor ada dua objek yaitu conn dan cmd
        {
            conn = new MySqlConnection(constring); //menghubungkan ke db localhost
            cmd = new MySqlCommand(); //utk menuliskan perintah sql (delete, insert, dll)
        }

        public static DataTable SelectAll()//jadikan method static, mendapatkan data dari database dg format datatable
        {
            conn = new MySqlConnection(constring);
            DataTable db = new DataTable(); // pembuatan objek datatable sebagai tempat penampungan data
            //dt = DataBuku.SelectAll;
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_buku", conn)) //proses pembuatan sql commant, set objek conn utk menghubungkan ke database di localhost
            {
                try
                {
                    conn.Open(); //koneksi dibuka
                    MySqlDataReader rdr = cmd.ExecuteReader(); //Commandnya/perintah select dieksekusi
                    db.Load(rdr); //datanya didapatkan dan disimpan dulu di objek reader (rdr), dari objek rdr dimasukkan lagi ke objek datatable (dt)
                    conn.Close(); //
                }
                catch (Exception e)
                {
                    String error = e.Message;
                }
            }
            return db;
        }

        public string insert()
        {
            string result = null;
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO tb_buku (KodeBuku,JudulBuku,PenulisBuku,PenerbitBuku,TahunTerbit,letakBuku) " +
                "VALUES (@KodeBuku,@JudulBuku,@PenulisBuku,@PenerbitBuku,@TahunTerbit,@letakBuku)", conn))
            {
                cmd.Parameters.AddWithValue("@id_buku", this.id_buku);
                cmd.Parameters.AddWithValue("@KodeBuku", this.KodeBuku);
                cmd.Parameters.AddWithValue("@JudulBuku", this.JudulBuku);
                cmd.Parameters.AddWithValue("@PenulisBuku", this.PenulisBuku);
                cmd.Parameters.AddWithValue("@PenerbitBuku", this.PenerbitBuku);
                cmd.Parameters.AddWithValue("@TahunTerbit", this.TahunTerbit);
                cmd.Parameters.AddWithValue("@letakBuku", this.letakBuku);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            return result;
        }

        public string Update()
        {
            string result = null;
            using (MySqlCommand cmd = new MySqlCommand("UPDATE tb_buku SET KodeBuku=@KodeBuku," +
                "JudulBuku=@JudulBuku,PenulisBuku=@PenulisBuku,PenerbitBuku=@PenerbitBuku,TahunTerbit=@TahunTerbit,letakBuku=@letakBuku WHERE id_buku=@id_buku", conn))
            {
                cmd.Parameters.AddWithValue("@id_buku", this.id_buku);
                cmd.Parameters.AddWithValue("@KodeBuku", this.KodeBuku);
                cmd.Parameters.AddWithValue("@JudulBuku", this.JudulBuku);
                cmd.Parameters.AddWithValue("@PenulisBuku", this.PenulisBuku);
                cmd.Parameters.AddWithValue("@PenerbitBuku", this.PenerbitBuku);
                cmd.Parameters.AddWithValue("@TahunTerbit", this.TahunTerbit);
                cmd.Parameters.AddWithValue("@letakBuku", this.letakBuku);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            return result;
        }

        public string Delete()
        {
            string result = null;
            using (MySqlCommand cmd = new MySqlCommand("DELETE FROM tb_buku WHERE id_buku=@id_buku ", conn))
            {
                cmd.Parameters.AddWithValue("@id_buku", this.id_buku);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            return result;
        }

        public static DataTable Select(String KodeBuku)
        {
            DataTable db = new DataTable();
            conn = new MySqlConnection(constring);
            cmd = conn.CreateCommand();
            if (KodeBuku != "")
            {
                cmd.CommandText = "SELECT * FROM tb_buku WHERE KodeBuku like @KodeBuku";
                cmd.Parameters.AddWithValue("@KodeBuku", "%" + KodeBuku + "%");
            }
            else cmd.CommandText = "SELECT * FROM tb_buku";
            try
            {
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                String s = cmd.CommandText;
                db.Load(rdr);
                conn.Close();
            }
            catch (Exception e)
            {
                String error = e.Message;
            }
            return db;
        }
    }
}
