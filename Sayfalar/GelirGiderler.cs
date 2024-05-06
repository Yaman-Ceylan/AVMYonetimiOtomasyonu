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
    public partial class GelirGiderler : Form
    {
        public GelirGiderler()
        {
            InitializeComponent();

            DataGelirVerileriListele();
            DataGiderVerileriListele();

            PozisyonVerileri();
        }

        public string LinkLblKullaniciID { get; set; }

        PersonelIslemler personelIslemler = new PersonelIslemler();
        GelirGiderIslemler gelirgiderIslemler = new GelirGiderIslemler();

        private void DataGelirVerileriListele()
        {
            dGridGelirlerTablosu.DataSource = null;
            dGridGelirlerTablosu.DataSource = gelirgiderIslemler.GetKiraGelirler();
            dGridGelirlerTablosu.Columns["IsletmeID"].HeaderText = "İşletme ID";
            dGridGelirlerTablosu.Columns["IsletmeAdi"].HeaderText = "İşletme Adı";
            dGridGelirlerTablosu.Columns["KiraBedeli"].HeaderText = "Kira Bedeli";

            double toplam = default(double);
            foreach (DataGridViewRow row in dGridGelirlerTablosu.Rows)
            {
                if (row.Cells["KiraBedeli"].Value != null && row.Cells["KiraBedeli"].Value.ToString() != "")
                {
                    double kiraBedeli;
                    if (double.TryParse(row.Cells["KiraBedeli"].Value.ToString(), out kiraBedeli))
                    {
                        toplam += kiraBedeli;
                    }
                }
            }
            txtToplamGelir.Text = toplam.ToString("#,##0.00 ₺");
        }

        private void DataGiderVerileriListele()
        {
            dGridGiderlerTablosu.DataSource = null;
            dGridGiderlerTablosu.DataSource = gelirgiderIslemler.GetPersonelGiderler();
            dGridGiderlerTablosu.Columns["PersonelTC"].HeaderText = "Personel TC";
            dGridGiderlerTablosu.Columns["Personel"].HeaderText = "Personel";
            dGridGiderlerTablosu.Columns["Pozisyon"].HeaderText = "Pozisyon";
            dGridGiderlerTablosu.Columns["Maas"].HeaderText = "Maaş";

            double toplam = default(double);
            foreach (DataGridViewRow row in dGridGiderlerTablosu.Rows)
            {
                if (row.Cells["Maas"].Value != null && row.Cells["Maas"].Value.ToString() != "")
                {
                    double maas;
                    if (double.TryParse(row.Cells["Maas"].Value.ToString(), out maas))
                    {
                        toplam += maas;
                    }
                }
            }
            txtToplamGider.Text = toplam.ToString("#,##0.00 ₺"); //para birimi ve formatı chatGPT kaynağından alınmıştır.
        }

        private void GelirGiderler_Shown(object sender, EventArgs e)
        {
            linklblKullaniciID.Text = LinkLblKullaniciID.ToUpper();
        }

        private void GelirGiderler_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void PozisyonVerileri()
        {
            foreach (var pozisyon in personelIslemler.GetPozisyonlar())
            {
                cmbPozisyonFil.Items.Add(new Pozisyon(pozisyon.Key, pozisyon.Value));
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

        private void btnFiltreGelir_Click(object sender, EventArgs e)
        {
            if (lblMinKiraFil.Visible == false)
            {
                lblMinKiraFil.Visible = true;
                lblMaxKiraFil.Visible = true;
                txtMinKiraFil.Visible = true;
                txtMaxKiraFil.Visible = true;                
                btnUygulaGelir.Visible = true;
            }
            else
            {
                lblMinKiraFil.Visible = false;
                lblMaxKiraFil.Visible = false;
                txtMinKiraFil.Visible = false;
                txtMaxKiraFil.Visible = false;
                btnUygulaGelir.Visible = false;
            }
        }

        private void btnUygulaGelir_Click(object sender, EventArgs e)
        {
            double doubMin;
            double doubMax;            
            if (double.TryParse(txtMinKiraFil.Text, out doubMin) && double.TryParse(txtMaxKiraFil.Text, out doubMax))
            {
                doubMin = Convert.ToDouble(txtMinKiraFil.Text);
                doubMax = Convert.ToDouble(txtMaxKiraFil.Text);
            }
            else
            {
                if (!double.TryParse(txtMinKiraFil.Text, out doubMin))
                {
                    doubMin = doubMin = default(double);
                }
                if (!double.TryParse(txtMaxKiraFil.Text, out doubMax))
                {
                    doubMax = 9999999999;
                }
            }

            dGridGelirlerTablosu.DataSource = null;
            dGridGelirlerTablosu.DataSource = gelirgiderIslemler.GetKiraGelirler(doubMin, doubMax);
            dGridGelirlerTablosu.Columns["IsletmeID"].HeaderText = "İşletme ID";
            dGridGelirlerTablosu.Columns["IsletmeAdi"].HeaderText = "İşletme Adı";
            dGridGelirlerTablosu.Columns["KiraBedeli"].HeaderText = "Kira Bedeli";

            double toplam = default(double);
            foreach (DataGridViewRow row in dGridGelirlerTablosu.Rows)
            {
                if (row.Cells["KiraBedeli"].Value != null && row.Cells["KiraBedeli"].Value.ToString() != "")
                {
                    double kiraBedeli;
                    if (double.TryParse(row.Cells["KiraBedeli"].Value.ToString(), out kiraBedeli))
                    {
                        toplam += kiraBedeli;
                    }
                }
            }
            txtToplamGelir.Text = toplam.ToString("#,##0.00 ₺");

            lblMinKiraFil.Visible = false;
            lblMaxKiraFil.Visible = false;
            txtMinKiraFil.Visible = false;
            txtMaxKiraFil.Visible = false;
            btnUygulaGelir.Visible = false;
        }


        private void btnFiltreleGider_Click(object sender, EventArgs e)
        {
            if (lblMinMaasFil.Visible == false)
            {
                lblMinMaasFil.Visible = true;
                lblMaxMaasFil.Visible = true;
                txtMinMaasFil.Visible = true;
                txtMaxMaasFil.Visible = true;
                lblPozisyonFil.Visible = true;
                cmbPozisyonFil.Visible = true;
                btnUygulaGider.Visible = true;
            }
            else
            {
                lblMinMaasFil.Visible = false;
                lblMaxMaasFil.Visible = false;
                txtMinMaasFil.Visible = false;
                txtMaxMaasFil.Visible = false;
                lblPozisyonFil.Visible = false;
                cmbPozisyonFil.Visible = false;
                btnUygulaGider.Visible = false;
            }
        }

        private void btnUygulaGider_Click(object sender, EventArgs e)
        {
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

            dGridGiderlerTablosu.DataSource = null;
            dGridGiderlerTablosu.DataSource = gelirgiderIslemler.GetPersonelGiderler(cmbPozisyonFil.Text, doubMin, doubMax);
            dGridGiderlerTablosu.Columns["PersonelTC"].HeaderText = "Personel TC";
            dGridGiderlerTablosu.Columns["Personel"].HeaderText = "Personel";
            dGridGiderlerTablosu.Columns["Pozisyon"].HeaderText = "Pozisyon";
            dGridGiderlerTablosu.Columns["Maas"].HeaderText = "Maaş";

            double toplam = default(double);
            foreach (DataGridViewRow row in dGridGiderlerTablosu.Rows)
            {
                if (row.Cells["Maas"].Value != null && row.Cells["Maas"].Value.ToString() != "")
                {
                    double maas;
                    if (double.TryParse(row.Cells["Maas"].Value.ToString(), out maas))
                    {
                        toplam += maas;
                    }
                }
            }
            txtToplamGider.Text = toplam.ToString("#,##0.00 ₺"); //para birimi ve format chatGPT kaynağından alınmıştır.

            lblMinMaasFil.Visible = false;
            lblMaxMaasFil.Visible = false;
            txtMinMaasFil.Visible = false;
            txtMaxMaasFil.Visible = false;
            lblPozisyonFil.Visible = false;
            cmbPozisyonFil.Visible = false;
            btnUygulaGider.Visible = false;
        }
    }
}
