using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpraviteljGradskogPrijevoza.Repositories;

namespace UpraviteljGradskogPrijevoza.Models
{
    public class Employee
    {
        public string OIB { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string IsManager { get; set; }

        public override string ToString()
        {

            return KorisnickoIme;
        }

     
    }
}
