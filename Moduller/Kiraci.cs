using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMYonetimiOtomasyonu.Moduller
{
    public class Kiraci
    {
        public int KiraciID{ get; set; }
        public string KiraciAdi { get; set; }
        public string KiraciTelefon { get; set; }
        public string KiraciEPosta { get; set; }

        public Kiraci(int kiraciId, string kiraciAdi, string kiraciTelefon, string kiraciEposta)
        {
            KiraciID = kiraciId;
            KiraciAdi = kiraciAdi;
            KiraciTelefon = kiraciTelefon;
            KiraciEPosta = kiraciEposta;
        }

        public Kiraci(int kiraciId, string kiraciAdi)
        {
            KiraciID = kiraciId;
            KiraciAdi = kiraciAdi;
        }

        public override string ToString()
        {
            return KiraciAdi;
        }
    }
}
