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
	/// Class that contains methods related to unit conversions.
	/// </summary>
	public static class UnitsConversions
	{
		/// <summary>
		/// Converts miles to kilometers.
		/// </summary>
		/// <param name="miles">Number of mile(s) to convert.</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double MilesToKm(double miles) => miles * 1.609344; // Convert

		/// <summary>
		/// Converts kilometers to miles.
		/// </summary>
		/// <param name="kilometers">Number of kilometer(s) to convert.</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double KmToMiles(double kilometers) => kilometers / 1.609344; // Convert

		public static double CelsiusToFahrenheit(double celsius) => celsius * 1.8 + 32; // Convert

		public static double FahrenheitToCelsius(double fahrenheit) => (fahrenheit - 32) / 1.8; // Convert
	}
}
