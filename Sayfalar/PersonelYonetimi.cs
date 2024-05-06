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
    public partial class PersonelYonetimi : Form
    {
        public PersonelYonetimi()
        {
            InitializeComponent();

            DataVerileriListele();
            
            PozisyonVerileri();
            CinsiyetVerileri();
        }

        bool ekleClick = default(bool);
        bool guncelleClick = default(bool);

        public int PozisyonID { get; set; }
        public string LinkLblKullaniciID { get; set; }
        public string SecilenTC { get; set; }

        PersonelIslemler personelIslemler = new PersonelIslemler();
        KullaniciIslemler kullaniciIslemler = new KullaniciIslemler();

        private void DataVerileriListele()
        {
            dGridPersonellerTablosu.DataSource = null;
            dGridPersonellerTablosu.DataSource = personelIslemler.GetPersoneller();
            dGridPersonellerTablosu.Columns["PersonelTC"].HeaderText = "Personel TC";
            dGridPersonellerTablosu.Columns["PersonelAdi"].HeaderText = "Personel Adı";
            dGridPersonellerTablosu.Columns["PersonelSoyadi"].HeaderText = "Personel Soyadı";
            dGridPersonellerTablosu.Columns["Cinsiyet"].HeaderText = "Cinsiyet";
            dGridPersonellerTablosu.Columns["Telefon"].HeaderText = "Telefon";
            dGridPersonellerTablosu.Columns["Eposta"].HeaderText = "E-Posta";
            dGridPersonellerTablosu.Columns["Adres"].HeaderText = "Adres";
            dGridPersonellerTablosu.Columns["Pozisyon"].HeaderText = "Pozisyon";
            dGridPersonellerTablosu.Columns["Maas"].HeaderText = "Maaş";
        }

        private void PersonelBilgileri()
        {
            if (SecilenTC != null)
            {
                List<Personel> personel = new List<Personel>();
                personel = personelIslemler.GetPersoneller(SecilenTC);
                if (personel.Count == 1)
                {
                    foreach (var person in personel)
                    {
                        txtPersonelTC.Text = person.PersonelTC;
                        txtPersonelAdi.Text = person.PersonelAdi;
                        txtPersonelSoyadi.Text = person.PersonelSoyadi;
                        cmbCinsiyet.Text = person.Cinsiyet;
                        txtTelefon.Text = person.Telefon;
                        txtEPosta.Text = person.Eposta;
                        txtAdres.Text = person.Adres;
                        cmbPozisyon.Text = person.Pozisyon;
                        txtMaas.Text = person.Maas.ToString("#,##0.00 ₺");  //Para birimi ve format yapısı chatGPT kaynağından alınmıştır.                       
                    }
                }

                lblPersonelTC.Visible = true;
                lblPersonelAdi.Visible = true;
                lblPersonelSoyadi.Visible = true;
                lblCinsiyet.Visible = true;
                lblTelefon.Visible = true;
                lblEPosta.Visible = true;
                lblAdres.Visible = true;
                lblPozisyon.Visible = true;
                lblMaas.Visible = true;
                txtPersonelTC.Visible = true;
                txtPersonelAdi.Visible = true;
                txtPersonelSoyadi.Visible = true;
                cmbCinsiyet.Visible = true;
                txtTelefon.Visible = true;
                txtEPosta.Visible = true;
                txtAdres.Visible = true;
                cmbPozisyon.Visible = true;
                txtMaas.Visible = true;

            }
            else
            {
                lblPersonelTC.Visible = false;
                lblPersonelAdi.Visible = false;
                lblPersonelSoyadi.Visible = false;
                lblCinsiyet.Visible = false;
                lblTelefon.Visible = false;
                lblEPosta.Visible = false;
                lblAdres.Visible = false;
                lblPozisyon.Visible = false;
                lblMaas.Visible = false;
                txtPersonelTC.Visible = false;
                txtPersonelAdi.Visible = false;
                txtPersonelSoyadi.Visible = false;
                cmbCinsiyet.Visible = false;
                txtTelefon.Visible = false;
                txtEPosta.Visible = false;
                txtAdres.Visible = false;
                cmbPozisyon.Visible = false;
                txtMaas.Visible = false;
            }
        }

        private void PersonelYonetimi_Shown(object sender, EventArgs e)
        {
            linklblKullaniciID.Text = LinkLblKullaniciID.ToUpper();
            int rolId = kullaniciIslemler.GetRolIDByKullaniciID(LinkLblKullaniciID);
            if (rolId != default(int) && rolId == 2)
            {
                btnDuzenle.Visible = false;
            }
        }

        private void PersonelYonetimi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cmbPozisyon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPozisyon.SelectedItem != null)
            {
                var secilenDeger = cmbPozisyon.SelectedItem.ToString();

                foreach (var pozisyon in personelIslemler.GetPozisyonlar())
                {
                    if (pozisyon.Value.Equals(secilenDeger))
                    {
                        this.PozisyonID = pozisyon.Key;
                    }
                }
            }
        }
        private void PozisyonVerileri()
        {
            foreach (var pozisyon in personelIslemler.GetPozisyonlar())
            {
                cmbPozisyon.Items.Add(new Pozisyon(pozisyon.Key, pozisyon.Value));
                cmbPozisyonFil.Items.Add(new Pozisyon(pozisyon.Key, pozisyon.Value));
            }
        }

        private void CinsiyetVerileri()
        {
            foreach (var cinsiyet in personelIslemler.GetCinsiyetler())
            {
                cmbCinsiyet.Items.Add(cinsiyet);
                cmbCinsiyetFil.Items.Add(cinsiyet);
            }
        }

        private void dGridPersonellerTablosu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PersonelBilgileri();
        }

        private void dGridPersonellerTablosu_SelectionChanged(object sender, EventArgs e)
        {
            if (dGridPersonellerTablosu.SelectedRows.Count > 0)
            {
                DataGridViewRow secilen = dGridPersonellerTablosu.SelectedRows[0];

                string secilenTC = secilen.Cells["PersonelTC"].Value.ToString(); 

                SecilenTC = secilenTC;
            }
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
            lblPersonelTC.Visible = true;
            lblPersonelAdi.Visible = true;
            lblPersonelSoyadi.Visible = true;
            lblCinsiyet.Visible = true;
            lblTelefon.Visible = true;
            lblEPosta.Visible = true;
            lblAdres.Visible = true;
            lblPozisyon.Visible = true;
            lblMaas.Visible = true;
            txtPersonelTC.Visible = true;
            txtPersonelAdi.Visible = true;
            txtPersonelSoyadi.Visible = true;
            cmbCinsiyet.Visible = true;
            txtTelefon.Visible = true;
            txtEPosta.Visible = true;
            txtAdres.Visible = true;
            cmbPozisyon.Visible = true;
            txtMaas.Visible = true;

            btnEkle.Visible = false;
            btnGuncelle.Visible = false;
            btnKaldir.Visible = false;
            btnKaydet.Visible = true;
            txtPersonelTC.Enabled = true;
            txtPersonelAdi.Enabled = true;
            txtPersonelSoyadi.Enabled = true;
            cmbCinsiyet.Enabled = true;
            txtTelefon.Enabled = true;
            txtEPosta.Enabled = true;
            txtAdres.Enabled = true;
            cmbPozisyon.Enabled = true;
            txtMaas.Enabled = true;
            txtPersonelTC.Text = null;
            txtPersonelAdi.Text = null;
            txtPersonelSoyadi.Text = null;
            cmbCinsiyet.Text = null;
            txtTelefon.Text = null;
            txtEPosta.Text = null;
            txtAdres.Text = null;
            cmbPozisyon.Text = null;
            txtMaas.Text = null;

            ekleClick = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            btnEkle.Visible = false;
            btnGuncelle.Visible = false;
            btnKaldir.Visible = false;
            btnKaydet.Visible = true;
            txtPersonelAdi.Enabled = true;
            txtPersonelSoyadi.Enabled = true;
            cmbCinsiyet.Enabled = true;
            txtTelefon.Enabled = true;
            txtEPosta.Enabled = true;
            txtAdres.Enabled = true;
            cmbPozisyon.Enabled = true;
            txtMaas.Enabled = true;

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
            txtPersonelTC.Enabled = false;
            txtPersonelAdi.Enabled = false;
            txtPersonelSoyadi.Enabled = false;
            cmbCinsiyet.Enabled = false;
            txtTelefon.Enabled = false;
            txtEPosta.Enabled = false;
            txtAdres.Enabled = false;
            cmbPozisyon.Enabled = false;
            txtMaas.Enabled = false;

            PersonelBilgileri();
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
            txtPersonelTC.Enabled = false;
            txtPersonelAdi.Enabled = false;
            txtPersonelSoyadi.Enabled = false;
            cmbCinsiyet.Enabled = false;
            txtTelefon.Enabled = false;
            txtEPosta.Enabled = false;
            txtAdres.Enabled = false;
            cmbPozisyon.Enabled = false;
            txtMaas.Enabled = false;

            PersonelBilgileri();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string cinsiyetDeger = null;
            if (cmbCinsiyet.SelectedItem != null) { cinsiyetDeger = cmbCinsiyet.SelectedItem.ToString(); }
            string pozisyonDeger = null;
            if (cmbPozisyon.SelectedItem != null) { pozisyonDeger = cmbPozisyon.SelectedItem.ToString(); }

            long longPersonelTC;
            long longTelefon;
            double maas;

            if (ekleClick)
            {
                if (!string.IsNullOrEmpty(txtPersonelTC.Text) && !string.IsNullOrEmpty(txtPersonelAdi.Text) && !string.IsNullOrEmpty(txtPersonelSoyadi.Text) && !string.IsNullOrEmpty(cinsiyetDeger) && !string.IsNullOrEmpty(txtTelefon.Text) && !string.IsNullOrEmpty(txtEPosta.Text) && !string.IsNullOrEmpty(txtAdres.Text) && !string.IsNullOrEmpty(pozisyonDeger) && !string.IsNullOrEmpty(txtMaas.Text))
                {
                    if (long.TryParse(txtPersonelTC.Text, out longPersonelTC) && long.TryParse(txtTelefon.Text, out longTelefon) && Double.TryParse(txtMaas.Text, out maas))
                    {
                        if (IsValidEmail(txtEPosta.Text))
                        {
                            string personelTC = txtPersonelTC.Text;
                            string personelAdi = txtPersonelAdi.Text;
                            string personelSoyadi = txtPersonelSoyadi.Text;
                            string cinsiyet = cinsiyetDeger;
                            string telefon = txtTelefon.Text;
                            string eposta = txtEPosta.Text;
                            string adres = txtAdres.Text;
                            int pozisyon = this.PozisyonID;
                            maas = Convert.ToDouble(txtMaas.Text);

                            bool result = personelIslemler.Ekle(personelTC, personelAdi, personelSoyadi, cinsiyet, telefon, eposta, adres, pozisyon, maas);

                            if (result)
                            {
                                MessageBox.Show("Personel Sisteme Başarıyla Eklendi.");

                                DataVerileriListele();
                                SecilenTC = null;
                                PersonelBilgileri();
                                ekleClick = false;
                                txtPersonelTC.Enabled = false;
                                txtPersonelAdi.Enabled = false;
                                txtPersonelSoyadi.Enabled = false;
                                cmbCinsiyet.Enabled = false;
                                txtTelefon.Enabled = false;
                                txtEPosta.Enabled = false;
                                txtAdres.Enabled = false;
                                cmbPozisyon.Enabled = false;
                                txtMaas.Enabled = false;
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
                    MessageBox.Show("Lütfen Boş Alanları Doldurun.");
                }
            }
            else if (guncelleClick)
            {
                if (!string.IsNullOrEmpty(txtPersonelTC.Text))
                {
                    if (string.IsNullOrEmpty(txtPersonelAdi.Text) && !string.IsNullOrEmpty(txtPersonelSoyadi.Text) && !string.IsNullOrEmpty(cinsiyetDeger) && !string.IsNullOrEmpty(txtTelefon.Text) && !string.IsNullOrEmpty(txtEPosta.Text) && !string.IsNullOrEmpty(txtAdres.Text) && !string.IsNullOrEmpty(pozisyonDeger) && !string.IsNullOrEmpty(txtMaas.Text))
                    {
                        if (long.TryParse(txtPersonelTC.Text, out longPersonelTC) && long.TryParse(txtTelefon.Text, out longTelefon) && Double.TryParse(txtMaas.Text, out maas))
                        {
                            if (IsValidEmail(txtEPosta.Text))
                            {
                                string personelTC = txtPersonelTC.Text;
                                string personelAdi = txtPersonelAdi.Text;
                                string personelSoyadi = txtPersonelSoyadi.Text;
                                string cinsiyet = cinsiyetDeger;
                                string telefon = txtTelefon.Text;
                                string eposta = txtEPosta.Text;
                                string adres = txtAdres.Text;
                                int pozisyon = this.PozisyonID;
                                maas = Convert.ToDouble(txtMaas.Text);

                                bool result = personelIslemler.Guncelle(personelTC, personelAdi, personelSoyadi, cinsiyet, telefon, eposta, adres, pozisyon, maas);

                                if (result)
                                {
                                    MessageBox.Show("Güncellemeler Başarıyla Kaydedildi.");

                                    DataVerileriListele();
                                    SecilenTC = null;
                                    PersonelBilgileri();
                                    guncelleClick = false;
                                    txtPersonelTC.Enabled = false;
                                    txtPersonelAdi.Enabled = false;
                                    txtPersonelSoyadi.Enabled = false;
                                    cmbCinsiyet.Enabled = false;
                                    txtTelefon.Enabled = false;
                                    txtEPosta.Enabled = false;
                                    txtAdres.Enabled = false;
                                    cmbPozisyon.Enabled = false;
                                    txtMaas.Enabled = false;
                                    btnEkle.Visible = true;
                                    btnGuncelle.Visible = true;
                                    btnKaldir.Visible = true;
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
            DialogResult dialogResult = MessageBox.Show("Bu Personeli Sistmeden Silmek Üzeresiniz, Onaylıyor Musunuz?", "Personel Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);  //chatGPT kaynağından alıntılanmıştır.

            if (dialogResult == DialogResult.Yes) //chatGPT kaynağından alıntılanmıştır.
            {
                if (SecilenTC != null)
                {
                    string personelTC = SecilenTC;

                    bool result = personelIslemler.Delete(personelTC);

                    if (result)
                    {
                        MessageBox.Show("Personel Silindi.");

                        DataVerileriListele();
                        SecilenTC = null;
                        PersonelBilgileri();
                    }
                    else
                    {
                        MessageBox.Show("Kaldırma İşlemi Başarısız.");
                    }
                }
                else
                {
                    MessageBox.Show("Personel Seçimi Yapılmadı.");
                }
            }
        }

        private void txtPersonelAra_TextChanged(object sender, EventArgs e)
        {
            dGridPersonellerTablosu.DataSource = null;
            dGridPersonellerTablosu.DataSource = personelIslemler.GetPersonelByArama(txtPersonelAra.Text);
            dGridPersonellerTablosu.Columns["PersonelTC"].HeaderText = "Personel TC";
            dGridPersonellerTablosu.Columns["PersonelAdi"].HeaderText = "Personel Adı";
            dGridPersonellerTablosu.Columns["PersonelSoyadi"].HeaderText = "Personel Soyadı";
            dGridPersonellerTablosu.Columns["Cinsiyet"].HeaderText = "Cinsiyet";
            dGridPersonellerTablosu.Columns["Telefon"].HeaderText = "Telefon";
            dGridPersonellerTablosu.Columns["Eposta"].HeaderText = "E-Posta";
            dGridPersonellerTablosu.Columns["Adres"].HeaderText = "Adres";
            dGridPersonellerTablosu.Columns["Pozisyon"].HeaderText = "Pozisyon";
            dGridPersonellerTablosu.Columns["Maas"].HeaderText = "Maaş";
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            if (lblCinsiyetFil.Visible == false)
            {
                lblCinsiyetFil.Visible = true;
                cmbCinsiyetFil.Visible = true;
                lblPozisyonFil.Visible = true;
                cmbPozisyonFil.Visible = true;
                lblMinMaasFil.Visible = true;
                txtMinMaasFil.Visible = true;
                lblMaxMaasFil.Visible = true;
                txtMaxMaasFil.Visible = true;
                btnUygula.Visible = true;
            }
            else
            {
                lblCinsiyetFil.Visible = false;
                cmbCinsiyetFil.Visible = false;
                lblPozisyonFil.Visible = false;
                cmbPozisyonFil.Visible = false;
                lblMinMaasFil.Visible = false;
                txtMinMaasFil.Visible = false;
                lblMaxMaasFil.Visible = false;
                txtMaxMaasFil.Visible = false;
                btnUygula.Visible = false;
            }
        }

        private void btnUygula_Click(object sender, EventArgs e)
        {
            txtPersonelAra.Text = null;

            double doubMin;
            double doubMax;
            if (double.TryParse(txtMinMaasFil.Text, out doubMin) && double.TryParse(txtMaxMaasFil.Text, out doubMax))
            {
                doubMin = Convert.ToDouble(txtMinMaasFil.Text);
                doubMax = Convert.ToDouble(txtMaxMaasFil.Text);
            }
            else
            {
                if (!double.TryParse(txtMinMaasFil.Text, out doubMin))
                {
                    doubMin = default(double);
                }
                if (!double.TryParse(txtMaxMaasFil.Text, out doubMax))
                {
                    doubMax = 9999999999;
                }
            }

            dGridPersonellerTablosu.DataSource = null;
            dGridPersonellerTablosu.DataSource = personelIslemler.GetPersonelByFiltre(cmbPozisyonFil.Text, cmbCinsiyetFil.Text, doubMin, doubMax);            
            dGridPersonellerTablosu.Columns["PersonelTC"].HeaderText = "Personel TC";
            dGridPersonellerTablosu.Columns["PersonelAdi"].HeaderText = "Personel Adı";
            dGridPersonellerTablosu.Columns["PersonelSoyadi"].HeaderText = "Personel Soyadı";
            dGridPersonellerTablosu.Columns["Cinsiyet"].HeaderText = "Cinsiyet";
            dGridPersonellerTablosu.Columns["Telefon"].HeaderText = "Telefon";
            dGridPersonellerTablosu.Columns["Eposta"].HeaderText = "E-Posta";
            dGridPersonellerTablosu.Columns["Adres"].HeaderText = "Adres";
            dGridPersonellerTablosu.Columns["Pozisyon"].HeaderText = "Pozisyon";
            dGridPersonellerTablosu.Columns["Maas"].HeaderText = "Maaş";

            lblCinsiyetFil.Visible = false;
            cmbCinsiyetFil.Visible = false;
            lblPozisyonFil.Visible = false;
            cmbPozisyonFil.Visible = false;
            lblMinMaasFil.Visible = false;
            txtMinMaasFil.Visible = false;
            lblMaxMaasFil.Visible = false;
            txtMaxMaasFil.Visible = false;
            btnUygula.Visible = false;
        }

        public bool IsValidEmail(string email) //Mail format uygunluğu chatGPT kaynağından alıntılanmıştır.
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
