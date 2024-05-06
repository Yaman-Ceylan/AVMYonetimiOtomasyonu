using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMYonetimiOtomasyonu.Moduller
{
    public class GuvenlikKamerası
    {
        public int KameraID { get; set; }
        public string KameraTipi { get; set; }
        public string Konum { get; set; }

        public GuvenlikKamerası(int kameraId, string kameraTipi, string konum)
        {
            KameraID = kameraId;
            KameraTipi = kameraTipi;
            Konum = konum;
        }
    }
}
