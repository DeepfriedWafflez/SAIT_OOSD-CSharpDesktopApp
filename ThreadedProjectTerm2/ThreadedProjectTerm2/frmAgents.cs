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
    
    public partial class frmAgents : Form
    {
        public frmMain activeFrmMain;
        public frmAgents()
        {
            InitializeComponent();
        }

        private void frmAgents_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this == activeFrmMain.activeFrmAgents)
                activeFrmMain.activeFrmPackages = null;
        }
    }
}
