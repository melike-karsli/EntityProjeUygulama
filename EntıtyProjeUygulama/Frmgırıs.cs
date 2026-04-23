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
    public partial class Frmgırıs : Form
    {
        public Frmgırıs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbEntıtyUrunEntities1 db = new DbEntıtyUrunEntities1();
            var sorgu = from x in db.ADMIN
                        where x.KULLANICI == textBox1.Text && x.SIFRE == textBox2.Text
                        select x;
            if (sorgu.Any())
            {
                
                Frmanaform frmanaform = new Frmanaform();
                frmanaform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış.");
            }
        }
    }
}
