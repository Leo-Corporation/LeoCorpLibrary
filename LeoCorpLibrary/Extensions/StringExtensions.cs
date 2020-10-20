using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary.Extensions
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
        public static int CountWord(this string value)
        {
            if (value.Length <= 0)
            {
                throw new ArgumentException("The 'value' argument cannot be null or empty");
            }

            string[] words = value.Split(new string[] { " ", ",", ";", ".", ":", "!", "?" }, StringSplitOptions.RemoveEmptyEntries); // Get all the words
            return words.Length; // Number of words
        }
    }
}
