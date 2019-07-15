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
    class KullaniciClass
    { MySqlCommand cmd;
        MySqlDataAdapter adapter;


        string sorgu;
        public DataTable KullaniciKontrol(string kul,string sif)
        {
            
            DataTable dt = new DataTable();
            sorgu = "select * from kullanicilar where Kullanici_Adi='" + kul + "' and Sifre='" + sif + "' and Durum=1";
            cmd = new MySqlCommand(sorgu, Access.conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }

     
    }
}
