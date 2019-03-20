using DBClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsClasses;

namespace ThreadedProjectTerm2
{
    public partial class frmSuppliers : Form
    {
        /**
        * Threaded project 2 - Team 1
        * Purpose: Form for the supplier data to be built into
        * Made by: Brent Ward
        * Date: March 19th 2019
        * **/

        //holder variables
        List<Supplier> suppliers = null;
        Supplier supp;

        public frmMain activeFrmMain;
        public frmSuppliers()
        {
            InitializeComponent();
        }

        //builds datagrid on load
        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            suppliers = SuppliersDB.GetSuppliers();
            supplierDataGridView.DataSource = suppliers;
        }

        private void frmSuppliers_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this == activeFrmMain.activeFrmSuppliers)
                activeFrmMain.activeFrmPackages = null;
        }


        //adds the input to the table
        private void AddButton_Click(object sender, EventArgs e)
        {
            if(isValid())
            {
                supp = new Supplier();
                this.buildSupplier(supp);
                try
                {
                    if (SuppliersDB.AddSupplier(supp))
                    {
                        MessageBox.Show("Supplier added successfully.", "Success");
                        clearContent();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add the suplier. Please try again.", "Database Error");
                        clearContent();
                    }

                }
                catch (Exception ex) { MessageBox.Show(ex.Message, ex.GetType().ToString()); }
            }        
        }

        //deletes the selected cell
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (isValid())//checks there is a value selected
            {
                //confirmation window
                DialogResult result = MessageBox.Show("Delete " + supp.SupName + "?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (!SuppliersDB.DeleteSupplier(supp))//failed
                        {
                            MessageBox.Show("Another user has updated or deleted that supplier.", "Database Error");
                            clearContent();
                        }
                        else//success
                        {
                            MessageBox.Show("Delete Successful.");
                            clearContent();
                        }

                    }
                    catch(Exception ex) { MessageBox.Show(ex.Message, ex.GetType().ToString()); }
                }
            }else { MessageBox.Show("Data fields are empty.", "Input Error"); }
        }

        //clears the input fields
        private void ClearButton_Click(object sender, EventArgs e)
        {
            clearContent();
        }

        //clicking cell auto fills text boxes
        private void supplierDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try//catches out of bounds clicks
            {
                supIDTextBox.Text = supplierDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                supNameTextBox.Text = supplierDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();

                supp = new Supplier();
                buildSupplier(supp);//sets the object to the current instance
            }catch(Exception ex) { MessageBox.Show("Please Only click in-bounds data.", "Invalid use"); }
            
        }

        //checks the fields are valid
        private bool isValid()
        {
            return Validator.IsPresent(supIDTextBox) && 
                   Validator.isWholeNumber(supIDTextBox, "ID") &&
                   Validator.isNonNegative(supIDTextBox, "ID") &&
                   Validator.IsPresent(supNameTextBox);
        }

        //builds the current supplier
        private void buildSupplier(Supplier supp)
        {
            supp.SupID = Convert.ToInt32(supIDTextBox.Text);
            supp.SupName = supNameTextBox.Text;
        }

        //resets the form (useful to update the datagrid for changes/new submissions)
        private void clearContent()
        {
            supIDTextBox.Clear();
            supNameTextBox.Clear();

            //resets the datagrid
            suppliers = SuppliersDB.GetSuppliers();
            supplierDataGridView.DataSource = suppliers;
        }
        
    }
}
