using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace KafeOtomasyon.cs.Models
{
    class Yukleme
    {
        MySqlDataReader dr;
        MySqlCommand cmd;
        Access acc = new Access();

        string sorgu;

        public MySqlDataReader SalonlariYaz()
        {
            dr.Close();
            sorgu = "select * from salonlar where Durum=1";
                cmd = new MySqlCommand(sorgu, Access.conn);
          
            dr = cmd.ExecuteReader();
                return dr;
            
        }
      

        public int SalonButonGenisligi(int gr)
        {
           
            int btn=0;
            sorgu = "select COUNT(*) from salonlar where Durum=1";
            cmd = new MySqlCommand(sorgu, Access.conn);
           dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                btn = Convert.ToInt16(dr[0]);
            }

           int btnweight =( gr / btn)-30;
         return btnweight;
          
        }

        public int ButonWeight(int gr)
        {
         
            int btn = 0;
            sorgu = "select COUNT(*) from masalar where Durum=1";
            cmd = new MySqlCommand(sorgu, Access.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                btn = Convert.ToInt16(dr[0]);
            }

            int btnweight = (gr / btn)-20;
        
            return btnweight;
        }


    }
   
}
