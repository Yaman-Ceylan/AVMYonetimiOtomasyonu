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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        public string LinkLblKullaniciID { get; set; }

        private void AnaSayfa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        private void AnaSayfa_Shown(object sender, EventArgs e)
        {
            linklblKullaniciID.Text = LinkLblKullaniciID.ToUpper();
        }

        private void linklblKullaniciID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KullaniciAyarlari kullaniciAyarlari = new KullaniciAyarlari();
            kullaniciAyarlari.LblKullanici = this.LinkLblKullaniciID;
            this.Hide();
            kullaniciAyarlari.ShowDialog();
        }

        private void btnKullaniciYonetimi_Click(object sender, EventArgs e)
        {
            KullaniciYonetimi kullaniciYonetimi = new KullaniciYonetimi();
            kullaniciYonetimi.LinkLblKullaniciID = this.LinkLblKullaniciID;
            this.Hide();
            kullaniciYonetimi.Show();
        }

        private void btnIsletmeYonetimi_Click(object sender, EventArgs e)
        {
            IsletmeYonetimi isletmeYonetimi = new IsletmeYonetimi();
            isletmeYonetimi.LinkLblKullaniciID = this.LinkLblKullaniciID;
            this.Hide();
            isletmeYonetimi.Show();
        }

        private void btnKiraciYonetimi_Click(object sender, EventArgs e)
        {
            KiraciYonetimi kiraciYonetimi = new KiraciYonetimi();
            kiraciYonetimi.LinkLblKullaniciID = this.LinkLblKullaniciID;
            this.Hide();
            kiraciYonetimi.Show();
        }

        private void btnKiraSozlesmeleri_Click(object sender, EventArgs e)
        {
            KiraSozlesmeleri kiraSozlesmeleri =new KiraSozlesmeleri();
            kiraSozlesmeleri.LinkLblKullaniciID = this.LinkLblKullaniciID;
            this.Hide();
            kiraSozlesmeleri.Show();
        }

        private void btnGelirYonetimi_Click(object sender, EventArgs e)
        {
            GelirGiderler gelirGiderler = new GelirGiderler();
            gelirGiderler.LinkLblKullaniciID = this.LinkLblKullaniciID;
            this.Hide();
            gelirGiderler.Show();
        }

        private void btnPersonelYonetimi_Click(object sender, EventArgs e)
        {
            PersonelYonetimi personelYonetimi = new PersonelYonetimi();
            personelYonetimi.LinkLblKullaniciID = this.LinkLblKullaniciID;
            this.Hide();
            personelYonetimi.Show();
        }

        private void btnGuvenlikYonetimi_Click(object sender, EventArgs e)
        {
            GuvenlikYonetimi guvenlikYonetimi = new GuvenlikYonetimi();
            guvenlikYonetimi.LinkLblKullaniciID = this.LinkLblKullaniciID;
            this.Hide();
            guvenlikYonetimi.Show();
        }
    }
}
