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

namespace KafeOtomasyon.cs
{
    public partial class KullaniciGiris : Form
    {
        public KullaniciGiris()
        {
            InitializeComponent();
        }
        public static string kim;
        string kullaniciadi;
        string sifre;
        DataTable dt;
        KullaniciClass kullanici = new KullaniciClass();
        Salonlar salonlar = new Salonlar();
        SifreKoy sk = new SifreKoy();
        Access acc = new Access();
        GarsonlarClass gc = new GarsonlarClass();
        string Ad;

        private void btnGiris_Click(object sender, EventArgs e)
        {  if (txtKullaniciAdi.Text != "" && txtSifre.Text != "")
            {
                kullaniciadi = txtKullaniciAdi.Text;
                sifre = txtSifre.Text;
                dt = new DataTable();

                dt = kullanici.KullaniciKontrol(kullaniciadi, sifre);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Kullanici adi veya şifre hatalı.", "Hata", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
                else
                {
                    //if (Convert.ToInt32(dt.Rows[0]["KullaniciTur"]) == 1)
                    //{
                    string kullanicid = dt.Rows[0]["Kullanici_Id"].ToString();
                    Salonlar.kullaniciId = kullanicid;
                    Salonlar.kullanicitr = dt.Rows[0]["KullaniciTur"].ToString();
                    Ayarlar.kullanici = dt.Rows[0]["KullaniciTur"].ToString();
                    MutfakForm.kullanicitur = dt.Rows[0]["KullaniciTur"].ToString();
                    SiparisClass.kullanciciTur= dt.Rows[0]["KullaniciTur"].ToString();

                    //}
                    //if (Convert.ToInt32(dt.Rows[0]["KullaniciTur"]) == 2)
                    //{
                    //    Ayarlar.kullanici = dt.Rows[0]["KullaniciTur"].ToString();

                    //}
                    this.Hide();
                    salonlar.ShowDialog();
                }
            }
            else
            { MessageBox.Show("Kullanici adi veya şifre boş geçilemez. ", "Hata", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification); }
        }

        private void KullaniciGiris_Load(object sender, EventArgs e)
        {

            txtKullaniciAdi.Clear();
            txtSifre.Clear();

            Button btnKullanici;
            acc.BaglantiDurumu();
            MySqlDataReader dr = gc.GarsonlarOlustur();
            int x = 20;
            int y = 20;
            while(dr.Read())
            {
                if (x > 430)
                {
                    x = 20;
                    y += 105;
                }
                btnKullanici = new Button();
                btnKullanici.Width = 90;
                btnKullanici.Height = 90;
                btnKullanici.Name = dr["Kullanici_Id"].ToString();
                btnKullanici.Text = dr["Kullanici_Adi"].ToString() + "\n" + dr["Kullanici_Soyadi"].ToString();
               
                btnKullanici.Location = new Point(x, y);
                btnKullanici.BackColor = Color.PaleTurquoise;
                btnKullanici.FlatStyle = FlatStyle.Flat;
                btnKullanici.FlatAppearance.BorderColor = Color.CadetBlue;
                btnKullanici.FlatAppearance.BorderSize = 2;
                btnKullanici.ForeColor = Color.Black;
                btnKullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            
               
                x += 105;               
            
                grpKullanicilar.Controls.Add(btnKullanici);
                btnKullanici.Click += new EventHandler(btnKullaniciClick);
            }
            dr.Close();
        }

        private void btnKullaniciClick(object sender, EventArgs e)
        {
          Button btnKullanici=(sender as Button);
            string[] dizi = btnKullanici.Text.Split('\n');
            Ad = dizi[0];
            txtKullaniciAdi.Text = Ad;
        }
  

        #region Tuşlar
        private void button2_Click(object sender, EventArgs e)
        {
            txtSifre.Text += 1.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtSifre.Text += 2.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtSifre.Text += 3.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtSifre.Text += 4.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtSifre.Text += 5.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtSifre.Text += 6.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtSifre.Text += 7.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtSifre.Text += 8.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtSifre.Text += 9.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtSifre.Text += 0.ToString();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            txtSifre.Text += ".";
        }
        private void button13_Click(object sender, EventArgs e)
        {
            
                char[] dizi = txtSifre.Text.ToCharArray();
                int sayi = dizi.Length;
            if (sayi!=0)
            {
                Array.Clear(dizi, sayi - 1, 1);
                txtSifre.Clear();
                foreach (char item in dizi)
                {
                    txtSifre.Text += item.ToString();
                }
            }
        }

        #endregion

        private void KullaniciGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sk.ShowDialog();
        }

        private void grpTuslar_Enter(object sender, EventArgs e)
        {

        }
    }
}
