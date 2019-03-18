namespace ThreadedProjectTerm2
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAgents = new System.Windows.Forms.ToolStripButton();
            this.btnSuppliers = new System.Windows.Forms.ToolStripButton();
            this.btnProducts = new System.Windows.Forms.ToolStripButton();
            this.btnPackages = new System.Windows.Forms.ToolStripButton();
            this.btnHome = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHome,
            this.btnPackages,
            this.btnProducts,
            this.btnSuppliers,
            this.btnAgents,
            this.btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(865, 35);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAgents
            // 
            this.btnAgents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAgents.Image = ((System.Drawing.Image)(resources.GetObject("btnAgents.Image")));
            this.btnAgents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgents.Name = "btnAgents";
            this.btnAgents.Size = new System.Drawing.Size(77, 32);
            this.btnAgents.Text = "Agents";
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSuppliers.Image = ((System.Drawing.Image)(resources.GetObject("btnSuppliers.Image")));
            this.btnSuppliers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(97, 32);
            this.btnSuppliers.Text = "Suppliers";
            // 
            // btnProducts
            // 
            this.btnProducts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnProducts.Image = ((System.Drawing.Image)(resources.GetObject("btnProducts.Image")));
            this.btnProducts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(93, 32);
            this.btnProducts.Text = "Products";
            // 
            // btnPackages
            // 
            this.btnPackages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPackages.Image = ((System.Drawing.Image)(resources.GetObject("btnPackages.Image")));
            this.btnPackages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPackages.Name = "btnPackages";
            this.btnPackages.Size = new System.Drawing.Size(95, 32);
            this.btnPackages.Text = "Packages";
            // 
            // btnHome
            // 
            this.btnHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(69, 32);
            this.btnHome.Text = "Home";
            // 
            // btnExit
            // 
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(47, 32);
            this.btnExit.Text = "Exit";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 450);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.Text = "Travel Experts - Agent Portal";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnHome;
        private System.Windows.Forms.ToolStripButton btnPackages;
        private System.Windows.Forms.ToolStripButton btnProducts;
        private System.Windows.Forms.ToolStripButton btnSuppliers;
        private System.Windows.Forms.ToolStripButton btnAgents;
        private System.Windows.Forms.ToolStripButton btnExit;
    }
}

