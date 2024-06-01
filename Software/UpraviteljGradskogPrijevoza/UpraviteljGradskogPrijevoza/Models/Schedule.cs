using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpraviteljGradskogPrijevoza.Models
{
    public class Schedule
    {
        public BusLine VoznaLinija { get; set; }
        public BusStation AutobusnaStanica { get; set; }
        public Employee Djelatnik { get; set; }
    }
}
