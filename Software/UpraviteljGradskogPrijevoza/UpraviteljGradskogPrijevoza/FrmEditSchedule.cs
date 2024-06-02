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
        Schedule Sschedule;
        public FrmEditSchedule(Schedule schedule)
        {
            InitializeComponent();
            Sschedule = schedule;
        }

        private void FrmEditSchedule_Load(object sender, EventArgs e)
        {
            cboBusLine.DataSource=BusLineRepository.GetBusLines();
            cboBusStation.DataSource=BusStationRepository.GetBusStations();
            txtEmployee.Text=FrmLogin.LoggedEmployee.ToString();

            if(Sschedule==null)
            {
                lblHeader.Text = "Unesi novi vozni red";           
            }
            else
            {
                lblHeader.Text = "Uredi vozni red";
                cboBusLine.SelectedItem= Sschedule.VoznaLinija;
                cboBusStation.SelectedItem = Sschedule.AutobusnaStanica;
            }
            this.Text = lblHeader.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (Sschedule == null)
            {
                Schedule newSchedule = new Schedule();
                newSchedule.VoznaLinija = cboBusLine.SelectedItem as BusLine;
                newSchedule.AutobusnaStanica = cboBusStation.SelectedItem as BusStation;
                newSchedule.Djelatnik = EmployeeRepository.GetEmployeeByUsername(txtEmployee.Text);
                ScheduleRepository.Insert(newSchedule);
                Close();
            }
            else
            {
                Schedule newSchedule = new Schedule();
                newSchedule.VoznaLinija = cboBusLine.SelectedItem as BusLine;
                newSchedule.AutobusnaStanica = cboBusStation.SelectedItem as BusStation;
                newSchedule.Djelatnik = EmployeeRepository.GetEmployeeByUsername(txtEmployee.Text);
                ScheduleRepository.Update(newSchedule,Sschedule);
                Close();
            }

        }
    }
}
