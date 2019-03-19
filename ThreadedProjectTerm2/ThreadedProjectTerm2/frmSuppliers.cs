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


        //adds the input tothe table
        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        //updates the selected cell with new data
        private void UpdateButton_Click(object sender, EventArgs e)
        {

        }

        //deletes the selected cell
        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        //clears the input fields
        private void ClearButton_Click(object sender, EventArgs e)
        {

        }

        //clicking cell auto fills text boxes
        private void supplierDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
