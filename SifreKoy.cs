using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace KafeOtomasyon.cs
{
    public partial class SifreKoy : Form
    {
        public SifreKoy()
        {
            InitializeComponent();
        }

        MySqlDataAdapter adapter;
        //public string Sifrele(string sifrelenecek)
        //{
        //    MD5CryptoServiceProvider md = new MD5CryptoServiceProvider();
        //    byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecek);
        //    dizi = md.ComputeHash(dizi);
        //    StringBuilder sb = new StringBuilder();
        //    foreach (byte item in dizi)
        //    {
        //        sb.Append(item.ToString("x2").ToLower());
        //    }
        //    return sb.ToString();

        //}

        public bool Degistir(string kln, string sifre, string yenisfre)
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("select * from kullanicilar where binary Sifre='" + sifre + "' and Kullanici_Adi='" + kln + "'", Access.conn);

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            adapter.Dispose();

            if (dt.Rows.Count > 0)
            {
                try
                {
                    MySqlCommand cmd1 = new MySqlCommand("update kullanicilar set Sifre='" + yenisfre + "' where binary Kullanici_Adi='" + kln + "'", Access.conn);
                    cmd1.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            string kul = txtKullanici.Text;
            string ps = txtEskiSfre.Text;
            string ns = txtyeniSifre.Text;

            if(Degistir(kul,ps,ns))
                MessageBox.Show("Degisti");
            else
                MessageBox.Show("Hatalı");
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
