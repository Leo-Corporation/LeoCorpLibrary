/*
MIT License

Copyright (c) Léo Corporation

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeoCorpLibrary.UI
{
	/// <summary>
	/// Class that contains methods related to screens.
	/// </summary>
	public static class ScreenHelpers
	{
		/// <summary>
		/// Gets the current screen's DPI.
		/// </summary>
		/// <param name="form">The window to get the DPI.</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double GetScreenDPIFromWinForm(System.Windows.Forms.Form form)
		{
			System.Drawing.Graphics graphics = System.Drawing.Graphics.FromHwnd(form.Handle);
			return graphics.DpiX;
		}

		/// <summary>
		/// Gets the current screen's DPI.
		/// </summary>
		/// <param name="window">The window to get the DPI.</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double GetScreenDPIFromWPFWindow(System.Windows.Window window)
		{
			System.Drawing.Graphics graphics = System.Drawing.Graphics.FromHwnd(new System.Windows.Interop.WindowInteropHelper(window).Handle);
			return graphics.DpiX;
		}
	}
}
