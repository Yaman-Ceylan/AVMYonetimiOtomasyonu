using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMYonetimiOtomasyonu.Moduller
{
    public class Gelir
    {
        public int IsletmeID{ get; set; }
        public string IsletmeAdi { get; set; }
        public double KiraBedeli { get; set; }

        public Gelir(int isletmeId, string isletmeAdi, double kiraBedeli)
        {
            IsletmeID = isletmeId;
            IsletmeAdi = isletmeAdi;
            KiraBedeli = kiraBedeli;
        }
    }
}
