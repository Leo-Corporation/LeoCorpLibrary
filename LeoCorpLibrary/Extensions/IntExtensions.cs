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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary.Extensions
{
    /// <summary>
    /// Methods that extends the <see cref="int"/> type.
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Determines if the <see cref="int"/> value is even.
        /// </summary>
        /// <param name="value">The <see cref="int"/> to check.</param>
        /// <returns>A <see cref="bool"/> value.</returns>
        public static bool IsEven(this int value)
        {
            string str = value.ToString(); // Convert to string

            if (str.EndsWith("0") || str.EndsWith("2") || str.EndsWith("4") || str.EndsWith("6") || str.EndsWith("8")) // Check if the latest number is even
            {
                return true; // The number is even
            }
            else
            {
                return false; // The number is odd
            }
        }
    }
}
