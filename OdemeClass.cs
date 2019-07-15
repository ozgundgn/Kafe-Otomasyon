using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace KafeOtomasyon.cs
{
    class OdemeClass
    {
     
        MySqlCommand cmd;

        public bool OdemeAl(ArrayList dizi,int odemesekli,int masaid)
        {
            try
            {
                foreach (string a in dizi)
            {

                cmd = new MySqlCommand("OdemeAl", Access.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("urunadi", a));
                cmd.Parameters["urunadi"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new MySqlParameter("tbid", masaid));
                cmd.Parameters["tbid"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new MySqlParameter("paystyle", odemesekli));
                cmd.Parameters["paystyle"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                
            }
            return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool MasaIptal(int mi)
        {
            try
            {
                string sorgu = "update masalar set Durum=1 where Masa_Id=" + mi;
                cmd = new MySqlCommand(sorgu, Access.conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
    


        }
    }
}
