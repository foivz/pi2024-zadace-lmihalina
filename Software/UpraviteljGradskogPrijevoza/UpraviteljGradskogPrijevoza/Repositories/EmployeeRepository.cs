using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpraviteljGradskogPrijevoza.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UpraviteljGradskogPrijevoza.Repositories
{
    public class EmployeeRepository
    {
        public static Employee GetEmployee(string username)
        {
            string sql = $"SELECT * FROM Djelatnik WHERE KorisnickoIme='{username}'";
            return FetchEmployee(sql);
        }

        public static Employee GetEmployee(int id)
        {
            string sql = $"SELECT * FROM Djelatnik WHERE OIB='{id}'";
            return FetchEmployee(sql);
        }
        private static Employee FetchEmployee(string sql)
        {
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            Employee employee = null;
            if (reader.HasRows == true)
            {
                reader.Read();
                employee = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return employee;

        }

        private static Employee CreateObject(SqlDataReader reader)
        {
            string oib = reader["OIB"].ToString();
            string ime = reader["Ime"].ToString();
            string prezime = reader["Prezime"].ToString();
            string korisnicko_ime= reader["KorisnickoIme"].ToString() ;
            string lozinka = reader["Lozinka"].ToString();
            string is_manager = reader["isManager"].ToString();

            var employee = new Employee
            {
                OIB = oib,
                Ime = ime,
                Prezime = prezime,
                KorisnickoIme = korisnicko_ime,
                Lozinka = lozinka,
                IsManager=is_manager
            };
            return employee;
        }
    }
}
