using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpraviteljGradskogPrijevoza.Models
{
    public class BusLine
    {
        public int ID { get; set; }
        public string ImeLinije  { get; set; }
        public Employee Djelatnik { get; set; }
    }
}
