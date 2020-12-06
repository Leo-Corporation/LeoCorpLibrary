using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LeoCorpLibrary.Core
{
    /// <summary>
    /// Methods to encrypt/decrypt <see cref="string"/>.
    /// </summary>
    public static class Crypt
    {
        /// <summary>
        /// Encrypts a <see cref="string"/>.
        /// </summary>
        /// <param name="source">The <see cref="string"/> to encrypt.</param>
        /// <param name="key">The key that will be used to encrypt and decrypt the string.</param>
        /// <returns>A <see cref="string"/> value.</returns>
        public static string Encrypt(string source, string key)
        {
            using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider()) // Create MD5CryptoServiceProvider
                {
                    byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    byte[] data = Encoding.UTF8.GetBytes(source); // Encrypt
                    return Convert.ToBase64String(tripleDESCryptoService.CreateEncryptor().TransformFinalBlock(data, 0, data.Length)); // Return the encrypted string
                }
            }
        }

        /// <summary>
        /// Decrypts an encrypted <see cref="string"/>.
        /// </summary>
        /// <param name="encrypt">The encrypted <see cref="string"/>.</param>
        /// <param name="key">The key that will be used to encrypt and decrypt the string.</param>
        /// <returns>A <see cref="string"/> value.</returns>
        public static string Decrypt(string encrypt, string key)
        {
            using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider()) // Create MD5CryptoServiceProvider
                {
                    byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    byte[] data = Convert.FromBase64String(encrypt); // Decrypt
                    return Encoding.UTF8.GetString(tripleDESCryptoService.CreateDecryptor().TransformFinalBlock(data, 0, data.Length)); // Return the decrypted string
                }
            }
        }
    }
}
