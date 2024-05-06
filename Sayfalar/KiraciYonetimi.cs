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
    public partial class KiraciYonetimi : Form
    {
        public KiraciYonetimi()
        {
            InitializeComponent();

            DataVerileriListele();
        }

        bool ekleClick = default(bool);
        bool guncelleClick = default(bool);

        public int MekanID { get; set; }
        public int KonumID { get; set; }
        public string LinkLblKullaniciID { get; set; }
        public int SecilenId { get; set; }

        KiraciIslemler kiraciIslemler = new KiraciIslemler();
        KullaniciIslemler kullaniciIslemler = new KullaniciIslemler();

        private void DataVerileriListele()
        {
            dGridKiracilarTablosu.DataSource = null;
            dGridKiracilarTablosu.DataSource = kiraciIslemler.GetKiracilar();
            dGridKiracilarTablosu.Columns["KiraciID"].HeaderText = "Kiracı ID";
            dGridKiracilarTablosu.Columns["KiraciAdi"].HeaderText = "Kiracı Adı";
            dGridKiracilarTablosu.Columns["KiraciTelefon"].HeaderText = "Kiracı Telefon";
            dGridKiracilarTablosu.Columns["KiraciEPosta"].HeaderText = "Kiracı E-Posta";
        }

        private void KiraciBilgileri()
        {
            if (SecilenId != default(int))
            {
                List<Kiraci> kiraci = new List<Kiraci>();
                kiraci = kiraciIslemler.GetKiracilar(SecilenId);
                if (kiraci.Count == 1)
                {
                    foreach (var kira in kiraci)
                    {
                        txtKiraciID.Text = kira.KiraciID.ToString();
                        txtKiraciAdi.Text = kira.KiraciAdi;
                        txtKiraciTelefon.Text = kira.KiraciTelefon;
                        txtKiraciEposta.Text = kira.KiraciEPosta;
                    }
                }

                lblKiraciID.Visible = true;
                lblKiraciAdi.Visible = true;
                lblKiraciTelefon.Visible = true;
                lblKiraciEposta.Visible = true;
                txtKiraciID.Visible = true;
                txtKiraciAdi.Visible = true;
                txtKiraciTelefon.Visible = true;
                txtKiraciEposta.Visible = true;
            }
            else
            {
                lblKiraciID.Visible = false;
                lblKiraciAdi.Visible = false;
                lblKiraciTelefon.Visible = false;
                lblKiraciEposta.Visible = false;
                txtKiraciID.Visible = false;
                txtKiraciAdi.Visible = false;
                txtKiraciTelefon.Visible = false;
                txtKiraciEposta.Visible = false;
            }
        }

        private void KiraciYonetimi_Shown(object sender, EventArgs e)
        {
            linklblKullaniciID.Text = LinkLblKullaniciID.ToUpper();
            int rolId = kullaniciIslemler.GetRolIDByKullaniciID(LinkLblKullaniciID);
            if (rolId != default(int) && rolId == 2)
            {
                btnDuzenle.Visible = false;
            }
        }

        private void KiraciYonetimi_FormClosed(object sender, FormClosedEventArgs e)
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

        private void dGridKiracilarTablosu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            KiraciBilgileri();
        }

        private void dGridKiracilarTablosu_SelectionChanged(object sender, EventArgs e)
        {
            if (dGridKiracilarTablosu.SelectedRows.Count > 0)
            {
                DataGridViewRow secilen = dGridKiracilarTablosu.SelectedRows[0];

                int secilenId = (int)secilen.Cells["KiraciID"].Value;

                SecilenId = secilenId;
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
            lblKiraciID.Visible = true;
            lblKiraciAdi.Visible = true;
            lblKiraciTelefon.Visible = true;
            lblKiraciEposta.Visible = true;
            txtKiraciID.Visible = true;
            txtKiraciAdi.Visible = true;
            txtKiraciTelefon.Visible = true;
            txtKiraciEposta.Visible = true;

            btnEkle.Visible = false;
            btnGuncelle.Visible = false;
            btnKaldir.Visible = false;
            btnKaydet.Visible = true;
            txtKiraciAdi.Enabled = true;
            txtKiraciTelefon.Enabled = true;
            txtKiraciEposta.Enabled = true;
            txtKiraciID.Text = null;
            txtKiraciAdi.Text = null;
            txtKiraciTelefon.Text = null;
            txtKiraciEposta.Text = null;

            ekleClick = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            btnEkle.Visible = false;
            btnGuncelle.Visible = false;
            btnKaldir.Visible = false;
            btnKaydet.Visible = true;
            txtKiraciAdi.Enabled = true;
            txtKiraciTelefon.Enabled = true;
            txtKiraciEposta.Enabled = true;

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
            txtKiraciAdi.Enabled = false;
            txtKiraciTelefon.Enabled = false;
            txtKiraciEposta.Enabled = false;

            KiraciBilgileri();
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
            txtKiraciAdi.Enabled = false;
            txtKiraciTelefon.Enabled = false;
            txtKiraciEposta.Enabled = false;

            KiraciBilgileri();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            long longTelefon;

            if (ekleClick)
            {
                if (!string.IsNullOrEmpty(txtKiraciAdi.Text) && !string.IsNullOrEmpty(txtKiraciTelefon.Text) && !string.IsNullOrEmpty(txtKiraciEposta.Text))
                {
                    if (long.TryParse(txtKiraciTelefon.Text, out longTelefon))
                    {
                        if (IsValidEmail(txtKiraciEposta.Text))
                        {
                            string kiraciAdi = txtKiraciAdi.Text;
                            string kiraciTelefon = txtKiraciTelefon.Text;
                            string kiraciEposta = txtKiraciEposta.Text;

                            bool result = kiraciIslemler.Ekle(kiraciAdi, kiraciTelefon, kiraciEposta);

                            if (result)
                            {
                                MessageBox.Show("Kiracı Sisteme Başarıyla Eklendi.");

                                DataVerileriListele();
                                SecilenId = default(int);
                                KiraciBilgileri();
                                ekleClick = false;
                                txtKiraciAdi.Enabled = false;
                                txtKiraciTelefon.Enabled = false;
                                txtKiraciEposta.Enabled = false;
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
                        MessageBox.Show("Alanların Bilgilerini Doğru Şekilde Girin.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Boş Alanları Doldurunuz.");
                }
            }
            else if (guncelleClick)
            {
                if (!string.IsNullOrEmpty(txtKiraciID.Text))
                {
                    if (!string.IsNullOrEmpty(txtKiraciAdi.Text) && !string.IsNullOrEmpty(txtKiraciTelefon.Text) && !string.IsNullOrEmpty(txtKiraciEposta.Text))
                    {
                        if (long.TryParse(txtKiraciTelefon.Text, out longTelefon))
                        {
                            if (IsValidEmail(txtKiraciEposta.Text))
                            {
                                int kiraciId = Convert.ToInt32(txtKiraciID.Text);
                                string kiraciAdi = txtKiraciAdi.Text;
                                string kiraciTelefon = txtKiraciTelefon.Text;
                                string kiraciEposta = txtKiraciEposta.Text;

                                bool result = kiraciIslemler.Guncelle(kiraciId, kiraciAdi, kiraciTelefon, kiraciEposta);

                                if (result)
                                {
                                    MessageBox.Show("Güncellemeler Başarıyla Kaydedildi.");

                                    DataVerileriListele();
                                    SecilenId = default(int);
                                    KiraciBilgileri();
                                    guncelleClick = false;
                                    txtKiraciAdi.Enabled = false;
                                    txtKiraciTelefon.Enabled = false;
                                    txtKiraciEposta.Enabled = false;
                                    btnKaydet.Visible = false;
                                    btnEkle.Visible = true;
                                    btnGuncelle.Visible = true;
                                    btnKaldir.Visible = true;
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
                            MessageBox.Show("Alanların Bilgilerini Doğru Şekilde Girin.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Boş Alanları Doldurun.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Bir Seçim Yapın.");
                }
            }
        }

        private void btnKaldir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bu Kiracıyı Sistmeden Silmek Üzeresiniz, Onaylıyor Musunuz?", "Kiracı Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                if (SecilenId != default(int))
                {
                    int kiraciId = SecilenId;

                    bool result = kiraciIslemler.Delete(kiraciId);

                    if (result)
                    {
                        MessageBox.Show("Kiracı Kaldırıldı.");

                        DataVerileriListele();
                        SecilenId = default(int);
                        KiraciBilgileri();
                    }
                    else
                    {
                        MessageBox.Show("Kaldırma İşlemi Başarısız.");
                    }
                }
                else
                {
                    MessageBox.Show("Kiracı Seçimi Yapılmadı.");
                }
            }
        }

        private void txtKiraciAra_TextChanged(object sender, EventArgs e)
        {
            dGridKiracilarTablosu.DataSource = null;
            dGridKiracilarTablosu.DataSource = kiraciIslemler.GetKiraciByArama(txtKiraciAra.Text);
            dGridKiracilarTablosu.Columns["KiraciID"].HeaderText = "Kiracı ID";
            dGridKiracilarTablosu.Columns["KiraciAdi"].HeaderText = "Kiracı Adı";
            dGridKiracilarTablosu.Columns["KiraciTelefon"].HeaderText = "Kiracı Telefon";
            dGridKiracilarTablosu.Columns["KiraciEPosta"].HeaderText = "Kiracı E-Posta";
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            if (lblKiraciAdiFil.Visible == false)
            {
                lblKiraciAdiFil.Visible = true;
                txtKiraciAdiFil.Visible = true;
                btnUygula.Visible = true;
            }
            else
            {
                lblKiraciAdiFil.Visible = false;
                txtKiraciAdiFil.Visible = false;
                btnUygula.Visible = false;
            }
        }

        private void btnUygula_Click(object sender, EventArgs e)
        {
            txtKiraciAra.Text = null;

            dGridKiracilarTablosu.DataSource = null;
            dGridKiracilarTablosu.DataSource = kiraciIslemler.GetKiraciFiltre(txtKiraciAdiFil.Text); ;
            dGridKiracilarTablosu.Columns["KiraciID"].HeaderText = "Kiracı ID";
            dGridKiracilarTablosu.Columns["KiraciAdi"].HeaderText = "Kiracı Adı";
            dGridKiracilarTablosu.Columns["KiraciTelefon"].HeaderText = "Kiracı Telefon";
            dGridKiracilarTablosu.Columns["KiraciEPosta"].HeaderText = "Kiracı E-Posta";
        }

        public bool IsValidEmail(string email)
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
