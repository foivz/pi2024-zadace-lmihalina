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


namespace UpraviteljGradskogPrijevoza
{
    public partial class FrmLogin : Form
    {
        string Username="a", Password="b";
        public FrmLogin()
        {
            InitializeComponent();
            DB.SetConfiguration("PI2324_lmihalina22_DB", "PI2324_lmihalina22_User", "8j]{j4cH");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (txtUsername.Text == "" || txtPassword.Text == "")
                MessageBox.Show("Molimo unesite sve podatke!", "Prijava neuspješna", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtUsername.Text == Username && txtPassword.Text == Password)
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
