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
    public partial class HazırSiparisler : Form
    {
        public HazırSiparisler()
        {
            InitializeComponent(); //listBox1.Items.Add(item.Key.ToString() + "  " + item.Value.ToString());
        }
        MutfakClass mc = new MutfakClass();
        public static SortedList hzrsprslr = new SortedList();
        public SortedList alinanlar;

        private void HazırSiparisler_Load(object sender, EventArgs e)
        {          
            foreach (DictionaryEntry item in hzrsprslr)
            {
                    chkHazirSiparisler.Items.Add(item.Value.ToString() + "-" + item.Key.ToString());
            }          
        }
        private void btnAl_Click(object sender, EventArgs e)
        {
            ArrayList indexsil = new ArrayList();
            alinanlar = new SortedList();
            foreach (string  item in chkHazirSiparisler.CheckedItems)
            {
                string[] alinan = item.Split('-');
                string masaid = alinan[0];
                string urun = alinan[1];

                int index = chkHazirSiparisler.Items.IndexOf(item);
                indexsil.Add(index);

                alinanlar.Add(urun, masaid);//ilk eklediğimizi Key olarak ekliyor 2. yi value olarak ekliyor
               
            }
            int eksilt = 0;
            foreach (int item in indexsil)
            { 
                if (item!=0)
                {
                    int a = item - eksilt;
                    chkHazirSiparisler.Items.RemoveAt(a);
                }
                else { chkHazirSiparisler.Items.RemoveAt(item); }                
                eksilt++;
            }
            mc.SiparisAlindi(alinanlar);
            hzrsprslr.Clear();

            foreach (string  item in chkHazirSiparisler.Items)
            {
                string[] dizi1 = item.ToString().Split('-');
                string id = dizi1[0];
                string urunbilgi = dizi1[1];

                hzrsprslr.Add(urunbilgi,id);
            }
            if(hzrsprslr.Count==0)
            {
                ((Salonlar)Application.OpenForms.OfType<Salonlar>().SingleOrDefault()).btnHazirSiparis.Visible = false;
            }
                    
        }
    }
}
