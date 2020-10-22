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

namespace LeoCorpLibrary.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] Append<T>(this T[] array, T item)
        {
            if (array.Length == 0) // If the array is empty
            {
                return new T[] { item }; // Return a new array with the item
            }

            T[] items = { item }; // Create an array with the items
            return new List<T>(array.Concat(items)).ToArray(); // Return the final array
        }

        public static T[] Append<T>(this T[] array, params T[] items)
        {
            if (array.Length == 0) // If the array is empty
            {
                T[] finalArrayEmpty = new T[items.Length]; // Final array
                
                for (int i = 0; i < items.Length; i++) // For each item
                {
                    finalArrayEmpty[i] = items[i]; // Add each item to the array
                }

                return finalArrayEmpty; // Return final array
            }

            T[] finalArray = new T[items.Length]; // Create an array

            for (int i = 0; i < items.Length; i++) // For each item
            {
                finalArray[i] = items[i]; // Add each item to the array
            }

            return new List<T>(array.Concat(finalArray)).ToArray(); // Return the final array
        }
    }
}
