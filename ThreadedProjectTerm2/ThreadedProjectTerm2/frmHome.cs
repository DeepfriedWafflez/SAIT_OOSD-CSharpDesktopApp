using System;
using System.Drawing;
using System.IO;
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

        //scrolling background -- Made By: Brent Ward
        int x = Screen.PrimaryScreen.WorkingArea.Width;
        int y = Screen.PrimaryScreen.WorkingArea.Height;

        Image bg;
        int bg_x = 0;
        int bgWidth = 0;
        int bgHeight = 0;

        private void frmHome_Load(object sender, EventArgs e)
        {
            bgHolder.Width = x;
            bgHolder.Height = y;

            BG_Box.Image = new Bitmap(x, y);
            BG_Box.ClientSize = BG_Box.Image.Size;
            bg = Image.FromFile(@"..\..\img\clouds.jpg");
            BG_Box.Image = bg;

            bgTimer.Start();
        }

        private void BG_Box_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bg, new Rectangle(0, 0, this.Width, this.Height), new Rectangle(x, y, this.Width, this.Height), GraphicsUnit.Pixel);

        }

        private void bgTimer_Tick(object sender, EventArgs e)
        {
            if(bg_x <= bgWidth)
            {
                bg_x = 0;
            }else { bg_x++; }
            BG_Box.Refresh();
        }
    }
}
