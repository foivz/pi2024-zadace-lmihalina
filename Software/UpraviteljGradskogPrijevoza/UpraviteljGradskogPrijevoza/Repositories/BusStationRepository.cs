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
    public class BusStationRepository
    {
        public static BusStation GetBusStation(int id)
        {
            BusStation busStation = null;
            string sql = $"SELECT * FROM AutobusnaStanica WHERE ID={id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                busStation = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return busStation;
        }

        public static List<BusStation> GetBusStations()
        {
            List<BusStation> busStations = new List<BusStation>();

            string sql = "SELECT * FROM AutobusnaStanica";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            while (reader.Read())
            {
                BusStation busStation = CreateObject(reader);
                busStations.Add(busStation);
            }

            reader.Close();
            DB.CloseConnection();
            return busStations;
        }

        private static BusStation CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["ID"].ToString());
            string naselje  = reader["Naselje"].ToString();
            string adresa = reader["Adresa"].ToString() ;

            string djelatnikOIB = reader["DjelatnikOIB"].ToString();
            var djelatnik = EmployeeRepository.GetEmployeeByOIB(djelatnikOIB);

           var busStation = new BusStation
           {
               ID = id,
               Naselje = naselje,
               Adresa = adresa,
               Djelatnik=djelatnik,
           };

            return busStation;
        }
    }
}
