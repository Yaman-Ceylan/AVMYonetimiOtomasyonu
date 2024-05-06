using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMYonetimiOtomasyonu.Moduller
{
    public class KullaniciYonetimModul
    {
        public string KullaniciID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public string RolAdi { get; set; }

        public KullaniciYonetimModul(string kullaniciId, string ad, string soyad, string eposta, string sifre, string rolAdi)
        {
            KullaniciID = kullaniciId;
            Adi = ad;
            Soyadi = soyad;
            Eposta = eposta;
            Sifre = sifre;
            RolAdi = rolAdi;
        }
    }
}
