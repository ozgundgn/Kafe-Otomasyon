using System;
using System.Collections;
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
    public partial class Garsonlar : Form
    {
        public Garsonlar()
        {
            InitializeComponent();
            this.Height = 1000;
        }
        GarsonlarClass gc = new GarsonlarClass();
        string harf, hangitxt, rakam;

        public void Kalvye(TextBox txt,string yazi)
        {
            txt.Text += yazi;
        }

        int userid;
        private void Garsonlar_Load(object sender, EventArgs e)
        {
            txtAd.Clear();
            txtSoyad.Clear();
            maskedTextBox1.Clear();
          

            dtgGarsonlar.DataSource = gc.GarsonlarGetir();
            dtgGarsonlar.Columns["Kullanici_Id"].Visible = false;
            dtgGarsonlar.Columns["KullaniciTur"].Visible = false;
            dtgGarsonlar.Columns["Sifre"].Visible = false;
            dtgGarsonlar.Columns["KullaniciTur_Id"].Visible = false;

            dtgGarsonlar.Columns["Kullanici_Adi"].HeaderText = "Adi";
            dtgGarsonlar.Columns["Kullanici_Soyadi"].HeaderText = "Soyadi";
            dtgGarsonlar.Columns["KullaniciTur_Adi"].HeaderText = "Görev";

            dtgGarsonlar.ClearSelection();
            
            cmbGorev.DataSource = gc.GetirKullaniciTur();
            cmbGorev.DisplayMember = "KullaniciTur_Adi";
            cmbGorev.ValueMember = "KullaniciTur_Id";

            cmbKullaniciDurum.DataSource = gc.GetirKullaniciDurum();
            cmbKullaniciDurum.ValueMember = "Durum_Id";
            cmbKullaniciDurum.DisplayMember = "Durum_Adi";
        }

        private void btnGarsonEkle_Click(object sender, EventArgs e)
        {
            if(txtAd.Text!="" && txtSoyad.Text!="" && cmbGorev.SelectedValue!=null && maskedTextBox1.Text!="")
            {
                if(gc.GarsonEkle(txtAd.Text,txtSoyad.Text,cmbGorev.SelectedValue.ToString(),maskedTextBox1.Text))
                { MessageBox.Show("Eklendi");}
                else { MessageBox.Show("Test");}
            }
            else
            {
                MessageBox.Show("Gerekli bilgileri giriniz.");
            }
            dtgGarsonlar.DataSource = gc.GarsonlarGetir();
        }

        private void btnGrsnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtAd.Text !=" " && txtSoyad.Text !=" " && cmbGorev.SelectedValue != null && maskedTextBox1.Text != "")
            {
                if (gc.GarsonGuncelle(txtAd.Text, txtSoyad.Text, cmbGorev.SelectedValue.ToString(), maskedTextBox1.Text, userid,cmbKullaniciDurum.SelectedValue.ToString()))
                { MessageBox.Show("Güncellendi","Güncelleme İşlemi",MessageBoxButtons.OK,MessageBoxIcon.Asterisk); }
                else { MessageBox.Show("Test"); }
            }
            else
            {
                MessageBox.Show("Gerekli bilgileri giriniz.");
            }
            dtgGarsonlar.DataSource = gc.GarsonlarGetir();
        }

        private void btnGrsnSil_Click(object sender, EventArgs e)
        {
            if (dtgGarsonlar.SelectedRows.Count>0)
            {
                if (gc.GarsonSil(userid))
                { MessageBox.Show("Silindi"); }
                else { MessageBox.Show("Test"); }
            }
            else
            {
                MessageBox.Show("Bir işlem  seçiniz.");
            }
            dtgGarsonlar.DataSource = gc.GarsonlarGetir();
        }

        private void dtgGarsonlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           txtAd.Text= dtgGarsonlar.Rows[dtgGarsonlar.CurrentCell.RowIndex].Cells["Kullanici_Adi"].Value.ToString();
            txtSoyad.Text = dtgGarsonlar.Rows[dtgGarsonlar.CurrentCell.RowIndex].Cells["Kullanici_Soyadi"].Value.ToString();
            cmbGorev.SelectedValue=dtgGarsonlar.Rows[dtgGarsonlar.CurrentCell.RowIndex].Cells["KullaniciTur"].Value;
            maskedTextBox1.Text= dtgGarsonlar.Rows[dtgGarsonlar.CurrentCell.RowIndex].Cells["Telefon"].Value.ToString();

            userid= Convert.ToInt32(dtgGarsonlar.Rows[dtgGarsonlar.CurrentCell.RowIndex].Cells["Kullanici_Id"].Value.ToString());        
          
        }

        private void btnTumunuGoster_Click(object sender, EventArgs e)
        {
            dtgGarsonlar.ClearSelection();
            dtgGarsonlar.DataSource = gc.GelmisGecmisGarsonlarGetir();
            dtgGarsonlar.Columns["Kullanici_Id"].Visible = false;
            dtgGarsonlar.Columns["KullaniciTur"].Visible = false;
            dtgGarsonlar.Columns["Sifre"].Visible = false;
            dtgGarsonlar.Columns["KullaniciTur_Id"].Visible = false;

            dtgGarsonlar.Columns["Kullanici_Adi"].HeaderText = "Adi";
            dtgGarsonlar.Columns["Kullanici_Soyadi"].HeaderText = "Soyadi";
            dtgGarsonlar.Columns["KullaniciTur_Adi"].HeaderText = "Görev";
            dtgGarsonlar.Columns["GirisTarihi"].HeaderText = "Giris Tarihi";
            dtgGarsonlar.Columns["CikisTarihi"].HeaderText = "Çıkış Tarihi";

            dtgGarsonlar.ClearSelection(); 

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            harf = b.Text;
            if (!string.IsNullOrEmpty(hangitxt))
            {
                if (hangitxt == "Ad")
                {
                    Kalvye(txtAd, harf);
                }
                if (hangitxt == "Soyad")
                {
                    Kalvye(txtSoyad, harf);
                }
                if (hangitxt == "Telefon")
                {
                    maskedTextBox1.Text += harf;
                }
                         
            }
        }

        private void btnbackSpace_Click(object sender, EventArgs e)
        {
            ArrayList yazi = new ArrayList();
            if (hangitxt == "Ad")
            {
                foreach (char item in txtAd.Text)
                {
                    yazi.Add(item);
                }
                int elemansayisi = yazi.Count;
                if(elemansayisi-1>=0)
                {
                    yazi.RemoveAt(elemansayisi - 1);
                }
                
                txtAd.Clear();
                foreach(char item in yazi)
                {
                    txtAd.Text += item.ToString();
                }
                
            }
            if(hangitxt=="Soyad")
            {
                foreach (char item in txtSoyad.Text)
                {
                    yazi.Add(item);
                }
                int elemansayisi = yazi.Count;
                if(elemansayisi-1>=0)
                {
                    yazi.RemoveAt(elemansayisi - 1);
                }
                
                txtSoyad.Clear();
                foreach (char item in yazi)
                {
                    txtSoyad.Text += item.ToString();
                }
            }
            if (hangitxt == "Telefon")
            {
                foreach (char item in maskedTextBox1.Text)
                {
                    yazi.Add(item);
                }
                int elemansayisi = yazi.Count;
                yazi.RemoveAt(elemansayisi - 1);
               maskedTextBox1.Clear();
                foreach (char item in yazi)
                {
                   maskedTextBox1.Text+= item.ToString();
                }
            }        
        }


        private void btnBosluk_Click(object sender, EventArgs e)
        {
            harf = " ";
            if (hangitxt == "Ad")
            {
                Kalvye(txtAd, harf);
            }
            if (hangitxt == "Soyad")
            {
                Kalvye(txtSoyad, harf);
            }
        

        }

        private void maskedTextBox1_Click(object sender, EventArgs e)
        {
            hangitxt = "Telefon";
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txtSoyad_Click(object sender, EventArgs e)
        {
            hangitxt = "Soyad";
        }

        private void txtAd_Click(object sender, EventArgs e)
        {
            hangitxt = "Ad";
        }
    }
}
