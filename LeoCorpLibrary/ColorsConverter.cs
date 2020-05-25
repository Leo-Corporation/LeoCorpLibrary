using LeoCorpLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary
{
    /// <summary>
    /// Classe permettant de convertir des types de couleur.
    /// </summary>
    public static class ColorsConverter
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
        /// Permet de convertir une couleur RGB en couleur HEX (<see cref="HEXColor"/>).
        /// </summary>
        /// <param name="red">Rouge.</param>
        /// <param name="green">Vert.</param>
        /// <param name="blue">Bleu.</param>
        /// <returns>Valeur <see cref="HEXColor"/>.</returns>
        public static HEXColor RGBtoHEX(int red, int green, int blue)
        {
            return HEXColor.FromRGB(red, green, blue);
        }

        /// <summary>
        /// Permet de convertir une couleur RGB (<see cref="Color"/>) en couleur HEX (<see cref="HEXColor"/>).
        /// </summary>
        /// <param name="color"></param>
        /// <returns>Valeur <see cref="HEXColor"/>.</returns>
        public static HEXColor RGBtoHEX(Color color)
        {
            return HEXColor.FromRGB(color);
        }

        /// <summary>
        /// Permet de convertir une couleur HEX (<see cref="HEXColor"/>) en couleur RGB (<see cref="Color"/>).
        /// </summary>
        /// <param name="hexColor">Couleur HEX.</param>
        /// <exception cref="Exceptions.HEXInvalidValueException"/>
        /// <returns>Valeur <see cref="HEXColor"/></returns>
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
        /// Permet de convertir une couleur HEX (<see cref="HEXColor"/>) en couleur HSV (<see cref="HSVColor"/>).
        /// </summary>
        /// <param name="hexColor"></param>
        /// <exception cref="Exceptions.HEXInvalidValueException"/>
        /// <returns>Valeur <see cref="HSVColor"/></returns>
        public static HSVColor HEXtoHSV(HEXColor hexColor)
        {
            HSVColor hSVColor = new HSVColor();
            hSVColor = RGBtoHSV(HEXtoRGB(hexColor));
            return hSVColor;
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
        /// Teinte.
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
        /// <returns>Valeur <see cref="HSVColor"/></returns>
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
        /// <exception cref="Exceptions.RGBInvalidValueException"/>
        /// <returns>Valeur <see cref="HSVColor"/></returns>
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
    /// Structure d'une couleur HEX.
    /// </summary>
    public struct HEXColor
    {

        /// <summary>
        /// Valeur de la couleur.
        /// </summary>
        public string Value;

        /// <summary>
        /// Permet de créer une couleur HEX (<see cref="HEXColor"/>) à partir d'une couleur (<see cref="Color"/>)
        /// </summary>
        /// <param name="color">Couleur (<see cref="Color"/>).</param>
        /// <returns>Valeur <see cref="HEXColor"/>.</returns>
        public static HEXColor FromRGB(Color color)
        {
            HEXColor toReturn = new HEXColor();
            toReturn.Value = ColorTranslator.FromHtml(String.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B)).Name.Remove(0, 2);
            return toReturn;
        }

        /// <summary>
        /// Permet de créer une couleur HEX (<see cref="HEXColor"/>) à partir de valeurs <see cref="int"/>.
        /// </summary>
        /// <param name="red">Rouge.</param>
        /// <param name="blue">Bleu.</param>
        /// <param name="green">Vert</param>
        /// <exception cref="Exceptions.RGBInvalidValueException"/>
        /// <returns>Valeur <see cref="HEXColor"/></returns>
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
