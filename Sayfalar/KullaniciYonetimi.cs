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
    public partial class KullaniciYonetimi : Form
    {
        public KullaniciYonetimi()
        {
            InitializeComponent();

            DataVerileriListele();
            RolVerileri();
        }

        bool ekleClick = default(bool);
        bool guncelleClick = default(bool);
        string mevcutId;
        string mevcutAd;
        string mevcutSoyad;
        string mevcutEposta;
        string mevcutSifre;
        string mevcutRol;

        public string LinkLblKullaniciID { get; set; }
        public string SecilenId { get; set; }
        public int RolID { get; set; }

        KullaniciIslemler kullaniciIslemler = new KullaniciIslemler();

        AcilisSayfasi acilisSayfasi = new AcilisSayfasi();

        private void KullaniciYonetimi_Shown(object sender, EventArgs e)
        {
            linklblKullaniciID.Text = LinkLblKullaniciID.ToUpper();
            int rolId = kullaniciIslemler.GetRolIDByKullaniciID(LinkLblKullaniciID);
            if (rolId != default(int) && rolId == 2)
            {
                btnDuzenle.Visible = false;
            }
        }
        private void KullaniciYonetimi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linklblAnaSayfa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.LinkLblKullaniciID = this.LinkLblKullaniciID;
            this.Hide();
            anaSayfa.Show();
        }
        private void linklblKullaniciID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KullaniciAyarlari kullaniciAyarlari = new KullaniciAyarlari();
            kullaniciAyarlari.LblKullanici = LinkLblKullaniciID;
            this.Hide();
            kullaniciAyarlari.ShowDialog();
        }
        private void linklblCikis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AcilisSayfasi acilisSayfasi = new AcilisSayfasi();
            this.Hide();
            if (acilisSayfasi.Visible == false)
            {
                acilisSayfasi.Visible = true;
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            btnEkle.Visible = true;
            btnGuncelle.Visible = true;
            btnKaldir.Visible = true;
            btnTamam.Visible = true;
            btnVazgec.Visible = true;
            btnDuzenle.Visible = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            lblKullaniciID.Visible = true;
            lblKullaniciAdi.Visible = true;
            lblKullaniciSoyadi.Visible = true;
            lblEposta.Visible = true;
            lblSifre.Visible = true;
            lblRol.Visible = true;
            txtKullaniciID.Visible = true;
            txtKullaniciAdi.Visible = true;
            txtKullaniciSoyadi.Visible = true;
            txtKullaniciEposta.Visible = true;
            txtKullaniciSifre.Visible = true;
            cmbRol.Visible = true;

            btnEkle.Visible = false;
            btnGuncelle.Visible = false;
            btnKaldir.Visible = false;
            btnKaydet.Visible = true;
            txtKullaniciID.Enabled = true;
            txtKullaniciAdi.Enabled = true;
            txtKullaniciSoyadi.Enabled = true;
            txtKullaniciEposta.Enabled = true;
            txtKullaniciSifre.Enabled = true;
            cmbRol.Enabled = true;
            txtKullaniciID.Text = null;
            txtKullaniciAdi.Text = null;
            txtKullaniciSoyadi.Text = null;
            txtKullaniciEposta.Text = null;
            txtKullaniciSifre.Text = null;
            cmbRol.Text = null;

            ekleClick = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            btnEkle.Visible = false;
            btnGuncelle.Visible = false;
            btnKaldir.Visible = false;
            btnKaydet.Visible = true;
            txtKullaniciID.Enabled = true;
            txtKullaniciAdi.Enabled = true;
            txtKullaniciSoyadi.Enabled = true;
            txtKullaniciEposta.Enabled = true;
            txtKullaniciSifre.Enabled = true;
            cmbRol.Enabled = true;

            guncelleClick = true;
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            DataVerileriListele();

            btnEkle.Visible = false;
            btnGuncelle.Visible = false;
            btnKaldir.Visible = false;
            btnKaydet.Visible = false;
            btnVazgec.Visible = false;
            btnTamam.Visible = false;
            btnDuzenle.Visible = true;
            txtKullaniciID.Enabled = false;
            txtKullaniciAdi.Enabled = false;
            txtKullaniciSoyadi.Enabled = false;
            txtKullaniciEposta.Enabled = false;
            txtKullaniciSifre.Enabled = false;
            cmbRol.Enabled = false;

            KullaniciBilgileri();
        }
        private void btnTamam_Click(object sender, EventArgs e)
        {
            DataVerileriListele();

            btnEkle.Visible = false;
            btnGuncelle.Visible = false;
            btnKaldir.Visible = false;
            btnKaydet.Visible = false;
            btnVazgec.Visible = false;
            btnTamam.Visible = false;
            btnDuzenle.Visible = true;
            txtKullaniciID.Enabled = false;
            txtKullaniciAdi.Enabled = false;
            txtKullaniciSoyadi.Enabled = false;
            txtKullaniciEposta.Enabled = false;
            txtKullaniciSifre.Enabled = false;
            cmbRol.Enabled = false;

            KullaniciBilgileri();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string rolDeger = null;
            if (cmbRol.SelectedItem != null) { rolDeger = cmbRol.SelectedItem.ToString(); }

            if (ekleClick)
            {
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

                        bool result = kullaniciIslemler.Ekle(kullaniciId, ad, soyad, eposta, sifre, rolID);

                        if (result)
                        {
                            MessageBox.Show("Kullanıcı Sisteme Başarıyla Eklendi.");
                            DataVerileriListele();
                            SecilenId = null;
                            KullaniciBilgileri();
                            ekleClick = false;
                            txtKullaniciID.Enabled = false;
                            txtKullaniciAdi.Enabled = false;
                            txtKullaniciSoyadi.Enabled = false;
                            txtKullaniciEposta.Enabled = false;
                            txtKullaniciSifre.Enabled = false;
                            cmbRol.Enabled = false;
                            btnEkle.Visible = true;
                            btnGuncelle.Visible = true;
                            btnKaldir.Visible = true;
                            btnKaydet.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Ekleme Başarısız.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Lütfen Geçerli Bir Mail Adresi Girin.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Boş Alanları Doldurun.");
                }
            }
            else if (guncelleClick)
            {
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
                            if (mevcutId == LinkLblKullaniciID)
                            {
                                LinkLblKullaniciID = kullaniciId;
                                linklblKullaniciID.Text = LinkLblKullaniciID.ToUpper();

                                int rol = kullaniciIslemler.GetRolIDByKullaniciID(LinkLblKullaniciID);
                                if (rol != default(int) && rol == 2)
                                {
                                    btnDuzenle.Visible = false;
                                    btnEkle.Visible = false;
                                    btnGuncelle.Visible = false;
                                    btnKaldir.Visible = false;
                                    btnTamam.Visible = false;
                                    btnVazgec.Visible = false;
                                }
                                else if (rol != default(int) && rol == 1)
                                {
                                    btnEkle.Visible = true;
                                    btnGuncelle.Visible = true;
                                    btnKaldir.Visible = true;
                                }
                            }
                            DataVerileriListele();
                            SecilenId = null;
                            KullaniciBilgileri();
                            guncelleClick = false;
                            txtKullaniciID.Enabled = false;
                            txtKullaniciAdi.Enabled = false;
                            txtKullaniciSoyadi.Enabled = false;
                            txtKullaniciEposta.Enabled = false;
                            txtKullaniciSifre.Enabled = false;
                            cmbRol.Enabled = false;
                            btnKaydet.Visible = false;
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
                    MessageBox.Show("Lütfen Boş Alanları Doldurun.");
                }
            }
        }

        private void btnKaldir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bu Hesabı Silmek Üzeresiniz, Onaylıyor Musunuz?", "Hesabı Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //bu satır chatGPT yardımı

            if (dialogResult == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(SecilenId))
                {
                    string kullaniciId = SecilenId;

                    bool result = kullaniciIslemler.Delete(kullaniciId);

                    if (result)
                    {
                        MessageBox.Show("Kullanıcı Kaldırıldı.");
                        if (kullaniciId == LinkLblKullaniciID)
                        {
                            this.Hide();
                            if (acilisSayfasi.Visible == false)
                            {
                                acilisSayfasi.Visible = true;
                            }
                        }
                        else
                        {
                            DataVerileriListele();
                            SecilenId = null;
                            KullaniciBilgileri();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Kaldırma İşlemi Başarısız.");
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı Seçimi Yapılmadı.");
                }
            }
        }

        private void DataVerileriListele()
        {
            dGridKullanicilarTablosu.DataSource = null;
            dGridKullanicilarTablosu.DataSource = kullaniciIslemler.GetKullaniciYonetimiTablo();
            dGridKullanicilarTablosu.Columns["KullaniciID"].HeaderText = "Kullanıcı ID";
            dGridKullanicilarTablosu.Columns["Adi"].HeaderText = "Adı";
            dGridKullanicilarTablosu.Columns["Soyadi"].HeaderText = "Soyadı";
            dGridKullanicilarTablosu.Columns["Eposta"].HeaderText = "E-Posta";
            dGridKullanicilarTablosu.Columns["Sifre"].HeaderText = "Şifre";
            dGridKullanicilarTablosu.Columns["RolAdi"].HeaderText = "Rol";
        }

        private void KullaniciBilgileri()
        {
            if (SecilenId != null)
            {
                List<Kullanici> kullanici = new List<Kullanici>();
                kullanici = kullaniciIslemler.GetKullanicilar(SecilenId);
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
                mevcutRol = cmbRol.Text;

                lblKullaniciID.Visible = true;
                lblKullaniciAdi.Visible = true;
                lblKullaniciSoyadi.Visible = true;
                lblEposta.Visible = true;
                lblSifre.Visible = true;
                lblRol.Visible = true;
                txtKullaniciID.Visible = true;
                txtKullaniciAdi.Visible = true;
                txtKullaniciSoyadi.Visible = true;
                txtKullaniciEposta.Visible = true;
                txtKullaniciSifre.Visible = true;
                cmbRol.Visible = true;
            }
            else
            {
                lblKullaniciID.Visible = false;
                lblKullaniciAdi.Visible = false;
                lblKullaniciSoyadi.Visible = false;
                lblEposta.Visible = false;
                lblSifre.Visible = false;
                lblRol.Visible = false;
                txtKullaniciID.Visible = false;
                txtKullaniciAdi.Visible = false;
                txtKullaniciSoyadi.Visible = false;
                txtKullaniciEposta.Visible = false;
                txtKullaniciSifre.Visible = false;
                cmbRol.Visible = false;
            }
        }

        private void txtKullaniciAra_TextChanged(object sender, EventArgs e)
        {
            dGridKullanicilarTablosu.DataSource = null;
            dGridKullanicilarTablosu.DataSource = kullaniciIslemler.GetKullaniciByArama(txtKullaniciAra.Text);
            dGridKullanicilarTablosu.Columns["KullaniciID"].HeaderText = "Kullanıcı ID";
            dGridKullanicilarTablosu.Columns["Adi"].HeaderText = "Adı";
            dGridKullanicilarTablosu.Columns["Soyadi"].HeaderText = "Soyadı";
            dGridKullanicilarTablosu.Columns["Eposta"].HeaderText = "E-Posta";
            dGridKullanicilarTablosu.Columns["Sifre"].HeaderText = "Şifre";
            dGridKullanicilarTablosu.Columns["RolAdi"].HeaderText = "Rol";
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            if (lblKullaniciIDFil.Visible == false)
            {
                lblKullaniciIDFil.Visible = true;
                txtKullaniciIDFil.Visible = true;
                lblRolFil.Visible = true;
                cmbRolFil.Visible = true;
                btnUygula.Visible = true;
            }
            else
            {
                lblKullaniciIDFil.Visible = false;
                txtKullaniciIDFil.Visible = false;
                lblRolFil.Visible = false;
                cmbRolFil.Visible = false;
                btnUygula.Visible = false;
            }

        }
        private void btnUygula_Click(object sender, EventArgs e)
        {
            txtKullaniciAra.Text = null;

            dGridKullanicilarTablosu.DataSource = null;
            dGridKullanicilarTablosu.DataSource = kullaniciIslemler.GetKullaniciYonetimiTablo(txtKullaniciIDFil.Text, cmbRolFil.Text); ;
            dGridKullanicilarTablosu.Columns["KullaniciID"].HeaderText = "Kullanıcı ID";
            dGridKullanicilarTablosu.Columns["Adi"].HeaderText = "Adı";
            dGridKullanicilarTablosu.Columns["Soyadi"].HeaderText = "Soyadı";
            dGridKullanicilarTablosu.Columns["Eposta"].HeaderText = "E-Posta";
            dGridKullanicilarTablosu.Columns["Sifre"].HeaderText = "Şifre";
            dGridKullanicilarTablosu.Columns["RolAdi"].HeaderText = "Rol";

            lblKullaniciIDFil.Visible = false;
            txtKullaniciIDFil.Visible = false;
            lblRolFil.Visible = false;
            cmbRolFil.Visible = false;
            btnUygula.Visible = false;
        }

        private void dGridKullanicilarTablosu_SelectionChanged(object sender, EventArgs e)
        {
            if (dGridKullanicilarTablosu.SelectedRows.Count > 0)
            {
                DataGridViewRow secilen = dGridKullanicilarTablosu.SelectedRows[0];

                string secilenId = secilen.Cells["KullaniciID"].Value.ToString();

                SecilenId = secilenId;
            }
        }
        private void dGridKullanicilarTablosu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            KullaniciBilgileri();
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

        private void RolVerileri()
        {
            foreach (var rol in kullaniciIslemler.GetRoller())
            {
                cmbRol.Items.Add(new Rol(rol.Key, rol.Value));
                cmbRolFil.Items.Add(new Rol(rol.Key, rol.Value));
            }
        }

        public bool IsValidEmail(string email) //mail doğrulam işlemi chatGPT yardımı
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
    }
}
