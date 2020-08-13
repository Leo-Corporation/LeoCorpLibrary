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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary
{
    /// <summary>
    /// Classe regroupant des méthodes liées aux mathématiques.
    /// </summary>
    public static class Maths
    {
        /// <summary>
        /// Permet de faire une somme de nombres de type double.
        /// </summary>
        /// <param name="args">Nombres.</param>
        /// <returns>Valeur de type <see cref="double"/>.</returns>
        public static double Sum(params double[] args) // Somme
        {
            double finalResult = 0;
            foreach (double arg in args)
            {
                finalResult += arg; // Ajoute les nombres
            }
            return finalResult;
        }

        /// <summary>
        /// Permet d'obtneir à partir d'une liste de nombre de type double, le plus petit d'entre eux.
        /// </summary>
        /// <param name="numbers">Nombres.</param>
        /// <returns>Valeur de type <see cref="double"/>.</returns>
        public static double GetLowestNumber(params double[] numbers)
        {
            double lowestNumber = numbers[0];
            foreach (double number in numbers)
            {
                if (number < lowestNumber)
                {
                    lowestNumber = number;
                }
            }
            return lowestNumber;
        }

        /// <summary>
        /// Permet d'obtenir à partir d'une liste de nombre de type double, le plus grand d'entre eux.
        /// </summary>
        /// <param name="numbers">Nombres.</param>
        /// <returns>Valeur de type <see cref="double"/>.</returns>
        public static double GetBiggestNumber(params double[] numbers) // Obtient le nombre le plus grand
        {
            double biggestNumber = numbers[0]; // Fonction compatible avec des nombres négatifs
            foreach (double number in numbers) // Pour chaque nombre
            {
                if (number > biggestNumber) // Si le nombre est plus grand le plus grand nombre, alors il devient le plus grand nombre
                {
                    biggestNumber = number;
                }
            }
            return biggestNumber;
        }

        /// <summary>
        /// Classe regroupant des méthodes liées aux cercles.
        /// </summary>
        public static class Circle
        {
            /// <summary>
            /// Permet d'obtenir l'aire d'un cercle à partir d'un rayon donné.
            /// </summary>
            /// <param name="radius">Rayon du cercle.</param>
            /// <returns>Valeur de type <see cref="double"/>.</returns>
            public static double GetArea(double radius) // Obtenir l'aire d'un cercle
            {
                return Math.PI * Math.Sqrt(radius); // Formule
            }

            /// <summary>
            /// Permet d'obtenir le périmètre d'un cercle à partir d'un rayon donné.
            /// </summary>
            /// <param name="radius">Rayon du cercle.</param>
            /// <returns>Valeur de type <see cref="double"/>.</returns>
            public static double GetPerimeter(double radius) // Obtenir le périmètre d'un cercle
            {
                return 2 * Math.PI * radius; // Formule
            }
        }

        /// <summary>
        /// Classe regroupant des méthodes liées aux triangles.
        /// </summary>
        public static class Triangle
        {
            /// <summary>
            /// Permet d'obtenir l'aire d'un triangle à partir de la hauteur et de la base de ce dernier.
            /// </summary>
            /// <param name="height">Hauteur du triangle.</param>
            /// <param name="weight">Largeur/base du triangle.</param>
            /// <returns>Valeur de type <see cref="double"/>.</returns>
            public static double GetArea(double height, double weight) // Obtenir l'aire d'un triangle
            {
                return height * weight / 2; // Formule
            }

            /// <summary>
            /// Permet d'obtenir le prérimètre d'un triangle, à partir de la longueur de ses côtés.
            /// </summary>
            /// <param name="side1">Côté du triangle.</param>
            /// <param name="side2">Côté du triangle.</param>
            /// <param name="side3">Côté du triangle.</param>
            /// <returns>Valeur de type <see cref="double"/>.</returns>
            public static double GetPerimeter(double side1, double side2, double side3) // Obtenir le périmètre d'un triangle
            {
                return Sum(side1, side2, side3); // Formule
            }

            /// <summary>
            /// Permet de connaître si un triangle est construisable ou non à partir des dimentions de ce triangle.
            /// </summary>
            /// <param name="side1">Côté du triangle.</param>
            /// <param name="side2">Côté du triangle.</param>
            /// <param name="side3">Côté du triangle.</param>
            /// <returns>Valeur de type <see cref="bool"/>.</returns>
            public static bool IsBuildable(double side1, double side2, double side3) // Triangle construisable ?
            {
                bool result = false; // Résultat final
                double biggestSide = GetBiggestNumber(side1, side2, side3); // Obtient le grand côté
                if (biggestSide == side1) // Si le grand coté est side1
                {
                    if (biggestSide < (side2 + side3)) // Formule pour savoir si le triangle est construisable
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else if (biggestSide == side2) // Si le grand coté est side2
                {
                    if (biggestSide < (side1 + side3)) // Formule pour savoir si le triangle est construisable
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else if (biggestSide == side3) // Si le grand coté est side3
                {
                    if (biggestSide < (side1 + side2)) // Formule pour savoir si le triangle est construisable
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Classe regroupant des méthodes liées au cube.
        /// </summary>
        public static class Cube
        {
            /// <summary>
            /// Permet d'obtenir le volume d'un cube.
            /// </summary>
            /// <param name="side">Longueur du côté.</param>
            /// <param name="height">Hauteur.</param>
            /// <returns>Valeur de type <see cref="double"/>.</returns>
            public static double GetVolume(double side, double height)
            {
                return side * side * height; // Retourne le résultat
            }

            /// <summary>
            /// Permet d'obtenir le volume d'un cube.
            /// </summary>
            /// <param name="side">Longeur du côté.</param>
            /// <returns>Valeur de type <see cref="double"/>.</returns>
            public static double GetVolume(double side)
            {
                return side * side * side; // Retourner le résultat
            }

            /// <summary>
            /// Permet d'obtenir le bord d'un cube.
            /// </summary>
            /// <param name="area">Aire.</param>
            /// <returns>Valeur de type <see cref="double"/>.</returns>
            public static double GetEdge(double area)
            {
                return Math.Sqrt(area / 6); // Retourner le résultat
            }
        }

        /// <summary>
        /// Classe regroupant des méthodes liées au cylindre
        /// </summary>
        public static class Cylinder
        {
            /// <summary>
            /// Permet d'obtenir le volume d'un cylindre.
            /// </summary>
            /// <param name="radius">Rayon.</param>
            /// <param name="height">Hauteur.</param>
            /// <returns>Valeur de type <see cref="double"/>.</returns>
            public static double GetVolume(double radius, double height)
            {
                return Math.PI * radius * radius * height; // Retourner le résultat
            }

            /// <summary>
            /// Permet d'obtenir la hauteur d'un cylindre.
            /// </summary>
            /// <param name="area">Aire.</param>
            /// <param name="radius">Rayon.</param>
            /// <returns>Valeur de type <see cref="double"/>.</returns>
            public static double GetHeight(double area, double radius)
            {
                return area / (2 * Math.PI * radius) - radius; // Retourner le résultat
            }

            /// <summary>
            /// Permet d'obtenir l'aire de la base d'un cylindre.
            /// </summary>
            /// <param name="radius">Rayon.</param>
            /// <returns>Valeur de type <see cref="double"/>.</returns>
            public static double GetBaseArea(double radius)
            {
                return Math.PI * radius * radius; // Retourner le résultat
            }
        }

        /// <summary>
        /// Classe regroupant des méthodes liées à la pyramide.
        /// </summary>
        public static class Pyramid
        {
            /// <summary>
            /// Permet d'obtenir le volume d'une pyramide.
            /// </summary>
            /// <param name="lenght">Longeur.</param>
            /// <param name="width">Largeur.</param>
            /// <param name="height">Hauteur.</param>
            /// <returns>Valeur de type <see cref="double"/>.</returns>
            public static double GetVolume(double lenght, double width, double height)
            {
                return lenght * width * (height / 3); // Retourner le résultat
            }

            /// <summary>
            /// Permet d'obtenir la hauteur d'une pyramide.
            /// </summary>
            /// <param name="width">Largeur.</param>
            /// <param name="lenght">Longueur.</param>
            /// <param name="volume">Volume.</param>
            /// <returns>Valeur de type <see cref="double"/>.</returns>
            public static double GetHeight(double width, double lenght, double volume)
            {
                return 3 * (volume / (width * lenght)); // Retourner le résultat
            }

            /// <summary>
            /// Permet d'obtenir la longueur de la base.
            /// </summary>
            /// <param name="areaBase">Aire de la base.</param>
            /// <param name="width">Largeur.</param>
            /// <returns>Valeur de type <see cref="double"/>.</returns>
            public static double GetLenghtBase(double areaBase, double width)
            {
                return areaBase / width; // Retourner le résultat
            }

            /// <summary>
            /// Permet d'obtenir la largeur de la base.
            /// </summary>
            /// <param name="areaBase">Aire de la base.</param>
            /// <param name="lenght">Longueur.</param>
            /// <returns>Valeur de type <see cref="double"/>.</returns>
            public static double GetWidthBase(double areaBase, double lenght)
            {
                return areaBase / lenght; // Retourner le résultat
            }
        }
    }
}
