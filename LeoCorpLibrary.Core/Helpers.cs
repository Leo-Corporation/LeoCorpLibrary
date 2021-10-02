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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeoCorpLibrary.Core
{
	/// <summary>
	/// Contains usefull methods that don't fit in other categories.
	/// </summary>
	public static class Helpers
	{
		/// <summary>
		/// Checks if a specified URL is valid or not.
		/// </summary>
		/// <param name="url">The URL to check.</param>
		/// <returns>A <see cref="bool"/> value.</returns>
		public static bool IsUrlValid(string url)
		{
			Regex regex = new Regex("[a-zA-Z]+://[a-zA-Z]+\\.[a-zA-Z]+", RegexOptions.IgnoreCase);
			return regex.IsMatch(url);
		}

		/// <summary>
		/// Gets the URL's protocol as a string.
		/// </summary>
		/// <param name="url">The URL.</param>
		/// <returns>A <see cref="string"/> value.</returns>
		public static string GetUrlProtocol(string url) => url.Split(new string[] { "://" }, StringSplitOptions.None)[0];

		/// <summary>
		/// Returns <c>true</c> if the url's protocol is "HTTPS".
		/// </summary>
		/// <param name="url">The URL to check.</param>
		/// <returns>A <see cref="bool"/> value.</returns>
		public static bool IsUrlHttps(string url) => GetUrlProtocol(url) == "https";
	}
}
