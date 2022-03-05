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

using LeoCorpLibrary.Core.Extensions;
using System;

namespace LeoCorpLibrary.Core
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

		/// <summary>
		/// Converts Celsius (°C) to Fahrenhait (°F).
		/// </summary>
		/// <param name="celsius">Number of Celsius to convert.</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double CelsiusToFahrenheit(double celsius) => celsius * 1.8 + 32; // Convert

		/// <summary>
		/// Converts Fahrenheit (°F) to Celcius (°C).
		/// </summary>
		/// <param name="fahrenheit">Number of Fahrenheit to convert.</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double FahrenheitToCelsius(double fahrenheit) => (fahrenheit - 32) / 1.8; // Convert

		/// <summary>
		/// Converts Cubic Meters (m³) to Litre (L).
		/// </summary>
		/// <param name="m3">Number of Cubic meter(s) to convert.</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double M3ToLitre(double m3) => m3 * 1000; // Convert

		/// <summary>
		/// Converts Litre (L) to Cubic meters (m³).
		/// </summary>
		/// <param name="litre">Number of Litre(s) to convert.</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double LitreToM3(double litre) => litre / 1000; // Convert

		/// <summary>
		/// Converts Feet to Meters.
		/// </summary>
		/// <param name="feet">Number of feet to convert.</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double FeetToMeters(double feet) => feet / 3.2808399; // Convert

		/// <summary>
		/// Converts Meters to Feet.
		/// </summary>
		/// <param name="meters">Number of meters to convert.</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double MetersToFeet(double meters) => meters * 3.2808399; // Convert

		/// <summary>
		/// Converts Pound(s) to Kilogram(s).
		/// </summary>
		/// <param name="pounds">Number of pounds to convert.</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double PoundsToKilograms(double pounds) => pounds / 2.20462262; // Convert

		/// <summary>
		/// Converts Kilogram(s) to Pound(s).
		/// </summary>
		/// <param name="kg">Number of kilograms to convert.</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double KilogramsToPounds(double kg) => kg * 2.20462262; //
																			  // 
		/// <summary>
		/// Converts to seconds a <see cref="TimeUnits"/>.
		/// </summary>
		/// <param name="d">The time unit to convert.</param>
		/// <param name="timeUnits">The unit of the time. (ex: minutes, hours...)</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double TimeUnitToSeconds(this double d, TimeUnits timeUnits)
		{
			switch (timeUnits)
			{
				case TimeUnits.Milliseconds:
					return TimeSpan.FromMilliseconds(d).TotalSeconds; // Convert and Return the expected value
				case TimeUnits.Minutes:
					return TimeSpan.FromMinutes(d).TotalSeconds; // Convert and Return the expected value
				case TimeUnits.Hours:
					return TimeSpan.FromHours(d).TotalSeconds; // Convert and Return the expected value
				case TimeUnits.Days:
					return TimeSpan.FromDays(d).TotalSeconds; // Convert and Return the expected value
				default:
					return d;
			}
		}

		/// <summary>
		/// Converts to minutes a <see cref="TimeUnits"/>.
		/// </summary>
		/// <param name="d">The time unit to convert.</param>
		/// <param name="timeUnits">The unit of the time. (ex: minutes, hours...)</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double TimeUnitToMinutes(this double d, TimeUnits timeUnits)
		{
			switch (timeUnits)
			{
				case TimeUnits.Milliseconds:
					return TimeSpan.FromMilliseconds(d).TotalMinutes; // Convert and Return the expected value
				case TimeUnits.Seconds:
					return TimeSpan.FromSeconds(d).TotalMinutes; // Convert and Return the expected value
				case TimeUnits.Hours:
					return TimeSpan.FromHours(d).TotalMinutes; // Convert and Return the expected value
				case TimeUnits.Days:
					return TimeSpan.FromDays(d).TotalMinutes; // Convert and Return the expected value
				default:
					return d;
			}
		}

		/// <summary>
		/// Converts to hours a <see cref="TimeUnits"/>.
		/// </summary>
		/// <param name="d">The time unit to convert.</param>
		/// <param name="timeUnits">The unit of the time. (ex: minutes, hours...)</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double TimeUnitToHours(this double d, TimeUnits timeUnits)
		{
			switch (timeUnits)
			{
				case TimeUnits.Milliseconds:
					return TimeSpan.FromMilliseconds(d).TotalHours; // Convert and Return the expected value
				case TimeUnits.Seconds:
					return TimeSpan.FromSeconds(d).TotalHours; // Convert and Return the expected value
				case TimeUnits.Minutes:
					return TimeSpan.FromMinutes(d).TotalHours; // Convert and Return the expected value
				case TimeUnits.Days:
					return TimeSpan.FromDays(d).TotalHours; // Convert and Return the expected value
				default:
					return d;
			}
		}

		/// <summary>
		/// Converts to days a <see cref="TimeUnits"/>.
		/// </summary>
		/// <param name="d">The time unit to convert.</param>
		/// <param name="timeUnits">The unit of the time. (ex: minutes, hours...)</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double TimeUnitToDays(this double d, TimeUnits timeUnits)
		{
			switch (timeUnits)
			{
				case TimeUnits.Milliseconds:
					return TimeSpan.FromMilliseconds(d).TotalDays; // Convert and Return the expected value
				case TimeUnits.Seconds:
					return TimeSpan.FromSeconds(d).TotalDays; // Convert and Return the expected value
				case TimeUnits.Minutes:
					return TimeSpan.FromMinutes(d).TotalDays; // Convert and Return the expected value
				case TimeUnits.Hours:
					return TimeSpan.FromHours(d).TotalDays; // Convert and Return the expected value
				default:
					return d;
			}
		}
	}
}
