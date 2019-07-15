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
    class SalonlarClass
    {
        Access acc = new Access();
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        MySqlDataReader dr;
        DataTable dt;
        string sorgu;
      
        public DataTable GetirSalon(int s)
        {            
                dt = new DataTable();
                sorgu = @"select COUNT(Masa_Id),Masa_Id as sayi from masalar as m left join salonlar as sa on sa.Salon_Id=m.Salon 
                      left join durum as d on d.Durum_Id=m.Durum where Salon_Id=" + s;
                cmd = new MySqlCommand(sorgu, Access.conn);
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
          
            adapter.Dispose();
                return dt;
        }

        public int SalonMasaSayi(int slnid)
        {        
            int btn = 0;
            sorgu = "select COUNT(*) from masalar where Durum=1 and Salon=" + slnid;
            cmd = new MySqlCommand(sorgu, Access.conn);
           dr = cmd.ExecuteReader();
            try
            {
                if (dr.Read())
                {
                    btn = Convert.ToInt32(dr[0]);
                }
                return btn;
            }
            catch (Exception)
            {
                btn = 0;
                return btn;
            }
           
        }

        public DataTable GetirSiparis(int id)
        {
           
            dt = new DataTable();
            sorgu = @"select Masa_Id,Urun,UrunKategori,Adet,Fiyat from siparis as s left join urunler as u on u.Urun_Adi=s.Urun where s.Masa_Id=" + id +" and s.Odeme_Durumu=2";
            cmd = new MySqlCommand(sorgu, Access.conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            adapter.Dispose();
            return dt;
        }

        public MySqlDataReader GetirKategoriler()
        {
         
            sorgu = "select UrunKategori_Id,Isim,Durum from urunkategori where Durum=1";
            cmd = new MySqlCommand(sorgu, Access.conn);
            dr = cmd.ExecuteReader();
            return dr;

        }

        public MySqlDataReader GetirUrun(string id)
        {          
            sorgu = "select * from urunler where Durum=1 and UrunKategori='"+id+"'";
            cmd = new MySqlCommand(sorgu, Access.conn);
            dr = cmd.ExecuteReader();
            return dr;
        }

        public MySqlDataReader MasaRengi(int salonid)
        {     
            sorgu = "select * from masalar where Salon='"+salonid+"'";
            cmd = new MySqlCommand(sorgu, Access.conn);
            dr = cmd.ExecuteReader();
            return dr;            
        }

        public DataTable MasadakiSiparis(int masaid)
        {
            DataTable dt = new DataTable();
            sorgu = "select * from siparis where Masa_Id=" + masaid + " and Odeme_Durumu=2";
            cmd = new MySqlCommand(sorgu, Access.conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public MySqlDataReader TasinilabilirMasalar()
        {
            sorgu = "select * from masalar as m left join salonlar as s on s.Salon_Id=m.Salon where m.Durum in (1,4) and s.Durum=1";
            cmd = new MySqlCommand(sorgu, Access.conn);
            dr = cmd.ExecuteReader();
            return dr;
        }

        public DataTable TasinilacakMasaSiparis(int t)
        {
            dt = new DataTable();
            sorgu = "select * from siparis as s left join urunler as u on u.Urun_Adi = s.Urun where s.Masa_Id = " + t +" and s.Odeme_Durumu = 2";
            cmd = new MySqlCommand(sorgu, Access.conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public DataTable TasinacakMasaSiparis(int t)
        {
            dt = new DataTable();
            sorgu = "select * from siparis as s left join urunler as u on u.Urun_Adi = s.Urun where s.Masa_Id = " + t + " and s.Odeme_Durumu = 2";
            cmd = new MySqlCommand(sorgu, Access.conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public void SiparisTasi(int yenimasaid,string urun,string adet,string fiyat,string tarih,string garson,string odemedurumu,string siparisdrm,int masa2)
        {
            sorgu = "insert into siparis (Masa_Id,Urun,Adet,Fiyat,Tarih,Garson,Odeme_Durumu,SiparisDurum,TasindigiMasa) values ('"+yenimasaid+"','"+urun+"','"+adet+"','"+fiyat+"','"+tarih+"','"+garson+"','"+odemedurumu+"','"+ siparisdrm+"','"+ masa2+"')";
            cmd = new MySqlCommand(sorgu, Access.conn);
        
            //cmd = new MySqlCommand("SiparisTasima", Access.conn);
            //cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.Add(new MySqlParameter("yenimasaid", yenimasaid));
            //cmd.Parameters["yenimasaid"].Direction = ParameterDirection.Input;

            //cmd.Parameters.Add(new MySqlParameter("urun", urun));
            //cmd.Parameters["urun"].Direction = ParameterDirection.Input;

            //cmd.Parameters.Add(new MySqlParameter("adet", adet));
            //cmd.Parameters["adet"].Direction = ParameterDirection.Input;

            //cmd.Parameters.Add(new MySqlParameter("fiyat", fiyat));
            //cmd.Parameters["fiyat"].Direction = ParameterDirection.Input;

            //cmd.Parameters.Add(new MySqlParameter("tarih", tarih));
            //cmd.Parameters["tarih"].Direction = ParameterDirection.Input;

            //cmd.Parameters.Add(new MySqlParameter("garson", garson));
            //cmd.Parameters["garson"].Direction = ParameterDirection.Input;


            //cmd.Parameters.Add(new MySqlParameter("odemedurumu", odemedurumu));
            //cmd.Parameters["odemedurumu"].Direction = ParameterDirection.Input;

            //cmd.Parameters.Add(new MySqlParameter("siparisdrm", siparisdrm));
            //cmd.Parameters["siparisdrm"].Direction = ParameterDirection.Input;

            //cmd.Parameters.Add(new MySqlParameter("masa2", masa2));
            //cmd.Parameters["masa2"].Direction = ParameterDirection.Input;

            cmd.ExecuteNonQuery();
        }

        public void MasaDurumDegistir(string name)
        {
            sorgu = "update masalar set Durum=1 where Masa_Id='" + name + "'";
            cmd = new MySqlCommand(sorgu, Access.conn);
            cmd.ExecuteNonQuery();
        }

        public void SiparisSil(int eskimasa,string urun,string odemedurumu,string siparisdrm)
        {
            sorgu = "delete from siparis where Masa_Id='"+eskimasa+"' and Odeme_Durumu='"+odemedurumu+"' and Urun='"+urun+"' and SiparisDurum='"+siparisdrm+"' order by Rand() Limit 1";
            cmd = new MySqlCommand(sorgu, Access.conn);
            cmd.ExecuteNonQuery();

        }
    }
}
