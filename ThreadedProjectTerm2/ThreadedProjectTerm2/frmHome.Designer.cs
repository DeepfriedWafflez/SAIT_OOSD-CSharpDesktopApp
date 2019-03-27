namespace ThreadedProjectTerm2
{
    partial class frmHome
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
            this.bgHolder = new System.Windows.Forms.Panel();
            this.BG_Box = new System.Windows.Forms.PictureBox();
            this.bgTimer = new System.Windows.Forms.Timer(this.components);
            this.bgHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BG_Box)).BeginInit();
            this.SuspendLayout();
            // 
            // bgHolder
            // 
            this.bgHolder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bgHolder.Controls.Add(this.BG_Box);
            this.bgHolder.Location = new System.Drawing.Point(0, 0);
            this.bgHolder.Name = "bgHolder";
            this.bgHolder.Size = new System.Drawing.Size(550, 338);
            this.bgHolder.TabIndex = 0;
            // 
            // BG_Box
            // 
            this.BG_Box.Location = new System.Drawing.Point(3, 3);
            this.BG_Box.Name = "BG_Box";
            this.BG_Box.Size = new System.Drawing.Size(544, 332);
            this.BG_Box.TabIndex = 0;
            this.BG_Box.TabStop = false;
            this.BG_Box.Paint += new System.Windows.Forms.PaintEventHandler(this.BG_Box_Paint);
            // 
            // bgTimer
            // 
            this.bgTimer.Enabled = true;
            this.bgTimer.Tick += new System.EventHandler(this.bgTimer_Tick);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 337);
            this.Controls.Add(this.bgHolder);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmHome";
            this.Text = "frmHome";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmHome_FormClosed);
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.bgHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BG_Box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bgHolder;
        private System.Windows.Forms.PictureBox BG_Box;
        private System.Windows.Forms.Timer bgTimer;
    }
}