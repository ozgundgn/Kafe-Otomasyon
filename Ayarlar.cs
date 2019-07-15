using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KafeOtomasyon.cs.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;

namespace KafeOtomasyon.cs
{
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
            Size = new Size(970, 1000);
        }
        Access bag = new Access();
        AyarlarClass ayar = new AyarlarClass();
        Garsonlar garson = new Garsonlar();

        int kategorid, urunid,salonid;
        string urunadi, urundrm, urunfyt, urunktgri,harf,hangitxt;
        string salonadi, masasayisi, masadurum;
    
        public static string kullanici;
        private readonly object maskedTextBox1;

        private void Ayarlar_Load(object sender, EventArgs e)
        {   
            grpOzet.Visible = false;
            grpUrunler.Visible = false;
            grpKategori.Visible = false;
            grpSalonlar.Visible = false;
            grpmasalar.Visible = false;
            nmrcBirimFyt.ThousandsSeparator = true;
            bag.BaglantiDurumu();    
       
        }

        private void Kalvye(TextBox txt,string a)
        {
            txt.Text += a;
        }

        private void btn1_Click(object sender,EventArgs e)
        {
            Button b = (Button)sender;
            harf = b.Text;
            
            if (!string.IsNullOrEmpty(hangitxt))
            {
                if (hangitxt == "SalonAdi")
                {
                    Kalvye(txtSalonAdi, harf);
                }
                if (hangitxt == "MasaSayisi")
                {
                    Kalvye(txtMasaSayisi, harf);
                }
                if (hangitxt == "KategoriAdi")
                {
                    Kalvye(txtKategoriAdi, harf);
                }
                if (hangitxt == "UrunAdi")
                {
                    Kalvye(txtUrunAdi, harf);
                }
                if (hangitxt == "Arama")
                {
                    Kalvye(txtArama, harf);
                }
                if (hangitxt == "BirimFiyat")
                {
                   string a= textBox1.Text += harf;
                   
                    nmrcBirimFyt.Value = Convert.ToDecimal(a);
                }

            }
        }

        private void btnBosluk_Click(object sender, EventArgs e)
        {
            harf = " ";
            if (hangitxt == "SalonAdi")
            {
                Kalvye(txtSalonAdi, harf);
            }
            if (hangitxt == "MasaSayisi")
            {
                Kalvye(txtMasaSayisi, harf);
            }
            if (hangitxt == "KategoriAdi")
            {
                Kalvye(txtKategoriAdi, harf);
            }
            if (hangitxt == "UrunAdi")
            {
                Kalvye(txtUrunAdi, harf);
            }
            if (hangitxt == "Arama")
            {
                Kalvye(txtArama, harf);
            }
        }

        private void btnbackSpace_Click(object sender, EventArgs e)
        {
            ArrayList dizi = new ArrayList();

            if (!string.IsNullOrEmpty(hangitxt))
            {
                if (hangitxt == "SalonAdi")
                {
                     BackSpace(dizi,txtSalonAdi);
                }
                if (hangitxt == "MasaSayisi")
                {
                    BackSpace(dizi, txtMasaSayisi);
                }
                if (hangitxt == "KategoriAdi")
                {
                    BackSpace(dizi, txtKategoriAdi);
                }
                if (hangitxt == "UrunAdi")
                {
                    BackSpace(dizi, txtUrunAdi);
                }
                if (hangitxt == "Arama")
                {
                    BackSpace(dizi, txtArama);
                }
                if (hangitxt == "BirimFiyat")
                {
                    ArrayList aa = new ArrayList();

                    foreach (char item in textBox1.Text)
                    {
                        aa.Add(item);                       
                    }
                    textBox1.Clear();
                    int g = aa.Count;
                    aa.RemoveAt(g - 1);
                    foreach (char item in aa)
                    {
                        textBox1.Text += item.ToString();
                    }
                    nmrcBirimFyt.Value = 0;
                    nmrcBirimFyt.Value = Convert.ToDecimal(textBox1.Text);
                }

            }
        }

        private void BackSpace(ArrayList dizi,TextBox txt)
        {
            if (txt.Text!="")
               {
                foreach (char item in txt.Text)
                {
                    dizi.Add(item);
                }
                int sayi = dizi.Count;
                dizi.RemoveAt(sayi - 1);
                txt.Clear();
                foreach (char item in dizi)
                {
                    txt.Text += item;
                }

              }       
        }

        #region Salonlar

        private void btnSalonlar_Click(object sender, EventArgs e)
        {
            
            dtgOzet.DataSource = null;

            grpOzet.Visible = false;
            grpKategori.Visible = false;
            grpmasalar.Visible = false;
            grpUrunler.Visible = false;

            grpSalonlar.Location = new Point(230, 12);
            grpSalonlar.Size = new Size(681, 664);
            grpSalonlar.Visible = true;
            dtgSalonlar.DataSource = ayar.GetirSalon();
            dtgSalonlar.Columns["Salon_Id"].Visible = false;
            dtgSalonlar.Columns["Salon_Isim"].HeaderText = "Salon Adi";
            dtgSalonlar.Columns["Durum_Id"].Visible = false;

            cmbdurum.DataSource = ayar.GetirDurum();
            cmbdurum.DisplayMember = "Durum_Adi";
            cmbdurum.ValueMember = "Durum_Id";

            btnSalonSil.Visible = false;

        }

        private void txtSalonAdi_Click(object sender, EventArgs e)
        {
            hangitxt = "SalonAdi";
        }

        private void btnSalonEkle_Click_1(object sender, EventArgs e)
        {
            if(txtSalonAdi.Text!=" " && cmbdurum.SelectedValue!=null)
            {
                ayar.SalonEkle(txtSalonAdi.Text, Convert.ToInt32(cmbdurum.SelectedValue.ToString()));
            }
            else
            {
                MessageBox.Show("Boş alanları doldurunuz.");
            }
            
            dtgSalonlar.DataSource = ayar.GetirSalon();
        }

        //private void btnSalonSil_Click(object sender, EventArgs e)
        //{
        //    if (dtgSalonlar.SelectedCells != null)
        //    {
        //        ayar.SalonSil(salonid);
        //    }
        //    else { MessageBox.Show("silme işlemi için bir salon seçiniz."); }

        //    dtgSalonlar.DataSource = ayar.GetirSalon();
        //}


        private void btnSalonGuncelle_Click(object sender, EventArgs e)
        {
            if (txtSalonAdi.Text!="" && cmbdurum.SelectedValue != null)
            {
                ayar.SalonGuncelle(txtSalonAdi.Text, cmbdurum.SelectedValue.ToString(), salonid);
            }
            else
            {
                MessageBox.Show("Boş alanları doldurunuz.");
            }

            dtgSalonlar.DataSource = ayar.GetirSalon();
        }

        private void dtgSalonlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            salonid = Convert.ToInt32(dtgSalonlar.Rows[dtgSalonlar.CurrentCell.RowIndex].Cells["Salon_Id"].Value.ToString());
            txtSalonAdi.Text = dtgSalonlar.Rows[dtgSalonlar.CurrentCell.RowIndex].Cells["Salon_Isim"].Value.ToString();
            cmbdurum.SelectedValue = dtgSalonlar.Rows[dtgSalonlar.CurrentCell.RowIndex].Cells["Durum_Id"].Value;
        }
        #endregion

        #region Masa
        private void btnMasa_Click(object sender, EventArgs e)
        {
            grpmasalar.Location = new Point(230, 12);
            grpmasalar.Size = new Size(681, 664);
            cmbSalonadi.SelectedText = "";
            txtMasaSayisi.Text = "";
       
            dtgOzet.DataSource = null;

            grpOzet.Visible = false;
            grpUrunler.Visible = false;
            grpKategori.Visible = false;
            grpSalonlar.Visible = false;
            grpmasalar.Visible = true;


            cmbSalonadi.DataSource = ayar.GetirSalon();
            cmbSalonadi.DisplayMember = "Salon_Isim";
            cmbSalonadi.ValueMember = "Salon_Id";

            cmbMasadrm.DataSource = ayar.GetirDurum();
            cmbMasadrm.DisplayMember = "Durum_Adi";
            cmbMasadrm.ValueMember = "Durum_Id";

            dtgmasalar.DataSource = ayar.GetirMasa();
            dtgmasalar.Columns["Salon_Isim"].HeaderText = "Salon";
            dtgmasalar.Columns["Durum_Adi"].HeaderText = "Masa Durumu";
            dtgmasalar.Columns["Masa"].HeaderText = "Masa Sayısı";
          

            dtgmasalar.ClearSelection();
        }

        private void txtMasaSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnMEkle_Click(object sender, EventArgs e)
        {

            if (cmbSalonadi.SelectedValue != null && cmbMasadrm.SelectedValue != null && txtMasaSayisi.Text != "")
            {
                ayar.masasayi = Convert.ToInt32(txtMasaSayisi.Text);

                if (ayar.MasaEkle(Convert.ToInt32(cmbSalonadi.SelectedValue), Convert.ToInt32(cmbMasadrm.SelectedValue)))
                { MessageBox.Show("Eklendi"); }
                else { MessageBox.Show("Eklenmedi"); }
            }
            else
                MessageBox.Show("Lütfen gerekli bilgileri girin");

            dtgmasalar.DataSource = ayar.GetirMasa();
        }

        private void btnMasaSil_Click(object sender, EventArgs e)
        {
            if (cmbSalonadi.SelectedValue != null && cmbMasadrm.SelectedValue != null && txtMasaSayisi.Text != "")
            {
                ayar.MasaSilStore(Convert.ToInt32(cmbSalonadi.SelectedValue));

                dtgmasalar.DataSource = ayar.GetirMasa();
            }
        }

        private void dtgmasalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbSalonadi.Text = salonadi = dtgmasalar.Rows[dtgmasalar.CurrentCell.RowIndex].Cells["Salon_Isim"].Value.ToString();
            txtMasaSayisi.Text = masasayisi = dtgmasalar.Rows[dtgmasalar.CurrentCell.RowIndex].Cells["Masa"].Value.ToString();
            cmbMasadrm.Text = masadurum = dtgmasalar.Rows[dtgmasalar.CurrentCell.RowIndex].Cells["Durum_Adi"].Value.ToString();
        }

        private void txtMasaSayisi_Click(object sender, EventArgs e)
        {
            hangitxt = "MasaSayisi";
        }
        #endregion

        #region Kategoriler

        private void btnKategori_Click(object sender, EventArgs e)
        {
            dtgOzet.DataSource = null;

            grpKategori.Location = new Point(230, 12);
            grpKategori.Size = new Size(681, 664);

            grpOzet.Visible = false;
            grpUrunler.Visible = false;
            grpSalonlar.Visible = false;
            grpmasalar.Visible = false;
            grpKategori.Visible = true;

            cmbKategoriDrm.DataSource = ayar.GetirDurum();
            cmbKategoriDrm.DisplayMember = "Durum_Adi";
            cmbKategoriDrm.ValueMember = "Durum_Id";

            dtgKategori.DataSource = ayar.GetirKategori();
            dtgKategori.Columns["Durum_Adi"].HeaderText = "Durum";
            dtgKategori.Columns["Durum_Id"].Visible = false;
            dtgKategori.Columns["UrunKategori_Id"].Visible = false;
            dtgKategori.ClearSelection();


        }

        private void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            if (txtKategoriAdi.Text != " " && cmbKategoriDrm.SelectedValue != null)
            {
                if (ayar.KategoriEkle(txtKategoriAdi.Text, cmbKategoriDrm.SelectedValue.ToString()))
                {
                    MessageBox.Show("Eklendi");
                }
            }
            else
            { MessageBox.Show("Eksik bilgileri giriniz."); }

            dtgKategori.DataSource = ayar.GetirKategori();
        }

        private void btnKategoriDegstr_Click(object sender, EventArgs e)
        {
            if (txtKategoriAdi.Text != " " && cmbKategoriDrm.SelectedValue != null)
            {
                if (ayar.kategoriDegistir(txtKategoriAdi.Text, cmbKategoriDrm.SelectedValue.ToString(), kategorid))
                {
                    MessageBox.Show("Güncellendi");
                }
                else
                { MessageBox.Show("Test"); }
                dtgKategori.DataSource = ayar.GetirKategori();
            }
        }

        private void dtgKategori_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKategoriAdi.Text = dtgKategori.Rows[dtgKategori.CurrentCell.RowIndex].Cells["Isim"].Value.ToString();
            cmbdurum.SelectedValue = dtgKategori.Rows[dtgKategori.CurrentCell.RowIndex].Cells["Durum_Id"].Value;
            kategorid = Convert.ToInt32(dtgKategori.Rows[dtgKategori.CurrentCell.RowIndex].Cells["UrunKategori_Id"].Value.ToString());
        }

   
        private void txtKategoriAdi_Click(object sender, EventArgs e)
        {
            hangitxt = "KategoriAdi";
        }

        #endregion

        #region Urunler

        private void txtUrunAdi_Click(object sender, EventArgs e)
        {
            hangitxt = "UrunAdi";
        }

        private void btnUrunler_Click(object sender, EventArgs e)
        {
            grpUrunler.Location = new Point(230, 12);
            grpUrunler.Size = new Size(681, 664);

            dtgOzet.DataSource = null;
            grpOzet.Visible = false;
            grpKategori.Visible = false;
            grpmasalar.Visible = false;
            grpSalonlar.Visible = false;
            grpUrunler.Visible = true;

            dtgUrunler.DataSource = ayar.GetirUrunler();

            cmbKategori.DataSource = ayar.GetirKategori();

            cmbKategori.DisplayMember = "Isim";
            cmbKategori.ValueMember = "UrunKategori_Id";

            cmbUrunDurum.DataSource = ayar.GetirKategori();
            cmbUrunDurum.DisplayMember = "Durum_Adi";
            cmbUrunDurum.ValueMember = "Durum_Id";

            dtgUrunler.Columns["Urunler_Id"].Visible = false;
            dtgUrunler.Columns["Durum_Adi"].HeaderText = "Durum";
            dtgUrunler.Columns["Urun_Adi"].HeaderText = "Ürün Adi";
            dtgUrunler.Columns["Birim_Fiyat"].HeaderText = "Birim Fiyat";
            dtgUrunler.Columns["Isim"].HeaderText = "Kategori";
            dtgUrunler.ClearSelection();

        }   

        private void btnUrunekle_Click(object sender, EventArgs e)
        {
            if (txtUrunAdi.Text != " " && nmrcBirimFyt.Text != " " && cmbUrunDurum.SelectedValue != null && cmbKategori.SelectedValue != null)
            {
                if (ayar.UrunEkle(txtUrunAdi.Text, nmrcBirimFyt.Text, cmbKategori.SelectedValue.ToString(), cmbUrunDurum.SelectedValue.ToString()))
                {
                    MessageBox.Show("Eklendi");
                }
            }
            else
            { MessageBox.Show("Eksik bilgileri giriniz."); }

            dtgUrunler.DataSource = ayar.GetirUrunler();
        }


        private void btnUrunDegıstır_Click(object sender, EventArgs e)
        {
            if (txtUrunAdi.Text != " " && nmrcBirimFyt.Text != " " && cmbUrunDurum.SelectedValue != null && cmbKategori.SelectedValue != null)
            {
                if (ayar.UrunDegistir(txtUrunAdi.Text, nmrcBirimFyt.Text, cmbKategori.SelectedValue.ToString(), cmbUrunDurum.SelectedValue.ToString(), urunid))
                {
                    MessageBox.Show("Güncellendi");
                }
            }
            else
            { MessageBox.Show("Eksik bilgileri giriniz."); }

            dtgUrunler.DataSource = ayar.GetirUrunler();
        }

        private void dtgUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            urunid = Convert.ToInt32(dtgUrunler.Rows[dtgUrunler.CurrentCell.RowIndex].Cells["Urunler_Id"].Value.ToString());
            txtUrunAdi.Text = urunadi = dtgUrunler.Rows[dtgUrunler.CurrentCell.RowIndex].Cells["Urun_Adi"].Value.ToString();
            cmbUrunDurum.Text = urundrm = dtgUrunler.Rows[dtgUrunler.CurrentCell.RowIndex].Cells["Durum_Adi"].Value.ToString();
            nmrcBirimFyt.Text = urunfyt = dtgUrunler.Rows[dtgUrunler.CurrentCell.RowIndex].Cells["Birim_Fiyat"].Value.ToString();
            cmbKategori.Text = urunktgri = dtgUrunler.Rows[dtgUrunler.CurrentCell.RowIndex].Cells["Isim"].Value.ToString();
        }

        private void nmrcBirimFyt_Click(object sender, EventArgs e)
        {
            hangitxt = "BirimFiyat";
        }
        #endregion

        #region Ozet

        private void btnOzet_Click(object sender, EventArgs e)
        {
            grpOzet.Location = new Point(230, 12);
            grpOzet.Size = new Size(681, 650);

            label7.Text = "toplam fiyat TL";
            label7.ForeColor = Color.Gray;
            grpUrunler.Visible = false;
            grpKategori.Visible = false;
            grpmasalar.Visible = false;
            grpSalonlar.Visible = false;

            if (dtgOzet.DataSource == null)
            {              
                if (kullanici == 2.ToString())
                {
                    grpOzet.Visible = true;
                    dtgOzet.DataSource = ayar.GetirOzet(txtArama.Text, dtpilk.Value.ToString("yyyy-MM-dd"), dtpSon.Value.ToString("yyyy-MM-dd"));
                    dtgOzet.Columns["Kullanici_Adi"].HeaderText = "Garson Adi";
                    dtgOzet.Columns["Siparis_Id"].HeaderText = "Adisyon Numarası";
                    dtgOzet.ClearSelection();
                }

            }
            else { grpOzet.Visible = false; }
        }

        private void btnKullanicilar_Click(object sender, EventArgs e)
        {
            garson.ShowDialog();
        }

        private void btnToplam_Click(object sender, EventArgs e)
        {
            double toplam = 0;
            if (dtgOzet.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dtgOzet.Rows)
                {
                    toplam += Convert.ToDouble(item.Cells["Fiyat"].Value);
                }
            }

            label7.Text = ":" + toplam.ToString() + " " + "TL";
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            dtgOzet.DataSource = ayar.GetirOzet(txtArama.Text, dtpilk.Value.ToString("yyyy-MM-dd"), dtpSon.Value.ToString("yyyy-MM-dd"));
            dtgOzet.ClearSelection();
           
        }
        private void txtArama_Click(object sender, EventArgs e)
        {
            hangitxt = "Arama";
        }


        #endregion

        private void Ayarlar_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtgOzet.DataSource = null;
        }
    
    }
}
