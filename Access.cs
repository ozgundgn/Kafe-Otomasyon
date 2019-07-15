using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;


namespace KafeOtomasyon.cs
{
    class Access
    {

        private static string dbhost = "localhost";
        private static string dbusername = "root";
        private static string dbpassword = "qwerty01";
        private static string dbName = "kafe";
        private static string dbPort = "3306";

        public static MySqlConnection conn;

        public bool BaglantiDurumu()
        {
            if (conn == null || conn.State != ConnectionState.Open)
            {
                try
                {
                    conn = new MySqlConnection(string.Format("Server={0};Port={4};Database={1};Uid={2};Pwd={3};", dbhost, dbName, dbusername, dbpassword,dbPort));
                    conn.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            else
            { return true; }
        }

        public static bool BaglantiKapat()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
                return true;
            }
                return false;           
        }
              
    }
}
