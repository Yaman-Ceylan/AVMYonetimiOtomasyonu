using AVMYonetimiOtomasyonu.Database;
using AVMYonetimiOtomasyonu.Moduller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVMYonetimiOtomasyonu
{
    public partial class KullaniciAyarlari : Form
    {
        public KullaniciAyarlari()
        {
            InitializeComponent();

            RolVerileri();
        }

        string mevcutId;
        string mevcutAd;
        string mevcutSoyad;
        string mevcutEposta;
        string mevcutSifre;
        string mevcutRoltext;

        bool silKntrl = default(bool);
      
        public string LblKullanici { get; set; }
        public int RolID { get; set; }

        KullaniciIslemler kullaniciIslemler = new KullaniciIslemler();

        AcilisSayfasi acilisSayfasi = new AcilisSayfasi();
        AnaSayfa anaSayfa = new AnaSayfa();

        private void KullaniciAyarlari_Shown(object sender, EventArgs e)
        {
            KullaniciBilgileri();
        }

        public void KullaniciBilgileri()
        {
            lblKullanici.Text = LblKullanici.ToUpper();

            List<Kullanici> kullanici = new List<Kullanici>();
            kullanici = kullaniciIslemler.GetKullanicilar(LblKullanici);
            int rolId = default(int);
            if (kullanici.Count == 1)
            {
                foreach (var kul in kullanici)
                {
                    txtKullaniciID.Text = kul.KullaniciID;
                    txtKullaniciAdi.Text = kul.KullaniciAdi;
                    txtKullaniciSoyadi.Text = kul.KullaniciSoyadi;
                    txtKullaniciEposta.Text = kul.Eposta;
                    txtKullaniciSifre.Text = kul.Sifre;
                    rolId = kul.RolID;
                    cmbRol.Text = (rolId == 1) ? "Yönetici" : "Standart";
                }
            }

            mevcutId = txtKullaniciID.Text;
            mevcutAd = txtKullaniciAdi.Text;
            mevcutSoyad = txtKullaniciSoyadi.Text;
            mevcutEposta = txtKullaniciEposta.Text;
            mevcutSifre = txtKullaniciSifre.Text;
            mevcutRoltext = cmbRol.Text;
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

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            btnGuncelle.Visible = false;
            btnHesabiSil.Visible = false;
            btnKaydet.Visible = true;
            btnVazgec.Visible = true;
            btnTamam.Enabled = false;
            txtKullaniciID.Enabled = true;
            txtKullaniciAdi.Enabled = true;
            txtKullaniciSoyadi.Enabled = true;
            txtKullaniciEposta.Enabled = true;
            txtKullaniciSifre.Enabled = true;
            if (mevcutRoltext == "Yönetici")
            {
                cmbRol.Enabled = true;
            }
            else
            {
                cmbRol.Enabled = false;
            }
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string rolDeger = null;
            if (cmbRol.SelectedItem != null) { rolDeger = cmbRol.SelectedItem.ToString(); }
            if (!string.IsNullOrEmpty(txtKullaniciID.Text) && !string.IsNullOrEmpty(txtKullaniciAdi.Text) && !string.IsNullOrEmpty(txtKullaniciSoyadi.Text) && !string.IsNullOrEmpty(txtKullaniciEposta.Text) && !string.IsNullOrEmpty(txtKullaniciSifre.Text) && !string.IsNullOrEmpty(rolDeger))
            {
                if (IsValidEmail(txtKullaniciEposta.Text))
                {
                    string kullaniciId = txtKullaniciID.Text;
                    string ad = txtKullaniciAdi.Text;
                    string soyad = txtKullaniciSoyadi.Text;
                    string eposta = txtKullaniciEposta.Text;
                    string sifre = txtKullaniciSifre.Text;
                    int rolID = this.RolID;

                    bool result = kullaniciIslemler.Guncelle(mevcutId, mevcutEposta, mevcutSifre, kullaniciId, ad, soyad, eposta, sifre, rolID);

                    if (result)
                    {
                        MessageBox.Show("Güncellemeler Başarıyla Kaydedildi.");
                        LblKullanici = kullaniciId;
                        KullaniciBilgileri();

                        btnGuncelle.Visible = true;
                        btnHesabiSil.Visible = true;
                        btnKaydet.Visible = false;
                        btnVazgec.Visible = false;
                        btnTamam.Enabled = true;
                        txtKullaniciID.Enabled = false;
                        txtKullaniciAdi.Enabled = false;
                        txtKullaniciSoyadi.Enabled = false;
                        txtKullaniciEposta.Enabled = false;
                        txtKullaniciSifre.Enabled = false;
                        cmbRol.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme Başarısız.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Geçerli Bir Mail Adresi Girin.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurunuz.");
            }
        }

        private void btnHesabiSil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Hesabınızı Silmek Üzeresiniz, Onaylıyor Musunuz?", "Hesabı Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //chatGPT yardımı

            if (dialogResult == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(txtKullaniciID.Text))
                {
                    string kullaniciId = txtKullaniciID.Text;

                    bool result = kullaniciIslemler.Delete(kullaniciId);

                    if (result)
                    {
                        MessageBox.Show("Silme İşlemi Başarılı.");
                        silKntrl = true;
                        this.Close();
                        if (acilisSayfasi.Visible == false)
                        {
                            acilisSayfasi.Visible = true;
                        }                      
                    }
                    else
                    {
                        MessageBox.Show("Silme İşlemi Başarısız.");
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı Bilgisi Alınamadı.");
                }
            }        
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            KullaniciBilgileri();

            btnGuncelle.Visible = true;
            btnHesabiSil.Visible = true;
            btnKaydet.Visible = false;
            btnVazgec.Visible = false;
            btnTamam.Enabled = true;
            txtKullaniciID.Enabled = false;
            txtKullaniciAdi.Enabled = false;
            txtKullaniciSoyadi.Enabled = false;
            txtKullaniciEposta.Enabled = false;
            txtKullaniciSifre.Enabled = false;
            cmbRol.Enabled = false;
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool IsValidEmail(string email) //mail format doğrulama işlemi chatGPT yardımı
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void RolVerileri()
        {
            foreach (var rol in kullaniciIslemler.GetRoller())
            {
                cmbRol.Items.Add(new Rol(rol.Key, rol.Value));
            }
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRol.SelectedItem != null)
            {
                var secilenDeger = cmbRol.SelectedItem.ToString();

                foreach (var rol in kullaniciIslemler.GetRoller())
                {
                    if (rol.Value.Equals(secilenDeger))
                    {
                        this.RolID = rol.Key;
                    }
                }
            }
        }

        private void KullaniciAyarlari_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (silKntrl)
            {
                anaSayfa.Hide();
            }
            else
            {
                anaSayfa.LinkLblKullaniciID = LblKullanici;
                anaSayfa.Show();
            }
        }
    }
}
