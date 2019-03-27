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

<<<<<<< HEAD
<<<<<<< HEAD
        //scrolling background -- Made By: Brent Ward
        int x = Screen.PrimaryScreen.WorkingArea.Width;
        int y = Screen.PrimaryScreen.WorkingArea.Height;
=======
=======
>>>>>>> parent of 7399323... scrolling background -Partly complete
        //scrolling background
        private int bg_x = 0;
        private int bg_y = 0;
>>>>>>> parent of 7399323... scrolling background -Partly complete

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

<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> parent of 7399323... scrolling background -Partly complete
            if(bg_x == bgWidth)
            {
                bg_x = 0;
            }else { bg_x += 4; }
<<<<<<< HEAD
>>>>>>> parent of 7399323... scrolling background -Partly complete
=======
>>>>>>> parent of 7399323... scrolling background -Partly complete
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
