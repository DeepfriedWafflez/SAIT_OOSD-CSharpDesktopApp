using DBClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        List<Package> packages;
        Package package;
        bool IsDateValid = true;


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
             try
            {

                // packageDataGridView.DataSource = PackageDB.DisplayPackagesInGrid();
                packages = PackageDB.DisplayPackagesInGrid();
                packageDataGridView.DataSource = packages; //packages is the list to hold the list of packages
                pkrPkgStartDate.Checked = false;
                pkrPkgEndDate.Checked = false;


            }
            catch(Exception ex)
            {
                MessageBox.Show("Error occured while loading page", "Connection Error");
            }
           
        }
        //private void packageDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        DataGridViewRow row = packageDataGridView.Rows[e.RowIndex];
        //        txtPackageId.Text = row.Cells[0].Value.ToString();
        //        txtPkgName.Text = row.Cells[1].Value.ToString();
        //        pkrPkgStartDate.Text = row.Cells[2].Value.ToString();
        //        pkrPkgEndDate.Text = row.Cells[3].Value.ToString();
        //        txtPkgDesc.Text = row.Cells[4].Value.ToString();
        //        txtPkgBasePrice.Text = row.Cells[5].Value.ToString();
        //        txtPkgAgencyCom.Text = row.Cells[6].Value.ToString();

        //        List<Bookings> bookingList = new List<Bookings>();

        //        int packageId = Convert.ToInt32(txtPackageId.Text);
        //        bookingList = PackageDB.DisplayBookingsInGrid(packageId);
        //        bookingsDataGridView.DataSource = bookingList;


        //    }
        //}
        private void packageDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (packageDataGridView.SelectedRows.Count > 0) //execute block code if rows exists in the grid
            {
                package = (Package)packageDataGridView.SelectedRows[0].DataBoundItem; //selectedrows[0] gets the row selected by user, 
                //typecast it in Package type & assign it to reference variable, now accesss properties of Package thru package variable
                //assigns values to controls of the from from corresponding Gridview.
                this.txtPackageId.Text = package.PackageId.ToString();
                txtPkgName.Text = package.PkgName;
                pkrPkgStartDate.Text = package.PkgStartDate.ToString();
                pkrPkgEndDate.Text = package.PkgEndDate.ToString();
                txtPkgBasePrice.Text = package.PkgBasePrice.ToString();
                if (package.PkgDesc == null)
                {
                    txtPkgDesc.Text = "";
                }
                else txtPkgDesc.Text = package.PkgDesc.ToString();


                if (package.PkgAgencyCommission == null)
                {
                    txtPkgAgencyCom.Text = "";
                }
                else
                    txtPkgAgencyCom.Text = package.PkgAgencyCommission.ToString();

                //popualting related product in product gridview

                List<Bookings> bookingList = new List<Bookings>();

                int packageId = Convert.ToInt32(txtPackageId.Text);
                bookingList = PackageDB.DisplayBookingsInGrid(packageId);
                bookingsDataGridView.DataSource = bookingList;
    
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == null)
            {
                packages = PackageDB.DisplayPackagesInGrid();
                packageDataGridView.DataSource = packages; //packages is the list to hold the list of packages
            }
            else
            {
                packages = PackageDB.SearchByText(txtSearch.Text);
                packageDataGridView.DataSource = packages;
            }

        }


        /// <summary>
        /// Add Package method adds the package into the package table, PackageID textbox  on the form is disabled as it's auto-incremented
        /// in the database table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPkg_Click_1(object sender, EventArgs e)
        {

            Package pkgObj = new Package();

         
            try
            {
                if (Validator.IsPresent(txtPkgName) && (Validator.IsPresent(txtPkgBasePrice)) && (Validator.isNonNegative(txtPkgBasePrice, "Base Price")))
                {

                    var pkg = packages.SingleOrDefault(pk => pk.PkgName.ToLower() == txtPkgName.Text.ToLower());
                    if (pkg == null)
                    {

                        if (pkrPkgStartDate.Checked == true && pkrPkgEndDate.Checked == true)
                        {
                           
                            if (pkrPkgEndDate.Value.Date.CompareTo(pkrPkgStartDate.Value.Date) <= 0)
                            {
                                MessageBox.Show("Start Date should be less than End Date", "Date Selection Error", MessageBoxButtons.OK);
                            }
                        
                        }
                      
                        else
                        {
                            this.PutPackageData(pkgObj);

                            PackageDB.PackageAdd(pkgObj);
                            MessageBox.Show("Package Added Successfully");
                            Refresh();
                            // packageDataGridView.DataSource = PackageDB.DisplayPackagesInGrid();
                            packages = PackageDB.DisplayPackagesInGrid();
                            packageDataGridView.DataSource = packages; //packages is the list to hold the list of packagesckages
                        }
                    }
                    else
                    {
                        MessageBox.Show("Package Id: " + pkg.PackageId + "\nPackage Name: " + pkg.PkgName + " already Exsits");
                        txtPkgName.Text = "";
                        txtPkgName.SelectAll();
                    }

                }
                else MessageBox.Show("Package Name & Base Price have to entered");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Update method updates the Packages table with the modified data from the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdatePkg_Click(object sender, EventArgs e)
        {
            Package newPackage = new Package();//Created new package object which is empty for now
            try
            {

                if (txtPackageId.Text != "")
                {
                    if (Validator.IsPresent(txtPkgName) && (Validator.IsPresent(txtPkgBasePrice)) && (Validator.isNonNegative(txtPkgBasePrice, "Base Price")))
                    {
                        if (pkrPkgStartDate.Checked == true && pkrPkgEndDate.Checked == true)
                        {

                            if (pkrPkgEndDate.Value.Date.CompareTo(pkrPkgStartDate.Value.Date) <= 0)
                            {
                                MessageBox.Show("Start Date should be less than End Date", "Date Selection Error", MessageBoxButtons.OK);
                            }
                            else
                            {
                                newPackage.PackageId = int.Parse(txtPackageId.Text); //populates the PackageID property of the object
                                PutPackageData(newPackage);  //  calls the putpackagedata() method to populate rest of the properties

                                bool success = PackageDB.PackageUpdate(package, newPackage);
                                if (success)
                                {
                                    MessageBox.Show("Package Updated Successfully");
                                    Refresh();

                                    packages = PackageDB.DisplayPackagesInGrid();
                                    packageDataGridView.DataSource = packages; //packages is the list to hold the list of packages

                                }
                            }
                        }
                    }
                }
                else MessageBox.Show("please select a record from the grid to update", "selection error");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.GetType().ToString() + ex.Message);
                MessageBox.Show("Can't update the record now as it is beeing accessed by someone else", "Update Error");
            }
        }


        /// <summary>
        /// Clicking on Row within the grid, populates the data in the controls places on the form from the Grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnDeletePkg_Click_1(object sender, EventArgs e)
        {
            Package pkgObj = new Package();
            
            try
            {
                if(txtPackageId.Text != "")
                {
                    pkgObj.PackageId = Convert.ToInt32(txtPackageId.Text);
                    PutPackageData(pkgObj);
                    var packageNames = PackageDB.CheckBeforeDelete();
                    if (packageNames.Count != 0)
                    {
                        MessageBox.Show("Can't Delete Package. Please delete dependent tables first");
                    }
                    else
                    {

                        bool success = PackageDB.PackageDelete(pkgObj);
                        if (success)
                        {
                            MessageBox.Show("Package deleted successfully");

                        }
                    }
                  
                    Refresh();
                 //   packageDataGridView.DataSource = PackageDB.DisplayPackagesInGrid();
                    packages = PackageDB.DisplayPackagesInGrid();
                    packageDataGridView.DataSource = packages; //packages is the list to hold the list of packages                   
                }
                else
                {
                    MessageBox.Show("Please select the recprd to delete from the grid","Select Error");
                }

            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.GetType().ToString() + ex.Message);
                MessageBox.Show("Can't delete the record now as it is beeing accessed by someone else", "Delete Error");
            }

        }

        /// <summary>
        /// CLears out all text boxes inputs 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearPkgFields_Click_1(object sender, EventArgs e)
        {
            
            Refresh();
        }

        private void Refresh()
        {
            txtPackageId.Text = "";
            txtPkgName.Text = "";
            txtPkgDesc.Text = "";
            txtPkgBasePrice.Text = "";
            txtPkgAgencyCom.Text = "";
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
            package.PkgBasePrice = double.Parse(txtPkgBasePrice.Text);


            if (pkrPkgStartDate.Checked == false && pkrPkgEndDate.Checked == true)
            {
                MessageBox.Show("Can't have End Date without Start Date");
            }
            else if (pkrPkgStartDate.Checked == true && pkrPkgEndDate.Checked == false)
            {
                package.PkgStartDate = DateTime.Parse(pkrPkgStartDate.Text);
                package.PkgEndDate = Convert.ToDateTime(null);
            }
            else if (pkrPkgStartDate.Checked == true && pkrPkgEndDate.Checked == true)
            {
                package.PkgStartDate = DateTime.Parse(pkrPkgStartDate.Text);
                package.PkgEndDate = DateTime.Parse(pkrPkgEndDate.Text);
            }
            else
            {
                package.PkgStartDate = null;
                package.PkgEndDate = null;
            }

            if (txtPkgDesc.Text == "")
            {
                package.PkgDesc = null;
            }
            else package.PkgDesc = txtPkgDesc.Text;


            if (txtPkgAgencyCom.Text == "")
            {
                package.PkgAgencyCommission = null;
            }
            else
                package.PkgAgencyCommission = Convert.ToDouble(txtPkgAgencyCom.Text);

        }

     

        //Event handler to make sure price fields can take only numbers from keyboard but can backspac
        //private void txtPkgBasePrice_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
        //    if (e.KeyChar == (char)13)
        //    {
        //        txtPkgBasePrice.Text = string.Format("{0:n0}", double.Parse(txtPkgBasePrice.Text));
        //    }
        //}

        //private void txtPkgAgencyCom_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if ((!char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)8 && e.KeyChar != (char)46))
        //        e.Handled = true;
        //    if (e.KeyChar == (char)13)
        //    {
        //        txtPkgBasePrice.Text = string.Format("{0:n0}", double.Parse(txtPkgBasePrice.Text));
        //    }
        //}


    }//class

} //namespace



