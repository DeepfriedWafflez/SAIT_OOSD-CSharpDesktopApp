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


/// <summary>
///         Purpose: To perform CRUD operation on packages offered by company and reflect that in the database
///        Author: Birju Nakrani - 773649
///        Date: March 25, 2019

/// </summary>


namespace ThreadedProjectTerm2
{
    public partial class frmPackages : Form
    {
        public frmMain activeFrmMain;
        List<Package> packages;
        Package package;

        List<Product> products;
        List<Supplier> suppliers;

        bool compare = true;



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


                int packageId = Convert.ToInt32(txtPackageId.Text);

                //populating related products in product list view
                 products = PackageDB.DisplayProductsInList(packageId);
                lstProductsonPackagefrm.DataSource = products;

                //populating related suppliers in product list view
                suppliers = PackageDB.DisplaySuppliersInList(packageId);
                lstSuppliersonPackagefrm.DataSource = suppliers;


                //popualting related bookings in booking gridview

                List<Bookings> bookingList = new List<Bookings>();
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
                if (Validator.IsPresent(txtPkgName) && (Validator.IsPresent(txtPkgBasePrice) && (Validator.isNonNegative(txtPkgBasePrice, "Base Price"))))
                {

                    var pkg = packages.SingleOrDefault(pk => pk.PkgName.ToLower() == txtPkgName.Text.ToLower()); //checks if same package name already exists in database. returns null if no duplicate found else returns >0
                    if (pkg == null)
                    {

                        if (pkrPkgStartDate.Checked == true && pkrPkgEndDate.Checked == true)
                        {

                            if (pkrPkgEndDate.Value.Date.CompareTo(pkrPkgStartDate.Value.Date) <= 0)
                            {
                                MessageBox.Show("Start Date should be less than End Date", "Date Selection Error", MessageBoxButtons.OK);
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
                                PutPackageData(newPackage);  //  calls the putpackagedata() method to populate rest of the properties
                                newPackage.PackageId = int.Parse(txtPackageId.Text); //populates the PackageID property of the object

                                bool success = PackageDB.PackageUpdate(package, newPackage);
                                if (success)
                                {
                                    MessageBox.Show("Package Updated Successfully", "Package Update");
                                    Refresh();

                                    packages = PackageDB.DisplayPackagesInGrid();
                                    packageDataGridView.DataSource = packages; //packages is the list to hold the list of packages

                                }
                            }
                            
                        }
                    
                      else
                        {
                            
                            PutPackageData(newPackage);  //  calls the putpackagedata() method to populate rest of the properties
                            newPackage.PackageId = int.Parse(txtPackageId.Text); //populates the PackageID property of the object

                            bool success = PackageDB.PackageUpdate(package, newPackage);
                            if (success)
                            {
                                MessageBox.Show("Package Updated Successfully","Package Update");
                                Refresh();

                                packages = PackageDB.DisplayPackagesInGrid();
                                packageDataGridView.DataSource = packages; //packages is the list to hold the list of packages

                            }

                        }
                 
                    }else
                    {
                        MessageBox.Show("Package Name & Base Price have to entered");
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
                    var packageCount = PackageDB.CheckBeforeDelete(pkgObj.PackageId);
                    if (packageCount > 0)
                    {
                        MessageBox.Show("Can't Delete Package. Please delete dependent tables first");
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to delete this item from database?\n" +
                                    "Delete action cannot be undone.", "Confirm deletion", MessageBoxButtons.OKCancel);

                        if (result.ToString() == "OK")
                        {
                            bool success = PackageDB.PackageDelete(pkgObj);
                            if (success)
                            {

                                MessageBox.Show("Package has been Deleted");
                            }
                        }
                    }       
                        
                   
                  
                    Refresh();
               
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
            if (txtPkgAgencyCom.Text == "")
            {
                package.PkgAgencyCommission = null;

            }
            else if (Convert.ToDouble(txtPkgAgencyCom.Text) > Convert.ToDouble(txtPkgBasePrice.Text))
            {
                MessageBox.Show("Agency Commission Can't be more than Package Price");
                compare = false;

            }
            else package.PkgAgencyCommission = Convert.ToDouble(txtPkgAgencyCom.Text);

            package.PkgName = txtPkgName.Text;
            package.PkgBasePrice = double.Parse(txtPkgBasePrice.Text);

            //Checking for all conditions before inputting Date into database as Dates are nullable

            if (pkrPkgStartDate.Checked == true && pkrPkgEndDate.Checked == false)
            {
                package.PkgStartDate = DateTime.Parse(pkrPkgStartDate.Text);
                package.PkgEndDate = null;
            }
            else if (pkrPkgStartDate.Checked == true && pkrPkgEndDate.Checked == true)
            {
                package.PkgStartDate = DateTime.Parse(pkrPkgStartDate.Text);
                package.PkgEndDate = DateTime.Parse(pkrPkgEndDate.Text);
            }
            else if (pkrPkgStartDate.Checked == false && pkrPkgEndDate.Checked == true)
            {
                package.PkgStartDate = null;
                package.PkgEndDate = DateTime.Parse(pkrPkgEndDate.Text);
            }
             else 
            {
                package.PkgStartDate = null;
                package.PkgEndDate = null;
            }

            //Checking for  conditions before inputting Description into database as Description is nullable

            if (txtPkgDesc.Text == "")
            {
                package.PkgDesc = null;
            }
            else package.PkgDesc = txtPkgDesc.Text;

           // Checking for  conditions before inputting Agency Commission into database as Commission is nullable

            
        }

      
    }//class

} //namespace



