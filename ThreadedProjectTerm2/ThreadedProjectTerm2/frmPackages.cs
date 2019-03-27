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
    public partial class frmPackages : Form
    {
        public frmMain activeFrmMain;
        List<Package> packages = new List<Package>();
        Package pkg = null;

        public frmPackages()
        {
            InitializeComponent();
        }

        private void frmPackages_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this == activeFrmMain.activeFrmPackages)
                activeFrmMain.activeFrmPackages = null;
        }

        private void frmPackages_Load(object sender, EventArgs e)
        {
            packages = PackageDB.DisplayPackagesInGrid(); //packages is the list to hold the list of packages
            packageDataGridView.DataSource = packages; //binding the list of packages to Grid
        }

        /// <summary>
        /// Clicking on Row within the grid, populates the data in the controls places on the form from the Grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void packageDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (packageDataGridView.SelectedRows.Count > 0) //execute block code if rows exists in the grid
            {
                var package = (Package)packageDataGridView.SelectedRows[0].DataBoundItem; //selectedrows[0] gets the row selected by user, 
                //typecast it in Package type & assign it to variable, now accesss properties of Package thru package variable
                //assigns values to controls of the from from corresponding Gridview.
                this.txtPackageId.Text = package.PackageId.ToString(); 
                txtPkgName.Text = package.PkgName;
                pkrPkgStartDate.Text = package.PkgStartDate.ToString();
                pkrPkgEndDate.Text = package.PkgEndDate.ToString();
                txtPkgDesc.Text = package.PkgDesc.ToString();
                txtPkgBasePrice.Text = package.PkgBasePrice.ToString();
                txtPkgAgencyCom.Text = package.PkgAgencyCommission.ToString();

            }
        }
        
        private void btnDeletePkg_Click(object sender, EventArgs e)
        {
            Package pkgObj = new Package();
            pkgObj.PackageId = Convert.ToInt32(txtPackageId.Text);
            PutPackageData(pkgObj);
            
            int result = 0;
            try
            {
                var packageNames = PackageDB.CheckBeforeDelete();
                if(packageNames.Count != 0)
                {
                     MessageBox.Show("Can't Delete Package. Please delete dependent tables first");
                }
                else
                {
                    int pkgId = Convert.ToInt32(txtPackageId.Text);
                    bool success = PackageDB.PackageDelete(pkgObj);
                    if (success)
                    {
                        MessageBox.Show("Package deleted successfully");
                      
                    }
                }

                packages = PackageDB.DisplayPackagesInGrid(); //packages is the list to hold the list of packages
                packageDataGridView.DataSource = packages; //binding the list of packages to Grid
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }

        /// <summary>
        /// Add Package method adds the package into the package table, PackageID textbox  on the form is disabled as it's auto-incremented
        /// in the database table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPkg_Click(object sender, EventArgs e)
        {

            Package pkgObj = new Package();
            if (Validator.IsPresent(txtPkgName) && (Validator.IsPresent(txtPkgBasePrice)))
            {
                this.PutPackageData(pkgObj); //calling putPackageData() to fill Package Object
                foreach (char pkgName in pkgObj.PkgName)
                {
                    if(Convert.ToString(pkgName) == txtPkgName.Text)
                    {
                        MessageBox.Show("Package Name already Exists");
                    }
                }
           
                    try
                    {
                        PackageDB.PackageAdd(pkgObj);
                        MessageBox.Show("Package Added Successfully");
                        packages = PackageDB.DisplayPackagesInGrid(); //packages is the list to hold the list of packages
                        packageDataGridView.DataSource = packages; //binding the list of packages to Grid

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }

            }
            else
                MessageBox.Show("Name & Base price of the package can't be empty");

        }

        /// <summary>
        /// Update method updates the Packages table with the modified data from the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Package pkgObj = new Package(); //Created new package object which is empty for now
            pkgObj.PackageId = int.Parse(txtPackageId.Text); //populates the PackageID property of the object
            this.PutPackageData(pkgObj); //calls the putpackagedata() method to populate rest of the properties
            if (Validator.IsPresent(txtPkgName) && (Validator.IsPresent(txtPkgBasePrice)))            
            {
                try
                {
                    bool success = PackageDB.PackageUpdate(pkgObj);
                    MessageBox.Show("Package Updated Successfully");
                    packages = PackageDB.DisplayPackagesInGrid(); //packages is the list to hold the list of packages
                    packageDataGridView.DataSource = packages; //binding the list of packages to Grid
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
            else
            {
                MessageBox.Show("Name & Base Price of the Package have to be entered");
            }
        }

        /// <summary>
        /// PutPackageData() is generic method to be called on the form whenever needed. PackageID is not part of it because 
        /// PackageAdd() method doesn't require packageid as it's auto-generated from database table.
        /// </summary>
        /// <param name="package"></param>
        private void PutPackageData(Package package)
        {
            double number;
            package.PkgName = txtPkgName.Text;
            package.PkgDesc = txtPkgDesc.Text;
            package.PkgBasePrice = double.Parse(txtPkgBasePrice.Text);
            package.PkgStartDate = DateTime.Parse(pkrPkgStartDate.Text);
            package.PkgEndDate = DateTime.Parse(pkrPkgEndDate.Text);
            if (double.TryParse(txtPkgAgencyCom.Text, out number))
            {
                package.PkgAgencyCommission = number;
            }
           
        }

        //Event handler to make sure price fields can take only numbers from keyboard but can backspac
        private void txtPkgBasePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
            if (e.KeyChar == (char)13)
            {
                txtPkgBasePrice.Text = string.Format("{0:n0}", double.Parse(txtPkgBasePrice.Text));
            }
        }

        private void txtPkgAgencyCom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)8 && e.KeyChar != (char)46))
                e.Handled = true;
            if (e.KeyChar == (char)13)
            {
                txtPkgBasePrice.Text = string.Format("{0:n0}", double.Parse(txtPkgBasePrice.Text));
            }
        }

      



    }//class

} //namespace



//private void packageDataGridView_CellContent_Click(object sender, EventArgs e)
//{
//    if (packageDataGridView.SelectedRows.Count > 0)
//    {
//        var package = (Package)packageDataGridView.SelectedRows[0].DataBoundItem;
//        int packageId = package.PackageId;
//        packageIdTextBox.Text = package.PackageId.ToString();
//        pkgNameTextBox.Text = package.PkgName;
//        pkgStartDateDateTimePicker.Text = package.PkgStartDate.ToString();
//        pkgEndDateDateTimePicker.Text = package.PkgEndDate.ToString();
//        pkgDescTextBox.Text = package.PkgDesc.ToString();
//        pkgBasePriceTextBox.Text = package.PkgBasePrice.ToString();
//        pkgAgencyCommissionTextBox.Text = package.PkgAgencyCommission.ToString();

//    }
//}