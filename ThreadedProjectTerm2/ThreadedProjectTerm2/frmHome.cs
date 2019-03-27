using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ThreadedProjectTerm2
{
    public partial class frmHome : Form
    {
        public frmMain activeFrmMain;
        public frmHome()
        {
            InitializeComponent();          
        }

        private void frmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this == activeFrmMain.activeFrmHome)
                activeFrmMain.activeFrmPackages = null;
        }
        
        //scrolling background -- Made By: Brent Ward
        private void frmHome_Load(object sender, EventArgs e)
        {
        }
    }
}
