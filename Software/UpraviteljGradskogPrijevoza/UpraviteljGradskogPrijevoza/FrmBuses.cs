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
            dgvBuses.Columns["Djelatnik"].HeaderText = "Autor";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = true;
            btnCancel.BackColor= Color.Red;
            string parametar = rdbManufacturer.Checked ? "Proizvodac" : "Registracija";
            string keyword = txtSearchBuses.Text;
            List<Bus> buses = BusRepository.SearchBuses(parametar, keyword);
            dgvBuses.DataSource= buses;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled= false;
            btnCancel.BackColor = Color.Silver;
            txtSearchBuses.Text="";
            FrmBuses_Load(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Bus selectedBus = dgvBuses.CurrentRow.DataBoundItem as Bus;
            if (selectedBus != null)
            {
                DialogResult result = MessageBox.Show
                    ("Jeste li sigurni da želite obrisati odabrani autobus?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (result == DialogResult.Yes)
                {
                    BusRepository.Delete(selectedBus.ID);
                    FrmBuses_Load(sender, e);
                }
            }
            else MessageBox.Show("Odaberite autobus koji želite obrisati!", "Brisanje neuspješno", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Bus selectedBus = dgvBuses.CurrentRow.DataBoundItem as Bus;
            FrmEditBuses frmEditBuses = new FrmEditBuses(selectedBus); 
            frmEditBuses.ShowDialog();    
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmEditBuses frmEditBuses = new FrmEditBuses(null);
            frmEditBuses.ShowDialog();
        }
    }
}
