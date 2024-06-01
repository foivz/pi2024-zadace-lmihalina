using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpraviteljGradskogPrijevoza.Models;

namespace UpraviteljGradskogPrijevoza.Repositories
{
    public class BusLineRepository
    {
        public static BusLine GetBusLine(int id)
        {
            BusLine busline = null;
            string sql = $"SELECT * FROM VoznaLinija WHERE ID={id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                busline = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return busline;
        }

        public static List<BusLine> GetBusLines()
        {
            List<BusLine> buslines = new List<BusLine>();

            string sql = "SELECT * FROM VoznaLinija";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            while (reader.Read())
            {
                BusLine busline = CreateObject(reader);
                buslines.Add(busline);
            }

            reader.Close();
            DB.CloseConnection();
            return buslines;
        }

        private static BusLine CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["ID"].ToString());
            string imeLinije = reader["ImeLinije"].ToString();

            string djelatnikOIB = reader["DjelatnikOIB"].ToString();
            var djelatnik = EmployeeRepository.GetEmployeeByOIB(djelatnikOIB);

            var busline = new BusLine
            {
                ID = id,
                ImeLinije = imeLinije,
                Djelatnik = djelatnik,
            };
            return busline;
        }
    }
}
