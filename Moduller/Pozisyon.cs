using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMYonetimiOtomasyonu.Moduller
{
    public class Pozisyon
    {
        public int PozisyonID { get; set; }
        public string PozisyonAdi { get; set; }

        public Pozisyon() { }

        public Pozisyon(int pozisyonId, string pozisyonAdi)
        {
            PozisyonID = pozisyonId;
            PozisyonAdi = pozisyonAdi;
        }

        public override string ToString()
        {
            return PozisyonAdi;
        }
    }
}
