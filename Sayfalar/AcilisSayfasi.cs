using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVMYonetimiOtomasyonu
{
    public partial class AcilisSayfasi : Form
    {
        public AcilisSayfasi()
        {
            InitializeComponent();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            KullaniciKayitSayfasi kullaniciKayitSayfasi = new KullaniciKayitSayfasi();
            kullaniciKayitSayfasi.Show();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            GirisSayfasi girisSayfasi = new GirisSayfasi();
            girisSayfasi.Show();
        }

        private void AcilisSayfasi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
