using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeoCorpLibrary.UI
{
    public static class WinFormsHelpers
    {
        public static void CenterControlOnForm(Control control, Form form)
        {
            control.Left = (form.ClientSize.Width - control.Width) / 2; // Center horizontally
            control.Top = (form.ClientSize.Height - control.Height) / 2; // Center vertically
        }

        public static void CenterControlOnForm(Control control, Form form, ControlAlignement controlAlignement)
        {
            if (controlAlignement == ControlAlignement.Horizontal) // If the alignement is horizontal
            {
                control.Left = (form.ClientSize.Width - control.Width) / 2; // Center horizontally
            }
            else // If the alignement is vertical
            {
                control.Top = (form.ClientSize.Height - control.Height) / 2; // Center vertically
            }
        }
    }

    public enum ControlAlignement
    {
        Horizontal,
        Vertical
    }
}
