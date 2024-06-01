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
        public BusLine Voznalinija { get; set; }
        public Employee Djelatnik { get; set; }
    }
}
