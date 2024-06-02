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
    public partial class FrmEditBuses : Form
    {
        private Bus bus;
        public FrmEditBuses(Bus selectedBus)
        {
            InitializeComponent();
            bus = selectedBus;
        }

        private void FrmEditBuses_Load(object sender, EventArgs e)
        {
            cboBusLine.DataSource = BusLineRepository.GetBusLines();
            cboEmployee.Text = FrmLogin.LoggedEmployee.ToString();
            if (bus == null)
            {
                lblHeader.Text = "Dodaj novi autobus";
            }
            else
            {
                lblHeader.Text = "Uredi autobus";
                txtID.Text=bus.ID.ToString();
                txtManufacturer.Text=bus.Proizvodac.ToString();
                txtRegistration.Text=bus.Registracija.ToString();
            }

            
        }
    }
}
