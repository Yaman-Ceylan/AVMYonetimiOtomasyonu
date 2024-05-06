using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMYonetimiOtomasyonu.Moduller
{
    public class Rol
    {
        public int RolID { get; set; }
        public string RolAdi { get; set; }

        public Rol() { }

        public Rol(int rolID, string rolAdi)
        {
            RolID = rolID;
            RolAdi = rolAdi;
        }

        public override string ToString()
        {
            return RolAdi;
        }
    }
}