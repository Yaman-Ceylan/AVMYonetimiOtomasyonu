using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMYonetimiOtomasyonu.Moduller
{
    public class Kullanici
    {
        public string KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSoyadi { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public int RolID { get; set; }

        public Kullanici(string kullaniciId, string ad, string soyad, string eposta, string sifre, int rolID)
        {
            KullaniciID = kullaniciId;
            KullaniciAdi = ad;
            KullaniciSoyadi = soyad;
            Eposta = eposta;
            Sifre = sifre;
            RolID = rolID;
        }
    }
}