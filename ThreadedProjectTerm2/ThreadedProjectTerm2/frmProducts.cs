﻿using System;
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
    public partial class frmProducts : Form
    {
        public frmMain activeFrmMain;
        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (this == activeFrmMain.activeFrmProducts)
                activeFrmMain.activeFrmPackages = null;
        }
    }
}
