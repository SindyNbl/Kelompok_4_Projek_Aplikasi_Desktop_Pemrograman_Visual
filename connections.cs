using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace aplikasidekstopperpustakaan
{
    class Connection
    {
        public static MySqlConnection Conn = new MySqlConnection();

        static string server = "localhost;";
        static string database = "apkperpus;";
        static string Uid = "roo;t";
        static string password = ";";

        public static MySqlConnection dataSource()
        {
            Conn = new MySqlConnection($"server={server} database={database} Uid={Uid} password={password}");
            return Conn;
        }

        public void ConnOpen()
        {
            dataSource();
            Conn.Open();
        }

        public void ConnClose()
        {
            dataSource();
            Conn.Close();
        }
    }
}
