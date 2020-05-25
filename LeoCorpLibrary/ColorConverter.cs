using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary
{
    /// <summary>
    /// Classe permettant de convertir des types de couleur
    /// </summary>
    public static class ColorConverter
    {

    }

	/// <summary>
	/// Structure d'une couleur HSV
	/// </summary>
    public struct HSVColor
    {
		// Note : Ce code provient initialement de ce projet : https://www.codeproject.com/questions/996265/rgb-to-hsv-conversion
		// Il a été ici amélioré

		/// <summary>
		/// Luminosié
		/// </summary>
		public float Hue;

		/// <summary>
		/// Saturation
		/// </summary>
		public float Saturation;

		/// <summary>
		/// Valeur
		/// </summary>
		public float Value;

		/// <summary>
		/// Permet de créer une couleur HSV à partir d'une couleur (<see cref="Color"/>)
		/// </summary>
		/// <param name="color">Couleur (<see cref="Color"/>)</param>
		/// <returns></returns>
		public static HSVColor FromRGB(Color color)
		{
			HSVColor toReturn = new HSVColor();

			int max = Math.Max(color.R, Math.Max(color.G, color.B));
			int min = Math.Min(color.R, Math.Min(color.G, color.B));

			toReturn.Hue = (float) Math.Round(color.GetHue());
			toReturn.Saturation = (float) ((max == 0) ? 0 : 1d - (1d * min / max)) * 100;
			toReturn.Saturation = (float) Math.Round(toReturn.Saturation);
			toReturn.Value = (float) Math.Round(((max / 255d) * 100));

			return toReturn;
		}

		/// <summary>
		/// Permet de créer une couleur HSV à partir d'une couleur (<see cref="Color"/>)
		/// </summary>
		/// <param name="red">Rouge</param>
		/// <param name="green">Vert</param>
		/// <param name="blue">Bleu</param>
		/// <returns></returns>
		public static HSVColor FromRGB(int red, int green, int blue)
        {
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
	/// Structure d'une couleur HEX
	/// </summary>
    public struct HEXColor
    {

    }
}
