using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpraviteljGradskogPrijevoza.Models
{
    public class BusStation
    {
        public int ID { get; set; }
        public string Naselje { get; set; }
        public string Adresa { get; set; }
        public Employee Djelatnik { get; set; }

        public override string ToString()
        {
            return $"{Adresa}, {Naselje} ";
        }
    }

   
}
