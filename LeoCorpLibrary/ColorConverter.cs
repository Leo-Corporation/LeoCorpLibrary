using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary
{
    /// <summary>
    /// Classe permettant de convertir des types de couleur.
    /// </summary>
    public static class ColorConverter
    {

		/// <summary>
		/// Permet de convertir une couleur RGB en couleur HSV (<see cref="HSVColor"/>).
		/// </summary>
		/// <param name="red">Rouge.</param>
		/// <param name="green">Vert.</param>
		/// <param name="blue">Bleu.</param>
		/// <returns>Couleur <see cref="HSVColor"/></returns>
		public static HSVColor RGBtoHSV(int red, int green, int blue)
        {
			return HSVColor.FromRGB(red, green, blue);
        }

		/// <summary>
		/// Permet de convertir une couleur RGB (<see cref="Color"/>) en couleur HSV (<see cref="HSVColor"/>).
		/// </summary>
		/// <param name="color">Couleur (<see cref="Color"/>).</param>
		/// <returns></returns>
		public static HSVColor RGBtoHSV(Color color)
        {
			return HSVColor.FromRGB(color);
        }

        /// <summary>
        /// Permet de convertir une couleur HSV en couleur RGB.
        /// </summary>
        /// <param name="h">Luminosité.</param>
        /// <param name="S">Saturation.</param>
        /// <param name="V">Valeur.</param>
        /// <param name="r">Rouge.</param>
        /// <param name="g">Vert.</param>
        /// <param name="b">Bleu.</param>
        public static Color HSVtoRGB(double h, double S, double V, out int r, out int g, out int b)
        {
            // Code par
            // T. Nathan Mundhenk
            // mundhenk@usc.edu

            double H = h;
            while (H < 0) { H += 360; };
            while (H >= 360) { H -= 360; };
            double R, G, B;
            if (V <= 0)
            { R = G = B = 0; }
            else if (S <= 0)
            {
                R = G = B = V;
            }
            else
            {
                double hf = H / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = V * (1 - S);
                double qv = V * (1 - S * f);
                double tv = V * (1 - S * (1 - f));
                switch (i)
                {

                    // Red is the dominant color

                    case 0:
                        R = V;
                        G = tv;
                        B = pv;
                        break;

                    // Green is the dominant color

                    case 1:
                        R = qv;
                        G = V;
                        B = pv;
                        break;
                    case 2:
                        R = pv;
                        G = V;
                        B = tv;
                        break;

                    // Blue is the dominant color

                    case 3:
                        R = pv;
                        G = qv;
                        B = V;
                        break;
                    case 4:
                        R = tv;
                        G = pv;
                        B = V;
                        break;

                    // Red is the dominant color

                    case 5:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

                    case 6:
                        R = V;
                        G = tv;
                        B = pv;
                        break;
                    case -1:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // The color is not defined, we should throw an error.

                    default:
                        R = G = B = V; // Just pretend its black/white
                        break;
                }
            }
            r = Clamp((int)(R * 255.0));
            g = Clamp((int)(G * 255.0));
            b = Clamp((int)(B * 255.0));
            Color color = Color.FromArgb(r, g, b);
            return color;
        }

        /// <summary>
        /// Clamp a value to 0-255
        /// </summary>
        private static int Clamp(int i)
        {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return i;
        }
    }

	/// <summary>
	/// Structure d'une couleur HSV.
	/// </summary>
    public struct HSVColor
    {
		// Note : Ce code provient initialement de ce projet : https://www.codeproject.com/questions/996265/rgb-to-hsv-conversion
		// Il a été ici amélioré

		/// <summary>
		/// Luminosié.
		/// </summary>
		public float Hue;

		/// <summary>
		/// Saturation.
		/// </summary>
		public float Saturation;

		/// <summary>
		/// Valeur.
		/// </summary>
		public float Value;

		/// <summary>
		/// Permet de créer une couleur HSV à partir d'une couleur (<see cref="Color"/>).
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
		/// Permet de créer une couleur HSV à partir d'une couleur (<see cref="Color"/>).
		/// </summary>
		/// <param name="red">Rouge.</param>
		/// <param name="green">Vert.</param>
		/// <param name="blue">Bleu.</param>
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
	/// Structure d'une couleur HEX.
	/// </summary>
    public struct HEXColor
    {
		
    }
}
