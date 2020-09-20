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
using LeoCorpLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary
{
    /// <summary>
    /// A class that contains methods to generate Guids.
    /// </summary>
    public static class GuidGenerator
    {
        /// <summary>
        /// Generates a new Guid and convert it's value to a string value.
        /// </summary>
        /// <returns>A <see cref="string"/> value.</returns>
        public static string Generate()
        {
            return Guid.NewGuid().ToString(); // Return the value
        }

        /// <summary>
        /// Generates a new Guid and convert it's value to a string value.
        /// </summary>
        /// <param name="lenght">Lenght of the Guid.</param>
        /// <exception cref="InvalidGuidLenghtException"></exception>
        /// <returns>A <see cref="string"/> value.</returns>
        public static string Generate(int lenght)
        {
            if (lenght <= 0 || lenght > 32) // If the lenght is invalid
            {
                throw new InvalidGuidLenghtException("The lenght of a Guid must be higher than 0."); // Error
            }
            return Guid.NewGuid().ToString("N").Substring(0, lenght); // Return the value
        }

        /// <summary>
        /// Generates a Guid from a specified <see cref="string"/>.
        /// </summary>
        /// <param name="fromString">Generate the guid from a specified <see cref="string"/>.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>A <see cref="string"/> value.</returns>
        public static string Generate(string fromString)
        {
            if (string.IsNullOrEmpty(fromString)) // If no value is specified
            {
                throw new ArgumentNullException("'fromString' is null or empty.");
            }

            MD5 mD5 = MD5.Create();
            byte[] data = mD5.ComputeHash(Encoding.Default.GetBytes(fromString)); // Get the bytes
            return new Guid(data).ToString();
        }

        /// <summary>
        /// Generates a new Guid from <see cref="GuidGeneratorParameters"/>.
        /// </summary>
        /// <param name="guidGeneratorParameters">Parameters of the Guid Generation.</param>
        /// <exception cref="InvalidGuidLenghtException"></exception>
        /// <returns>A <see cref="string"/> value.</returns>
        public static string Generate(GuidGeneratorParameters guidGeneratorParameters)
        {
            Guid guid = Guid.NewGuid();
            string result = guid.ToString();

            if (guidGeneratorParameters.Lenght <= 0 || guidGeneratorParameters.Lenght > 32) // If the lenght is invalid
            {
                throw new InvalidGuidLenghtException("The lenght of a Guid must be higher than 0."); // Error
            }

            if (guidGeneratorParameters.UseUpperCaseOnly)
            {
                if (guidGeneratorParameters.WithBraces && !guidGeneratorParameters.WithHyphens)
                {
                    result = "{" + guid.ToString("N").ToUpper() + "}";
                }
                else if (!guidGeneratorParameters.WithBraces && guidGeneratorParameters.WithHyphens)
                {
                    result = guid.ToString().ToUpper();
                }
                else if (guidGeneratorParameters.WithBraces && guidGeneratorParameters.WithHyphens)
                {
                    result = guid.ToString("B").ToUpper();
                }
                else if (!guidGeneratorParameters.WithBraces && !guidGeneratorParameters.WithHyphens)
                {
                    result = guid.ToString("N").ToUpper();
                }
            }
            else
            {
                if (guidGeneratorParameters.WithBraces && !guidGeneratorParameters.WithHyphens)
                {
                    result = "{" + guid.ToString("N") + "}";
                }
                else if (!guidGeneratorParameters.WithBraces && guidGeneratorParameters.WithHyphens)
                {
                    result = guid.ToString();
                }
                else if (guidGeneratorParameters.WithBraces && guidGeneratorParameters.WithHyphens)
                {
                    result = guid.ToString("B");
                }
                else if (!guidGeneratorParameters.WithBraces && !guidGeneratorParameters.WithHyphens)
                {
                    result = guid.ToString("N");
                }
            }

            return result.Substring(0, guidGeneratorParameters.Lenght);
        }

        /// <summary>
        /// Generates a new Guid from string and from <see cref="GuidGeneratorParameters"/>.
        /// </summary>
        /// <param name="fromString">Generate the guid from a specified <see cref="string"/>.</param>
        /// <param name="guidGeneratorParameters">Parameters of the Guid Generation.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidGuidLenghtException"></exception>
        /// <returns>A <see cref="string"/> value.</returns>
        public static string Generate(string fromString, GuidGeneratorParameters guidGeneratorParameters)
        {
            if (string.IsNullOrEmpty(fromString)) // If no value is specified
            {
                throw new ArgumentNullException("'fromString' is null or empty.");
            }

            if (guidGeneratorParameters.Lenght <= 0 || guidGeneratorParameters.Lenght > 32) // If the lenght is invalid
            {
                throw new InvalidGuidLenghtException("The lenght of a Guid must be higher than 0."); // Error
            }

            MD5 mD5 = MD5.Create();
            byte[] data = mD5.ComputeHash(Encoding.Default.GetBytes(fromString)); // Get the bytes

            Guid guid = new Guid(data);
            string result = guid.ToString();

            if (guidGeneratorParameters.UseUpperCaseOnly)
            {
                if (guidGeneratorParameters.WithBraces && !guidGeneratorParameters.WithHyphens)
                {
                    result = "{" + guid.ToString("N").ToUpper() + "}";
                }
                else if (!guidGeneratorParameters.WithBraces && guidGeneratorParameters.WithHyphens)
                {
                    result = guid.ToString().ToUpper();
                }
                else if (guidGeneratorParameters.WithBraces && guidGeneratorParameters.WithHyphens)
                {
                    result = guid.ToString("B");
                }
                else if (!guidGeneratorParameters.WithBraces && !guidGeneratorParameters.WithHyphens)
                {
                    result = guid.ToString("N").ToUpper();
                }
            }
            else
            {
                if (guidGeneratorParameters.WithBraces && !guidGeneratorParameters.WithHyphens)
                {
                    result = "{" + guid.ToString("N") + "}";
                }
                else if (!guidGeneratorParameters.WithBraces && guidGeneratorParameters.WithHyphens)
                {
                    result = guid.ToString();
                }
                else if (guidGeneratorParameters.WithBraces && guidGeneratorParameters.WithHyphens)
                {
                    result = guid.ToString("B");
                }
                else if (!guidGeneratorParameters.WithBraces && !guidGeneratorParameters.WithHyphens)
                {
                    result = guid.ToString("N");
                }
            }

            return result.Substring(0, guidGeneratorParameters.Lenght);
        }
    }
}
