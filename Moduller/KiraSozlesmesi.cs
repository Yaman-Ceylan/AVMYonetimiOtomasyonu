using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMYonetimiOtomasyonu.Moduller
{
    public class KiraSozlesmesi
    {
        public int KiraID { get; set; }
        public string Isletme { get; set; }
        public string Kiraci { get; set; }
        public string MekanTipi { get; set; }
        public string Konum{ get; set; }
        public string KiralikAlan { get; set; }
        public double KiraBedeli { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }

        public KiraSozlesmesi(int kiraId, string isletme, string kiraci, string mekanTipi, string konum, string kiralikAlan, double kiraBedeli, DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            KiraID = kiraId;
            Isletme = isletme;
            Kiraci = kiraci;
            MekanTipi = mekanTipi;
            Konum = konum;
            KiralikAlan = kiralikAlan;
            KiraBedeli = kiraBedeli;
            BaslangicTarihi = baslangicTarihi;
            BitisTarihi = bitisTarihi;
        }
    }
}
