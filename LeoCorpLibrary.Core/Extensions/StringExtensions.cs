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
using System.Linq;

namespace LeoCorpLibrary.Core.Extensions
{
	/// <summary>
	/// Methods that extends the <see cref="string"/> type.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Counts the number of words in a <see cref="string"/>.
		/// </summary>
		/// <param name="value">The <see cref="string"/> where the words should be counted.</param>
		/// <returns>A <see cref="int"/> value.</returns>
		public static int CountWords(this string value)
		{
			if (value.Length <= 0) // If the length of the string is less or equal to 0
			{
				throw new ArgumentException("The 'value' argument cannot be null or empty"); // Error
			}

			string[] words = value.Split(new string[] { " ", ",", ";", ".", ":", "!", "?" }, StringSplitOptions.RemoveEmptyEntries); // Get all the words
			return words.Length; // Number of words
		}

		/// <summary>
		/// Counts the number of words in a <see cref="string"/>.
		/// </summary>
		/// <param name="value">The <see cref="string"/> where the words should be counted.</param>
		/// <param name="wordSeparator">The separator of the words. Example: ", ; : ! ? .  ".</param>
		/// <returns>A <see cref="int"/> value.</returns>
		public static int CountWords(this string value, string[] wordSeparator)
		{
			if (value.Length <= 0) // If the length of the string is less or equal to 0
			{
				throw new ArgumentException("The 'value' argument cannot be null or empty"); // Error
			}

			string[] words = value.Split(wordSeparator, StringSplitOptions.RemoveEmptyEntries); // Get all the words
			return words.Length; // Number of words
		}

		/// <summary>
		/// Encrypts a <see cref="string"/>.
		/// </summary>
		/// <param name="source">The <see cref="string"/> to encrypt.</param>
		/// <param name="key">The key that will be used to encrypt and decrypt the string.</param>
		/// <returns>A <see cref="string"/> value.</returns>
		public static string Encrypt(this string source, string key)
		{
			return Crypt.Encrypt(source, key); // Return the encrypted string
		}

		/// <summary>
		/// Decrypts an encrypted <see cref="string"/>.
		/// </summary>
		/// <param name="encrypt">The encrypted <see cref="string"/>.</param>
		/// <param name="key">The key that will be used to encrypt and decrypt the string.</param>
		/// <returns>A <see cref="string"/> value.</returns>
		public static string Decrypt(this string encrypt, string key)
		{
			return Crypt.Decrypt(encrypt, key); // Return the decrypted value
		}

		/// <summary>
		/// Allows you to upper the first letter of a <see cref="string"/>.
		/// </summary>
		/// <param name="s">The <see cref="string"/>.</param>
		/// <returns>A <see cref="string"/> value.</returns>
		public static string UpperFirstLetter(this string s)
		{
			if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s)) // If the string is null, empty, or contains only whitespaces
			{
				throw new ArgumentNullException(nameof(s), "The specified string shouldn't be null, empty, or only equal to whitespaces."); // Error
			}

			return s.Substring(0, 1).ToUpper() + s.Remove(0, 1); // Upper the first letter
		}

		/// <summary>
		/// Uppers letter(s) of a specified string from a starting postion and a length.
		/// </summary>
		/// <param name="s">The <see cref="string"/>.</param>
		/// <param name="startIndex">The index where the letter(s) should be uppered.</param>
		/// <param name="length">The length of the part of the <see cref="string"/> that should be uppered.</param>
		/// <returns>A <see cref="string"/> value.</returns>
		public static string UpperLettersAt(this string s, int startIndex, int length)
		{
			if (length <= 0) // If the length is equal or lower than 0
			{
				throw new ArgumentNullException(nameof(length), "The 'length' parameter should be at least equal to 1."); // Error
			}

			if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s)) // If the string is null, empty, or contains only whitespaces
			{
				throw new ArgumentNullException(nameof(s), "The specified string shouldn't be null, empty, or only equal to whitespaces."); // Error
			}

			string r = ""; // Final string
			for (int i = 0; i < s.Length; i++) // For each character
			{
				if (i >= startIndex && i <= length) // If should be in upper case
				{
					r += s[i].ToString().ToUpper(); // Upper
				}
				else
				{
					r += s[i].ToString(); // Do nothing
				}
			}
			return r; // Return result
		}

		/// <summary>
		/// Checks if a <see cref="string"/> is ending with the same punctuation than an other one.
		/// </summary>
		/// <param name="s">The <see cref="string"/> to check.</param>
		/// <param name="stringToCheck">The <see cref="string"/> to compare.</param>
		/// <returns>A <see cref="bool"/> value.</returns>
		public static bool IsEndingWithSamePunctuation(this string s, string stringToCheck)
		{
			return s[s.Length - 1].ToString() == stringToCheck[stringToCheck.Length - 1].ToString(); // Return true or false
		}

		/// <summary>
		/// Checks if a <see cref="string"/> is ending with the same punctuation than an other one.
		/// </summary>
		/// <param name="s">The <see cref="string"/> to check.</param>
		/// <param name="stringToCheck">The <see cref="string"/> to compare.</param>
		/// <param name="punctuationToCheck">The punctuation sign to check for.</param>
		/// <returns>A <see cref="bool"/> value.</returns>
		public static bool IsEndingWithSamePunctuation(this string s, string stringToCheck, string punctuationToCheck)
		{
			return s.EndsWith(punctuationToCheck) && stringToCheck.EndsWith(punctuationToCheck); // Return true or false
		}

		/// <summary>
		/// Splits a <see cref="string"/> lines to an array.
		/// </summary>
		/// <param name="s">The<see cref="string"/>.</param>
		/// <returns>A <see cref="string"/>[] value.</returns>
		public static string[] SplitLines(this string s) => s.Split(new string[] { "\n", "\r", "\r\n" }, StringSplitOptions.None);

		/// <summary>
		/// Checks if a letter is being repeated in a <see cref="string"/>.
		/// </summary>
		/// <param name="s"></param>
		/// <returns>A <see cref="bool"/> value.</returns>
		public static bool HasRepeatedCharacters(this string s)
		{
			return !s.Where((c, i) => i >= 2 && s[i - 1] == c && s[i - 2] == c).Any();
		}
	}
}
