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
    public partial class frmProducts : Form
    {
        public frmMain activeFrmMain;  
        List<Product> productsList;    //list of all products
        List<Supplier> supplierList;  //list of all suppliers
        List<ProductSupplier> productSupplierList;  //list of productSupplier items for a given product
        Product currentProduct;        //current product being modified

        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this == activeFrmMain.activeFrmProducts)
                activeFrmMain.activeFrmPackages = null;
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadProductSuppliers(currentProduct.ProductId);
            SetUpFrmControls();
        }

        /**********************************************************
         * 
         *                      Form set-up methods
         * 
         * 
         * ********************************************************/


        private void LoadProducts(int selectedProductId = -1)
        {

            //get the product and supplier lists from database
            productsList = ProductDB.GetProducts();
            supplierList = SuppliersDB.GetSuppliers();
            
            //populate product list box
            lstProducts.DataSource = productsList;
            
            //no currentProduct object exists, create one by selecting first item in the lstProducts
            if (selectedProductId == -1)  
            {
                lstProducts.SelectedIndex = 0;
                currentProduct = ProductDB.getProductById(Convert.ToInt32(lstProducts.SelectedValue));
            }
        }

        private void LoadProductSuppliers (int prodId)
        {
            lvProdSuppliers.Items.Clear();

            productSupplierList = ProductSupplierDB.GetProductSuppliersByProductID(prodId);
            grpProdSupplier.Text = "Suppliers providing product: " + currentProduct.ProdName;
            
            var prodSuppliersNames = from productSupplierItem in productSupplierList
                                     join supplierItem in supplierList
                                     on productSupplierItem.SupplierId equals supplierItem.SupID
                                     orderby supplierItem.SupName
                                     select new { productSupplierItem.ProductSupplierId, supplierItem.SupName };


            if (prodSuppliersNames != null)
            { 
                int i = 0;
                foreach (var item in prodSuppliersNames)
                {
                    lvProdSuppliers.Items.Add(item.ProductSupplierId.ToString());
                    lvProdSuppliers.Items[i].SubItems.Add(item.SupName);
                    i++;
                }

            }
        }

        private void SetUpFrmControls()
        {

            grpProductAddEdit.Visible = false;
            grpProdSupplierAdd.Visible = false;
            grpProductButtons.Enabled = true;
            grpProdSupplier.Enabled = true;
            txtProdAddEdit.Text = "";

        }

        /***************************************************************
         * 
         *          Product Controls Event Methods
         * 
         * 
         * *************************************************************/


        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            grpProductAddEdit.Visible = true;
            grpProductButtons.Enabled = false;
            grpProdSupplier.Enabled = false;
            btnProductAdd.Visible = true;
            btnProductSave.Visible = false;
            txtProdAddEdit.SelectAll();
            txtProdAddEdit.Focus();

        }

        private void btnProductCancel_Click(object sender, EventArgs e)
        {
            grpProductAddEdit.Visible = false;
            txtProdAddEdit.Text = "";
            grpProductButtons.Enabled = true;
            grpProdSupplier.Enabled = true;

        }

        private void lstProducts_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            currentProduct = ProductDB.getProductById(Convert.ToInt32(lstProducts.SelectedValue));
            supplierList = SuppliersDB.GetSuppliers();
            //concurrency issue occurs if product is deleted from DB
            LoadProductSuppliers(currentProduct.ProductId);

        }

        private void btnProductEdit_Click(object sender, EventArgs e)
        {
            grpProductAddEdit.Visible = true;
            grpProductButtons.Enabled = false;
            grpProdSupplier.Enabled = false;
            btnProductAdd.Visible = false;
            btnProductSave.Visible = true;
            txtProdAddEdit.Text = currentProduct.ProdName;
            txtProdAddEdit.SelectAll();
            txtProdAddEdit.Focus();
        }

        //save change (update) to Product in database
        private void btnProductSave_Click(object sender, EventArgs e)
        {

            if (Validator.IsPresent(txtProdAddEdit)) 
            { 
                Product newProduct = new Product();
                newProduct = currentProduct;
                newProduct.ProdName = txtProdAddEdit.Text;

                if(ProductDB.UpdateProduct(currentProduct, newProduct))
                {
                    //refresh form
                    int tempId = currentProduct.ProductId;
                    LoadProducts();
                    SetUpFrmControls();
                    MessageBox.Show(lstProducts.SelectedValue.ToString());
                    lstProducts.SelectedValue = tempId;
                    currentProduct = ProductDB.getProductById(tempId);
                }
                else
                { 
                    MessageBox.Show("An error occurred updating the database.  Please try again.");
                }
            }
        }

        //add new product to database
        private void btnProductAdd_Click_1(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtProdAddEdit))
            {
                Product newProduct = new Product();
                newProduct = currentProduct;
                newProduct.ProdName = txtProdAddEdit.Text;
                int newId = -1;
                newId = ProductDB.AddProduct(newProduct);
                MessageBox.Show(newId.ToString());
                if (newId != -1)
                {
                    //refresh form
                    LoadProducts();
                    SetUpFrmControls();
                    lstProducts.SelectedValue = newId;
                    currentProduct = ProductDB.getProductById(newId);
                }
                else
                {
                    MessageBox.Show("An error occurred updating the database.  Please try again.");
                }
            }
        }

        //delete product from database, or if product has related product-suppliers, 
        //prompt user to delete product-supplier items
        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            //check that an item is selected in the products list box
            if(lstProducts.SelectedValue != null)
            {
                //check for product-supplier items, if not zero, prompt user to delete these first
                if (productSupplierList.Count == 0)
                {
                    //get user confirmation 
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this item from database?\n" +
                                     "Delete action cannot be undone.","Confirm deletion", MessageBoxButtons.OKCancel);
 
                    if (result.ToString() == "OK")
                    {
                        if (!ProductDB.DeleteProduct(currentProduct))
                            MessageBox.Show("Product has already been deleted from the database.");
                        //reload the form and set currentProduct to first item in the product list
                        LoadProducts();
                        SetUpFrmControls();
                    }
                }
                else
                {
                    MessageBox.Show("This product has product-supplier items in the database.\n" +
                                    "Product-suppplier items must be deleted separately before\n" +
                                    "a product can be deleted from the database.", 
                                    "Delete action cancelled",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
            }
        }

        /*************************************************************** 
         *     
         *                  Product Supplier Control Events
         * 
         * 
         **************************************************************/

        private void lvProdSuppliers_Click(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection psSelectedItems =
                this.lvProdSuppliers.SelectedItems;

            foreach (ListViewItem item in psSelectedItems)
            {
                MessageBox.Show(item.SubItems[0].Text + " :: " + item.SubItems[1].Text);
            }

        }

        //display group box to add new product supplier
        private void btnProdSupplierAdd_Click(object sender, EventArgs e)
        {
            grpProdSupplierAdd.Visible = true;
            grpProdSupplier.Enabled = false;
            grpProductButtons.Enabled = false;


            var suppliersWithoutProductList = supplierList.Where(item => !productSupplierList.Any(item2 => item2.SupplierId == item.SupID));

            //query the supplier list to order by supplier name
            var suppliersWithoutProductListOrdered = (from supItems in suppliersWithoutProductList
                                                     orderby supItems.SupName
                                                     select supItems).ToArray();

            cboProductSupplierAdd.DataSource = suppliersWithoutProductListOrdered;

        }


        //cancel action to add new product supplier and hide group box
        private void btnProdSupplierCancel_Click(object sender, EventArgs e)
        {
            grpProdSupplierAdd.Visible = false;
            grpProdSupplier.Enabled = true;
            grpProductButtons.Enabled = true;
        }

        //save new product-supplier into database
        private void btnProdSupplierSave_Click(object sender, EventArgs e)
        {


            if (cboProductSupplierAdd.SelectedValue != null)
            {
                ProductSupplier ps = new ProductSupplier
                {
                    ProductId = currentProduct.ProductId,
                    SupplierId = Convert.ToInt32(cboProductSupplierAdd.SelectedValue)
                };

                int addedProdSupplierId = ProductSupplierDB.AddProductSupplier(ps);

                if (addedProdSupplierId != 0)
                {
                    //refresh suppliers part of form
                    SetUpFrmControls();
                    LoadProductSuppliers(currentProduct.ProductId);
                }
                else
                {
                    MessageBox.Show("A problem occured adding this item to the database.  Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please select a supplier from the drop-down list to add.", "Data entry error");
            }
        }

        //delete product supplier item from database
        private void btnProdSupplierDelete_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection psSelectedItems =
                    this.lvProdSuppliers.SelectedItems;

            //confirm that only one item is selected
            if (psSelectedItems.Count != 0)
            {
                //get selected product-supplier id
  
                int selectedProductSupplier = Convert.ToInt32(psSelectedItems[0].SubItems[0].Text);

                ProductSupplier ps = ProductSupplierDB.getProductSupplierById(selectedProductSupplier);

                if (ps != null)  //Product-Supplier exists
                {

                    // !!!!!!!!! TO BE ADDED - CHECK FOR PACKAGES ASSOCIATED WITH Product-Supplier item
                    // To be added once Birju has committed classes for Packages-Products-Suppliers

                    if (ProductSupplierDB.DeleteProductSupplier(ps))
                    {
                        MessageBox.Show("Supplier removed from this product.");
                    }
                    else
                    {
                        MessageBox.Show("A problem occurred with removing this supplier.");
                    }
                } 
                else
                {
                    //ProductSupplier item does not exist in database - concurrency issue
                    MessageBox.Show("Supplier has already been removed from this product");

                }

                LoadProductSuppliers(currentProduct.ProductId);
                SetUpFrmControls();
            }
            else
            {
                MessageBox.Show("Please select a supplier to delete.");
            }
        }
    }


}
