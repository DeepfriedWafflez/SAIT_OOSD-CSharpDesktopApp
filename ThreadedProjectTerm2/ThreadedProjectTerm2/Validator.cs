using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadedProjectTerm2
{
    public class Validator
    {
        public static bool IsPresent(TextBox tb)
        {
            bool result = true;
            if(tb.Text == "") result = false;

            return result;
        }
    }
}
