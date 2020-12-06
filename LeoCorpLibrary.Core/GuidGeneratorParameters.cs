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

namespace LeoCorpLibrary.Core
{
    /// <summary>
    /// A class that can be used in <see cref="GuidGenerator.Generate()"/> as an argument.
    /// </summary>
    public class GuidGeneratorParameters
    {
        /// <summary>
        /// The constructor for <see cref="GuidGeneratorParameters"/>.
        /// </summary>
        public GuidGeneratorParameters()
        {
            Lenght = 32; // Set the default value
            WithHyphens = true; // Set the default value
            WithBraces = false; // Set the default value
            UseUpperCaseOnly = false; // Set the default value
        }

        /// <summary>
        /// Lenght of the Guid to generate.
        /// </summary>
        public int Lenght { get; set; }

        /// <summary>
        /// Include or not hyphens, such as: <c>00000000-0000-0000-0000-00000000</c>
        /// </summary>
        public bool WithHyphens { get; set; }

        /// <summary>
        /// Include or not braces, such as: <c>{00000000-0000-0000-0000-00000000}</c>
        /// </summary>
        public bool WithBraces { get; set; }

        /// <summary>
        /// Use only upper case if true. Uses only lower case if false.
        /// </summary>
        public bool UseUpperCaseOnly { get; set; }
    }
}
