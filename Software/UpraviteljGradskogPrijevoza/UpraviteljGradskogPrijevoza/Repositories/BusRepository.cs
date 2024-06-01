using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using UpraviteljGradskogPrijevoza.Models;

namespace UpraviteljGradskogPrijevoza.Repositories
{
    public class BusRepository
    {
        public static Bus GetBus(int id)
        {
            Bus bus = null;
            string sql = $"SELECT * FROM Autobusi WHERE ID={id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows) 
            {
                reader.Read();
                bus = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return bus;
        }

        public static List<Bus> GetBuses() 
        {
            List<Bus> buses = new List<Bus>();

            string sql = "SELECT * FROM Autobusi";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            while(reader.Read())
            {
                Bus bus= CreateObject(reader);
                buses.Add(bus);
            }

            reader.Close();
            DB.CloseConnection();
            return buses;
        }

        public static List<Bus> SearchBuses(string parametar, string keyword)
        {
            List<Bus> buses= new List<Bus>();
            string sql = $"SELECT * FROM Autobusi WHERE {parametar} LIKE '%{keyword}%'"; 
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            while (reader.Read())
            {
                Bus bus = CreateObject(reader);
                buses.Add(bus);
            }

            reader.Close();
            DB.CloseConnection();
            return buses;
        }

        private static Bus CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["ID"].ToString());
            string proizvodac = reader["Proizvodac"].ToString();
            string registracija = reader["Registracija"].ToString();
            int.TryParse(reader["VoznaLinijaID"].ToString(), out int voznaLinijaID);
            string djelatnikOIB = reader["DjelatnikOIB"].ToString();

            var bus = new Bus
            {
                ID = id,
                Proizvodac = proizvodac,
                Registracija = registracija,
                VoznalinijaID = voznaLinijaID,
                DjelatnikOIB=djelatnikOIB
            };

            return bus;
        }
    }
}
