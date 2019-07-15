using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;

namespace KafeOtomasyon.cs
{   
    class MutfakClass
    {
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;
        
        string sorgu;

        public MySqlDataReader MasadakiUrunler(int tableid)
        {           
            sorgu = @"select Urun,Adet,SiparisDurum from siparis as s left join urunler as u on u.Urun_Adi=s.Urun 
                               where s.Masa_Id=" + tableid + " and s.Odeme_Durumu=2 and s.SiparisDurum in (2,1) and u.UrunKategori in (3,4,5,6)";
            cmd = new MySqlCommand(sorgu, Access.conn);
            dr = cmd.ExecuteReader();
            return dr;
        }

        public MySqlDataReader SiparisliMasa()
        {
            sorgu = "select m.Masa_Id,s.Salon_Isim,u.Urun_Adi from masalar as m left join salonlar as s on s.Salon_Id=m.Salon left join siparis as sip on sip.Masa_Id=m.Masa_Id left join urunler as u on u.Urun_Adi=sip.Urun  where sip.SiparisDurum in(2,1) and sip.Odeme_Durumu=2 and m.Durum=4 and u.Urunkategori in(3,4,5,6) group by m.Masa_Id";
          //  sorgu = @"select m.Masa_Id,s.Salon_Isim from masalar as m left join salonlar as s on s.Salon_Id=m.Salon where m.Durum=4";
            cmd = new MySqlCommand(sorgu, Access.conn);
            dr = cmd.ExecuteReader();
            return dr;
        }

        public void SiparisHazir(ArrayList dizi, int masaid)
        {
            for (int i = 0; i < dizi.Count; i++)
            {              
                sorgu = "update siparis set SiparisDurum=1 where Masa_Id=" + masaid + " and Urun='" + dizi[i].ToString() + "' and SiparisDurum=2 and Odeme_Durumu=2";
                cmd = new MySqlCommand(sorgu, Access.conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void SiparisAlindi(SortedList dizi)
        {
            SortedList liste = new SortedList();

                foreach (DictionaryEntry item in dizi)
                {
                string[] array = item.Key.ToString().Split('_');
                string urunadi = array[0];
                
                sorgu = "update siparis set SiparisDurum=3 where Masa_Id=" + item.Value.ToString() + " and Urun='" +urunadi + "' and Odeme_Durumu=2 and SiparisDurum=1";
                cmd = new MySqlCommand(sorgu, Access.conn);
                cmd.ExecuteNonQuery();
                }                     
        }
    }
}
