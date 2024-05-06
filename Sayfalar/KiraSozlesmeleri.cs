using AVMYonetimiOtomasyonu.Database;
using AVMYonetimiOtomasyonu.Moduller;
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
    public partial class KiraSozlesmeleri : Form
    {
        public KiraSozlesmeleri()
        {
            InitializeComponent();

            DataVerileriListele();

            IsletmeVerileri();
            KiraciVerileri();
            MekanVerileri();
            KonumVerileri();
        }

        bool ekleClick = default(bool);
        bool guncelleClick = default(bool);

        public int IsletmeID { get; set; }
        public int KiraciID { get; set; }
        public int MekanID { get; set; }
        public int KonumID { get; set; }
        public string LinkLblKullaniciID { get; set; }
        public int SecilenId { get; set; }

        SozlesmeIslemler sozlesmeIslemler = new SozlesmeIslemler();
        IsletmeIslemler isletmeIslemler = new IsletmeIslemler();
        KullaniciIslemler kullaniciIslemler = new KullaniciIslemler();
        KiraciIslemler kiraciIslemler = new KiraciIslemler();

        private void DataVerileriListele()
        {
            dGridSozlesmelerTablosu.DataSource = null;
            dGridSozlesmelerTablosu.DataSource = sozlesmeIslemler.GetSozlesmeler();
            dGridSozlesmelerTablosu.Columns["KiraID"].HeaderText = "Kira ID";
            dGridSozlesmelerTablosu.Columns["Isletme"].HeaderText = "İşletme";
            dGridSozlesmelerTablosu.Columns["Kiraci"].HeaderText = "Kiracı";
            dGridSozlesmelerTablosu.Columns["MekanTipi"].HeaderText = "Mekan Tipi";
            dGridSozlesmelerTablosu.Columns["Konum"].HeaderText = "Konum";
            dGridSozlesmelerTablosu.Columns["KiralikAlan"].HeaderText = "Kiralık Alan m2";
            dGridSozlesmelerTablosu.Columns["KiraBedeli"].HeaderText = "Kira Bedeli";
            dGridSozlesmelerTablosu.Columns["BaslangicTarihi"].HeaderText = "Başlangıç Tarihi";
            dGridSozlesmelerTablosu.Columns["BitisTarihi"].HeaderText = "Bitiş Tarihi";
        }

        private void SozlesmeBilgileri()
        {
            if (SecilenId != default(int))
            {
                List<KiraSozlesmesi> sozlesme = new List<KiraSozlesmesi>();
                sozlesme = sozlesmeIslemler.GetSozlesmeler(SecilenId);
                if (sozlesme.Count == 1)
                {
                    foreach (var soz in sozlesme)
                    {
                        txtKiraID.Text = soz.KiraID.ToString();
                        cmbIsletme.Text = soz.Isletme;
                        cmbKiraci.Text = soz.Kiraci;
                        cmbMekanTipi.Text = soz.MekanTipi;
                        cmbKonum.Text = soz.Konum;
                        txtKiralikAlan.Text = soz.KiralikAlan;
                        txtKiraBedeli.Text = soz.KiraBedeli.ToString("#,##0.00 ₺");  //para birimi ve formatı chatGPT kaynağından alınmıştır.
                        txtBaslangicTarihi.Text = soz.BaslangicTarihi.ToString("dd-MM-yyyy"); //tarih formatı chatGPT aynağından alınmıştır.
                        txtBitisTarihi.Text = soz.BitisTarihi.ToString("dd-MM-yyyy");
                    }
                }

                lblKiraID.Visible = true;
                lblIsletme.Visible = true;
                lblKiraci.Visible = true;
                lblMekanTipi.Visible = true;
                lblKonum.Visible = true;
                lblKiralikAlan.Visible = true;
                lblKiraBedeli.Visible = true;
                lblBaslangicTarihi.Visible = true;
                lblBitisTarihi.Visible = true;
                txtKiraID.Visible = true;
                cmbIsletme.Visible = true;
                cmbKiraci.Visible = true;
                cmbMekanTipi.Visible = true;
                cmbKonum.Visible = true;
                txtKiralikAlan.Visible = true;
                txtKiraBedeli.Visible = true;
                txtBaslangicTarihi.Visible = true;
                txtBitisTarihi.Visible = true;

            }
            else
            {
                lblKiraID.Visible = false;
                lblIsletme.Visible = false;
                lblKiraci.Visible = false;
                lblMekanTipi.Visible = false;
                lblKonum.Visible = false;
                lblKiralikAlan.Visible = false;
                lblKiraBedeli.Visible = false;
                lblBaslangicTarihi.Visible = false;
                lblBitisTarihi.Visible = false;
                txtKiraID.Visible = false;
                cmbIsletme.Visible = false;
                cmbKiraci.Visible = false;
                cmbMekanTipi.Visible = false;
                cmbKonum.Visible = false;
                txtKiralikAlan.Visible = false;
                txtKiraBedeli.Visible = false;
                txtBaslangicTarihi.Visible = false;
                txtBitisTarihi.Visible = false;
            }
        }

        private void KiraSozlesmeleri_Shown(object sender, EventArgs e)
        {
            linklblKullaniciID.Text = LinkLblKullaniciID.ToUpper();
            int rolId = kullaniciIslemler.GetRolIDByKullaniciID(LinkLblKullaniciID);
            if (rolId != default(int) && rolId == 2)
            {
                btnDuzenle.Visible = false;
            }
        }

        private void KiraSozlesmeleri_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cmbIsletme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIsletme.SelectedItem != null)
            {
                var secilenDeger = cmbIsletme.SelectedItem.ToString();

                foreach (var isletme in isletmeIslemler.GetIsletmeler())
                {
                    if (isletme.IsletmeAdi.Equals(secilenDeger))
                    {
                        this.IsletmeID = isletme.IsletmeID;
                    }
                }
            }
        }
        private void IsletmeVerileri()
        {
            foreach (var isletme in isletmeIslemler.GetIsletmeler())
            {
                cmbIsletme.Items.Add(new Isletme(isletme.IsletmeID, isletme.IsletmeAdi));
            }
        }

        private void cmbKiraci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKiraci.SelectedItem != null)
            {
                var secilenDeger = cmbKiraci.SelectedItem.ToString();

                foreach (var kiraci in kiraciIslemler.GetKiracilar())
                {
                    if (kiraci.KiraciAdi.Equals(secilenDeger))
                    {
                        this.KiraciID = kiraci.KiraciID;
                    }
                }
            }
        }
        private void KiraciVerileri()
        {
            foreach (var kiraci in kiraciIslemler.GetKiracilar())
            {
                cmbKiraci.Items.Add(new Kiraci(kiraci.KiraciID, kiraci.KiraciAdi));
            }
        }

        private void cmbMekanTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMekanTipi.SelectedItem != null)
            {
                var secilenDeger = cmbMekanTipi.SelectedItem.ToString();

                foreach (var mekan in isletmeIslemler.GetMekanlar())
                {
                    if (mekan.Value.Equals(secilenDeger))
                    {
                        this.MekanID = mekan.Key;
                    }
                }
            }
        }
        private void MekanVerileri()
        {
            foreach (var mekan in isletmeIslemler.GetMekanlar())
            {
                cmbMekanTipi.Items.Add(new Mekan(mekan.Key, mekan.Value));
            }
        }

        private void cmbKonum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKonum.SelectedItem != null)
            {
                var secilenDeger = cmbKonum.SelectedItem.ToString();

                foreach (var konum in isletmeIslemler.GetKonumlar())
                {
                    if (konum.Value.Equals(secilenDeger))
                    {
                        this.KonumID = konum.Key;
                    }
                }
            }
        }
        private void KonumVerileri()
        {
            foreach (var konum in isletmeIslemler.GetKonumlar())
            {
                cmbKonum.Items.Add(new Mekan(konum.Key, konum.Value));
            }
        }

        private void dGridSozlesmelerTablosu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SozlesmeBilgileri();
        }

        private void dGridSozlesmelerTablosu_SelectionChanged(object sender, EventArgs e)
        {
            if (dGridSozlesmelerTablosu.SelectedRows.Count > 0)
            {
                DataGridViewRow secilen = dGridSozlesmelerTablosu.SelectedRows[0];

                int secilenId = (int)secilen.Cells["KiraID"].Value;

                SecilenId = secilenId;
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
            lblKiraID.Visible = true;
            lblIsletme.Visible = true;
            lblKiraci.Visible = true;
            lblMekanTipi.Visible = true;
            lblKonum.Visible = true;
            lblKiralikAlan.Visible = true;
            lblKiraBedeli.Visible = true;
            lblBaslangicTarihi.Visible = true;
            lblBitisTarihi.Visible = true;
            txtKiraID.Visible = true;
            cmbIsletme.Visible = true;
            cmbKiraci.Visible = true;
            cmbMekanTipi.Visible = true;
            cmbKonum.Visible = true;
            txtKiralikAlan.Visible = true;
            txtKiraBedeli.Visible = true;
            txtBaslangicTarihi.Visible = true;
            txtBitisTarihi.Visible = true;

            btnEkle.Visible = false;
            btnGuncelle.Visible = false;
            btnKaldir.Visible = false;
            btnKaydet.Visible = true;
            cmbIsletme.Enabled = true;
            cmbKiraci.Enabled = true;
            cmbMekanTipi.Enabled = true;
            cmbKonum.Enabled = true;
            txtKiralikAlan.Enabled = true;
            txtKiraBedeli.Enabled = true;
            txtBaslangicTarihi.Enabled = true;
            txtBitisTarihi.Enabled = true;
            txtKiraID.Text = null;
            cmbIsletme.Text = null;
            cmbKiraci.Text = null;
            cmbMekanTipi.Text = null;
            cmbKonum.Text = null;
            txtKiralikAlan.Text = null;
            txtKiraBedeli.Text = null;
            txtBaslangicTarihi.Text = null;
            txtBitisTarihi.Text = null;

            ekleClick = true;
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            btnEkle.Visible = false;
            btnGuncelle.Visible = false;
            btnKaldir.Visible = false;
            btnKaydet.Visible = true;
            cmbIsletme.Enabled = true;
            cmbKiraci.Enabled = true;
            cmbMekanTipi.Enabled = true;
            cmbKonum.Enabled = true;
            txtKiralikAlan.Enabled = true;
            txtKiraBedeli.Enabled = true;
            txtBaslangicTarihi.Enabled = true;
            txtBitisTarihi.Enabled = true;

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
            cmbIsletme.Enabled = false;
            cmbKiraci.Enabled = false;
            cmbMekanTipi.Enabled = false;
            cmbKonum.Enabled = false;
            txtKiralikAlan.Enabled = false;
            txtKiraBedeli.Enabled = false;
            txtBaslangicTarihi.Enabled = false;
            txtBitisTarihi.Enabled = false;

            SozlesmeBilgileri();
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
            cmbIsletme.Enabled = false;
            cmbKiraci.Enabled = false;
            cmbMekanTipi.Enabled = false;
            cmbKonum.Enabled = false;
            txtKiralikAlan.Enabled = false;
            txtKiraBedeli.Enabled = false;
            txtBaslangicTarihi.Enabled = false;
            txtBitisTarihi.Enabled = false;

            SozlesmeBilgileri();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string isletmeDeger = null;
            if (cmbIsletme.SelectedItem != null) { isletmeDeger = cmbIsletme.SelectedItem.ToString(); }
            string kiraciDeger = null;
            if (cmbKiraci.SelectedItem != null) { kiraciDeger = cmbKiraci.SelectedItem.ToString(); }
            string mekanTipiDeger = null;
            if (cmbMekanTipi.SelectedItem != null) { mekanTipiDeger = cmbMekanTipi.SelectedItem.ToString(); }
            string konumDeger = null;
            if (cmbKonum.SelectedItem != null) { konumDeger = cmbKonum.SelectedItem.ToString(); }

            double kiraBedeli;
            DateTime baslangictarihi;
            DateTime bitistarihi;

            if (ekleClick)
            {
                if (!string.IsNullOrEmpty(isletmeDeger) && !string.IsNullOrEmpty(kiraciDeger) && !string.IsNullOrEmpty(mekanTipiDeger) && !string.IsNullOrEmpty(konumDeger) && !string.IsNullOrEmpty(txtKiralikAlan.Text) && !string.IsNullOrEmpty(txtKiraBedeli.Text) && !string.IsNullOrEmpty(txtBaslangicTarihi.Text) && !string.IsNullOrEmpty(txtBitisTarihi.Text))
                {
                    if (Double.TryParse(txtKiraBedeli.Text, out kiraBedeli) && DateTime.TryParse(txtBaslangicTarihi.Text, out baslangictarihi) && DateTime.TryParse(txtBitisTarihi.Text, out bitistarihi))
                    {
                        int isletme = this.IsletmeID;
                        int kiraci = this.KiraciID;
                        int mekan = this.MekanID;
                        int konum = this.KonumID;
                        string kiralikAlan = txtKiralikAlan.Text;
                        kiraBedeli = Convert.ToDouble(txtKiraBedeli.Text);

                        string[] parcalar = txtBaslangicTarihi.Text.Split('-', '/', '.'); //ayıraç fonksiyonu kullanarak tarih formatını değiştirme yöntemi chatGPT kaynağından alıntılanmıştır.
                        string baslangicTarihi = parcalar[2] + "-" + parcalar[1] + "-" + parcalar[0];
                        parcalar = txtBitisTarihi.Text.Split('-', '/', '.'); //ayıraç fonksiyonu kullanarak tarih formatını değiştirme yöntemi chatGPT kaynağından alıntılanmıştır.
                        string bitisTarihi = parcalar[2] + "-" + parcalar[1] + "-" + parcalar[0];

                        bool result = sozlesmeIslemler.Ekle(isletme, kiraci, mekan, konum, kiralikAlan, kiraBedeli, baslangicTarihi, bitisTarihi);

                        if (result)
                        {
                            MessageBox.Show("Sözleşme Oluşturuldu.");

                            DataVerileriListele();
                            SecilenId = default(int);
                            SozlesmeBilgileri();
                            ekleClick = false;
                            cmbIsletme.Enabled = false;
                            cmbKiraci.Enabled = false;
                            cmbMekanTipi.Enabled = false;
                            cmbKonum.Enabled = false;
                            txtKiralikAlan.Enabled = false;
                            txtKiraBedeli.Enabled = false;
                            txtBaslangicTarihi.Enabled = false;
                            txtBitisTarihi.Enabled = false;
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
                if (!string.IsNullOrEmpty(txtKiraID.Text))
                {
                    if (!string.IsNullOrEmpty(isletmeDeger) && !string.IsNullOrEmpty(kiraciDeger) && !string.IsNullOrEmpty(mekanTipiDeger) && !string.IsNullOrEmpty(konumDeger) && !string.IsNullOrEmpty(txtKiralikAlan.Text) && !string.IsNullOrEmpty(txtKiraBedeli.Text) && !string.IsNullOrEmpty(txtBaslangicTarihi.Text) && !string.IsNullOrEmpty(txtBitisTarihi.Text))
                    {
                        if (Double.TryParse(txtKiraBedeli.Text, out kiraBedeli) && DateTime.TryParse(txtBaslangicTarihi.Text, out baslangictarihi) && DateTime.TryParse(txtBitisTarihi.Text, out bitistarihi))
                        {
                            int kiraId = SecilenId;
                            int isletme = this.IsletmeID;
                            int kiraci = this.KiraciID;
                            int mekan = this.MekanID;
                            int konum = this.KonumID;
                            string kiralikAlan = txtKiralikAlan.Text;
                            kiraBedeli = Convert.ToDouble(txtKiraBedeli.Text);

                            string[] parcalar = txtBaslangicTarihi.Text.Split('-', '/', '.'); //ayıraç fonksiyonu kullanarak tarih formatını değiştirme yöntemi chatGPT kaynağından alıntılanmıştır.
                            string baslangicTarihi = parcalar[2] + "-" + parcalar[1] + "-" + parcalar[0];
                            parcalar = txtBitisTarihi.Text.Split('-', '/', '.'); //ayıraç fonksiyonu kullanarak tarih formatını değiştirme yöntemi chatGPT kaynağından alıntılanmıştır.
                            string bitisTarihi = parcalar[2] + "-" + parcalar[1] + "-" + parcalar[0];

                            bool result = sozlesmeIslemler.Guncelle(kiraId, isletme, kiraci, mekan, konum, kiralikAlan, kiraBedeli, baslangicTarihi, bitisTarihi);

                            if (result)
                            {
                                MessageBox.Show("Sözleşme Başarıyla Güncellendi.");

                                DataVerileriListele();
                                SecilenId = default(int);
                                SozlesmeBilgileri();
                                guncelleClick = false;
                                cmbIsletme.Enabled = false;
                                cmbKiraci.Enabled = false;
                                cmbMekanTipi.Enabled = false;
                                cmbKonum.Enabled = false;
                                txtKiralikAlan.Enabled = false;
                                txtKiraBedeli.Enabled = false;
                                txtBaslangicTarihi.Enabled = false;
                                txtBitisTarihi.Enabled = false;
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
            DialogResult dialogResult = MessageBox.Show("Bu Sözleşmeyi Silmek Üzeresiniz, Onaylıyor Musunuz?", "Sözleşme Kaldır", MessageBoxButtons.YesNo, MessageBoxIcon.Question);  //chatGPT yardımı

            if (dialogResult == DialogResult.Yes)
            {
                if (SecilenId != default(int))
                {
                    int kiraId = SecilenId;

                    bool result = sozlesmeIslemler.Delete(kiraId);

                    if (result)
                    {
                        MessageBox.Show("Sözleşme Kaldırıldı.");

                        DataVerileriListele();
                        SecilenId = default(int);
                        SozlesmeBilgileri();
                    }
                    else
                    {
                        MessageBox.Show("Silme İşlemi Başarısız.");
                    }
                }
                else
                {
                    MessageBox.Show("Sözleşme Seçimi Yapılmadı.");
                }
            }
        }

        private void txtSozlesmeAra_TextChanged(object sender, EventArgs e)
        {
            dGridSozlesmelerTablosu.DataSource = null;
            dGridSozlesmelerTablosu.DataSource = sozlesmeIslemler.GetSozlesmeByArama(txtSozlesmeAra.Text);
            dGridSozlesmelerTablosu.Columns["KiraID"].HeaderText = "Kira ID";
            dGridSozlesmelerTablosu.Columns["Isletme"].HeaderText = "İşletme";
            dGridSozlesmelerTablosu.Columns["Kiraci"].HeaderText = "Kiracı";
            dGridSozlesmelerTablosu.Columns["MekanTipi"].HeaderText = "Mekan Tipi";
            dGridSozlesmelerTablosu.Columns["Konum"].HeaderText = "Konum";
            dGridSozlesmelerTablosu.Columns["KiralikAlan"].HeaderText = "Kiralık Alan m2";
            dGridSozlesmelerTablosu.Columns["KiraBedeli"].HeaderText = "Kira Bedeli";
            dGridSozlesmelerTablosu.Columns["BaslangicTarihi"].HeaderText = "Başlangıç Tarihi";
            dGridSozlesmelerTablosu.Columns["BitisTarihi"].HeaderText = "Bitiş Tarihi";
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            if (lblTarihFil.Visible == false)
            {
                lblTarihFil.Visible = true;
                dtFil1.Visible = true;
                dtFil2.Visible = true;
                btnUygula.Visible = true;
                btnTemizle.Visible = true;
            }
            else
            {
                lblTarihFil.Visible = false;
                dtFil1.Visible = false;
                dtFil2.Visible = false;
                btnUygula.Visible = false;
                btnTemizle.Visible = false;
            }
        }

        private void btnUygula_Click(object sender, EventArgs e)
        {
            txtSozlesmeAra.Text = null;

            dGridSozlesmelerTablosu.DataSource = null;
            dGridSozlesmelerTablosu.DataSource = sozlesmeIslemler.GetSozlesmelerFiltre(dtFil1.Value.ToString("yyyy-MM-dd"), dtFil2.Value.ToString("yyyy-MM-dd")); // tarih formatı değiştirmede dış kaynak yardımı alınmıştır
            dGridSozlesmelerTablosu.Columns["KiraID"].HeaderText = "Kira ID";
            dGridSozlesmelerTablosu.Columns["Isletme"].HeaderText = "İşletme";
            dGridSozlesmelerTablosu.Columns["Kiraci"].HeaderText = "Kiracı";
            dGridSozlesmelerTablosu.Columns["MekanTipi"].HeaderText = "Mekan Tipi";
            dGridSozlesmelerTablosu.Columns["Konum"].HeaderText = "Konum";
            dGridSozlesmelerTablosu.Columns["KiralikAlan"].HeaderText = "Kiralık Alan m2";
            dGridSozlesmelerTablosu.Columns["KiraBedeli"].HeaderText = "Kira Bedeli";
            dGridSozlesmelerTablosu.Columns["BaslangicTarihi"].HeaderText = "Başlangıç Tarihi";
            dGridSozlesmelerTablosu.Columns["BitisTarihi"].HeaderText = "Bitiş Tarihi";

            lblTarihFil.Visible = false;
            dtFil1.Visible = false;
            dtFil2.Visible = false;
            btnUygula.Visible = false;
            btnTemizle.Visible = false;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            dGridSozlesmelerTablosu.DataSource = null;
            dGridSozlesmelerTablosu.DataSource = sozlesmeIslemler.GetSozlesmeler();
            dGridSozlesmelerTablosu.Columns["KiraID"].HeaderText = "Kira ID";
            dGridSozlesmelerTablosu.Columns["Isletme"].HeaderText = "İşletme";
            dGridSozlesmelerTablosu.Columns["Kiraci"].HeaderText = "Kiracı";
            dGridSozlesmelerTablosu.Columns["MekanTipi"].HeaderText = "Mekan Tipi";
            dGridSozlesmelerTablosu.Columns["Konum"].HeaderText = "Konum";
            dGridSozlesmelerTablosu.Columns["KiralikAlan"].HeaderText = "Kiralık Alan m2";
            dGridSozlesmelerTablosu.Columns["KiraBedeli"].HeaderText = "Kira Bedeli";
            dGridSozlesmelerTablosu.Columns["BaslangicTarihi"].HeaderText = "Başlangıç Tarihi";
            dGridSozlesmelerTablosu.Columns["BitisTarihi"].HeaderText = "Bitiş Tarihi";
        }
    }
}
