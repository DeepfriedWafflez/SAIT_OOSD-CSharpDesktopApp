using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadedProjectTerm2
{
    /**
     * Threaded project 2 - Team 1
     * Purpose: Agent object to store agent data from database
     * Made by: Brent Ward
     * Date: Marth 30th 2019
     * **/
    class TransparentPanel : Panel
    {

    public TransparentPanel()
        {
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x00000020;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, 50, 50, 50)), this.ClientRectangle);
        }
    }
}
