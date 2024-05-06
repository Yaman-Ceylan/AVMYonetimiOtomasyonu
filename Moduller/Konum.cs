using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMYonetimiOtomasyonu.Moduller
{
    public class Konum
    {
        public int KonumID { get; set; }
        public string KonumAdi { get; set; }

        public Konum() { }

        public Konum(int konumID, string konumAdi)
        {
            KonumID = konumID;
            KonumAdi = konumAdi;
        }

        public override string ToString()
        {
            return KonumAdi;
        }
    }
}
