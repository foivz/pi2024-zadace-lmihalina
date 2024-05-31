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
    public partial class FrmBuses : Form
    {
        public FrmBuses()
        {
            InitializeComponent();
        }

        private void FrmBuses_Load(object sender, EventArgs e)
        {
            List<Bus> buses = BusRepository.GetBuses();
            dgvBuses.DataSource = buses;
        }
    }
}
