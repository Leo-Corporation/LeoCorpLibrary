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
