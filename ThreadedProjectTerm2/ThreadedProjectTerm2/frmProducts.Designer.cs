namespace ThreadedProjectTerm2
{
    partial class frmProducts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productSupplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpProdSupplier = new System.Windows.Forms.GroupBox();
            this.lvProdSuppliers = new System.Windows.Forms.ListView();
            this.PSId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.supName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnProdSupplierDelete = new System.Windows.Forms.Button();
            this.btnProdSupplierAdd = new System.Windows.Forms.Button();
            this.grpProdSupplierAdd = new System.Windows.Forms.GroupBox();
            this.btnProdSupplierCancel = new System.Windows.Forms.Button();
            this.cboProductSupplierAdd = new System.Windows.Forms.ComboBox();
            this.btnProdSupplierSave = new System.Windows.Forms.Button();
            this.grpProductButtons = new System.Windows.Forms.GroupBox();
            this.lstProducts = new System.Windows.Forms.ListBox();
            this.btnProductShowAddNew = new System.Windows.Forms.Button();
            this.btnProductShowEdit = new System.Windows.Forms.Button();
            this.btnProductDelete = new System.Windows.Forms.Button();
            this.grpProductAddEdit = new System.Windows.Forms.GroupBox();
            this.btnProductAdd = new System.Windows.Forms.Button();
            this.btnProductCancel = new System.Windows.Forms.Button();
            this.btnProductSave = new System.Windows.Forms.Button();
            this.txtProdAddEdit = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSupplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.grpProdSupplier.SuspendLayout();
            this.grpProdSupplierAdd.SuspendLayout();
            this.grpProductButtons.SuspendLayout();
            this.grpProductAddEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // productSupplierBindingSource
            // 
            this.productSupplierBindingSource.DataSource = typeof(TravelExpertsClasses.ProductSupplier);
            // 
            // productBindingSource1
            // 
            this.productBindingSource1.DataSource = typeof(TravelExpertsClasses.Product);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.grpProdSupplier);
            this.panel1.Controls.Add(this.grpProdSupplierAdd);
            this.panel1.Controls.Add(this.grpProductButtons);
            this.panel1.Controls.Add(this.grpProductAddEdit);
            this.panel1.Location = new System.Drawing.Point(12, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 408);
            this.panel1.TabIndex = 0;
            // 
            // grpProdSupplier
            // 
            this.grpProdSupplier.Controls.Add(this.lvProdSuppliers);
            this.grpProdSupplier.Controls.Add(this.btnProdSupplierDelete);
            this.grpProdSupplier.Controls.Add(this.btnProdSupplierAdd);
            this.grpProdSupplier.Location = new System.Drawing.Point(280, 25);
            this.grpProdSupplier.Margin = new System.Windows.Forms.Padding(2);
            this.grpProdSupplier.Name = "grpProdSupplier";
            this.grpProdSupplier.Padding = new System.Windows.Forms.Padding(2);
            this.grpProdSupplier.Size = new System.Drawing.Size(358, 293);
            this.grpProdSupplier.TabIndex = 15;
            this.grpProdSupplier.TabStop = false;
            this.grpProdSupplier.Text = "Suppliers for product [insert product name]";
            this.grpProdSupplier.Enter += new System.EventHandler(this.grpProdSupplier_Enter);
            // 
            // lvProdSuppliers
            // 
            this.lvProdSuppliers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PSId,
            this.supName});
            this.lvProdSuppliers.FullRowSelect = true;
            this.lvProdSuppliers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvProdSuppliers.Location = new System.Drawing.Point(12, 60);
            this.lvProdSuppliers.Margin = new System.Windows.Forms.Padding(2);
            this.lvProdSuppliers.MultiSelect = false;
            this.lvProdSuppliers.Name = "lvProdSuppliers";
            this.lvProdSuppliers.Size = new System.Drawing.Size(329, 215);
            this.lvProdSuppliers.TabIndex = 7;
            this.lvProdSuppliers.UseCompatibleStateImageBehavior = false;
            this.lvProdSuppliers.View = System.Windows.Forms.View.Details;
            // 
            // PSId
            // 
            this.PSId.Text = "PSid";
            this.PSId.Width = 0;
            // 
            // supName
            // 
            this.supName.Text = "Supplier Name";
            this.supName.Width = 300;
            // 
            // btnProdSupplierDelete
            // 
            this.btnProdSupplierDelete.Location = new System.Drawing.Point(12, 25);
            this.btnProdSupplierDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnProdSupplierDelete.Name = "btnProdSupplierDelete";
            this.btnProdSupplierDelete.Size = new System.Drawing.Size(162, 23);
            this.btnProdSupplierDelete.TabIndex = 6;
            this.btnProdSupplierDelete.Text = "Remove supplier from product";
            this.btnProdSupplierDelete.UseVisualStyleBackColor = true;
            // 
            // btnProdSupplierAdd
            // 
            this.btnProdSupplierAdd.Location = new System.Drawing.Point(178, 25);
            this.btnProdSupplierAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnProdSupplierAdd.Name = "btnProdSupplierAdd";
            this.btnProdSupplierAdd.Size = new System.Drawing.Size(162, 23);
            this.btnProdSupplierAdd.TabIndex = 5;
            this.btnProdSupplierAdd.Text = "Add supplier for this product";
            this.btnProdSupplierAdd.UseVisualStyleBackColor = true;
            // 
            // grpProdSupplierAdd
            // 
            this.grpProdSupplierAdd.Controls.Add(this.btnProdSupplierCancel);
            this.grpProdSupplierAdd.Controls.Add(this.cboProductSupplierAdd);
            this.grpProdSupplierAdd.Controls.Add(this.btnProdSupplierSave);
            this.grpProdSupplierAdd.Location = new System.Drawing.Point(280, 331);
            this.grpProdSupplierAdd.Margin = new System.Windows.Forms.Padding(2);
            this.grpProdSupplierAdd.Name = "grpProdSupplierAdd";
            this.grpProdSupplierAdd.Padding = new System.Windows.Forms.Padding(2);
            this.grpProdSupplierAdd.Size = new System.Drawing.Size(358, 83);
            this.grpProdSupplierAdd.TabIndex = 13;
            this.grpProdSupplierAdd.TabStop = false;
            this.grpProdSupplierAdd.Text = "Add Supplier to Product";
            this.grpProdSupplierAdd.Visible = false;
            this.grpProdSupplierAdd.Enter += new System.EventHandler(this.grpProdSupplierAdd_Enter);
            // 
            // btnProdSupplierCancel
            // 
            this.btnProdSupplierCancel.Location = new System.Drawing.Point(70, 52);
            this.btnProdSupplierCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnProdSupplierCancel.Name = "btnProdSupplierCancel";
            this.btnProdSupplierCancel.Size = new System.Drawing.Size(50, 21);
            this.btnProdSupplierCancel.TabIndex = 4;
            this.btnProdSupplierCancel.Text = "Cancel";
            this.btnProdSupplierCancel.UseVisualStyleBackColor = true;
            // 
            // cboProductSupplierAdd
            // 
            this.cboProductSupplierAdd.DataSource = this.supplierBindingSource;
            this.cboProductSupplierAdd.DisplayMember = "SupName";
            this.cboProductSupplierAdd.FormattingEnabled = true;
            this.cboProductSupplierAdd.Location = new System.Drawing.Point(16, 27);
            this.cboProductSupplierAdd.Margin = new System.Windows.Forms.Padding(2);
            this.cboProductSupplierAdd.Name = "cboProductSupplierAdd";
            this.cboProductSupplierAdd.Size = new System.Drawing.Size(325, 21);
            this.cboProductSupplierAdd.TabIndex = 0;
            this.cboProductSupplierAdd.ValueMember = "SupID";
            // 
            // btnProdSupplierSave
            // 
            this.btnProdSupplierSave.Location = new System.Drawing.Point(16, 52);
            this.btnProdSupplierSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnProdSupplierSave.Name = "btnProdSupplierSave";
            this.btnProdSupplierSave.Size = new System.Drawing.Size(50, 21);
            this.btnProdSupplierSave.TabIndex = 3;
            this.btnProdSupplierSave.Text = "Add";
            this.btnProdSupplierSave.UseVisualStyleBackColor = true;
            // 
            // grpProductButtons
            // 
            this.grpProductButtons.Controls.Add(this.lstProducts);
            this.grpProductButtons.Controls.Add(this.btnProductShowAddNew);
            this.grpProductButtons.Controls.Add(this.btnProductShowEdit);
            this.grpProductButtons.Controls.Add(this.btnProductDelete);
            this.grpProductButtons.Location = new System.Drawing.Point(26, 25);
            this.grpProductButtons.Margin = new System.Windows.Forms.Padding(2);
            this.grpProductButtons.Name = "grpProductButtons";
            this.grpProductButtons.Padding = new System.Windows.Forms.Padding(2);
            this.grpProductButtons.Size = new System.Drawing.Size(235, 294);
            this.grpProductButtons.TabIndex = 14;
            this.grpProductButtons.TabStop = false;
            this.grpProductButtons.Text = "Product List";
            this.grpProductButtons.Enter += new System.EventHandler(this.grpProductButtons_Enter);
            // 
            // lstProducts
            // 
            this.lstProducts.DataSource = this.productBindingSource1;
            this.lstProducts.DisplayMember = "ProdName";
            this.lstProducts.FormattingEnabled = true;
            this.lstProducts.Location = new System.Drawing.Point(12, 55);
            this.lstProducts.Margin = new System.Windows.Forms.Padding(2);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(205, 225);
            this.lstProducts.TabIndex = 11;
            this.lstProducts.ValueMember = "ProductId";
            // 
            // btnProductShowAddNew
            // 
            this.btnProductShowAddNew.Location = new System.Drawing.Point(12, 18);
            this.btnProductShowAddNew.Margin = new System.Windows.Forms.Padding(2);
            this.btnProductShowAddNew.Name = "btnProductShowAddNew";
            this.btnProductShowAddNew.Size = new System.Drawing.Size(63, 21);
            this.btnProductShowAddNew.TabIndex = 5;
            this.btnProductShowAddNew.Text = "Add new";
            this.btnProductShowAddNew.UseVisualStyleBackColor = true;
            // 
            // btnProductShowEdit
            // 
            this.btnProductShowEdit.Location = new System.Drawing.Point(79, 18);
            this.btnProductShowEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnProductShowEdit.Name = "btnProductShowEdit";
            this.btnProductShowEdit.Size = new System.Drawing.Size(63, 21);
            this.btnProductShowEdit.TabIndex = 3;
            this.btnProductShowEdit.Text = "Edit";
            this.btnProductShowEdit.UseVisualStyleBackColor = true;
            // 
            // btnProductDelete
            // 
            this.btnProductDelete.Location = new System.Drawing.Point(149, 18);
            this.btnProductDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnProductDelete.Name = "btnProductDelete";
            this.btnProductDelete.Size = new System.Drawing.Size(63, 21);
            this.btnProductDelete.TabIndex = 6;
            this.btnProductDelete.Text = "Delete";
            this.btnProductDelete.UseVisualStyleBackColor = true;
            // 
            // grpProductAddEdit
            // 
            this.grpProductAddEdit.Controls.Add(this.btnProductAdd);
            this.grpProductAddEdit.Controls.Add(this.btnProductCancel);
            this.grpProductAddEdit.Controls.Add(this.btnProductSave);
            this.grpProductAddEdit.Controls.Add(this.txtProdAddEdit);
            this.grpProductAddEdit.Location = new System.Drawing.Point(21, 331);
            this.grpProductAddEdit.Margin = new System.Windows.Forms.Padding(2);
            this.grpProductAddEdit.Name = "grpProductAddEdit";
            this.grpProductAddEdit.Padding = new System.Windows.Forms.Padding(2);
            this.grpProductAddEdit.Size = new System.Drawing.Size(239, 83);
            this.grpProductAddEdit.TabIndex = 12;
            this.grpProductAddEdit.TabStop = false;
            this.grpProductAddEdit.Text = "Add/Edit Product";
            this.grpProductAddEdit.Visible = false;
            this.grpProductAddEdit.Enter += new System.EventHandler(this.grpProductAddEdit_Enter);
            // 
            // btnProductAdd
            // 
            this.btnProductAdd.Location = new System.Drawing.Point(25, 52);
            this.btnProductAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnProductAdd.Name = "btnProductAdd";
            this.btnProductAdd.Size = new System.Drawing.Size(50, 21);
            this.btnProductAdd.TabIndex = 3;
            this.btnProductAdd.Text = "Add";
            this.btnProductAdd.UseVisualStyleBackColor = true;
            // 
            // btnProductCancel
            // 
            this.btnProductCancel.Location = new System.Drawing.Point(79, 52);
            this.btnProductCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnProductCancel.Name = "btnProductCancel";
            this.btnProductCancel.Size = new System.Drawing.Size(50, 21);
            this.btnProductCancel.TabIndex = 2;
            this.btnProductCancel.Text = "Cancel";
            this.btnProductCancel.UseVisualStyleBackColor = true;
            // 
            // btnProductSave
            // 
            this.btnProductSave.Location = new System.Drawing.Point(17, 52);
            this.btnProductSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnProductSave.Name = "btnProductSave";
            this.btnProductSave.Size = new System.Drawing.Size(50, 21);
            this.btnProductSave.TabIndex = 1;
            this.btnProductSave.Text = "Save";
            this.btnProductSave.UseVisualStyleBackColor = true;
            // 
            // txtProdAddEdit
            // 
            this.txtProdAddEdit.Location = new System.Drawing.Point(17, 26);
            this.txtProdAddEdit.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdAddEdit.Name = "txtProdAddEdit";
            this.txtProdAddEdit.Size = new System.Drawing.Size(205, 20);
            this.txtProdAddEdit.TabIndex = 0;
            // 
            // frmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 439);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmProducts";
            this.Text = "Products";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProducts_FormClosed);
            this.Load += new System.EventHandler(this.frmProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSupplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.grpProdSupplier.ResumeLayout(false);
            this.grpProdSupplierAdd.ResumeLayout(false);
            this.grpProductButtons.ResumeLayout(false);
            this.grpProductAddEdit.ResumeLayout(false);
            this.grpProductAddEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.BindingSource productSupplierBindingSource;
        private System.Windows.Forms.BindingSource productBindingSource1;
        private System.Windows.Forms.BindingSource supplierBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpProdSupplier;
        private System.Windows.Forms.ListView lvProdSuppliers;
        private System.Windows.Forms.ColumnHeader PSId;
        private System.Windows.Forms.ColumnHeader supName;
        private System.Windows.Forms.Button btnProdSupplierDelete;
        private System.Windows.Forms.Button btnProdSupplierAdd;
        private System.Windows.Forms.GroupBox grpProdSupplierAdd;
        private System.Windows.Forms.Button btnProdSupplierCancel;
        private System.Windows.Forms.ComboBox cboProductSupplierAdd;
        private System.Windows.Forms.Button btnProdSupplierSave;
        private System.Windows.Forms.GroupBox grpProductButtons;
        private System.Windows.Forms.ListBox lstProducts;
        private System.Windows.Forms.Button btnProductShowAddNew;
        private System.Windows.Forms.Button btnProductShowEdit;
        private System.Windows.Forms.Button btnProductDelete;
        private System.Windows.Forms.GroupBox grpProductAddEdit;
        private System.Windows.Forms.Button btnProductAdd;
        private System.Windows.Forms.Button btnProductCancel;
        private System.Windows.Forms.Button btnProductSave;
        private System.Windows.Forms.TextBox txtProdAddEdit;
    }
}