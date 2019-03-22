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
            this.btnProductEdit = new System.Windows.Forms.Button();
            this.btnProductAddNew = new System.Windows.Forms.Button();
            this.btnProductDelete = new System.Windows.Forms.Button();
            this.grpProductAddEdit = new System.Windows.Forms.GroupBox();
            this.txtProdEdit = new System.Windows.Forms.TextBox();
            this.btnProductSave = new System.Windows.Forms.Button();
            this.btnProductCancel = new System.Windows.Forms.Button();
            this.grpProductButtons = new System.Windows.Forms.GroupBox();
            this.lstProducts = new System.Windows.Forms.ListBox();
            this.productBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.grpProdSupplier = new System.Windows.Forms.GroupBox();
            this.lvProdSuppliers = new System.Windows.Forms.ListView();
            this.PSId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.supName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpProdSupplierAdd = new System.Windows.Forms.GroupBox();
            this.btnProdSupplierCancel = new System.Windows.Forms.Button();
            this.cboProductSupplierAdd = new System.Windows.Forms.ComboBox();
            this.btnProdSupplierSave = new System.Windows.Forms.Button();
            this.btnProdSupplierDelete = new System.Windows.Forms.Button();
            this.btnProdSupplierAdd = new System.Windows.Forms.Button();
            this.btnProductAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSupplierBindingSource)).BeginInit();
            this.grpProductAddEdit.SuspendLayout();
            this.grpProductButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).BeginInit();
            this.grpProdSupplier.SuspendLayout();
            this.grpProdSupplierAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // productSupplierBindingSource
            // 
            this.productSupplierBindingSource.DataSource = typeof(TravelExpertsClasses.ProductSupplier);
            // 
            // btnProductEdit
            // 
            this.btnProductEdit.Location = new System.Drawing.Point(118, 28);
            this.btnProductEdit.Name = "btnProductEdit";
            this.btnProductEdit.Size = new System.Drawing.Size(94, 32);
            this.btnProductEdit.TabIndex = 3;
            this.btnProductEdit.Text = "Edit";
            this.btnProductEdit.UseVisualStyleBackColor = true;
            this.btnProductEdit.Click += new System.EventHandler(this.btnProductEdit_Click);
            // 
            // btnProductAddNew
            // 
            this.btnProductAddNew.Location = new System.Drawing.Point(18, 28);
            this.btnProductAddNew.Name = "btnProductAddNew";
            this.btnProductAddNew.Size = new System.Drawing.Size(94, 32);
            this.btnProductAddNew.TabIndex = 5;
            this.btnProductAddNew.Text = "Add new";
            this.btnProductAddNew.UseVisualStyleBackColor = true;
            this.btnProductAddNew.Click += new System.EventHandler(this.btnProductAdd_Click);
            // 
            // btnProductDelete
            // 
            this.btnProductDelete.Location = new System.Drawing.Point(224, 28);
            this.btnProductDelete.Name = "btnProductDelete";
            this.btnProductDelete.Size = new System.Drawing.Size(94, 32);
            this.btnProductDelete.TabIndex = 6;
            this.btnProductDelete.Text = "Delete";
            this.btnProductDelete.UseVisualStyleBackColor = true;
            this.btnProductDelete.Click += new System.EventHandler(this.btnProductDelete_Click);
            // 
            // grpProductAddEdit
            // 
            this.grpProductAddEdit.Controls.Add(this.btnProductAdd);
            this.grpProductAddEdit.Controls.Add(this.btnProductCancel);
            this.grpProductAddEdit.Controls.Add(this.btnProductSave);
            this.grpProductAddEdit.Controls.Add(this.txtProdEdit);
            this.grpProductAddEdit.Location = new System.Drawing.Point(21, 503);
            this.grpProductAddEdit.Name = "grpProductAddEdit";
            this.grpProductAddEdit.Size = new System.Drawing.Size(359, 127);
            this.grpProductAddEdit.TabIndex = 8;
            this.grpProductAddEdit.TabStop = false;
            this.grpProductAddEdit.Text = "Add/Edit Product";
            this.grpProductAddEdit.Visible = false;
            // 
            // txtProdEdit
            // 
            this.txtProdEdit.Location = new System.Drawing.Point(25, 40);
            this.txtProdEdit.Name = "txtProdEdit";
            this.txtProdEdit.Size = new System.Drawing.Size(306, 26);
            this.txtProdEdit.TabIndex = 0;
            // 
            // btnProductSave
            // 
            this.btnProductSave.Location = new System.Drawing.Point(25, 80);
            this.btnProductSave.Name = "btnProductSave";
            this.btnProductSave.Size = new System.Drawing.Size(75, 32);
            this.btnProductSave.TabIndex = 1;
            this.btnProductSave.Text = "Save";
            this.btnProductSave.UseVisualStyleBackColor = true;
            this.btnProductSave.Click += new System.EventHandler(this.btnProductSave_Click);
            // 
            // btnProductCancel
            // 
            this.btnProductCancel.Location = new System.Drawing.Point(118, 80);
            this.btnProductCancel.Name = "btnProductCancel";
            this.btnProductCancel.Size = new System.Drawing.Size(75, 32);
            this.btnProductCancel.TabIndex = 2;
            this.btnProductCancel.Text = "Cancel";
            this.btnProductCancel.UseVisualStyleBackColor = true;
            this.btnProductCancel.Click += new System.EventHandler(this.btnProductCancel_Click);
            // 
            // grpProductButtons
            // 
            this.grpProductButtons.Controls.Add(this.lstProducts);
            this.grpProductButtons.Controls.Add(this.btnProductAddNew);
            this.grpProductButtons.Controls.Add(this.btnProductEdit);
            this.grpProductButtons.Controls.Add(this.btnProductDelete);
            this.grpProductButtons.Location = new System.Drawing.Point(28, 32);
            this.grpProductButtons.Name = "grpProductButtons";
            this.grpProductButtons.Size = new System.Drawing.Size(352, 452);
            this.grpProductButtons.TabIndex = 10;
            this.grpProductButtons.TabStop = false;
            // 
            // lstProducts
            // 
            this.lstProducts.DataSource = this.productBindingSource1;
            this.lstProducts.DisplayMember = "ProdName";
            this.lstProducts.FormattingEnabled = true;
            this.lstProducts.ItemHeight = 20;
            this.lstProducts.Location = new System.Drawing.Point(18, 84);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(306, 344);
            this.lstProducts.TabIndex = 11;
            this.lstProducts.ValueMember = "ProductId";
            this.lstProducts.SelectedIndexChanged += new System.EventHandler(this.lstProducts_SelectedIndexChanged_1);
            // 
            // productBindingSource1
            // 
            this.productBindingSource1.DataSource = typeof(TravelExpertsClasses.Product);
            // 
            // grpProdSupplier
            // 
            this.grpProdSupplier.Controls.Add(this.lvProdSuppliers);
            this.grpProdSupplier.Controls.Add(this.btnProdSupplierDelete);
            this.grpProdSupplier.Controls.Add(this.btnProdSupplierAdd);
            this.grpProdSupplier.Location = new System.Drawing.Point(409, 33);
            this.grpProdSupplier.Name = "grpProdSupplier";
            this.grpProdSupplier.Size = new System.Drawing.Size(537, 451);
            this.grpProdSupplier.TabIndex = 11;
            this.grpProdSupplier.TabStop = false;
            this.grpProdSupplier.Text = "Suppliers for product [insert product name]";
            // 
            // lvProdSuppliers
            // 
            this.lvProdSuppliers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PSId,
            this.supName});
            this.lvProdSuppliers.FullRowSelect = true;
            this.lvProdSuppliers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvProdSuppliers.Location = new System.Drawing.Point(18, 92);
            this.lvProdSuppliers.MultiSelect = false;
            this.lvProdSuppliers.Name = "lvProdSuppliers";
            this.lvProdSuppliers.Size = new System.Drawing.Size(492, 329);
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
            // grpProdSupplierAdd
            // 
            this.grpProdSupplierAdd.Controls.Add(this.btnProdSupplierCancel);
            this.grpProdSupplierAdd.Controls.Add(this.cboProductSupplierAdd);
            this.grpProdSupplierAdd.Controls.Add(this.btnProdSupplierSave);
            this.grpProdSupplierAdd.Location = new System.Drawing.Point(409, 503);
            this.grpProdSupplierAdd.Name = "grpProdSupplierAdd";
            this.grpProdSupplierAdd.Size = new System.Drawing.Size(537, 127);
            this.grpProdSupplierAdd.TabIndex = 9;
            this.grpProdSupplierAdd.TabStop = false;
            this.grpProdSupplierAdd.Text = "Add Supplier to Product";
            this.grpProdSupplierAdd.Visible = false;
            // 
            // btnProdSupplierCancel
            // 
            this.btnProdSupplierCancel.Location = new System.Drawing.Point(105, 80);
            this.btnProdSupplierCancel.Name = "btnProdSupplierCancel";
            this.btnProdSupplierCancel.Size = new System.Drawing.Size(75, 32);
            this.btnProdSupplierCancel.TabIndex = 4;
            this.btnProdSupplierCancel.Text = "Cancel";
            this.btnProdSupplierCancel.UseVisualStyleBackColor = true;
            this.btnProdSupplierCancel.Click += new System.EventHandler(this.btnProdSupplierCancel_Click);
            // 
            // cboProductSupplierAdd
            // 
            this.cboProductSupplierAdd.FormattingEnabled = true;
            this.cboProductSupplierAdd.Location = new System.Drawing.Point(24, 42);
            this.cboProductSupplierAdd.Name = "cboProductSupplierAdd";
            this.cboProductSupplierAdd.Size = new System.Drawing.Size(310, 28);
            this.cboProductSupplierAdd.TabIndex = 0;
            // 
            // btnProdSupplierSave
            // 
            this.btnProdSupplierSave.Location = new System.Drawing.Point(24, 80);
            this.btnProdSupplierSave.Name = "btnProdSupplierSave";
            this.btnProdSupplierSave.Size = new System.Drawing.Size(75, 32);
            this.btnProdSupplierSave.TabIndex = 3;
            this.btnProdSupplierSave.Text = "Add";
            this.btnProdSupplierSave.UseVisualStyleBackColor = true;
            this.btnProdSupplierSave.Click += new System.EventHandler(this.btnProdSupplierSave_Click);
            // 
            // btnProdSupplierDelete
            // 
            this.btnProdSupplierDelete.Location = new System.Drawing.Point(18, 38);
            this.btnProdSupplierDelete.Name = "btnProdSupplierDelete";
            this.btnProdSupplierDelete.Size = new System.Drawing.Size(243, 36);
            this.btnProdSupplierDelete.TabIndex = 6;
            this.btnProdSupplierDelete.Text = "Remove supplier from product";
            this.btnProdSupplierDelete.UseVisualStyleBackColor = true;
            this.btnProdSupplierDelete.Click += new System.EventHandler(this.btnProdSupplierDelete_Click);
            // 
            // btnProdSupplierAdd
            // 
            this.btnProdSupplierAdd.Location = new System.Drawing.Point(267, 38);
            this.btnProdSupplierAdd.Name = "btnProdSupplierAdd";
            this.btnProdSupplierAdd.Size = new System.Drawing.Size(243, 36);
            this.btnProdSupplierAdd.TabIndex = 5;
            this.btnProdSupplierAdd.Text = "Add supplier for this product";
            this.btnProdSupplierAdd.UseVisualStyleBackColor = true;
            this.btnProdSupplierAdd.Click += new System.EventHandler(this.btnProdSupplierAdd_Click);
            // 
            // btnProductAdd
            // 
            this.btnProductAdd.Location = new System.Drawing.Point(33, 80);
            this.btnProductAdd.Name = "btnProductAdd";
            this.btnProductAdd.Size = new System.Drawing.Size(75, 32);
            this.btnProductAdd.TabIndex = 3;
            this.btnProductAdd.Text = "Add";
            this.btnProductAdd.UseVisualStyleBackColor = true;
            this.btnProductAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // frmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 675);
            this.Controls.Add(this.grpProdSupplier);
            this.Controls.Add(this.grpProdSupplierAdd);
            this.Controls.Add(this.grpProductButtons);
            this.Controls.Add(this.grpProductAddEdit);
            this.Name = "frmProducts";
            this.Text = "frmProducts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProducts_FormClosed);
            this.Load += new System.EventHandler(this.frmProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSupplierBindingSource)).EndInit();
            this.grpProductAddEdit.ResumeLayout(false);
            this.grpProductAddEdit.PerformLayout();
            this.grpProductButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).EndInit();
            this.grpProdSupplier.ResumeLayout(false);
            this.grpProdSupplierAdd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.Button btnProductEdit;
        private System.Windows.Forms.Button btnProductAddNew;
        private System.Windows.Forms.Button btnProductDelete;
        private System.Windows.Forms.BindingSource productSupplierBindingSource;
        private System.Windows.Forms.GroupBox grpProductAddEdit;
        private System.Windows.Forms.Button btnProductCancel;
        private System.Windows.Forms.Button btnProductSave;
        private System.Windows.Forms.TextBox txtProdEdit;
        private System.Windows.Forms.GroupBox grpProductButtons;
        private System.Windows.Forms.ListBox lstProducts;
        private System.Windows.Forms.BindingSource productBindingSource1;
        private System.Windows.Forms.GroupBox grpProdSupplier;
        private System.Windows.Forms.ListView lvProdSuppliers;
        private System.Windows.Forms.ColumnHeader PSId;
        private System.Windows.Forms.ColumnHeader supName;
        private System.Windows.Forms.GroupBox grpProdSupplierAdd;
        private System.Windows.Forms.Button btnProdSupplierCancel;
        private System.Windows.Forms.ComboBox cboProductSupplierAdd;
        private System.Windows.Forms.Button btnProdSupplierSave;
        private System.Windows.Forms.Button btnProdSupplierDelete;
        private System.Windows.Forms.Button btnProdSupplierAdd;
        private System.Windows.Forms.Button btnProductAdd;
    }
}