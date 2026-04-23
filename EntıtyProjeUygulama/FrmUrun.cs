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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        DbEntıtyUrunEntities1 db = new DbEntıtyUrunEntities1();
        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.URUN select new
            {
                x.URUNID,
                x.URUNADI,
                x.MARKA,
                x.STOK,
                x.FIYAT,
                x.KATEGORI1.AD, //URUN tablosuyla ilişkili olan KATEGORI tablosundan AD alanını cagırdık.
                                //Adı KATEGORI1 oldu çünkü diğer tablodakı KATEGORI kolonu ıle karışmamalıdır
                x.DURUM
            }).ToList();

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            URUN t = new URUN();
            t.URUNADI = txtadı.Text;
            t.MARKA = txtmarka.Text;
            t.STOK = short.Parse(txtstok.Text);
            t.FIYAT = decimal.Parse(txtfıyat.Text);
            t.KATEGORI= int.Parse(cmbkategori.SelectedValue.ToString());
            t.DURUM = true;
            db.URUN.Add(t);

            db.SaveChanges();
            MessageBox.Show("Ürün Eklendi");

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x= Convert.ToInt32(txtıd.Text);
            var urun = db.URUN.Find(x);
            db.URUN.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi");

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtıd.Text);
            var urun = db.URUN.Find(x);
            urun.URUNADI = txtadı.Text;
            urun.MARKA = txtmarka.Text;
            urun.STOK = short.Parse(txtstok.Text);
           // urun.FIYAT = decimal.Parse(txtfıyat.Text);
            //urun.KATEGORI = int.Parse(cmbkategori.Text);
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi");

        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.KATEGORI
                               select new
                               {
                                   x.ID,
                                   x.AD // Buraya x. yazınca listede KATEGORIAD çıkmalı
                               }).ToList();

            cmbkategori.ValueMember = "ID";
            cmbkategori.DisplayMember = "AD";
            cmbkategori.DataSource = kategoriler;
        }

        private void txtadı_TextChanged(object sender, EventArgs e)
        {

        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtadı.Text = cmbkategori.SelectedValue.ToString();
        }
    }
}
