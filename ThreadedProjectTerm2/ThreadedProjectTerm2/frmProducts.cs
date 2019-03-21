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
            supplierList = SuppliersDB.GetSuppliers();

            // foreach (Supplier s in supplierList)
            // Console.WriteLine(s.SupName);

            //LoadProduct();
        }

        private void LoadProduct()
        {
            listBox1.Items.Clear();
            Console.WriteLine(lstProducts.SelectedValue.ToString());
            currentProduct = ProductDB.getProductById(Convert.ToInt32(lstProducts.SelectedValue));
            productSupplierList = ProductSupplierDB.GetProductSuppliersByProductID(currentProduct.ProductId);
            grpProdSupplier.Text = "Suppliers providing product: " + currentProduct.ProdName;
            Console.WriteLine(productSupplierList.Count.ToString());
            Console.WriteLine(currentProduct.ToString());
            var prodSuppliersNames = from productSupplierItem in productSupplierList
                                     join supplierItem in supplierList
                                     on productSupplierItem.SupplierId equals supplierItem.SupID
                                     orderby supplierItem.SupName
                                     select new { productSupplierItem.ProductSupplierId, supplierItem.SupName };

            //Console.WriteLine(prodSuppliersNames.ToString());



            foreach (var item in prodSuppliersNames)
            {
                listBox1.Items.Add(item.SupName);
            }
        }
        

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
           // productsList = ProductDB.GetProducts();
            //lstProducts.DataSource = productsList;

            supplierList = SuppliersDB.GetSuppliers();

            LoadProduct();
        }


    }
}
