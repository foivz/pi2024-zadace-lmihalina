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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Schedule selectedSchedule = dgvSchedules.CurrentRow.DataBoundItem as Schedule;
            if(selectedSchedule != null) 
            {
                DialogResult result = MessageBox.Show
                    ("Jeste li sigurni da želite obrisati odabranu instancu voznog reda?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    ScheduleRepository.Delete(selectedSchedule.VoznaLinija.ID, selectedSchedule.AutobusnaStanica.ID);
                    FrmSchedule_Load(sender, e);
                }
            }
            else MessageBox.Show("Odaberite instancu vozne linije koju želite obrisati!", "Brisanje neuspješno", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
    }
}
