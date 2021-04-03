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

namespace LeoCorpLibrary
{
    /// <summary>
    /// Class that contains methods relatives to maths.
    /// </summary>
    public static class Maths
    {
        /// <summary>
        /// Allows you to do a sum of <see cref="double"/> numbers.
        /// </summary>
        /// <param name="args">Numbers.</param>
        /// <returns>A <see cref="double"/> value.</returns>
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
        /// Allows you to get the lowest number from specified <see cref="double"/> numbers.
        /// </summary>
        /// <param name="numbers">Numbers.</param>
        /// <returns>A <see cref="double"/> value.</returns>
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
        /// Allows you to get the biggest number from specified <see cref="double"/> numbers.
        /// </summary>
        /// <param name="numbers">Numbers.</param>
        /// <returns>A <see cref="double"/> value.</returns>
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
        /// Class that coontains methods for circles.
        /// </summary>
        public static class Circle
        {
            /// <summary>
            /// Allows you to get the area of a circle.
            /// </summary>
            /// <param name="radius">Circle's radius</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetArea(double radius) // Obtenir l'aire d'un cercle
            {
                return Math.PI * radius * radius; // Formule
            }

            /// <summary>
            /// Allows you to get the perimeter of a circle.
            /// </summary>
            /// <param name="radius">Circle's radius.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetPerimeter(double radius) // Obtenir le périmètre d'un cercle
            {
                return 2 * Math.PI * radius; // Formule
            }
        }

        /// <summary>
        /// Class that contains methods for triangles.
        /// </summary>
        public static class Triangle
        {
            /// <summary>
            /// Allows you to get the area of triangle from it's height and width/base.
            /// </summary>
            /// <param name="height">Triangle's height.</param>
            /// <param name="width">Triangle's base/width.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetArea(double height, double width) // Obtenir l'aire d'un triangle
            {
                return height * width / 2; // Formule
            }

            /// <summary>
            /// Allows you to get the perimeter of a triangle.
            /// </summary>
            /// <param name="side1">Triangle's side.</param>
            /// <param name="side2">Triangle's side.</param>
            /// <param name="side3">Triangle's side.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetPerimeter(double side1, double side2, double side3) // Obtenir le périmètre d'un triangle
            {
                return Sum(side1, side2, side3); // Formule
            }


            /// <summary>
            /// Allows you to get a triangle's hypotenuse from its sides, using Pythagore.
            /// </summary>
            /// <param name="side1">The first side of the triangle.</param>
            /// <param name="side2">The second side of the triangle.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetHypotenuse(double side1, double side2)
            {
                return Math.Sqrt(side1 * side1 + side2 * side2); // Get hypotenuse (Pythagore)
            }

            /// <summary>
            /// Allows you to know if a triangle is buildable or not.
            /// </summary>
            /// <param name="side1">Triangle's side.</param>
            /// <param name="side2">Triangle's side.</param>
            /// <param name="side3">Triangle's side.</param>
            /// <returns>A <see cref="bool"/> value.</returns>
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
        /// Class that contains methods for cubes.
        /// </summary>
        public static class Cube
        {
            /// <summary>
            /// Allows you to get the volume of a cube/cuboid.
            /// </summary>
            /// <param name="side">Cube's side.</param>
            /// <param name="height">Cube's height.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetVolume(double side, double height)
            {
                return side * side * height; // Retourne le résultat
            }

            /// <summary>
            /// Allows you to get the volume of cube.
            /// </summary>
            /// <param name="side">Cube's side.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetVolume(double side)
            {
                return side * side * side; // Retourner le résultat
            }

            /// <summary>
            /// Allows you to get the edge of a cube.
            /// </summary>
            /// <param name="area">Area.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetEdge(double area)
            {
                return Math.Sqrt(area / 6); // Retourner le résultat
            }
        }

        /// <summary>
        /// Class that contains methods for cylinders.
        /// </summary>
        public static class Cylinder
        {
            /// <summary>
            /// Allows you to get the volume of a cylinder.
            /// </summary>
            /// <param name="radius">Radius.</param>
            /// <param name="height">Height.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetVolume(double radius, double height)
            {
                return Math.PI * radius * radius * height; // Retourner le résultat
            }

            /// <summary>
            /// Allows you to get the height of cylinder.
            /// </summary>
            /// <param name="area">Area.</param>
            /// <param name="radius">Radius.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetHeight(double area, double radius)
            {
                return area / (2 * Math.PI * radius) - radius; // Retourner le résultat
            }

            /// <summary>
            /// Allows you to get the area of cylinder.
            /// </summary>
            /// <param name="radius">Radius.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetBaseArea(double radius)
            {
                return Math.PI * radius * radius; // Retourner le résultat
            }
        }

        /// <summary>
        /// Class that contains methods for pyramids.
        /// </summary>
        public static class Pyramid
        {
            /// <summary>
            /// Allows you to get the volume of a pyramid.
            /// </summary>
            /// <param name="lenght">Lenght of the pyramid.</param>
            /// <param name="width">Width of the pyramid.</param>
            /// <param name="height">Height of the pyramid.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetVolume(double lenght, double width, double height)
            {
                return lenght * width * (height / 3); // Retourner le résultat
            }

            /// <summary>
            /// Allows you to get the height of a pyramid.
            /// </summary>
            /// <param name="width">Width of the pyramid.</param>
            /// <param name="lenght">Lenght of the pyramid.</param>
            /// <param name="volume">Volume.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetHeight(double width, double lenght, double volume)
            {
                return 3 * (volume / (width * lenght)); // Retourner le résultat
            }

            /// <summary>
            /// Allows you to get the lenght of the base of a pyramid.
            /// </summary>
            /// <param name="areaBase">Base's area.</param>
            /// <param name="width">Width of the pyramid.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetLenghtBase(double areaBase, double width)
            {
                return areaBase / width; // Retourner le résultat
            }

            /// <summary>
            /// Allows you to get hte width of the base of a pyramid.
            /// </summary>
            /// <param name="areaBase">Base's are.</param>
            /// <param name="lenght">Lenght of the pyramid.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetWidthBase(double areaBase, double lenght)
            {
                return areaBase / lenght; // Retourner le résultat
            }
        }

        /// <summary>
        /// Class that contains methods for rectangles.
        /// </summary>
        public static class Rectangle
        {
            /// <summary>
            /// Allows you to get a rectangle's diagonal.
            /// </summary>
            /// <param name="width">The width of the rectangle.</param>
            /// <param name="lenght">The lenght of the rectangle.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetDiagonal(double width, double lenght)
            {
                return Math.Sqrt(width * width + lenght * lenght); // Get diagonal
            }
        }

        /// <summary>
        /// Class that contains methods for diamonds.
        /// </summary>
        public static class Diamond
        {
            /// <summary>
            /// Allows you to get the perimeter of diamond from it's side.
            /// </summary>
            /// <param name="side">The lenght of the side of the diamond.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetPerimeter(double side)
            {
                return 4 * side; // Get perimeter
            }

            /// <summary>
            /// Allows you to get the area of a diamond.
            /// </summary>
            /// <param name="diag1">The diagonal of the diamond.</param>
            /// <param name="diag2">The diagonal of the diamond.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetArea(double diag1, double diag2)
            {
                return diag1 * (diag2 / 2); // Get the area
            }
        }

        /// <summary>
        /// Class that contains methods for hexagons.
        /// </summary>
        public static class Hexagon
        {
            /// <summary>
            /// Allows you to get the perimeter of an hexagon from it's side.
            /// </summary>
            /// <param name="side">The lenght of the side of the hexagon.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetPerimeter(double side)
            {
                return 6 * side; // Get the perimeter
            }

            /// <summary>
            /// Allows you to get the area of an hexagon from it's side.
            /// </summary>
            /// <param name="side">The lenght of the side of the hexagon.</param>
            /// <returns>A <see cref="double"/> value.</returns>
            public static double GetArea(double side)
            {
                return 3 * (Math.Sqrt(3) / 2) * side * side; // Get the area
            }
        }

        public static class Trigonometry
		{
            public static double GetTriangleOpposedSide(double angle, double hypotenuse)
			{
                return Math.Sin(angle) * hypotenuse; // Return the opposed side
			}
		}
    }
}
