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
    public partial class IsletmeYonetimi : Form
    {
        public IsletmeYonetimi()
        {
            InitializeComponent();

            DataVerileriListele();
            MekanVerileri();
            KonumVerileri();
        }

        bool ekleClick = default(bool);
        bool guncelleClick = default(bool);

        public int MekanID { get; set; }
        public int KonumID { get; set; }
        public string LinkLblKullaniciID { get; set; }
        public int SecilenId { get; set; }

        IsletmeIslemler isletmeIslemler = new IsletmeIslemler();
        KullaniciIslemler kullaniciIslemler = new KullaniciIslemler();

        private void DataVerileriListele()
        {
            dGridIsletmelerTablosu.DataSource = null;
            dGridIsletmelerTablosu.DataSource = isletmeIslemler.GetIsletmeler();
            dGridIsletmelerTablosu.Columns["IsletmeID"].HeaderText = "İşletme ID";
            dGridIsletmelerTablosu.Columns["IsletmeAdi"].HeaderText = "İşletme Adı";
            dGridIsletmelerTablosu.Columns["MekanTipi"].HeaderText = "Mekan Tipi";
            dGridIsletmelerTablosu.Columns["IsletmeTelefon"].HeaderText = "İşletme Telefon";
            dGridIsletmelerTablosu.Columns["CalisanSayisi"].HeaderText = "Çalışan Sayısı";
            dGridIsletmelerTablosu.Columns["Konum"].HeaderText = "Konum";
        }

        private void IsletmeBilgileri()
        {
            if (SecilenId != default(int))
            {
                List<Isletme> isletme = new List<Isletme>();
                isletme = isletmeIslemler.GetIsletmeler(SecilenId);
                if (isletme.Count == 1)
                {
                    foreach (var isle in isletme)
                    {
                        txtIsletmeID.Text = isle.IsletmeID.ToString();
                        txtIsletmeAdi.Text = isle.IsletmeAdi;
                        cmbMekanTipi.Text = isle.MekanTipi;
                        txtIsletmeTelefon.Text = isle.IsletmeTelefon;
                        txtCalisanSayisi.Text = isle.CalisanSayisi.ToString();
                        cmbKonum.Text = isle.Konum;
                    }
                }               

                lblIsletmeID.Visible = true;
                lblIsletmeAdi.Visible = true;
                lblMekanTipi.Visible = true;
                lblIsletmeTelefon.Visible = true;
                lblCalisanSayisi.Visible = true;
                lblKonum.Visible = true;
                txtIsletmeID.Visible = true;
                txtIsletmeAdi.Visible = true;
                cmbMekanTipi.Visible = true;
                txtIsletmeTelefon.Visible = true;
                txtCalisanSayisi.Visible = true;
                cmbKonum.Visible = true;
            }
            else
            {
                lblIsletmeID.Visible = false;
                lblIsletmeAdi.Visible = false;
                lblMekanTipi.Visible = false;
                lblIsletmeTelefon.Visible = false;
                lblCalisanSayisi.Visible = false;
                lblKonum.Visible = false;
                txtIsletmeID.Visible = false;
                txtIsletmeAdi.Visible = false;
                cmbMekanTipi.Visible = false;
                txtIsletmeTelefon.Visible = false;
                txtCalisanSayisi.Visible = false;
                cmbKonum.Visible = false;
            }
        }


        private void IsletmeYonetimi_Shown(object sender, EventArgs e)
        {
            linklblKullaniciID.Text = LinkLblKullaniciID.ToUpper();
            int rolId = kullaniciIslemler.GetRolIDByKullaniciID(LinkLblKullaniciID);
            if (rolId != default(int) && rolId == 2)
            {
                btnDuzenle.Visible = false;
            }
        }

        private void IsletmeYonetimi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
                cmbMekanTipiFil.Items.Add(new Mekan(mekan.Key, mekan.Value));
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
                cmbKonumFil.Items.Add(new Mekan(konum.Key, konum.Value));
            }
        }

        private void dGridKullanicilarTablosu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IsletmeBilgileri();
        }

        private void dGridKullanicilarTablosu_SelectionChanged(object sender, EventArgs e)
        {
            if (dGridIsletmelerTablosu.SelectedRows.Count > 0)
            {
                DataGridViewRow secilen = dGridIsletmelerTablosu.SelectedRows[0];

                int secilenId = (int)secilen.Cells["IsletmeID"].Value;

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
            lblIsletmeID.Visible = true;
            lblIsletmeAdi.Visible = true;
            lblMekanTipi.Visible = true;
            lblIsletmeTelefon.Visible = true;
            lblCalisanSayisi.Visible = true;
            lblKonum.Visible = true;
            txtIsletmeID.Visible = true;
            txtIsletmeAdi.Visible = true;
            cmbMekanTipi.Visible = true;
            txtIsletmeTelefon.Visible = true;
            txtCalisanSayisi.Visible = true;
            cmbKonum.Visible = true;

            btnEkle.Visible = false;
            btnGuncelle.Visible = false;
            btnKaldir.Visible = false;
            btnKaydet.Visible = true;            
            txtIsletmeAdi.Enabled = true;
            cmbMekanTipi.Enabled = true;
            txtIsletmeTelefon.Enabled = true;
            txtCalisanSayisi.Enabled = true;
            cmbKonum.Enabled = true;
            txtIsletmeID.Text = null;
            txtIsletmeAdi.Text = null;
            cmbMekanTipi.Text = null;
            txtIsletmeTelefon.Text = null;
            txtCalisanSayisi.Text = null;
            cmbKonum.Text = null;

            ekleClick = true;
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            btnEkle.Visible = false;
            btnGuncelle.Visible = false;
            btnKaldir.Visible = false;
            btnKaydet.Visible = true;
            txtIsletmeAdi.Enabled = true;
            cmbMekanTipi.Enabled = true;
            txtIsletmeTelefon.Enabled = true;
            txtCalisanSayisi.Enabled = true;
            cmbKonum.Enabled = true;

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
            txtIsletmeAdi.Enabled = false;
            cmbMekanTipi.Enabled = false;
            txtIsletmeTelefon.Enabled = false;
            txtCalisanSayisi.Enabled = false;
            cmbKonum.Enabled = false;

            IsletmeBilgileri();
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
            txtIsletmeAdi.Enabled = false;
            cmbMekanTipi.Enabled = false;
            txtIsletmeTelefon.Enabled = false;
            txtCalisanSayisi.Enabled = false;
            cmbKonum.Enabled = false;

            IsletmeBilgileri();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string mekanTipiDeger = null;
            if (cmbMekanTipi.SelectedItem != null) { mekanTipiDeger = cmbMekanTipi.SelectedItem.ToString(); }
            string konumDeger = null;
            if (cmbKonum.SelectedItem != null) { konumDeger = cmbKonum.SelectedItem.ToString(); }

            long longTelefon;
            int calisanSayisi;

            if (ekleClick)
            {
                if (!string.IsNullOrEmpty(txtIsletmeAdi.Text) && !string.IsNullOrEmpty(mekanTipiDeger) && !string.IsNullOrEmpty(txtIsletmeTelefon.Text) && !string.IsNullOrEmpty(txtCalisanSayisi.Text) && !string.IsNullOrEmpty(konumDeger))
                {
                    if (long.TryParse(txtIsletmeTelefon.Text, out longTelefon) && int.TryParse(txtCalisanSayisi.Text, out calisanSayisi))
                    {
                        string isletmeAdi = txtIsletmeAdi.Text;
                        int mekanID = this.MekanID;
                        string telefon = txtIsletmeTelefon.Text;
                        calisanSayisi = Convert.ToInt32(txtCalisanSayisi.Text);
                        int konumID = this.KonumID;

                        bool result = isletmeIslemler.Ekle(isletmeAdi, mekanID, telefon, calisanSayisi, konumID);

                        if (result)
                        {
                            MessageBox.Show("İşletme Sisteme Başarıyla Eklendi.");

                            DataVerileriListele();
                            SecilenId = default(int);
                            IsletmeBilgileri();
                            ekleClick = false;
                            txtIsletmeAdi.Enabled = false;
                            cmbMekanTipi.Enabled = false;
                            txtIsletmeTelefon.Enabled = false;
                            txtCalisanSayisi.Enabled = false;
                            cmbKonum.Enabled = false;
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
                if (!string.IsNullOrEmpty(txtIsletmeID.Text))
                {
                    if (!string.IsNullOrEmpty(txtIsletmeAdi.Text) && !string.IsNullOrEmpty(mekanTipiDeger) && !string.IsNullOrEmpty(txtIsletmeTelefon.Text) && !string.IsNullOrEmpty(txtCalisanSayisi.Text) && !string.IsNullOrEmpty(konumDeger))
                    {
                        if (long.TryParse(txtIsletmeTelefon.Text, out longTelefon) && int.TryParse(txtCalisanSayisi.Text, out calisanSayisi))
                        {
                            int isletmeId = Convert.ToInt32(txtIsletmeID.Text);
                            string isletmeAdi = txtIsletmeAdi.Text;
                            int mekanID = this.MekanID;
                            string telefon = txtIsletmeTelefon.Text;
                            calisanSayisi = Convert.ToInt32(txtCalisanSayisi.Text);
                            int konumID = this.KonumID;

                            bool result = isletmeIslemler.Guncelle(isletmeId, isletmeAdi, mekanID, telefon, calisanSayisi, konumID);

                            if (result)
                            {
                                MessageBox.Show("Güncellemeler Başarıyla Kaydedildi.");

                                DataVerileriListele();
                                SecilenId = default(int);
                                IsletmeBilgileri();
                                guncelleClick = false;
                                txtIsletmeAdi.Enabled = false;
                                cmbMekanTipi.Enabled = false;
                                txtIsletmeTelefon.Enabled = false;
                                txtCalisanSayisi.Enabled = false;
                                cmbKonum.Enabled = false;
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
            DialogResult dialogResult = MessageBox.Show("Bu İşletmeyi Sistmeden Silmek Üzeresiniz, Onaylıyor Musunuz?", "İşletme Kaldır", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //Uyarı onay mesaj kutusu özelliği chatGPT kaynağından alıntılanmıştır.

            if (dialogResult == DialogResult.Yes)
            {
                if (SecilenId != default(int))
                {
                    int isletmeId = SecilenId;

                    bool result = isletmeIslemler.Delete(isletmeId);

                    if (result)
                    {
                        MessageBox.Show("İşletme Kaldırıldı.");

                        DataVerileriListele();
                        SecilenId = default(int);
                        IsletmeBilgileri();
                    }
                    else
                    {
                        MessageBox.Show("Kaldırma İşlemi Başarısız.");
                    }
                }
                else
                {
                    MessageBox.Show("İşletme Seçimi Yapılmadı.");
                }
            }
        }

        private void txtIsletmeAra_TextChanged(object sender, EventArgs e)
        {
            dGridIsletmelerTablosu.DataSource = null;
            dGridIsletmelerTablosu.DataSource = isletmeIslemler.GetIsletmeByArama(txtIsletmeAra.Text);
            dGridIsletmelerTablosu.Columns["IsletmeID"].HeaderText = "İşletme ID";
            dGridIsletmelerTablosu.Columns["IsletmeAdi"].HeaderText = "İşletme Adı";
            dGridIsletmelerTablosu.Columns["MekanTipi"].HeaderText = "Mekan Tipi";
            dGridIsletmelerTablosu.Columns["IsletmeTelefon"].HeaderText = "İşletme Telefon";
            dGridIsletmelerTablosu.Columns["CalisanSayisi"].HeaderText = "Çalışan Sayısı";
            dGridIsletmelerTablosu.Columns["Konum"].HeaderText = "Konum";
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            if (lblMekanTipiFil.Visible == false)
            {
                lblMekanTipiFil.Visible = true;
                cmbMekanTipiFil.Visible = true;
                lblKonumFil.Visible = true;
                cmbKonumFil.Visible = true;
                btnUygula.Visible = true;
            }
            else
            {
                lblMekanTipiFil.Visible = false;
                cmbMekanTipiFil.Visible = false;
                lblKonumFil.Visible = false;
                cmbKonumFil.Visible = false;
                btnUygula.Visible = false;
            }
        }

        private void btnUygula_Click(object sender, EventArgs e)
        {
            txtIsletmeAra.Text = null;

            dGridIsletmelerTablosu.DataSource = null;
            dGridIsletmelerTablosu.DataSource = isletmeIslemler.GetIsletmelerFiltre(cmbMekanTipiFil.Text, cmbKonumFil.Text); ;
            dGridIsletmelerTablosu.Columns["IsletmeID"].HeaderText = "İşletme ID";
            dGridIsletmelerTablosu.Columns["IsletmeAdi"].HeaderText = "İşletme Adı";
            dGridIsletmelerTablosu.Columns["MekanTipi"].HeaderText = "Mekan Tipi";
            dGridIsletmelerTablosu.Columns["IsletmeTelefon"].HeaderText = "İşletme Telefon";
            dGridIsletmelerTablosu.Columns["CalisanSayisi"].HeaderText = "Çalışan Sayısı";
            dGridIsletmelerTablosu.Columns["Konum"].HeaderText = "Konum";

            lblMekanTipiFil.Visible = false;
            cmbMekanTipiFil.Visible = false;
            lblKonumFil.Visible = false;
            cmbKonumFil.Visible = false;
            btnUygula.Visible = false;
        }
    }
}
