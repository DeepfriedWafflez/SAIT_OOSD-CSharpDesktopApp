using System;
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
        private int bg_x = 0;
        private int bg_y = 0;

        private int bgWidth = 0;
        private int bgHeight = 0;
        
        private Image bg;

        private void frmHome_Load(object sender, EventArgs e)
        {
            bg = Image.FromFile(@"..\..\img\Sky-Background.jpeg");
            bgWidth = bg.Width;
            bgHeight = bg.Height;

            //double buffer
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            bgTimer.Start();
        }

        private void bgTimer_Tick(object sender, EventArgs e)
        {
            bgHolder.Invalidate();//forces repaint

            if(bg_x == bgWidth)
            {
                bg_x = 0;
            }else { bg_x += 4; }
        }

        private void bgHolder_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bg, new Rectangle(0, 0, this.Width, this.Height), new Rectangle(bg_x, bg_y, this.Width, this.Height), GraphicsUnit.Pixel);
        }
    }
}
