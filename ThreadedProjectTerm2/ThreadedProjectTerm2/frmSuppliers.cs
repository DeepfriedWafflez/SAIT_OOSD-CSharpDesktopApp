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
    public partial class frmSuppliers : Form
    {
        public frmMain activeFrmMain;
        public frmSuppliers()
        {
            InitializeComponent();
        }

        private void frmSuppliers_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this == activeFrmMain.activeFrmSuppliers)
                activeFrmMain.activeFrmPackages = null;
        }
    }
}
