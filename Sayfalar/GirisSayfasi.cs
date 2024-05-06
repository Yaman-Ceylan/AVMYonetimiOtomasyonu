using AVMYonetimiOtomasyonu.Database;
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
    public partial class GirisSayfasi : Form
    {
        public GirisSayfasi()
        {
            InitializeComponent();
        }

        AcilisSayfasi acilisSayfasi = new AcilisSayfasi();

        KullaniciIslemler kullaniciIslemler = new KullaniciIslemler();

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GirisSayfasi_FormClosed(object sender, FormClosedEventArgs e)
        {
            acilisSayfasi.Visible = true;
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtKullaniciID.Text) && !string.IsNullOrEmpty(txtKullaniciSifre.Text))
            {
                string kullaniciId = txtKullaniciID.Text;
                string sifre = txtKullaniciSifre.Text;

                bool result = kullaniciIslemler.GirisKontrol(kullaniciId, sifre);

                if (result)
                {
                    MessageBox.Show("Giriş Başarılı.");
                    AnaSayfa anaSayfa = new AnaSayfa();
                    anaSayfa.LinkLblKullaniciID = kullaniciId;
                    this.Close();
                    acilisSayfasi.Visible = false;
                    anaSayfa.Show();
                }
                else
                {
                    MessageBox.Show("Giriş Başarısız.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Kullanıcı ID ve Şifre Giriniz.");
            }
        }

        private void txtKullaniciID_KeyPress(object sender, KeyPressEventArgs e) //chatGPT yardımı alınmıştır
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Enter tuşuna basıldığında giriş yap butonuna tıklama işlemi
                btnGirisYap.PerformClick();
            }
        }

        private void txtKullaniciSifre_KeyPress(object sender, KeyPressEventArgs e) //chatGPT yardımı alınmıştır
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Enter tuşuna basıldığında giriş yap butonuna tıklama işlemi
                btnGirisYap.PerformClick();
            }
        }

        private void picBoxSifreGoster_Click(object sender, EventArgs e)
        {
            if (txtKullaniciSifre.PasswordChar != default(char))
            {
                txtKullaniciSifre.PasswordChar = default(char);
            }
            else
            {
                txtKullaniciSifre.PasswordChar = '*';
            }
        }
    }
}
