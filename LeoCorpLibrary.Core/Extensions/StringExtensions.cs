using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (value.Length <= 0) // If the lenght of the string is less or equal to 0
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
            if (value.Length <= 0) // If the lenght of the string is less or equal to 0
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
    }
}
