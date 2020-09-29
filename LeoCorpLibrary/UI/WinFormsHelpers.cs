using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeoCorpLibrary.UI
{
    /// <summary>
    /// A class that contains method to help you manage the UI of a Windows Forms application.
    /// </summary>
    public static class WinFormsHelpers
    {
        /// <summary>
        /// Centers a specified <see cref="Control"/> in a <see cref="Form"/>.
        /// </summary>
        /// <param name="control">The <see cref="Control"/> to center.</param>
        /// <param name="form">The <see cref="Form"/> where the control is going to be centered.</param>
        public static void CenterControlOnForm(Control control, Form form)
        {
            control.Left = (form.ClientSize.Width - control.Width) / 2; // Center horizontally
            control.Top = (form.ClientSize.Height - control.Height) / 2; // Center vertically
        }

        /// <summary>
        /// Centers a specified <see cref="Control"/> in a <see cref="Form"/>.
        /// </summary>
        /// <param name="control">The <see cref="Control"/> to center.</param>
        /// <param name="form">The <see cref="Form"/> where the control is going to be centered.</param>
        /// <param name="controlAlignement">If <see cref="ControlAlignement.Vertical"/>, the <see cref="Control"/> will be centered vertically. If <see cref="ControlAlignement.Horizontal"/>, the <see cref="Control"/> will be centered horizontally.</param>
        public static void CenterControlOnForm(Control control, Form form, ControlAlignement controlAlignement)
        {
            switch (controlAlignement)
            {
                case ControlAlignement.Horizontal:
                    control.Left = (form.ClientSize.Width - control.Width) / 2; // Center horizontally
                    break;
                case ControlAlignement.Vertical:
                    control.Top = (form.ClientSize.Height - control.Height) / 2; // Center vertically
                    break;
                case ControlAlignement.Both:
                    control.Left = (form.ClientSize.Width - control.Width) / 2; // Center horizontally
                    control.Top = (form.ClientSize.Height - control.Height) / 2; // Center vertically
                    break;
            }
        }
    }

    /// <summary>
    /// The alignement of a <see cref="Control"/>.
    /// </summary>
    public enum ControlAlignement
    {
        /// <summary>
        /// The alignement of the <see cref="Control"/> will be horizontal.
        /// </summary>
        Horizontal,

        /// <summary>
        /// The alignement of the <see cref="Control"/> will be vertical.
        /// </summary>
        Vertical,

        /// <summary>
        /// The alignement of the <see cref="Control"/> will be horizontal and vertical.
        /// </summary>
        Both
    }
}
