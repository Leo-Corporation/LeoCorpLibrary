using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary.Core.Extensions
{
    /// <summary>
    /// Methods that extends arrays.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Adds an item to an existing array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array where the item is going to be append.</param>
        /// <param name="item">The item which is going to be append in the array.</param>
        /// <returns>An <see cref="Array"/>.</returns>
        public static T[] Append<T>(this T[] array, T item)
        {
            if (array.Length == 0) // If the array is empty
            {
                return new T[] { item }; // Return a new array with the item
            }

            T[] items = { item }; // Create an array with the items
            return new List<T>(array.Concat(items)).ToArray(); // Return the final array
        }

        /// <summary>
        /// Adds items to an existing array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array where the items are going to be append.</param>
        /// <param name="items">The items which are going to be append in the array.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>An <see cref="Array"/>.</returns>
        public static T[] Append<T>(this T[] array, params T[] items)
        {
            if (items.Length <= 0) // If there is no items
            {
                throw new ArgumentNullException($"The '{nameof(items)}' parameter cannot be null or empty."); // Error
            }

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

        /// <summary>
        /// Removes a specific item from an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array where the item is going to be removed.</param>
        /// <param name="item">The item to remove.</param>
        /// <returns>An <see cref="Array"/>.</returns>
        public static T[] RemoveItem<T>(this T[] array, T item)
        {
            if (array.Length <= 0) // If the array is null or empty
            {
                throw new ArgumentNullException($"The '{nameof(array)}' parameter cannot be null or empty."); // Error
            }

            List<T> list = new List<T>(array); // Create list from the array
            list.Remove(item); // Remove the item
            return list.ToArray(); // Return the new array
        }

        /// <summary>
        /// Removes a specific item from an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array where the items are going to be removed.</param>
        /// <param name="items">The items to remove.</param>
        /// <returns>An <see cref="Array"/>.</returns>
        public static T[] RemoveItem<T>(this T[] array, params T[] items)
        {
            if (array.Length <= 0) // If the array is null or empty
            {
                throw new ArgumentNullException($"The '{nameof(array)}' parameter cannot be null or empty."); // Error
            }

            List<T> list = new List<T>(array); // Create list from array

            foreach (T item in items) // For each item
            {
                if (list.Contains(item)) // If the mist contains the item
                {
                    list.Remove(item); // Remove the item
                }
            }

            return list.ToArray(); // Return the new array
        }
    }
}
