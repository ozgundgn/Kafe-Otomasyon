using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace KafeOtomasyon.cs
{
    class GarsonlarClass
    {
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        MySqlDataReader dr;
        Access acc = new Access();
        DataTable dt;
        string sorgu;

        public DataTable GarsonlarGetir()
        {
            dt = new DataTable();
            sorgu = "select * from kullanicilar as k left join kullanicitur as ku on k.KullaniciTur=ku.KullaniciTur_Id where Durum=1";
            cmd = new MySqlCommand(sorgu, Access.conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        public DataTable GelmisGecmisGarsonlarGetir()
        {
            dt = new DataTable();
            sorgu = "select * from kullanicilar as k left join kullanicitur as ku on k.KullaniciTur=ku.KullaniciTur_Id";
            cmd = new MySqlCommand(sorgu, Access.conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public MySqlDataReader GarsonlarOlustur()
        {
            Access.BaglantiKapat();
            if (acc.BaglantiDurumu())
            { System.Windows.Forms.MessageBox.Show("Baglandı"); }
            else { System.Windows.Forms.MessageBox.Show("baglanmadı");}
            
            sorgu = "select * from kullanicilar as k left join kullanicitur as ku on k.KullaniciTur=ku.KullaniciTur_Id where Durum=1";
            cmd = new MySqlCommand(sorgu, Access.conn);
            dr = cmd.ExecuteReader();

            return dr;
        }

        public DataTable GetirKullaniciTur()
        {
            dt = new DataTable();
            sorgu = "select * from kullanicitur";
            cmd = new MySqlCommand(sorgu, Access.conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public DataTable GetirKullaniciDurum()
        {
            dt = new DataTable();
            sorgu = "select * from durum where Durum_Id in (1,2)";
            cmd = new MySqlCommand(sorgu, Access.conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public bool GarsonEkle(string ad, string soyad, string tur, string tel)
        {
            try
            {
                sorgu = "insert into kullanicilar (Kullanici_Adi,Kullanici_Soyadi,KullaniciTur,Telefon,Durum,Sifre,GirisTarihi) values ('"+ad+"','"+soyad+"','"+tur+"','"+tel+"',1,'"+1234+"','"+DateTime.Now.ToString("yyyy-MM-dd")+"')";
                cmd = new MySqlCommand(sorgu, Access.conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }          
        }

        public bool GarsonGuncelle(string ad, string soyad, string tur, string tel,int kulid,string durum)
        {
           try
            {   sorgu = "update kullanicilar set Kullanici_Adi='" + ad + "',Kullanici_Soyadi='" + soyad + "',KullaniciTur='" + tur + "',Telefon='" + tel + "',Durum='"+durum+"' where Kullanici_Id=" + kulid;
                cmd = new MySqlCommand(sorgu, Access.conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool GarsonSil(int kulid)
        {
            try
            {
                sorgu = "update kullanicilar set CikisTarihi='"+DateTime.Now.ToString("yyyy-MM-dd")+"',Durum=2 where Kullanici_Id=" + kulid;
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
