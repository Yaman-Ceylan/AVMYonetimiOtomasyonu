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
    public partial class KullaniciKayitSayfasi : Form
    {
        public KullaniciKayitSayfasi()
        {
            InitializeComponent();

            RolVerileri();
        }

        private int RolID { get; set; }

        KullaniciIslemler kullaniciIslemler = new KullaniciIslemler();

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KullaniciKayitSayfasi_FormClosed(object sender, FormClosedEventArgs e)
        {
            AcilisSayfasi acilisSayfasi = new AcilisSayfasi();
            acilisSayfasi.Visible = true;        
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            string rolDeger = null;
            if (cmbRol.SelectedItem != null) { rolDeger = cmbRol.SelectedItem.ToString(); }
            if (!string.IsNullOrEmpty(txtKullaniciID.Text) && !string.IsNullOrEmpty(txtKullaniciAdi.Text) && !string.IsNullOrEmpty(txtKullaniciSoyadi.Text) && !string.IsNullOrEmpty(txtKullaniciEposta.Text) && !string.IsNullOrEmpty(txtKullaniciSifre.Text) && !string.IsNullOrEmpty(txtSifreTekrar.Text) && !string.IsNullOrEmpty(rolDeger))
            {
                if (IsValidEmail(txtKullaniciEposta.Text))
                {
                    if (txtKullaniciSifre.Text == txtSifreTekrar.Text)
                    {
                        string kullaniciId = txtKullaniciID.Text;
                        string ad = txtKullaniciAdi.Text;
                        string soyad = txtKullaniciSoyadi.Text;
                        string eposta = txtKullaniciEposta.Text;
                        string sifre = txtKullaniciSifre.Text;
                        int rolID = this.RolID;

                        bool result = kullaniciIslemler.Ekle(kullaniciId, ad, soyad, eposta, sifre, rolID);

                        if (result)
                        {
                            MessageBox.Show("Kayıt Başarılı.");

                            txtKullaniciID.Text = null;
                            txtKullaniciAdi.Text = null;
                            txtKullaniciSoyadi.Text = null;
                            txtKullaniciEposta.Text = null;
                            txtKullaniciSifre.Text = null;
                            txtSifreTekrar.Text = null;
                            cmbRol.SelectedItem = null;
                        }
                        else
                        {
                            MessageBox.Show("Kayıt Başarısız.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Eşleşmiyor.");
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

        public bool IsValidEmail(string email) //mail doğrulama işlemi chatGPT yardımı
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

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtKullaniciID.Text = null;
            txtKullaniciAdi.Text = null;
            txtKullaniciSoyadi.Text = null;
            txtKullaniciEposta.Text = null;
            txtKullaniciSifre.Text = null;
            txtSifreTekrar.Text = null;
            cmbRol.SelectedItem = null;
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

        private void picBoxSifreGoster_Click(object sender, EventArgs e)
        {
            if (txtKullaniciSifre.PasswordChar != default(char) && txtSifreTekrar.PasswordChar != default(char))
            {
                txtKullaniciSifre.PasswordChar = default(char);
                txtSifreTekrar.PasswordChar = default(char);
            }
            else
            {
                txtKullaniciSifre.PasswordChar = '*';
                txtSifreTekrar.PasswordChar = '*';
            }           
        }
    }
}
