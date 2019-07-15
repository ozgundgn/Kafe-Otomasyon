using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Collections;

namespace KafeOtomasyon.cs
{
    public partial class MutfakForm : Form
    {
        public MutfakForm()
        {
            InitializeComponent();
        }
        MutfakClass mc = new MutfakClass();
        SortedList hazir = new SortedList();

        public string masaadi;
        public static string kullanicitur;
        public bool tiklama = false;
        int masaidd;
       
        private void MutfakForm_Load(object sender, EventArgs e)
        {
          
            Button btnmasa;
            MySqlDataReader dr = mc.SiparisliMasa();

            int x = 40;
            int y = 33;
            while (dr.Read())
            {
                btnmasa = new Button();        
                btnmasa.Location = new Point(x, y);
                btnmasa.BackColor = Color.CornflowerBlue;
                btnmasa.Width = 90;
                btnmasa.Height = 90;
                btnmasa.FlatStyle = FlatStyle.Flat;
                btnmasa.FlatAppearance.BorderColor = Color.WhiteSmoke;
                btnmasa.FlatAppearance.BorderSize = 2;
                btnmasa.Font = new Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                btnmasa.Name = dr["Masa_Id"].ToString();
                btnmasa.Text = dr["Salon_Isim"].ToString()+" "+"Masa"+" "+ btnmasa.Name;
                btnmasa.Click += new EventHandler(btnmasaClick);

                x += 105;
                if(x>605)
                {
                    x = 40;
                    y += 105;
                }
                grpSprsMasa.Controls.Add(btnmasa);
            }
            if (kullanicitur != 3.ToString())
            {
                chkSiparisLstbx.Enabled = false;
                btnHazir.Enabled = false;
              
            }
            dr.Close();
        }

        private void btnmasaClick(object sender, EventArgs e)
        {
            chkSiparisLstbx.Items.Clear();
            Button btnmasa = (sender as Button);
            MySqlDataReader dr = mc.MasadakiUrunler(Convert.ToInt32(btnmasa.Name));
            masaidd = Convert.ToInt32(btnmasa.Name);
            label1.Text = btnmasa.Text;
            while (dr.Read())
            {
                int index = 0;
                if (chkSiparisLstbx != null)
                {
                    foreach (string item in chkSiparisLstbx.Items)
                    {
                        string[] dizi = item.Split('_');
                        string urun = dizi[0];
                        int sayi = Convert.ToInt32(dizi[1]);

                        if (dr["Urun"].ToString() == urun)
                        {
                            sayi++;
                            chkSiparisLstbx.Items[index] = urun + "_" + sayi.ToString();
                            goto etiket;
                        }
                        index++;
                    }
                    chkSiparisLstbx.Items.Add(dr["Urun"].ToString() + "_" + dr["Adet"].ToString());
                    string a = dr["SiparisDurum"].ToString();
                    if (Convert.ToInt32(a) == 1)
                    {
                        chkSiparisLstbx.SetItemChecked(index, true);
                    }
                    goto etiket;
                }
                else
                {
                    chkSiparisLstbx.Items.Add(dr["Urun"].ToString() + "_" + dr["Adet"].ToString());
                    string a = dr["SiparisDurum"].ToString();
                    if (Convert.ToInt32(a) == 1)
                    {
                        chkSiparisLstbx.SetItemChecked(0, true);
                    }
                }
                etiket:;
            }

            dr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chkSiparisLstbx.CheckedItems.Count>0)
            {
                // hazir.Clear();
                ArrayList dizi = new ArrayList();
                foreach (object itemchecked in chkSiparisLstbx.CheckedItems)
                {
                    string[] dizi2 = itemchecked.ToString().Split('_');
                    string urun = dizi2[0].ToString();
                    string sayi = dizi2[1].ToString();
                    dizi.Add(urun);
                }

                mc.SiparisHazir(dizi, masaidd);


                ((Salonlar)Application.OpenForms.OfType<Salonlar>().SingleOrDefault()).btnHazirSiparis.Visible = true;
                foreach (string item in chkSiparisLstbx.CheckedItems)
                {
                    //string[] ayir = item.Split('-');
                    string a = item + "(" + label1.Text + ")";
                    //string b = ayir[1];
                    // hazir.Add(a, masaidd.ToString());
                    if (!HazırSiparisler.hzrsprslr.Contains(a))
                    { HazırSiparisler.hzrsprslr.Add(a, masaidd.ToString()); }
                    MessageBox.Show("Hazir!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
            }
        }


    }
}
