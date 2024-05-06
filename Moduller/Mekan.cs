using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMYonetimiOtomasyonu.Moduller
{
    public class Mekan
    {
        public int MekanID { get; set; }
        public string MekanTipi { get; set; }

        public Mekan() { }

        public Mekan(int mekanID, string mekanTipi)
        {
            MekanID = mekanID;
            MekanTipi = mekanTipi;
        }

        public override string ToString()
        {
            return MekanTipi;
        }
    }
}