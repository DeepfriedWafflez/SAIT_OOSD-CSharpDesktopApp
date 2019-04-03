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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            this.bgTimer = new System.Windows.Forms.Timer(this.components);
            this.bgHolder = new System.Windows.Forms.PictureBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.AdminLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.UsernameTxt = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.loginPanelTemp = new System.Windows.Forms.Panel();
            this.BannerPB = new System.Windows.Forms.PictureBox();
            this.mainPanelTemp = new System.Windows.Forms.Panel();
            this.mainLabelText = new System.Windows.Forms.Label();
            this.mainPanelHeader = new System.Windows.Forms.Label();
            this.CopyLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bgHolder)).BeginInit();
            this.loginPanelTemp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BannerPB)).BeginInit();
            this.mainPanelTemp.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgTimer
            // 
            this.bgTimer.Enabled = true;
            this.bgTimer.Interval = 150;
            this.bgTimer.Tick += new System.EventHandler(this.bgTimer_Tick);
            // 
            // bgHolder
            // 
            this.bgHolder.BackColor = System.Drawing.Color.Transparent;
            this.bgHolder.Location = new System.Drawing.Point(1, 0);
            this.bgHolder.Name = "bgHolder";
            this.bgHolder.Size = new System.Drawing.Size(1331, 660);
            this.bgHolder.TabIndex = 0;
            this.bgHolder.TabStop = false;
            this.bgHolder.Paint += new System.Windows.Forms.PaintEventHandler(this.bgHolder_Paint);
            // 
            // LoginBtn
            // 
            this.LoginBtn.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.Location = new System.Drawing.Point(108, 160);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(143, 38);
            this.LoginBtn.TabIndex = 0;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            // 
            // AdminLabel
            // 
            this.AdminLabel.AutoSize = true;
            this.AdminLabel.BackColor = System.Drawing.Color.Transparent;
            this.AdminLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminLabel.ForeColor = System.Drawing.Color.White;
            this.AdminLabel.Location = new System.Drawing.Point(94, 20);
            this.AdminLabel.Name = "AdminLabel";
            this.AdminLabel.Size = new System.Drawing.Size(169, 29);
            this.AdminLabel.TabIndex = 1;
            this.AdminLabel.Text = "Admin Login:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.UsernameLabel.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.ForeColor = System.Drawing.Color.White;
            this.UsernameLabel.Location = new System.Drawing.Point(47, 83);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(70, 20);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "Username:";
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.BackColor = System.Drawing.SystemColors.Control;
            this.UsernameTxt.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTxt.Location = new System.Drawing.Point(123, 80);
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.Size = new System.Drawing.Size(171, 25);
            this.UsernameTxt.TabIndex = 3;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.PasswordLabel.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.White;
            this.PasswordLabel.Location = new System.Drawing.Point(47, 123);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(66, 20);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Password:";
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.BackColor = System.Drawing.SystemColors.Control;
            this.PasswordTxt.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTxt.Location = new System.Drawing.Point(123, 120);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '*';
            this.PasswordTxt.Size = new System.Drawing.Size(171, 25);
            this.PasswordTxt.TabIndex = 5;
            // 
            // loginPanelTemp
            // 
            this.loginPanelTemp.BackColor = System.Drawing.Color.Transparent;
            this.loginPanelTemp.Controls.Add(this.PasswordTxt);
            this.loginPanelTemp.Controls.Add(this.PasswordLabel);
            this.loginPanelTemp.Controls.Add(this.UsernameTxt);
            this.loginPanelTemp.Controls.Add(this.UsernameLabel);
            this.loginPanelTemp.Controls.Add(this.AdminLabel);
            this.loginPanelTemp.Controls.Add(this.LoginBtn);
            this.loginPanelTemp.Location = new System.Drawing.Point(950, 23);
            this.loginPanelTemp.Name = "loginPanelTemp";
            this.loginPanelTemp.Size = new System.Drawing.Size(355, 220);
            this.loginPanelTemp.TabIndex = 1;
            // 
            // BannerPB
            // 
            this.BannerPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BannerPB.Location = new System.Drawing.Point(23, 23);
            this.BannerPB.Name = "BannerPB";
            this.BannerPB.Size = new System.Drawing.Size(902, 161);
            this.BannerPB.TabIndex = 2;
            this.BannerPB.TabStop = false;
            // 
            // mainPanelTemp
            // 
            this.mainPanelTemp.BackColor = System.Drawing.Color.Gray;
            this.mainPanelTemp.Controls.Add(this.mainLabelText);
            this.mainPanelTemp.Controls.Add(this.mainPanelHeader);
            this.mainPanelTemp.Location = new System.Drawing.Point(115, 245);
            this.mainPanelTemp.Name = "mainPanelTemp";
            this.mainPanelTemp.Size = new System.Drawing.Size(721, 302);
            this.mainPanelTemp.TabIndex = 3;
            // 
            // mainLabelText
            // 
            this.mainLabelText.AutoSize = true;
            this.mainLabelText.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabelText.ForeColor = System.Drawing.Color.White;
            this.mainLabelText.Location = new System.Drawing.Point(34, 51);
            this.mainLabelText.Name = "mainLabelText";
            this.mainLabelText.Size = new System.Drawing.Size(563, 120);
            this.mainLabelText.TabIndex = 1;
            this.mainLabelText.Text = resources.GetString("mainLabelText.Text");
            // 
            // mainPanelHeader
            // 
            this.mainPanelHeader.AutoSize = true;
            this.mainPanelHeader.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainPanelHeader.ForeColor = System.Drawing.Color.White;
            this.mainPanelHeader.Location = new System.Drawing.Point(16, 15);
            this.mainPanelHeader.Name = "mainPanelHeader";
            this.mainPanelHeader.Size = new System.Drawing.Size(336, 22);
            this.mainPanelHeader.TabIndex = 0;
            this.mainPanelHeader.Text = "Welcome to Travel Experts Agent Portal Application!";
            // 
            // CopyLabel
            // 
            this.CopyLabel.AutoSize = true;
            this.CopyLabel.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyLabel.ForeColor = System.Drawing.Color.White;
            this.CopyLabel.Location = new System.Drawing.Point(488, 636);
            this.CopyLabel.Name = "CopyLabel";
            this.CopyLabel.Size = new System.Drawing.Size(280, 16);
            this.CopyLabel.TabIndex = 4;
            this.CopyLabel.Text = "© Travel Experts 2019    -   Developed by: Team 1 Corp.";
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 661);
            this.Controls.Add(this.CopyLabel);
            this.Controls.Add(this.mainPanelTemp);
            this.Controls.Add(this.BannerPB);
            this.Controls.Add(this.loginPanelTemp);
            this.Controls.Add(this.bgHolder);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmHome";
            this.Opacity = 0.5D;
            this.Text = "frmHome";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmHome_FormClosed);
            this.Load += new System.EventHandler(this.frmHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bgHolder)).EndInit();
            this.loginPanelTemp.ResumeLayout(false);
            this.loginPanelTemp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BannerPB)).EndInit();
            this.mainPanelTemp.ResumeLayout(false);
            this.mainPanelTemp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer bgTimer;
        private System.Windows.Forms.PictureBox bgHolder;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label AdminLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox UsernameTxt;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.Panel loginPanelTemp;
        private System.Windows.Forms.PictureBox BannerPB;
        private System.Windows.Forms.Panel mainPanelTemp;
        private System.Windows.Forms.Label mainLabelText;
        private System.Windows.Forms.Label mainPanelHeader;
        private System.Windows.Forms.Label CopyLabel;
    }
}