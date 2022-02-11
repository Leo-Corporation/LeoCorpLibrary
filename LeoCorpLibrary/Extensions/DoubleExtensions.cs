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

namespace LeoCorpLibrary.Extensions
{
	/// <summary>
	/// Methods that extends the <see cref="double"/> type.
	/// </summary>
	public static class DoubleExtensions
	{
		/// <summary>
		/// Converts to seconds a <see cref="TimeUnits"/>.
		/// </summary>
		/// <param name="d">The time unit to convert.</param>
		/// <param name="timeUnits">The unit of the time. (ex: minutes, hours...)</param>
		/// <returns>A <see cref="double"/> value.</returns>
		public static double ToSeconds(this double d, TimeUnits timeUnits)
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
		public static double ToMinutes(this double d, TimeUnits timeUnits)
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
		public static double ToHours(this double d, TimeUnits timeUnits)
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
	}

	/// <summary>
	/// Time units such as milliseconds, seconds, minutes, etc...
	/// </summary>
	public enum TimeUnits
	{
		/// <summary>
		/// Milliseconds.
		/// </summary>
		Milliseconds,

		/// <summary>
		/// Seconds.
		/// </summary>
		Seconds,

		/// <summary>
		/// Minutes.
		/// </summary>
		Minutes,

		/// <summary>
		/// Hours.
		/// </summary>
		Hours,

		/// <summary>
		/// Days.
		/// </summary>
		Days
	}
}
