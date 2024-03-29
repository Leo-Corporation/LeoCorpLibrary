﻿/*
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

namespace LeoCorpLibrary.Core
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
		/// Converts radians to degrees.
		/// </summary>
		/// <param name="radians">Radians to convert.</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double RadiansToDegrees(double radians)
		{
			return radians * 57.2957795; // Degrees
		}

		/// <summary>
		/// Converts degrees to radians.
		/// </summary>
		/// <param name="degrees">Degrees to convert.</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double DegreesToRadians(double degrees)
		{
			return degrees / 57.2957795; // Radians
		}

		/// <summary>
		/// Returns <c>true</c> if the given <see cref="double"/> number is an integer (<see cref="int"/>).
		/// </summary>
		/// <param name="number">The number to test.</param>
		/// <returns>A <see cref="bool"/> value.</returns>
		public static bool IsInteger(double number) => (double)(int)number == number;

		/// <summary>
		/// Gets the opposite of a specified number.
		/// </summary>
		/// <param name="n">The number to get the opposite.</param>
		/// <returns>A <see cref="double"/> value.</returns>
		/// <example>If 10 is specified, the method will return -10.</example>
		public static double GetOpposite(double n) => 0 - n;

		/// <summary>
		/// Gets the positive of any number.
		/// </summary>
		/// <param name="n">The number you want to get the positive of.</param>
		/// <returns>A <see cref="double"/> value, the positive of the number.</returns>
		public static double GetPositive(double n) => n >= 0 ? n : -n;

		/// <summary>
		/// Gets the negative of any number.
		/// </summary>
		/// <param name="n">The number you want to get the negative of.</param>
		/// <returns>A <see cref="double"/> value, the ngeative of the number.</returns>
		public static double GetNegative(double n) => n <= 0 ? n : -n;

		/// <summary>
		/// Gets the results/images of specified numbers after applying to them a function. (<c>f(x) = x</c>)
		/// </summary>
		/// <param name="function">The function to apply.</param>
		/// <param name="numbers">The numbers you want to get the results after applying specific function.</param>
		/// <returns>An array of <see cref="double"/>.</returns>
		public static double[] GetResultsOf(Func<double, double> function, params double[] numbers) 
		{
			double[] results = new double[numbers.Length]; // Create a new array that will contain the results once the other method is applied to each number
			for (int i = 0; i < numbers.Length; i++) // For each number
			{
				results[i] = function(numbers[i]); // Apply the method to the number
			}
			return results; // Return the results
		}

		/// <summary>
		/// Returns the factorial of a specified number.
		/// </summary>
		/// <param name="n">The number to get the factorial.</param>
		/// <returns>A <see cref="int"/> value.</returns>
		/// <remarks>If you provide a number which the factorial will exeed <see cref="int.MaxValue"/>, the method will return <c>0</c>, or a wrong result.</remarks>
		public static int Factorial(int n)
		{
			if (n == 1 || n == 0) return 1;
			int r = 1;

			for (int i = 1; i <= (n < 0 ? 0 - n : n); i++)
			{
				r *= i;
			}

			return n < 0 ? 0 - r : r;
		}

		/// <summary>
		/// Gets if the number is positive or not.
		/// </summary>
		/// <param name="n">The number to check.</param>
		/// <returns>Returns <see langword="true"/> if the number is positive, a <see cref="bool"/> value.</returns>
		public static bool IsPositive(double n) => n > 0;

		/// <summary>
		/// Gets if the number is negative or not.
		/// </summary>
		/// <param name="n">The number to check.</param>
		/// <returns>Returns <see langword="true"/> if the number is negative, a <see cref="bool"/> value.</returns>
		public static bool IsNegative(double n) => n < 0;

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

			/// <summary>
			/// Returns <c>true</c> if a triangle is right.
			/// </summary>
			/// <param name="side1">A side of the triangle</param>
			/// <param name="side2">A side of the triangle</param>
			/// <param name="side3">A side of the triangle</param>
			/// <returns>A <see cref="bool"/> value.</returns>
			public static bool IsRight(double side1, double side2, double side3)
			{
				double hypotenuse = GetBiggestNumber(side1, side2, side3); // Get hypotenuse

				if (hypotenuse == side1)
				{
					return (side1 * side1) == (side2 * side2) + (side3 * side3); // Pythagorus
				}
				else if (hypotenuse == side2)
				{
					return (side1 * side2) == (side1 * side1) + (side3 * side3); // Pythagorus
				}
				else
				{
					return (side3 * side3) == (side2 * side2) + (side1 * side1); // Pythagorus
				}
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
			/// <param name="length">length of the pyramid.</param>
			/// <param name="width">Width of the pyramid.</param>
			/// <param name="height">Height of the pyramid.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetVolume(double length, double width, double height)
			{
				return length * width * (height / 3); // Retourner le résultat
			}

			/// <summary>
			/// Allows you to get the height of a pyramid.
			/// </summary>
			/// <param name="width">Width of the pyramid.</param>
			/// <param name="length">length of the pyramid.</param>
			/// <param name="volume">Volume.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetHeight(double width, double length, double volume)
			{
				return 3 * (volume / (width * length)); // Retourner le résultat
			}

			/// <summary>
			/// Allows you to get the length of the base of a pyramid.
			/// </summary>
			/// <param name="areaBase">Base's area.</param>
			/// <param name="width">Width of the pyramid.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetLengthBase(double areaBase, double width)
			{
				return areaBase / width; // Retourner le résultat
			}

			/// <summary>
			/// Allows you to get hte width of the base of a pyramid.
			/// </summary>
			/// <param name="areaBase">Base's are.</param>
			/// <param name="length">length of the pyramid.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetWidthBase(double areaBase, double length)
			{
				return areaBase / length; // Retourner le résultat
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
			/// <param name="length">The length of the rectangle.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetDiagonal(double width, double length)
			{
				return Math.Sqrt(width * width + length * length); // Get diagonal
			}

			/// <summary>
			/// Gets the area of a rectangle
			/// </summary>
			/// <param name="width">The width of the rectangle.</param>
			/// <param name="length">The length of the rectangle.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetArea(double width, double length)
			{
				return width * length; // Get area
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
			/// <param name="side">The length of the side of the diamond.</param>
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
			/// <param name="side">The length of the side of the hexagon.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetPerimeter(double side)
			{
				return 6 * side; // Get the perimeter
			}

			/// <summary>
			/// Allows you to get the area of an hexagon from it's side.
			/// </summary>
			/// <param name="side">The length of the side of the hexagon.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetArea(double side)
			{
				return 3 * (Math.Sqrt(3) / 2) * side * side; // Get the area
			}
		}

		/// <summary>
		/// Trigonometry related methods.
		/// </summary>
		public static class Trigonometry
		{
			/// <summary>
			/// Gets a triangle's opposed side from an angle and its hypotenuse.
			/// </summary>
			/// <param name="angle">The angle value (in radians).</param>
			/// <param name="hypotenuse">The hypotenuse length value.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetTriangleOpposedSideFromHypotenuse(double angle, double hypotenuse)
			{
				return Math.Sin(angle) * hypotenuse; // Return the opposed side
			}

			/// <summary>
			/// Gets a triangle's opposed side from an angle and its adjacent side.
			/// </summary>
			/// <param name="angle">The angle value (in radians).</param>
			/// <param name="adjacent">The adjacent side length value.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetTriangleOpposedSideFromAdjacent(double angle, double adjacent)
			{
				return Math.Tan(angle) * adjacent; // Return the opposed side
			}

			/// <summary>
			/// Gets a triangle's adjacent side from an angle and its hypotenuse.
			/// </summary>
			/// <param name="angle">The angle value (in radians).</param>
			/// <param name="hypotenuse">The hypotenuse length value.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetTriangleAdjacentSideFromHypotenuse(double angle, double hypotenuse)
			{
				return Math.Cos(angle) * hypotenuse; // Return the adjacent side
			}

			/// <summary>
			/// Gets a triangle's adjacent side from an angle and its opposed side.
			/// </summary>
			/// <param name="angle">The angle value (in radians).</param>
			/// <param name="opposed">The opposed side length value.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetTriangleAdjacentSideFromOpposedSide(double angle, double opposed)
			{
				return opposed / Math.Tan(angle); // Return the adjacent side
			}

			/// <summary>
			/// Gets a triangl's hypotenuse from an angle and its opposed side.
			/// </summary>
			/// <param name="angle">The angle value (in radians).</param>
			/// <param name="opposed">The opposed side length value.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetTriangleHypotenuseFromOpposedSide(double angle, double opposed)
			{
				return opposed / Math.Sin(angle); // Return the hypotenuse
			}

			/// <summary>
			/// Gets a triangl's hypotenuse from an angle and its adjacent side.
			/// </summary>
			/// <param name="angle">The angle value (in radians).</param>
			/// <param name="adjacent">The adjacent side length value.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetTriangleHypotenuseFromAdjacentSide(double angle, double adjacent)
			{
				return adjacent / Math.Cos(angle); // Return the hypotenuse
			}
		}

		/// <summary>
		/// Class that contains methods for spheres.
		/// </summary>
		public static class Sphere
		{
			/// <summary>
			/// Gets the area of a sphere.
			/// </summary>
			/// <param name="radius">The radius of the sphere.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetArea(double radius)
			{
				return 4 * Math.PI * (radius * radius);
			}

			/// <summary>
			/// Gets the volume of a sphere.
			/// </summary>
			/// <param name="radius">The radius of the sphere.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetVolume(double radius)
			{
				return 4 * Math.PI * (radius * radius * radius) / 3;
			}
		}

		/// <summary>
		/// Class that contains methods for cones.
		/// </summary>
		public static class Cone
		{
			/// <summary>
			/// Gets the volume of cone.
			/// </summary>
			/// <param name="radius">The radius of the cone.</param>
			/// <param name="height">The height of the cone.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetVolume(double radius, double height)
			{
				return Math.PI * (radius * radius) * height / 3;
			}
		}

		/// <summary>
		/// Class that contains percentage-related methods.
		/// </summary>
		public static class Percentage
		{
			/// <summary>
			/// Gets the result after an increase of x% of a specified value.
			/// </summary>
			/// <param name="value">The base value.</param>
			/// <param name="increaseRate">The evolution rate, in the following format: <c>x/100d</c>.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetResultPercentageIncrease(double value, double increaseRate) => (1 + increaseRate) * value;

			/// <summary>
			/// Gets the result after an decrease of x% of a specified value.
			/// </summary>
			/// <param name="value">The base value.</param>
			/// <param name="decreaseRate">The evolution rate, must be positive, in the following format: <c>x/100d</c>.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetResultPercentageDecrease(double value, double decreaseRate) => (decreaseRate >= 0) ? (1 - decreaseRate) * value : GetResultPercentageIncrease(value, decreaseRate);

			/// <summary>
			/// Gets the inverse of a specified evolution rate. For instance, if we have a decrease of 50%, <c>t = -0.5</c>, to get back to the orginal value, <c>t' = 1/(1+t)-1 = 1</c>.
			/// </summary>
			/// <remarks>To get the multiplier, add 1 to the returned value.</remarks>
			/// <param name="evolutionRate">The evolution rate to get the inverse of, in the following format: <c>x/100d</c>.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static double GetInvertedEvolutionRate(double evolutionRate) => 1 / (1 + evolutionRate) - 1;

			/// <summary>
			/// Gets the formatted string of a proportion.
			/// </summary>
			/// <example>For instance, 150/200 will return 75%.</example>
			/// <param name="proportion">The proportion to get the percentage of.</param>
			/// <returns>A <see cref="double"/> value.</returns>
			public static string ProportionToPercentageString(double proportion) => $"{proportion * 100}%";
		}
	}
}
