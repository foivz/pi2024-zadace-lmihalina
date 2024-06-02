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
    public partial class FrmSchedule : Form
    {
        public FrmSchedule()
        {
            InitializeComponent();
        }

        private void btnBuses_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void FrmSchedule_Load(object sender, EventArgs e)
        {
            List<Schedule> schedules = ScheduleRepository.GetSchedules();
            dgvSchedules.DataSource = schedules;
        }
    }
}
