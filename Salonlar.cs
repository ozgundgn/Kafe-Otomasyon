using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using KafeOtomasyon.cs.Models;


namespace KafeOtomasyon.cs
{
    public partial class Salonlar : Form
    {

        public Salonlar()
        {
            InitializeComponent();

            this.Width = 1073;
            this.Height = 780;
        }
 
        SalonlarClass sc = new SalonlarClass();
        Yukleme yk = new Yukleme();
        AyarlarClass ac = new AyarlarClass();
        SiparisClass order = new SiparisClass();
        MutfakForm mtf = new MutfakForm();
        MasaTasimaForm masatasi = new MasaTasimaForm();
        Ayarlar a = new Ayarlar();
        btnİptal ode = new btnİptal();

        List<UrunSınıf> eklenen = new List<UrunSınıf>();
        List<UrunSınıf> silinen = new List<UrunSınıf>();

        DataTable ilkdt;
        DataTable siparisdt;

        int masaid;
        int salonid;
        bool ekleme, silme = false;

        string price, name;
        public static string kullaniciId;
        public static string kullanicitr;
        public bool DidItOpen = false;

        private void Form1_Load(object sender, EventArgs e)
        {
          
            if(Convert.ToInt32(kullanicitr)==3)
            {
                btnHazirSiparis.Visible = false;
                button1.Enabled = false;
                btnSiparisAl.Enabled = false;
                btnOdeme.Enabled = false;
                
            }

            btnHazirSiparis.Visible = false;     
            grpButon.Controls.Clear();
            grpMasalar.Controls.Clear();
            label3.Text = "0";
            label1.Text = "ADİSYON";
            if (ilkdt != null)
            {
                ilkdt.Rows.Clear();
            }

            btnSiparisAl.Enabled = false;
            grpMasalar.Visible = true;
            Button btnS;
            int btnw = yk.SalonButonGenisligi(grpButon.Width);
            MySqlDataReader dr = yk.SalonlariYaz();//dr satır satır okuma işlemi yapacak

            int x = 10;
            int y = 30;

            while (dr.Read())
            {
                btnS = new Button();
                btnS.Width = btnw;
                btnS.Height = 90;
                btnS.Name = dr["Salon_Id"].ToString();
                btnS.Location = new Point(x, y);
                btnS.Text = dr["Salon_Isim"].ToString();
                btnS.FlatAppearance.BorderSize = 1;
                btnS.FlatAppearance.BorderColor = Color.Blue;
                btnS.BackColor = Color.BurlyWood;
                btnS.FlatStyle = FlatStyle.Flat;

                x += btnw + 15;
                grpButon.Controls.Add(btnS);
                btnS.Click += new EventHandler(btnSClick);

            }
            grpMasalar.Width = 720;
            grpMasalar.Height = 400;
            btnGeri.Visible = false;
     
            dr.Close();
    
        }
        public void btnSClick(object sender, EventArgs e)
        {
            Button btnS = (sender as Button);
            salonid = Convert.ToInt32(btnS.Name);
            grpMasalar.Controls.Clear();
            MasaOlustur(btnS.Text);
        }

        public void KategoriOlustur()
        {
            Button btnK;
           
            grpButon.Controls.Clear();

            int a = grpButon.Width;
            int b = grpButon.Height;
            int grpalan = a * b;

            MySqlDataReader dr = sc.GetirKategoriler();//dr satır satır okuma işlemi yapacak

            int x = 10;
            int y = 20;
            int sayac = 0;

            while (dr.Read())
            {
                btnK = new Button();
                btnK.Width = 150;
                btnK.Height = 60;
                btnK.Name = dr["UrunKategori_Id"].ToString();
                btnK.Location = new Point(x, y);
                btnK.Text = dr["Isim"].ToString();
                btnK.BackColor = Color.Crimson;
                btnK.Font = new Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                btnK.FlatAppearance.BorderColor = Color.Cornsilk;
                x += 165;
                grpButon.Controls.Add(btnK);
                btnK.Click += new EventHandler(btnKClick);
                sayac += 1;
                if (sayac == 4)
                {
                    y += 75;
                    x = 10;
                }
            }
            dr.Close();

        }
        public void btnKClick(object sender, EventArgs e)
        {
            Button btnK = (sender as Button);
            UrunOlustur(btnK.Name);

        }

        public void MasaOlustur(string ad)
        {
            int x = 20;
            int y = 20;
            int grpw = grpMasalar.Width;
            int grph = grpMasalar.Height;
         
            Button btnM;
            MySqlDataReader dr = sc.MasaRengi(salonid);

            
            while (dr.Read())
            {
                btnM = new Button();
                btnM.Width = 90;
                btnM.Height = 90;
                btnM.Location = new Point(x, y);               
                btnM.Name = dr["Masa_Id"].ToString();
                btnM.Text = ad + " Masa " + btnM.Name;
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

                x += 110;
                if (x >= 680)
                {
                    y += 110;
                    x = 20;
                }
                grpMasalar.Controls.Add(btnM);
                btnM.Click += new EventHandler(btnMClick);
               
            }
            dr.Close();
        }
        public void btnMClick(object sender, EventArgs e)
        {
            btnSiparisAl.Enabled = true;
            btnGeri.Visible = true;

            grpMasalar.Controls.Clear();
            ilkdt = new DataTable();
            Button btnM = (sender as Button);
            masaid =Convert.ToInt32( btnM.Name);
            ode.mi = Convert.ToInt32(btnM.Name);
            MasaTasimaForm.masaadi=label1.Text = btnM.Text;
            MasaTasimaForm.eskimasa = Convert.ToInt32(btnM.Name);
            ilkdt.Columns.Add("Urun", typeof(string));
            ilkdt.Columns.Add("Adet", typeof(int));
            ilkdt.Columns.Add("Fiyat", typeof(double));
                           
            siparisdt = new DataTable();
            siparisdt = sc.GetirSiparis(Convert.ToInt32(btnM.Name));
     
            if (siparisdt.Rows.Count > 0)
            {
                foreach (DataRow dr in siparisdt.Rows)
                {
                    foreach (DataRow item in ilkdt.Rows)
                    {
                        if (item["Urun"].ToString() == dr["Urun"].ToString())
                        {
                            int a = Convert.ToInt32(item["Adet"]);
                            double f = Convert.ToDouble(item["Fiyat"]);
                            double brmfyt = f / a;
                            a += 1;
                            f += brmfyt;
                            item["Adet"] = a;
                            item["Fiyat"] = f;
                            goto etiket;
                        }
                    }


                    DataRow ilkdr = ilkdt.NewRow();
                    ilkdr["Urun"] = dr["Urun"].ToString();
                    ilkdr["Adet"] = Convert.ToInt32(dr["Adet"]);
                    ilkdr["Fiyat"] = Convert.ToDouble(dr["Fiyat"]);
                    ilkdt.Rows.Add(ilkdr);
                    etiket:;
                }
            }

            double toplam = 0;
            foreach (DataRow item in ilkdt.Rows)
            {
                toplam += Convert.ToDouble(item["Fiyat"]);
            }

            if (btnM.BackColor == Color.DarkRed)
            {
                dtgSiparis.DataSource = null;
            }
            else
            {
                KategoriOlustur();
                label3.Text = toplam.ToString() + "TL";
                dtgSiparis.DataSource = ilkdt;
                dtgSiparis.ClearSelection();
            }
          
        }

        public void UrunOlustur(string s)
        {
            Button btnU;
          
            grpMasalar.Controls.Clear();

            MySqlDataReader dr = sc.GetirUrun(s);//dr satır satır okuma işlemi yapacak
            int x = 10;
            int y = 20;
            int sayac = 0;
            int btnw = 150;

            while (dr.Read())
            {
                btnU = new Button();
                btnU.Width = btnw;
                btnU.Height = 70;
                btnU.Name = dr["Urunler_Id"].ToString();
                btnU.Location = new Point(x, y);
                btnU.Text = dr["Urun_Adi"].ToString() + "-" + dr["Birim_Fiyat"].ToString();


                x += btnw + 15;
                grpMasalar.Controls.Add(btnU);
                btnU.Click += new EventHandler(btnUClick);
                sayac += 1;
                if (sayac == 4)
                {
                    y += 75;
                    x = 10;
                }
            }
            dr.Close();
        }
        public void btnUClick(object sender, EventArgs e)
        {
            Button btnU = (sender as Button);
            string[] dizi = btnU.Text.Split('-');
            price = dizi[1];
            name = dizi[0];

            UrunSınıf u = new UrunSınıf()
            {
                ad = name,
                fiyat = Convert.ToDouble(price),
                mid = masaid.ToString(),

            };
            eklenen.Add(u);
            AdisyonaEkle(name, price);
            double toplam = 0;
            foreach (DataRow item in ilkdt.Rows)
            {
                toplam += Convert.ToDouble(item["Fiyat"]);
            }

            ode.Odenecektutar = label3.Text = toplam.ToString() + " " + "TL";

        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {                           
            a.ShowDialog();
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            ode.AdisyonAdi = label1.Text;
            ode.Odenecektutar = label3.Text;
            ode.ShowDialog();
        }

        private void btnSiparisEkle_Click_1(object sender, EventArgs e)
        {
            bool hh = false;
            if (ekleme == true)//hem silme hem ekleme yapılmış olabilir
            {
                
                if (order.SiparisKaydet(ilkdt, eklenen, kullaniciId, masaid.ToString()))
                { hh = true; }            
            }          
            if(silme)
            {
                    order.SiparisKaydet(ilkdt, silinen, kullaniciId, masaid.ToString());
            }
            if (hh) { MessageBox.Show("Siparis eklendi", "Onay", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign); }
           
            DataTable table = new DataTable();
            table = sc.GetirSiparis(masaid);
            ilkdt.Rows.Clear();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    foreach (DataRow item in ilkdt.Rows)
                    {
                        if (item["Urun"].ToString() == dr["Urun"].ToString())
                        {
                            int a = Convert.ToInt32(item["Adet"]);
                            double f = Convert.ToDouble(item["Fiyat"]);
                            double brmfyt = f / a;
                            a += 1;
                            f += brmfyt;
                            item["Adet"] = a;
                            item["Fiyat"] = f;
                            goto etiket;
                        }
                    }
                    DataRow ilkdr = ilkdt.NewRow();
                    ilkdr["Urun"] = dr["Urun"].ToString();
                    ilkdr["Adet"] = Convert.ToInt32(dr["Adet"]);
                    ilkdr["Fiyat"] = Convert.ToDouble(dr["Fiyat"]);
                    ilkdt.Rows.Add(ilkdr);
                    etiket:;    
                }
            }

            dtgSiparis.DataSource = ilkdt;

            dtgSiparis.ClearSelection();
            double toplam = 0;
            foreach (DataRow item in ilkdt.Rows)
            {
                toplam += Convert.ToDouble(item["Fiyat"]);
            }
             label3.Text = toplam.ToString() + " " + "TL";
           
            ekleme = false;
            order.deger = false;
            eklenen.Clear();
            silinen.Clear();

        }

        private void Salonlar_FormClosing(object sender, FormClosingEventArgs e)
        {        
            KullaniciGiris d = new KullaniciGiris();        
            d.Show();
            kullaniciId = "";
        }

        private void btnSiparisler_Click(object sender, EventArgs e)
        {
           
            mtf.ShowDialog();
                      
        }

        private void btnHazirSiparis_Click(object sender, EventArgs e)
        {
            HazırSiparisler h = new HazırSiparisler();
            h.ShowDialog();
        }

        private void btnMasaTasi_Click(object sender, EventArgs e)
        {
            masatasi.ShowDialog();
        }

        private void dtgSiparis_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            order.urunadi = dtgSiparis.Rows[dtgSiparis.CurrentCell.RowIndex].Cells["Urun"].Value.ToString();

            int adet = (int)dtgSiparis.Rows[dtgSiparis.CurrentCell.RowIndex].Cells["Adet"].Value;
            double suankifiyat = (double)dtgSiparis.Rows[dtgSiparis.CurrentCell.RowIndex].Cells["Fiyat"].Value;
            double birimf = suankifiyat / adet;
            int index = dtgSiparis.CurrentCell.RowIndex;

            UrunSınıf u = new UrunSınıf()
            {
                ad = dtgSiparis.Rows[dtgSiparis.CurrentCell.RowIndex].Cells["Urun"].Value.ToString(),
                mid = masaid.ToString()
            };
            silinen.Add(u);
            silme = true;//true ise güncelleme yapacak;
            if ((adet - 1) >= 1)
            {
                adet -= 1;
                ilkdt.Rows[index]["Adet"] = adet;
                ilkdt.Rows[index]["Fiyat"] = (birimf * Convert.ToDouble(adet)).ToString("0,00");
            }
            else if ((adet - 1) == 0)
            {
                
                ilkdt.Rows[index].Delete();
                
            }
            order.sil = silme;
            order.fiyat = (birimf * Convert.ToDouble(adet)).ToString("0,00");
            order.adet2 = adet.ToString();

            double toplam = 0;
            foreach (DataRow item in ilkdt.Rows)
            {
                toplam += Convert.ToDouble(item["Fiyat"]);
            }

            label3.Text = toplam.ToString() + " " + "TL";

        }

        public void AdisyonaEkle(string s, string fiyat)
            {
                ekleme = true;
                order.ekle = true;
                DataRow dr;

                foreach (DataRow item in ilkdt.Rows)
                {
                    if (item["Urun"].ToString() == name)
                    {
                        int a = Convert.ToInt32(item["Adet"]);
                        double f = Convert.ToDouble(item["Fiyat"]);
                        f += Convert.ToDouble(fiyat);
                        a++;
                        item["Adet"] = a;
                        item["Fiyat"] = f;
                        goto etiket;
                    }

                }
                dr = ilkdt.NewRow();
                dr["Adet"] = 1;
                dr["Fiyat"] = Convert.ToDouble(price);
                dr["Urun"] = name;
                ilkdt.Rows.Add(dr);

                etiket:;
            }

     
        
    }
   
    //private void btnAltSalon_Click(object sender, EventArgs e)
    //{

    //    grpMasalar.Controls.Clear();
    //    salonid = 1;
    //    dt = new DataTable();
    //    dt = sc.GetirSalon(salonid);
    //    masasayi = Convert.ToInt32(dt.Rows[0]["sayi"].ToString());
    //    MasaOlustur(masasayi);
    //}

    //private void btnBahce_Click(object sender, EventArgs e)
    //{
    //    grpMasalar.Controls.Clear();
    //    salonid = 2;
    //    dt = new DataTable();
    //    dt = sc.GetirSalon(salonid);
    //    masasayi = Convert.ToInt32(dt.Rows[0]["sayi"].ToString());
    //    MasaOlustur(masasayi);
    //}

    //private void btnUstSalon_Click(object sender, EventArgs e)
    //{
    //    grpMasalar.Controls.Clear();
    //    salonid = 3;
    //    dt = new DataTable();
    //    dt = sc.GetirSalon(salonid);
    //    masasayi = Convert.ToInt32(dt.Rows[0]["sayi"].ToString());
    //    MasaOlustur(masasayi);

    //}

    //private void btnMasaEkle_Click(object sender, EventArgs e)
    //{
    //    Button btn;
    //    if (sc.MasaEkle(salonid))
    //    {
    //        if (yenix >= 670)
    //        {
    //            if (yeniy >= 260)
    //            {

    //                MessageBox.Show("Daha fazla masa giremezsiniz.");
    //            }
    //            else
    //            {
    //                yenix = 20;
    //                yeniy += 120;
    //            }
    //        }
    //        ms += 1;
    //        btn = new Button();
    //        btn.Width = 90;
    //        btn.Height = 90;
    //        btn.Location = new Point(yenix, yeniy);
    //        btn.Text = "Masa" + ms;
    //        btn.BackColor = Color.Violet;
    //        grpMasalar.Controls.Add(btn);

    //        yenix += 120;

    //    }
        //    else

        //        MessageBox.Show("hata");
        //}

        //private void btnBalkon_Click(object sender, EventArgs e)
        //{
        //    grpMasalar.Controls.Clear();
        //    salonid = 4;
        //    dt = new DataTable();
        //    dt = sc.GetirSalon(salonid);
        //    masasayi = Convert.ToInt32(dt.Rows[0]["sayi"].ToString());
        //    MasaOlustur(masasayi);

        //}
    

    }

