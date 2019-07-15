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
    class AyarlarClass
    {
        string sorgu;
        DataTable dt;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
       // MySqlDataReader dr;
        Access acc = new Access();

       public int masasayi;

        public bool SalonEkle(string slnisim,int drm)
        {
            try
            {
                sorgu = "insert into salonlar (Salon_Isim,Durum) values ('" + slnisim + "'," + drm + ")";
                cmd = new MySqlCommand(sorgu, Access.conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;

            }           
        }

        //public void SalonSil(int slnid)
        //{           
        //        sorgu = "delete from salonlar where Salon_Id=" + slnid;
        //        cmd = new MySqlCommand(sorgu, Access.conn);
        //        cmd.ExecuteNonQuery();          
        //}

        public DataTable GetirSalon()
        {
            dt = new DataTable();
            sorgu = @"select Salon_Id,Salon_Isim,d.Durum_Adi,d.Durum_Id from salonlar as s 
                      left join durum as d on d.Durum_Id=s.Durum";
            cmd = new MySqlCommand(sorgu, Access.conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            adapter.Dispose();
            return dt;
        }

        public DataTable GetirSalonMasa(int s)
        {

            dt = new DataTable();
            sorgu = @"select * from masalar where Salon=" + s;
            cmd = new MySqlCommand(sorgu, Access.conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            adapter.Dispose();
            return dt;
        }

        public DataTable GetirDurum()
        {    
            dt = new DataTable();
            sorgu = @"select * from durum where Durum_Id in (1,2)";
            cmd = new MySqlCommand(sorgu, Access.conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            adapter.Dispose();
            return dt;
        }

        public void SalonGuncelle(string text1, string text2,int salonid)
        {
            try
            {
                sorgu = "update salonlar set Salon_Isim='"+text1+"', Durum='"+text2+"' where Salon_Id="+salonid ;
                cmd = new MySqlCommand(sorgu, Access.conn);
                cmd.ExecuteNonQuery();
                //    return true;
            }
            catch (Exception)
            {
                //  return false;

            }
        }

        public bool MasaEkle(int slnid,int drm)
        {
           
            try
            {
                for (int i = 0; i < masasayi; i++)
                {
                    sorgu = "insert into masalar (Salon,Durum) values ('" + slnid + "'," + drm + ")";
                    cmd = new MySqlCommand(sorgu, Access.conn);
                    cmd.ExecuteNonQuery();
                   
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool MasaSilStore(int salonid)
        {
         
            try
            {
                cmd = new MySqlCommand("MasaSilme", Access.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("slnid", salonid));
                cmd.Parameters["slnid"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable GetirMasa()
        {
            dt = new DataTable();
            sorgu = @"select Count(Masa_Id) as Masa,d.Durum_Adi, s.Salon_Isim from masalar as m
                      left join durum as d on d.Durum_Id=m.Durum
                      left join salonlar as s on m.Salon=s.Salon_Id where m.Durum=1 group by s.Salon_Isim";
            cmd = new MySqlCommand(sorgu, Access.conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            adapter.Dispose();
            return dt;
        }

        public DataTable GetirKategori()
        {
      
            dt = new DataTable();
            sorgu = @"select UrunKategori_Id,d.Durum_Adi,Isim,d.Durum_Id from urunkategori as u left join durum as d on d.Durum_Id=u.Durum";
            cmd = new MySqlCommand(sorgu, Access.conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            adapter.Dispose();
            return dt;
        }

        public bool KategoriEkle(string ad,string durum)
        {
            try
            {
                sorgu = "insert into urunkategori (Isim,Durum) values ('" + ad + "'," + durum + ")";
                cmd = new MySqlCommand(sorgu, Access.conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool kategoriDegistir(string ad,string durum,int id)
        {
            try
            {
                sorgu = "update urunkategori set Isim='"+ad+"',Durum='"+ durum+"' where UrunKategori_Id="+id;
                cmd = new MySqlCommand(sorgu, Access.conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool UrunDegistir(string ad, string fyt,string kategori,string drm,int id)
        {
            try
            {
                sorgu = "update urunler set Urun_Adi='" + ad + "',Birim_Fiyat='"+fyt+"',UrunKategori='"+kategori+"',Durum='"+drm+"'  where Urunler_Id="+id;
                cmd = new MySqlCommand(sorgu, Access.conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UrunEkle(string ad, string fyt,string kategori,string drm)
        {
            try
            {
                sorgu = "insert into urunler (Urun_Adi,Birim_Fiyat,UrunKategori,Durum) values ('" + ad + "','" + fyt + "','"+kategori+"','"+drm+"')";
                cmd = new MySqlCommand(sorgu, Access.conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public DataTable GetirUrunler()
        {
            dt = new DataTable();
            sorgu = @"select u.Urunler_Id,d.Durum_Adi,u.Urun_Adi,u.Birim_Fiyat,ur.Isim from urunler as u left join durum as d on d.Durum_Id=u.Durum
                                                                       left join urunkategori as ur on ur.UrunKategori_Id=u.UrunKategori";
            cmd = new MySqlCommand(sorgu, Access.conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            adapter.Dispose();
            return dt;
        }

        public DataTable GetirOzet(string ad,string trh1,string trh2)
        {
            dt = new DataTable();
            sorgu = @"select s.Tarih,s.Siparis_Id,s.Masa_Id,k.Kullanici_Adi,s.Urun,s.Fiyat from siparis as s left join kullanicilar as k on k.Kullanici_Id=s.Garson where k.Kullanici_Adi like '" + ad + "%' and s.Tarih between '" +trh1 + "' and '"+trh2+"' order by s.Masa_Id asc";
            cmd = new MySqlCommand(sorgu, Access.conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            adapter.Dispose();
            return dt;
        }
      
    }

}
