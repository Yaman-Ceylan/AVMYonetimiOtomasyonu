using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMYonetimiOtomasyonu.Moduller
{
    public class Personel
    {
        public string PersonelTC { get; set; }
        public string PersonelAdi { get; set; }
        public string PersonelSoyadi { get; set; }
        public string Cinsiyet { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public string Adres { get; set; }
        public string Pozisyon { get; set; }
        public double Maas { get; set; }

        public Personel(string personelTC, string personelAdi, string personelSoyadi, string cinsiyet, string telefon, string eposta, string adres, string pozisyon, double maas)
        {
            PersonelTC = personelTC;
            PersonelAdi = personelAdi;
            PersonelSoyadi = personelSoyadi;
            Cinsiyet = cinsiyet;
            Telefon = telefon;
            Eposta = eposta;
            Adres = adres;
            Pozisyon = pozisyon;
            Maas = maas;
        }
    }
}
