using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpraviteljGradskogPrijevoza.Models;
using UpraviteljGradskogPrijevoza.Repositories;

namespace UpraviteljGradskogPrijevoza
{
    public partial class FrmEditSchedule : Form
    {
        public FrmEditSchedule(Schedule schedule)
        {
            InitializeComponent();
        }

        private void FrmEditSchedule_Load(object sender, EventArgs e)
        {
            cboBusLine.DataSource=BusLineRepository.GetBusLines();
            cboBusStation.DataSource=BusStationRepository.GetBusStations();
            txtEmployee.Text=FrmLogin.LoggedEmployee.ToString();
        }
    }
}
