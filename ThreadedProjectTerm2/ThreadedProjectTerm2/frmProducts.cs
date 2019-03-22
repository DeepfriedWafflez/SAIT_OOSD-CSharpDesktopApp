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

        }

        private void LoadProduct()
        {
            lvProdSuppliers.Items.Clear();

            //Console.WriteLine(lstProducts.SelectedValue.ToString());

            currentProduct = ProductDB.getProductById(Convert.ToInt32(lstProducts.SelectedValue));
            productSupplierList = ProductSupplierDB.GetProductSuppliersByProductID(currentProduct.ProductId);
            grpProdSupplier.Text = "Suppliers providing product: " + currentProduct.ProdName;
            
            var prodSuppliersNames = from productSupplierItem in productSupplierList
                                     join supplierItem in supplierList
                                     on productSupplierItem.SupplierId equals supplierItem.SupID
                                     orderby supplierItem.SupName
                                     select new { productSupplierItem.ProductSupplierId, supplierItem.SupName };

            //Console.WriteLine(prodSuppliersNames.ToString());


            int i = 0;
            foreach (var item in prodSuppliersNames)
            {
                lvProdSuppliers.Items.Add(item.ProductSupplierId.ToString());
                lvProdSuppliers.Items[i].SubItems.Add(item.SupName);
                i++;
            }

            lvProdSuppliers.Items[0].Focused = true;
            lvProdSuppliers.Items[0].Selected = true;

        }


        private void lvProdSuppliers_Click(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection psSelectedItems =
                this.lvProdSuppliers.SelectedItems;


            foreach (ListViewItem item in psSelectedItems)
            {
                MessageBox.Show(item.SubItems[0].Text + " :: " + item.SubItems[1].Text);
            }

        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            grpProductAddEdit.Visible = true;
            grpProductButtons.Enabled = false;
            btnProductAdd.Visible = true;
            btnProductSave.Visible = false;

        }

        private void btnProductCancel_Click(object sender, EventArgs e)
        {
            grpProductAddEdit.Visible = false;
            txtProdEdit.Text = "";
            grpProductButtons.Enabled = true;
            grpProdSupplier.Enabled = true;

        }

        private void lstProducts_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            supplierList = SuppliersDB.GetSuppliers();

            LoadProduct();

        }

        private void btnProductEdit_Click(object sender, EventArgs e)
        {
            grpProductAddEdit.Visible = true;
            grpProductButtons.Enabled = false;
            grpProdSupplier.Enabled = false;
            btnProductAdd.Visible = false;
            btnProductSave.Visible = true;
            txtProdEdit.Text = currentProduct.ProdName;
        }

        private void btnProdSupplierAdd_Click(object sender, EventArgs e)
        {
            grpProdSupplierAdd.Visible = true;
            grpProdSupplier.Enabled = false;
            grpProductButtons.Enabled = false;
        }

        private void btnProdSupplierCancel_Click(object sender, EventArgs e)
        {
            grpProdSupplierAdd.Visible = false;
            grpProdSupplier.Enabled = true;
            grpProductButtons.Enabled = true;
        }

        private void btnProductSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save function not added yet");
        }

        private void btnProdSupplierSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save function not added yet");
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete function not added yet");
        }

        private void btnProdSupplierDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save function not added yet");
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save function not added yet");
        }
    }


}
