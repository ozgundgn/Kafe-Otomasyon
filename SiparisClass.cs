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
    class SiparisClass
    {
        string sorgu;
        DataTable dat;
        MySqlCommand cmd;
        Access conn = new Access();
        public string urunadi, adet2, fiyat;
        public bool deger, sil, ekle;
        public static string kullanciciTur;
        public bool SiparisKaydet(DataTable dt, List<UrunSınıf> c, string kullanicid, string masaid)
        {
            dat = new DataTable();
            try
            {                
                if (ekle == true)//ekleme veya guncelleme yapacak
                {
                    foreach (UrunSınıf item in c)
                    {
                        sorgu = "insert into siparis ( Masa_Id,Urun,Adet,Fiyat,Tarih,Garson,Odeme_Durumu,SiparisDurum) values ('" + masaid + "','" + item.ad + "','1','" + item.fiyat + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + kullanicid + "',2,2)";
                        cmd = new MySqlCommand(sorgu, Access.conn);
                        cmd.ExecuteNonQuery();
                    }
                    ekle = false;
                    goto etiket;
                }
                if (sil)
                {
                     foreach (UrunSınıf item in c)
                     {
                            sorgu = "delete from siparis where Urun='" + item.ad + "' and Masa_Id='" + item.mid + "' and Odeme_Durumu=2 order by Rand() Limit 1";
                            cmd = new MySqlCommand(sorgu, Access.conn);
                            cmd.ExecuteNonQuery();

                     }
                        sil = false;
                }               
                
                etiket:;
                return true;
        }
            catch (Exception)
            {
                return false;
            }
}
    }
}

        

    
