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
