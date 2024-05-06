using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMYonetimiOtomasyonu.Database
{
    public class Database
    {
        public static string GetConnectionString
        {
            get { return "Data Source = localhost; user Id = root; password = 514514; database = avmyonetimiotomasyonu"; }
        }
    }
}