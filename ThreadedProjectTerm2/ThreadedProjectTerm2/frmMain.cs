using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadedProjectTerm2
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Main form that is the parent MDI form to manage the application:
        ///             
        ///     - stores application level variables to manage user credentials
        ///       and child form tranisitions
        ///     - provides code for menu buttons 
        ///     - loads the home page (frmHome) 
        ///     
        /// Author: Stuart Peters (parent/child form management)
        ///         Brent (user authenticaton - code is pending here)
        /// </summary>
        
        //form level variables that are set when a child opens and 
        //are used to track/test if a child form is open to 
        //avoid opening duplicate versions of each form when menu buttons are clicked 
        
        public frmHome activeFrmHome = null;
        public frmPackages activeFrmPackages = null;
        public frmProducts activeFrmProducts = null;
        public frmSuppliers activeFrmSuppliers = null;
        public frmAgents activeFrmAgents= null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (activeFrmHome == null)
            {
                activeFrmHome = new frmHome();
                activeFrmHome.MdiParent = this;
                activeFrmHome.WindowState = FormWindowState.Maximized;
                activeFrmHome.Show();
                activeFrmHome.ControlBox = false;
                activeFrmHome.activeFrmMain = this;
            }
            else
            {
                activeFrmHome.BringToFront();
                activeFrmHome.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnPackages_Click(object sender, EventArgs e)
        {
            if (activeFrmPackages == null)
            {
                activeFrmPackages = new frmPackages();
                activeFrmPackages.MdiParent = this;
                activeFrmPackages.WindowState = FormWindowState.Maximized;
                activeFrmPackages.Show();
                activeFrmPackages.ControlBox = false;
                activeFrmPackages.activeFrmMain = this;
            }
            else
            {
                activeFrmPackages.BringToFront();
                activeFrmPackages.WindowState = FormWindowState.Maximized;
            }

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            if (activeFrmProducts == null)
            {
                activeFrmProducts = new frmProducts();
                activeFrmProducts.MdiParent = this;
                activeFrmProducts.WindowState = FormWindowState.Maximized;
                activeFrmProducts.Show();
                activeFrmProducts.ControlBox = false;
                activeFrmProducts.activeFrmMain = this;
            }
            else
            {
                activeFrmProducts.BringToFront();
                activeFrmProducts.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            if (activeFrmSuppliers == null)
            {
                activeFrmSuppliers = new frmSuppliers();
                activeFrmSuppliers.MdiParent = this;
                activeFrmSuppliers.WindowState = FormWindowState.Maximized;
                activeFrmSuppliers.Show();
                activeFrmSuppliers.ControlBox = false;
                activeFrmSuppliers.activeFrmMain = this;
            }
            else
            {
                activeFrmSuppliers.BringToFront();
                activeFrmSuppliers.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnAgents_Click(object sender, EventArgs e)
        {
            if (activeFrmAgents == null)
            {
                activeFrmAgents = new frmAgents();
                activeFrmAgents.MdiParent = this;
                activeFrmAgents.WindowState = FormWindowState.Maximized;
                activeFrmAgents.Show();
                activeFrmAgents.ControlBox = false;
                activeFrmAgents.activeFrmMain = this;
            }
            else
            {
                activeFrmAgents.BringToFront();
                activeFrmAgents.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            activeFrmHome = new frmHome();
            activeFrmHome.MdiParent = this;
            activeFrmHome.WindowState = FormWindowState.Maximized;
            activeFrmHome.Show();
            activeFrmHome.ControlBox = false;
            activeFrmHome.activeFrmMain = this;
        }
    }
}
