using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KafeOtomasyon.cs
{
    public partial class MasaTasimaForm : Form
    {
        public MasaTasimaForm()
        {
            InitializeComponent();
        }
        Button btnM;
        MySqlDataReader dr;
        SalonlarClass sc = new SalonlarClass();
        public static int eskimasa;
        int yenimasa;
        string urun, adet, fiyat,garson, odemesekli, odemedurum, siparisdurum;
        DateTime tarih;
        DataTable dt;
        private void MasaTasimaForm_Load_1(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("Urun", typeof(string));
            dt.Columns.Add("Adet", typeof(string));
            dt.Columns.Add("Fiyat", typeof(string));
            dt.Columns.Add("Tarih", typeof(DateTime));
            dt.Columns.Add("Garson", typeof(string));
            dt.Columns.Add("OdemeDurum", typeof(string));
            dt.Columns.Add("SiparisDurum", typeof(string));
            dt.Columns.Add("EskiMasaId", typeof(string));

            dtgMasa1.DataSource = sc.TasinacakMasaSiparis(eskimasa);
            dtgMasa1.Columns["Siparis_Id"].Visible = false;
            dtgMasa1.Columns["Masa_Id"].HeaderText = "Masa No";
            dtgMasa1.Columns["Fiyat"].Visible = false;
            dtgMasa1.Columns["Tarih"].Visible = false;
            dtgMasa1.Columns["Garson"].Visible = false;
            dtgMasa1.Columns["Odeme_Sekli"].Visible = false;
            dtgMasa1.Columns["SiparisDurum"].Visible = false;
            dtgMasa1.Columns["Urunler_Id"].Visible = false;
            dtgMasa1.Columns["UrunKategori"].Visible = false;
            dtgMasa1.Columns["Urun_Adi"].Visible = false;
            dtgMasa1.Columns["Odeme_Durumu"].Visible = false;
            dtgMasa1.Columns["Adet"].Visible = false;
            dtgMasa1.Columns["Birim_Fiyat"].Visible = false;
            dtgMasa1.Columns["Durum"].Visible = false;
            dtgMasa1.ClearSelection();

            lbl1.Text = masaadi;

            int x = 25;
            int y = 20;

            dr = sc.TasinilabilirMasalar();
            while (dr.Read())
            {
                btnM = new Button();
                btnM.Width = 75;
                btnM.Height = 75;
                btnM.Location = new Point(x, y);
                btnM.Name = dr["Masa_Id"].ToString();
                btnM.Text = dr["Salon_Isim"].ToString() + " " + "Masa" + " " + dr["Masa_Id"].ToString();
                btnM.FlatAppearance.BorderSize = 2;
                btnM.FlatStyle = FlatStyle.Flat;
                if (Convert.ToInt32(dr["Durum"]) == 1)
                {
                    btnM.BackColor = Color.Green;
                }
                else if (Convert.ToInt32(dr["Durum"]) == 4)
                {
                    btnM.BackColor = Color.DarkMagenta;
                }
                else
                {
                    btnM.BackColor = Color.DarkRed;
                }

                x += 90;
                if (x >= 550)
                {
                    y += 90;
                    x = 25;
                }
                groupBox1.Controls.Add(btnM);
                btnM.Click += new EventHandler(btnMClick);


            }
            dr.Close();
        }

        public static string masaadi;

        private void btnMClick(object sender, EventArgs e)
        {
           
            Button btnM = (Button)sender;
            lbl2.Text = btnM.Text;
            yenimasa = Convert.ToInt32(btnM.Name);
            dtgMasa2.DataSource = sc.TasinilacakMasaSiparis(yenimasa);

            dtgMasa2.Columns["Urun"].Visible = true;
            dtgMasa2.Columns["TasindigiMasa"].Visible = true;
            dtgMasa2.Columns["Siparis_Id"].Visible = false;
            dtgMasa2.Columns["Masa_Id"].Visible = true;
            dtgMasa2.Columns["Masa_Id"].HeaderText = "Masa No";
            dtgMasa2.Columns["Fiyat"].Visible = false;
            dtgMasa2.Columns["Tarih"].Visible = false;
            dtgMasa2.Columns["Garson"].Visible = false;
            dtgMasa2.Columns["Odeme_Sekli"].Visible = false;
            dtgMasa2.Columns["SiparisDurum"].Visible = false;
            dtgMasa2.Columns["Urunler_Id"].Visible = false;
            dtgMasa2.Columns["UrunKategori"].Visible = false;
            dtgMasa2.Columns["Urun_Adi"].Visible=false;
            dtgMasa2.Columns["Odeme_Durumu"].Visible = false;
            dtgMasa2.Columns["Adet"].Visible = false;
            dtgMasa2.Columns["Birim_Fiyat"].Visible = false;
            dtgMasa2.Columns["Durum"].Visible = false;
            dtgMasa2.ClearSelection();

            foreach (DataRow item in dt.Rows)
            {
                DateTime tarihdegeri = Convert.ToDateTime(item["Tarih"].ToString());
                sc.SiparisTasi(yenimasa, item["Urun"].ToString(), item["Adet"].ToString(), item["Fiyat"].ToString(),tarihdegeri.ToString("yy-MM-dd"), item["Garson"].ToString(),item["OdemeDurum"].ToString(), item["SiparisDurum"].ToString(),Convert.ToInt32(item["EskiMasaId"].ToString()));
            }

            dtgMasa2.DataSource = sc.TasinilacakMasaSiparis(yenimasa);
            dtgMasa1.DataSource = sc.TasinacakMasaSiparis(eskimasa);

            DataTable table = new DataTable();
            table = sc.MasadakiSiparis(eskimasa);
            if(table.Rows.Count==0)
            {
                sc.MasaDurumDegistir(eskimasa.ToString());
            }
                      
        }

        private void dtgMasa1_CellClick(object sender, DataGridViewCellEventArgs e)
        {             
           urun = dtgMasa1.Rows[dtgMasa1.CurrentCell.RowIndex].Cells["Urun"].Value.ToString();
           adet = dtgMasa1.Rows[dtgMasa1.CurrentCell.RowIndex].Cells["Adet"].Value.ToString();
           fiyat = dtgMasa1.Rows[dtgMasa1.CurrentCell.RowIndex].Cells["Fiyat"].Value.ToString();
           tarih = Convert.ToDateTime(dtgMasa1.Rows[dtgMasa1.CurrentCell.RowIndex].Cells["Tarih"].Value.ToString());
           garson = dtgMasa1.Rows[dtgMasa1.CurrentCell.RowIndex].Cells["Garson"].Value.ToString();
           odemesekli = dtgMasa1.Rows[dtgMasa1.CurrentCell.RowIndex].Cells["Odeme_Sekli"].Value.ToString();
           odemedurum = dtgMasa1.Rows[dtgMasa1.CurrentCell.RowIndex].Cells["Odeme_Durumu"].Value.ToString();
           siparisdurum = dtgMasa1.Rows[dtgMasa1.CurrentCell.RowIndex].Cells["SiparisDurum"].Value.ToString();
            int index = dtgMasa1.CurrentRow.Index;
          

            sc.SiparisSil(eskimasa, urun, odemedurum, siparisdurum);
            dtgMasa1.DataSource = sc.TasinacakMasaSiparis(eskimasa);


            DataRow dr = dt.NewRow();
            dr["Urun"] = urun;
            dr["Adet"] = adet;
            dr["Fiyat"] = fiyat;
            dr["Tarih"] = tarih;
            dr["Garson"] = garson;
            dr["OdemeDurum"] = odemedurum;
            dr["SiparisDurum"] = siparisdurum;
            dr["EskiMasaId"] = eskimasa;

            dt.Rows.Add(dr);

            dtgGecis.DataSource = dt;
        }
    }
}
