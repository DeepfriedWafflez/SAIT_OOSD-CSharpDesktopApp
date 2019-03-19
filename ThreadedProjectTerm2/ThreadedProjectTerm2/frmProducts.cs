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
        List<Product> productsList;
        List<Supplier> supplierList;
        List<ProductSupplier> productSupplierList;  //list of productSupplier items for a given product
        Product currentProduct;

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
            productsList = ProductDB.GetProducts();
            lstProducts.DataSource = productsList;

            //set form to first item in product list
            //supplierList = SuppliersDB.GetSuppliers();
            currentProduct = ProductDB.getProductById(1);
            //productSupplierList = ProductSupplierDB.GetProductSuppliersByProductID(1);

            //lstSuppliers.DataSource = productSupplierList;

        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
