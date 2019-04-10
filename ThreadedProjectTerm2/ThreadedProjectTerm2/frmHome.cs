using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThreadedProjectTerm2
{
    public partial class frmHome : Form
    {
        /*
         * Author: Brent Ward
         * Date: March 22, 2019
         * Purpose: Designs a homepage for the form when it loads
         * */
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

        //Panel constructors
        TransparentPanel loginPanel;
        TransparentPanel mainPanel;
        TransparentPanel footerPanel;

        private void frmHome_Load(object sender, EventArgs e)
        {
            bgHolder.Width = x;
            bgHolder.Height = y;
            bg = Image.FromFile(@"..\..\img\clouds.jpg");
            bgHolder.Image = bg;
            
            bgWidth = bg.Width;
            bgHeight = bg.Height;

            //double buffer
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            bgTimer.Start();

            /*Panel & Form Styling
             * 
             * Had Trouble with my transparent panels visually tearing,
             * Pretty sure the issue comes from visual studio running on a low amount of
             * memory but not sure how to change this from a code standpoint.
             * */

            //login transparent Panel
            
            loginPanel = new TransparentPanel();
            loginPanel.Size = new System.Drawing.Size(375, 220);
            loginPanel.BackColor = System.Drawing.Color.Transparent;
            loginPanel.Location = new System.Drawing.Point((x-400),25);
            loginPanel.Controls.Add(AdminLabel);
            loginPanel.Controls.Add(UsernameLabel);
            loginPanel.Controls.Add(UsernameTxt);
            loginPanel.Controls.Add(PasswordLabel);
            loginPanel.Controls.Add(PasswordTxt);
            loginPanel.Controls.Add(LoginBtn);
            loginPanelTemp.Visible = false;//used to hold the controls to get their positioning set
            loginPanelTemp.Enabled = false;
            bgHolder.Controls.Add(loginPanel);

            //main transparent Panel -- WAY toomuch tearing to display for presentation
            /*
            mainPanel = new TransparentPanel();
            mainPanel.Size = new System.Drawing.Size(620, 200);
            mainPanel.BackColor = System.Drawing.Color.Transparent;
            mainPanel.Location = new System.Drawing.Point(150, 245);
            mainPanel.Controls.Add(mainPanelHeader);
            mainPanel.Controls.Add(mainLabelText);
            mainPanelTemp.Visible = false;
            mainPanelTemp.Enabled = false;
            bgHolder.Controls.Add(mainPanel);*/

            //footer panel
            footerPanel = new TransparentPanel();
            footerPanel.Size = new System.Drawing.Size(400, 30);
            footerPanel.BackColor = System.Drawing.Color.Transparent;
            footerPanel.Location = new System.Drawing.Point((x/2-200), (y - 100));
            CopyLabel.Location = new System.Drawing.Point(65, 5);
            footerPanel.Controls.Add(CopyLabel);
            bgHolder.Controls.Add(footerPanel);

            bgHolder.SendToBack();

            BannerPB.ImageLocation = @"..\..\img\banner.jpg";
            BannerPB.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void bgTimer_Tick(object sender, EventArgs e)
        {
            bgHolder.Invalidate();//forces repaint

            if(bg_x == 1000)
            {
                bg_x = 0;
            }else { bg_x += 1; }
        }

        private void bgHolder_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bgHolder.Image, new Rectangle(0, 0, this.Width, this.Height), new Rectangle(bg_x, bg_y, this.Width, this.Height), GraphicsUnit.Pixel);
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            UserInfoPanel.Visible = true;
        }
    }
}
