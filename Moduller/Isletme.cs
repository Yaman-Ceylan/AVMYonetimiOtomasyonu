using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMYonetimiOtomasyonu.Moduller
{
    public class Isletme
    {
        public int IsletmeID { get; set; }
        public string IsletmeAdi { get; set; }
        public string MekanTipi { get; set; }
        public string IsletmeTelefon { get; set; }
        public int CalisanSayisi { get; set; }
        public string Konum { get; set; }

        public Isletme(int isletmeId, string isletmeAdi, string mekanTipi, string isletmeTelefon, int calisanSayisi, string konum)
        {
            IsletmeID = isletmeId;
            IsletmeAdi = isletmeAdi;
            MekanTipi = mekanTipi;
            IsletmeTelefon = isletmeTelefon;
            CalisanSayisi = calisanSayisi;
            Konum = konum;
        }

        public Isletme(int isletmeId, string isletmeAdi)
        {
            IsletmeID = isletmeId;
            IsletmeAdi = isletmeAdi;
        }

        public override string ToString()
        {
            return IsletmeAdi;
        }
    }
}
