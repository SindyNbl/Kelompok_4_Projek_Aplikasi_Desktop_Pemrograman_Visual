using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikasidekstopperpustakaan
{
    class User : Connection 
    {
        protected String constring = "server = localhost; database = apkperpus; uid = root; SslMode = none; password =; ";
        //protected String constring = ConfigurationManager.ConnectionStrings["apkperpus"].ConnectionString;
        static MySqlConnection conn; //mengimport
        static MySqlCommand cmd;

        public int id_Login { get; set; }
        public String usernameLogin { get; set; }
        public String passwordLogin { get; set; }

        public User() //di dalam konstruktor ada dua objek yaitu conn dan cmd
        {
            conn = new MySqlConnection(constring); //menghubungkan ke db localhost
            cmd = new MySqlCommand(); //utk menuliskan perintah sql (delete, insert, dll)
        }

        public bool validasi()
        {
            bool result = false;
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM tb_admin WHERE usernameLogin=@username AND passwordLogin=(@password)";
            cmd.Parameters.AddWithValue("@username", this.usernameLogin);
            cmd.Parameters.AddWithValue("@password", this.passwordLogin);
            try
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    //user = new User(Convert.ToInt16(rdr["id_user"]), rdr["username"].ToString(), rdr["password"].ToString());
                    id_Login = Convert.ToInt16(rdr["id_Login"]);
                    result = true;
                }
            }
            catch (Exception e)
            {
                String error = e.Message;
            }
            conn.Close();
            return result;
        }
    }
}

