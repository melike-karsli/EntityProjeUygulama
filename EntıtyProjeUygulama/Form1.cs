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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //senin veritabanının tamamını temsil eder. Bu bir "yönetici" veya "köprüdür". İçinde tabloları (KATEGORI, URUN vb.) barındırır.Görevi: Veritabanına bağlanmak, değişiklikleri izlemek ve SQL komutlarını çalıştırmaktır.
         DbEntıtyUrunEntities1 db = new DbEntıtyUrunEntities1(); //DbEntıtyUrunEntities1 sınıfından db adında bir nesne oluşturduk
        private void btnlıstele_Click(object sender, EventArgs e)
        {
            var kategoriler=db.KATEGORI.ToList();//KATEGORI tablosundaki verileri listeledik
            dataGridView1.DataSource = kategoriler;//datagridview1 e kategoriler listesini atadık

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            KATEGORI K = new KATEGORI(); //KATEGORI sınıfından K adında bir nesne oluşturduk
            K.AD = textBox2.Text;//txtad den aldığımız veriyi kATEGORI AD sine atadık
            db.KATEGORI.Add(K); //KATEGORI tablosuna ekledik
            db.SaveChanges(); //değişiklikleri kaydettik
            MessageBox.Show("Kategori Eklendi");
        }

        private void btsıl_Click(object sender, EventArgs e)
        {
            int x= Convert.ToInt32(textBox1.Text);//txtid den aldığımız veriyi int türüne çevirdik
            var ktg = db.KATEGORI.Find(x);//KATEGORI tablosunda id si x e eşit olan veriyi bulduk
            db.KATEGORI.Remove(ktg);//Bulduğumuz veriyi KATEGORI tablosundan sildik
            db.SaveChanges(); //değişiklikleri kaydettik
            MessageBox.Show("Kategori Silindi");

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);//txtid den aldığımız veriyi int türüne çevirdik
            var ktg = db.KATEGORI.Find(x);//KATEGORI tablosunda id si x e eşit olan veriyi bulduk
                        ktg.AD = textBox2.Text; //txtad den aldığımız veriyi KATEGORI AD sine atadık
                        db.SaveChanges(); //değişiklikleri kaydettik
                        MessageBox.Show("Kategori Güncellendi");

        }
    }
}
