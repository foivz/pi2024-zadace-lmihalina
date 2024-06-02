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
    public class ScheduleRepository
    {
        public static Schedule GetSchedule(int linija, int stanica)
        {
            Schedule schedule = null;
            string sql = $"SELECT * FROM VozniRed WHERE VoznaLinijaID = {linija} AND AutobusnaStanicaID = {stanica}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                schedule = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return schedule;
        }
        public static List<Schedule> GetSchedules()
        {
            List<Schedule> schedules = new List<Schedule>();

            string sql = "SELECT * FROM VozniRed";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            while (reader.Read())
            {
                Schedule schedule = CreateObject(reader);
                schedules.Add(schedule);
            }

            reader.Close();
            DB.CloseConnection();
            return schedules;
        }

        public static void Delete(int idLinija, int idStanica)
        {
            string sql = $"DELETE FROM VozniRed WHERE VoznaLinijaID={idLinija} AND AutobusnaStanicaID={idStanica}";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        public static void Insert(Schedule schedule)
        {
            string sql = $"INSERT INTO VozniRed (VoznaLinijaID,AutobusnaStanicaID,DjelatnikOIB) VALUES ({schedule.VoznaLinija.ID},{schedule.AutobusnaStanica.ID},'{schedule.Djelatnik.OIB}')";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection() ;
        }

        private static Schedule CreateObject(SqlDataReader reader)
        {
            int linijaID = int.Parse(reader["VoznaLinijaID"].ToString());
            var linija = BusLineRepository.GetBusLine(linijaID);

            int stanicaID = int.Parse(reader["AutobusnaStanicaID"].ToString());
            var stanica = BusStationRepository.GetBusStation(stanicaID);

            string djelatnikOIB = reader["DjelatnikOIB"].ToString();
            Employee djelatnik = EmployeeRepository.GetEmployeeByOIB(djelatnikOIB);

            var schedule  = new Schedule
            {
                VoznaLinija=linija,
                AutobusnaStanica=stanica,
                Djelatnik=djelatnik,
            };

            return schedule;
        }

        internal static void Update(Schedule newSchedule, Schedule schedule)
        {
            string sql = $"UPDATE VozniRed SET VoznaLinijaID={newSchedule.VoznaLinija.ID}, AutobusnaStanicaID={newSchedule.AutobusnaStanica.ID}, " +
                $"DjelatnikOIB='{newSchedule.Djelatnik.OIB}' WHERE VoznaLinijaID={schedule.VoznaLinija.ID} AND AutobusnaStanicaID={schedule.AutobusnaStanica.ID}";
            DB.OpenConnection() ;
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
    }
}
