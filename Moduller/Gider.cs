using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMYonetimiOtomasyonu.Moduller
{
    public class Gider
    {
        public string PersonelTC { get; set; }
        public string Personel { get; set; }
        public string Pozisyon { get; set; }
        public double Maas{ get; set; }

        public Gider(string personelTC, string personel, string pozisyon, double maas)
        {
            PersonelTC = personelTC;
            Personel = personel;
            Pozisyon = pozisyon;
            Maas = maas;
        }
    }
}
