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
using LeoCorpLibrary.Exceptions;
using System;
using System.Drawing;
using System.Globalization;

namespace LeoCorpLibrary
{
	/// <summary>
	/// Class containing methods that allows you to convert types of colors.
	/// </summary>
	public static class ColorsConverter
	{
		/// <summary>
		/// Allows you to convert a RGB color into a <see cref="HSVColor"/>.
		/// </summary>
		/// <param name="red">Red.</param>
		/// <param name="green">Green.</param>
		/// <param name="blue">Blue.</param>
		/// <returns>A <see cref="HSVColor"/> value.</returns>
		public static HSVColor RGBtoHSV(int red, int green, int blue)
		{
			return HSVColor.FromRGB(red, green, blue);
		}

		/// <summary>
		/// Allows you to convert a RGB <see cref="Color"/> into a <see cref="HSVColor"/>.
		/// </summary>
		/// <param name="color">Couleur (<see cref="Color"/>).</param>
		/// <returns>A <see cref="HSVColor"/> value.</returns>
		public static HSVColor RGBtoHSV(Color color)
		{
			return HSVColor.FromRGB(color);
		}

		/// <summary>
		/// Allows you to convert a RGB color into a <see cref="HEXColor"/>.
		/// </summary>
		/// <param name="red">Red.</param>
		/// <param name="green">Green.</param>
		/// <param name="blue">Blue.</param>
		/// <returns>A <see cref="HEXColor"/> value.</returns>
		public static HEXColor RGBtoHEX(int red, int green, int blue)
		{
			return HEXColor.FromRGB(red, green, blue);
		}

		/// <summary>
		/// Allows you to convert a RGB <see cref="Color"/> into a <see cref="HEXColor"/>.
		/// </summary>
		/// <param name="color">Couleur.</param>
		/// <returns>A <see cref="HEXColor"/> value.</returns>
		public static HEXColor RGBtoHEX(Color color)
		{
			return HEXColor.FromRGB(color);
		}

		/// <summary>
		/// Allows you to convert a <see cref="HEXColor"/> into a RGB <see cref="Color"/>.
		/// </summary>
		/// <param name="hexColor"><see cref="HEXColor"/> to convert.</param>
		/// <exception cref="Exceptions.HEXInvalidValueException"/>
		/// <returns>A <see cref="Color"/> value.</returns>
		public static Color HEXtoRGB(HEXColor hexColor)
		{
			try
			{
				// Enleves les #
				if (hexColor.Value.IndexOf('#') != -1)
					hexColor.Value = hexColor.Value.Replace("#", "");
				int r, g, b = 0;
				r = int.Parse(hexColor.Value.Substring(0, 2), NumberStyles.AllowHexSpecifier);
				g = int.Parse(hexColor.Value.Substring(2, 2), NumberStyles.AllowHexSpecifier);
				b = int.Parse(hexColor.Value.Substring(4, 2), NumberStyles.AllowHexSpecifier);
				return Color.FromArgb(r, g, b);
			}
			catch
			{
				throw new HEXInvalidValueException("The specified HEX value is invalid.");
			}
		}

		/// <summary>
		/// Allows you to convert a <see cref="HEXColor"/> into a <see cref="HSVColor"/>.
		/// </summary>
		/// <param name="hexColor"><see cref="HEXColor"/> to convert.</param>
		/// <exception cref="Exceptions.HEXInvalidValueException"/>
		/// <returns>A <see cref="HSVColor"/> value.</returns>
		public static HSVColor HEXtoHSV(HEXColor hexColor)
		{
			HSVColor hSVColor = new HSVColor();
			hSVColor = RGBtoHSV(HEXtoRGB(hexColor));
			return hSVColor;
		}
	}

	/// <summary>
	/// A structure that contains infos and methods for a HSV Color.
	/// </summary>
	public struct HSVColor
	{
		// Note : Ce code provient initialement de ce projet : https://www.codeproject.com/questions/996265/rgb-to-hsv-conversion
		// Il a été ici amélioré

		/// <summary>
		/// Hue.
		/// </summary>
		public float Hue;

		/// <summary>
		/// Saturation.
		/// </summary>
		public float Saturation;

		/// <summary>
		/// Value.
		/// </summary>
		public float Value;

		/// <summary>
		/// Allows you to create a <see cref="HSVColor"/> from a <see cref="Color"/>.
		/// </summary>
		/// <param name="color"><see cref="Color"/> to convert.</param>
		/// <returns>A <see cref="HSVColor"/> value.</returns>
		public static HSVColor FromRGB(Color color)
		{
			HSVColor toReturn = new HSVColor();

			int max = Math.Max(color.R, Math.Max(color.G, color.B));
			int min = Math.Min(color.R, Math.Min(color.G, color.B));

			toReturn.Hue = (float)Math.Round(color.GetHue());
			toReturn.Saturation = (float)((max == 0) ? 0 : 1d - (1d * min / max)) * 100;
			toReturn.Saturation = (float)Math.Round(toReturn.Saturation);
			toReturn.Value = (float)Math.Round(((max / 255d) * 100));

			return toReturn;
		}

		/// <summary>
		/// Allows you to create a <see cref="HSVColor"/> from a RGB color.
		/// </summary>
		/// <param name="red">Red.</param>
		/// <param name="green">Green.</param>
		/// <param name="blue">Blue.</param>
		/// <exception cref="Exceptions.RGBInvalidValueException"/>
		/// <returns>A <see cref="HSVColor"/> value.</returns>
		public static HSVColor FromRGB(int red, int green, int blue)
		{
			if (!(red >= 0 && red <= 255 && green >= 0 && green <= 255 && blue >= 0 && blue <= 255)) // Si pas valide
			{
				throw new RGBInvalidValueException("The specified argmuents aren't RGB valid."); // Erreur
			}
			HSVColor toReturn = new HSVColor();
			Color color = Color.FromArgb(red, green, blue);
			int max = Math.Max(color.R, Math.Max(color.G, color.B));
			int min = Math.Min(color.R, Math.Min(color.G, color.B));

			toReturn.Hue = (float)Math.Round(color.GetHue());
			toReturn.Saturation = (float)((max == 0) ? 0 : 1d - (1d * min / max)) * 100;
			toReturn.Saturation = (float)Math.Round(toReturn.Saturation);
			toReturn.Value = (float)Math.Round(((max / 255d) * 100));

			return toReturn;
		}
	}

	/// <summary>
	/// A structure that contains infos and methods of a <see cref="HEXColor"/>.
	/// </summary>
	public struct HEXColor
	{

		/// <summary>
		/// Value of the color.
		/// </summary>
		public string Value;

		/// <summary>
		/// Allows you to create a <see cref="HEXColor"/> from a <see cref="Color"/>.
		/// </summary>
		/// <param name="color"><see cref="Color"/> to convert.</param>
		/// <returns>A <see cref="HEXColor"/> value.</returns>
		public static HEXColor FromRGB(Color color)
		{
			HEXColor toReturn = new HEXColor();
			toReturn.Value = ColorTranslator.FromHtml(String.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B)).Name.Remove(0, 2);
			return toReturn;
		}

		/// <summary>
		/// Allows you to create a <see cref="HEXColor"/>) from a RGB Color.
		/// </summary>
		/// <param name="red">Red.</param>
		/// <param name="blue">Blue.</param>
		/// <param name="green">Green.</param>
		/// <exception cref="Exceptions.RGBInvalidValueException"/>
		/// <returns>A <see cref="HEXColor"/> value.</returns>
		public static HEXColor FromRGB(int red, int green, int blue)
		{
			if (!(red >= 0 && red <= 255 && green >= 0 && green <= 255 && blue >= 0 && blue <= 255)) // Si pas valide
			{
				throw new RGBInvalidValueException("The specified argmuents aren't RGB valid."); // Erreur
			}
			HEXColor toReturn = new HEXColor(); // Couleur HEX
			toReturn.Value = ColorTranslator.FromHtml(String.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue)).Name.Remove(0, 2); // Conversion en HEX
			return toReturn; // Retourne la couleur HEX
		}
	}
}
