using DBLayer;
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
    public partial class FrmLogin : Form
    {
        Employee LoggedEmployee = new Employee();

        public FrmLogin()
        {
            InitializeComponent();
            DB.SetConfiguration("PI2324_lmihalina22_DB", "PI2324_lmihalina22_User", "8j]{j4cH");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            LoggedEmployee=EmployeeRepository.GetEmployee(txtUsername.Text);

            if (txtUsername.Text == "" || txtPassword.Text == "")
                MessageBox.Show("Molimo unesite sve podatke!", "Prijava neuspješna", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (LoggedEmployee!=null && LoggedEmployee.Lozinka==txtPassword.Text)
            {
                FrmBuses frmBuses = new FrmBuses();
                Hide();
                frmBuses.ShowDialog();
                Close();
            }
            else
                MessageBox.Show("Korisničko ime ili lozinka su pogrešni!", "Prijava neuspješna", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
        } 
    }
}
