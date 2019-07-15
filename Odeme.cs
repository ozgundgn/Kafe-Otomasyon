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
    public partial class btnİptal : Form
    {
        public btnİptal()
        {
            InitializeComponent();
        }

        SalonlarClass sc = new SalonlarClass();
        OdemeClass oc = new OdemeClass();
        DataTable ilkdt;
        DataTable siparisdt;
        ArrayList odenecekurunler = new ArrayList();

        public string Odenecektutar, AdisyonAdi;       
        public int mi,odemesekli;
      
        double fyt;
      
        int RadioButton()
        {
            if(radioNakit.Checked==true)
            { odemesekli = 1; }
            if(radioKrediKarti.Checked==true)
            {
                odemesekli = 2;
            }
            if(radioTicket.Checked==true)
            {
                odemesekli = 3;
            }
            if(radioButton1.Checked==true)
            {
                odemesekli = 4;
            }
            return odemesekli;
        }
        
        private void Odeme_Load(object sender, EventArgs e)
        {
            fyt = 0;
           
            lblAdisyon.Text = AdisyonAdi;
            dtgAdisyon2.ClearSelection();
            ilkdt = new DataTable();
            ilkdt.Columns.Add("Urun", typeof(string));
            ilkdt.Columns.Add("Adet", typeof(int));
            ilkdt.Columns.Add("Fiyat", typeof(double));

            siparisdt = new DataTable();
            siparisdt = sc.GetirSiparis(Convert.ToInt32(mi));

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

            lblTutar.Text = toplam.ToString() + "TL";
            dtgAdisyon2.DataSource = ilkdt;
            dtgAdisyon2.ClearSelection();

        }

        private void Ode_Click(object sender, EventArgs e)
        {
            odemesekli = RadioButton();
            if (odemesekli != 4)
            {
                if (oc.OdemeAl(odenecekurunler, odemesekli, mi))
                {
                    MessageBox.Show("Ödeme alındı.");
                }
                else { MessageBox.Show("Test"); }
                odenecekurunler.Clear();
                Salonlar ss = new Salonlar();
                ss.DidItOpen = true;
                fyt = 0;
                foreach (DataRow item in ilkdt.Rows)
                {
                    fyt += Convert.ToDouble(item["Fiyat"]);
                }

                lblTutar.Text = fyt.ToString() + "TL";
                fyt = 0;
            }
            else
            { oc.MasaIptal(mi); }
        }
 
        private void dtgAdisyon2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string urnadi = dtgAdisyon2.Rows[dtgAdisyon2.CurrentCell.RowIndex].Cells["Urun"].Value.ToString();
            int adet = Convert.ToInt32(dtgAdisyon2.Rows[dtgAdisyon2.CurrentCell.RowIndex].Cells["Adet"].Value.ToString());
            double fiyat= Convert.ToDouble(dtgAdisyon2.Rows[dtgAdisyon2.CurrentCell.RowIndex].Cells["Fiyat"].Value);
            double birimfiyat = fiyat / adet;
            int index = dtgAdisyon2.CurrentCell.RowIndex;

            odenecekurunler.Add(urnadi);
                adet -= 1;
                fyt += birimfiyat;
                fiyat -= birimfiyat;
                if (adet == 0)//silinmesi gerekse
                {
                    ilkdt.Rows[index].Delete();
                }
                else
                {
                    ilkdt.Rows[index]["Adet"] = adet;
                    ilkdt.Rows[index]["Fiyat"] = fiyat;
                }
          
            lblTutar.Text = fyt.ToString()+"TL";

        }
     
    }
}
