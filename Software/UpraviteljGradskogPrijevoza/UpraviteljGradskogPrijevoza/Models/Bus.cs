using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpraviteljGradskogPrijevoza.Models
{
    public class Bus
    {
        public int ID { get; set; }
        public string Proizvodac { get; set; }
        public string Registracija { get; set; }
        public int VoznalinijaID { get; set; }
        public string DjelatnikOIB { get; set; }
    }
}
