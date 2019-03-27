﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThreadedProjectTerm2
{
    public partial class frmHome : Form
    {
        public frmMain activeFrmMain;
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this == activeFrmMain.activeFrmHome)
                activeFrmMain.activeFrmPackages = null;
        }

        //scrolling background
        int x = Screen.PrimaryScreen.WorkingArea.Width;
        int y = Screen.PrimaryScreen.WorkingArea.Height;

        private int bg_x = 0;
        private int bg_y = 0;
        private int bgWidth = 0;
        private int bgHeight = 0;
        
        private Image bg;

        private void frmHome_Load(object sender, EventArgs e)
        {
            bgHolder.Width = x;
            bgHolder.Height = y;
            bg = Image.FromFile(@"..\..\img\clouds.jpg");
            
            bgWidth = bg.Width;
            bgHeight = bg.Height;

            //double buffer
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            bgTimer.Start();


            //Form styling
            loginPanel.BackColor = Color.FromArgb(160, 50, 50, 50);
            mainPanel.BackColor = Color.FromArgb(160, 50, 50, 50);

            loginPB.ImageLocation = @"..\..\img\loginIcon.png";
            loginPB.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void bgTimer_Tick(object sender, EventArgs e)
        {
            bgHolder.Invalidate();//forces repaint

            if(bg_x == 400)
            {
                bg_x = 0;
            }else { bg_x += 1; }
        }

        private void bgHolder_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bg, new Rectangle(0, 0, this.Width, this.Height), new Rectangle(bg_x, bg_y, this.Width, this.Height), GraphicsUnit.Pixel);
        }
    }
}
