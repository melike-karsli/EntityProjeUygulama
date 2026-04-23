using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntıtyProjeUygulama
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        DbEntıtyUrunEntities1 db = new DbEntıtyUrunEntities1();
        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.KATEGORI.Count().ToString();
            label3.Text = db.URUN.Count().ToString();
            label5.Text = db.MUSTERI.Count(x => x.DURUM == true).ToString();
            label7.Text = db.MUSTERI.Count(x => x.DURUM == false).ToString();
            label11.Text = db.URUN.Sum(x => x.STOK).ToString(); //toplam urun stok sayısı
            label13.Text = (from x in db.URUN orderby x.FIYAT descending select x.URUNADI).FirstOrDefault(); //en pahalı ürün
            label15.Text = (from x in db.URUN orderby x.FIYAT ascending select x.URUNADI).FirstOrDefault(); //en ucuz ürün
            label19.Text = db.SATIS.Sum(x => x.FIYAT).ToString() + "TL"; //toplam satış tutarı
            label9.Text = db.URUN.Count(x => x.KATEGORI == 1).ToString(); //kategorisi 1 olan ürün sayısı
            label23.Text = db.URUN.Count(x => x.URUNADI.Contains("BUZDOLABI")).ToString(); //buzdolabı sayısı   
            label17.Text= (from x in db.MUSTERI select x.SEHIR).Distinct().Count().ToString(); //farklı şehir sayısı
            //label21.Text= db.URUN.GroupBy(x => x.MARKA)              // Elemanları grupla
            //          .Where(g => g.Count() > 1)    // Birden fazla olanları seç
            //          .Select(y => y.Key)           // Değerin kendisini al
            //          .FirstOrDefault();            // İlkini al
            label21.Text= db.MARKAGETIR().FirstOrDefault(); //MARKAGETIR adında bir fonksiyon oluşturduk ve markaları getirdik. En çok kullanılan marka ekrana yazdırıldı.
        }
    }
}
