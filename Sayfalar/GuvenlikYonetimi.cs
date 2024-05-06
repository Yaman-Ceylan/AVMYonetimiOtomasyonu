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
    public partial class GuvenlikYonetimi : Form
    {
        public GuvenlikYonetimi()
        {
            InitializeComponent();

            DataVerileriListele();
            
            KonumVerileri();
        }

        bool ekleClick = default(bool);
        bool guncelleClick = default(bool);

        public int KonumID { get; set; }
        public string LinkLblKullaniciID { get; set; }
        public int SecilenId { get; set; }

        GuvenlikYonetimiIslemler guvenlikYonetimiIslemler = new GuvenlikYonetimiIslemler();
        KullaniciIslemler kullaniciIslemler = new KullaniciIslemler();
        PersonelIslemler personelIslemler = new PersonelIslemler();
        IsletmeIslemler isletmeIslemler = new IsletmeIslemler();

        private void DataVerileriListele()
        {
            dGridKameralarTablosu.DataSource = null;
            dGridKameralarTablosu.DataSource = guvenlikYonetimiIslemler.GetKameralar();
            dGridKameralarTablosu.Columns["KameraID"].HeaderText = "Kamera ID";
            dGridKameralarTablosu.Columns["KameraTipi"].HeaderText = "Kamera Tipi";
            dGridKameralarTablosu.Columns["Konum"].HeaderText = "Konum";
        }

        private void KameraBilgileri()
        {
            if (SecilenId != default(int))
            {
                List<GuvenlikKamerası> kamera = new List<GuvenlikKamerası>();
                kamera = guvenlikYonetimiIslemler.GetKameralar(SecilenId);
                if (kamera.Count == 1)
                {
                    foreach (var kam in kamera)
                    {
                        txtKameraID.Text = kam.KameraID.ToString();
                        txtKameraTipi.Text = kam.KameraTipi;
                        cmbKonum.Text = kam.Konum;
                    }
                }

                lblKameraID.Visible = true;
                lblKameraTipi.Visible = true;
                lblKonum.Visible = true;
                txtKameraID.Visible = true;
                txtKameraTipi.Visible = true;
                cmbKonum.Visible = true;
            }
            else
            {
                lblKameraID.Visible = true;
                lblKameraTipi.Visible = true;
                lblKonum.Visible = true;
                txtKameraID.Visible = true;
                txtKameraTipi.Visible = true;
                cmbKonum.Visible = true;
            }
        }

        private void GuvenlikYonetimi_Shown(object sender, EventArgs e)
        {
            linklblKullaniciID.Text = LinkLblKullaniciID.ToUpper();
            int rolId = kullaniciIslemler.GetRolIDByKullaniciID(LinkLblKullaniciID);
            if (rolId != default(int) && rolId == 2)
            {
                btnDuzenle.Visible = false;
            }

            txtGvnlkPersonelSayisi.Text = personelIslemler.GetGuvenlikPersoneliSayisi().ToString();
        }

        private void GuvenlikYonetimi_FormClosed(object sender, FormClosedEventArgs e)
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

        private void dGridKameralarTablosu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            KameraBilgileri();
        }

        private void dGridKameralarTablosu_SelectionChanged(object sender, EventArgs e)
        {
            if (dGridKameralarTablosu.SelectedRows.Count > 0)
            {
                DataGridViewRow secilen = dGridKameralarTablosu.SelectedRows[0];

                int secilenId = (int)secilen.Cells["KameraID"].Value;

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
            lblKameraID.Visible = true;
            lblKameraTipi.Visible = true;
            lblKonum.Visible = true;
            txtKameraID.Visible = true;
            txtKameraTipi.Visible = true;
            cmbKonum.Visible = true;

            btnEkle.Visible = false;
            btnGuncelle.Visible = false;
            btnKaldir.Visible = false;
            btnKaydet.Visible = true;
            txtKameraTipi.Enabled = true;
            cmbKonum.Enabled = true;
            txtKameraID.Text = null;
            txtKameraTipi.Text = null;
            cmbKonum.Text = null;

            ekleClick = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            btnEkle.Visible = false;
            btnGuncelle.Visible = false;
            btnKaldir.Visible = false;
            btnKaydet.Visible = true;
            txtKameraTipi.Enabled = true;
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
            txtKameraTipi.Enabled = false;
            cmbKonum.Enabled = false;

            KameraBilgileri();
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
            txtKameraTipi.Enabled = false;
            cmbKonum.Enabled = false;

            KameraBilgileri();
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {           
            string konumDeger = null;
            if (cmbKonum.SelectedItem != null) { konumDeger = cmbKonum.SelectedItem.ToString(); }

            if (ekleClick)
            {
                if (!string.IsNullOrEmpty(txtKameraTipi.Text) && !string.IsNullOrEmpty(konumDeger))
                {
                    string kameraTipi = txtKameraTipi.Text;
                    int konumID = this.KonumID;

                    bool result = guvenlikYonetimiIslemler.Ekle(kameraTipi, konumID);

                    if (result)
                    {
                        MessageBox.Show("Ekleme Başarılı.");

                        DataVerileriListele();
                        SecilenId = default(int);
                        KameraBilgileri();
                        ekleClick = false;
                        txtKameraTipi.Enabled = false;                       
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
                    MessageBox.Show("Lütfen Boş Alanları Doldurunuz.");
                }
            }
            else if (guncelleClick)
            {
                if (!string.IsNullOrEmpty(txtKameraID.Text))
                {
                    if (!string.IsNullOrEmpty(txtKameraTipi.Text) && !string.IsNullOrEmpty(konumDeger))
                    {
                        int kameraId = Convert.ToInt32(txtKameraID.Text);
                        string kameraTipi = txtKameraTipi.Text;
                        int konumID = this.KonumID;

                        bool result = guvenlikYonetimiIslemler.Guncelle(kameraId, kameraTipi, konumID);

                        if (result)
                        {
                            MessageBox.Show("Güncellemeler Başarıyla Kaydedildi.");

                            DataVerileriListele();
                            SecilenId = default(int);
                            KameraBilgileri();
                            guncelleClick = false;
                            txtKameraTipi.Enabled = false;
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
            DialogResult dialogResult = MessageBox.Show("Bu Güvenlik Kamerasını Sistmeden Silmek Üzeresiniz, Onaylıyor Musunuz?", "Kamera Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //chatGPT yardımı

            if (dialogResult == DialogResult.Yes)
            {
                if (SecilenId != default(int))
                {
                    int kameraId = SecilenId;

                    bool result = guvenlikYonetimiIslemler.Delete(kameraId);

                    if (result)
                    {
                        MessageBox.Show("Kamera Kaldırıldı.");

                        DataVerileriListele();
                        SecilenId = default(int);
                        KameraBilgileri();
                    }
                    else
                    {
                        MessageBox.Show("Kaldırma İşlemi Başarısız.");
                    }
                }
                else
                {
                    MessageBox.Show("Kamera Seçimi Yapılmadı.");
                }
            }
        }

        private void txtKameraAra_TextChanged(object sender, EventArgs e)
        {
            dGridKameralarTablosu.DataSource = null;
            dGridKameralarTablosu.DataSource = guvenlikYonetimiIslemler.GetKameraByArama(txtKameraAra.Text);
            dGridKameralarTablosu.Columns["KameraID"].HeaderText = "Kamera ID";
            dGridKameralarTablosu.Columns["KameraTipi"].HeaderText = "Kamera Tipi";
            dGridKameralarTablosu.Columns["Konum"].HeaderText = "Konum";
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            if (lblKonumFil.Visible == false)
            {
                lblKonumFil.Visible = true;
                cmbKonumFil.Visible = true;
                btnUygula.Visible = true;
            }
            else
            {

                lblKonumFil.Visible = false;
                cmbKonumFil.Visible = false;
                btnUygula.Visible = false;
            }
        }

        private void btnUygula_Click(object sender, EventArgs e)
        {
            dGridKameralarTablosu.DataSource = null;
            dGridKameralarTablosu.DataSource = guvenlikYonetimiIslemler.GetKameraFiltre(cmbKonumFil.Text);
            dGridKameralarTablosu.Columns["KameraID"].HeaderText = "Kamera ID";
            dGridKameralarTablosu.Columns["KameraTipi"].HeaderText = "Kamera Tipi";
            dGridKameralarTablosu.Columns["Konum"].HeaderText = "Konum";

            lblKonumFil.Visible = false;
            cmbKonumFil.Visible = false;
            btnUygula.Visible = false;
        }
    }
}
