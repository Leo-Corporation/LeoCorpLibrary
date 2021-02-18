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
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary
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
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>A <see cref="string"/> value.</returns>
        public static string Encrypt(string source, string key)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException(nameof(source), "The string cannot be null.");
            }

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
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>A <see cref="string"/> value.</returns>
        public static string Decrypt(string encrypt, string key)
        {
            if (string.IsNullOrEmpty(encrypt))
            {
                throw new ArgumentNullException(nameof(encrypt), "The string cannot be null.");
            }

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

        /// <summary>
        /// Encrypts a <see cref="string"/> using RSA encryption.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to encrypt.</param>
        /// <param name="rsaParameters">The RSA Key.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>A <see cref="byte"/>[] value.</returns>
        public static byte[] EncryptRSA(string str, RSAParameters rsaParameters)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(nameof(str), "The string cannot be null.");
            }

            UnicodeEncoding unicodeEncoding = new UnicodeEncoding(); // Create a new UnicodeEncoding

            byte[] encryptedData;
            using (RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider())
            {
                rSACryptoServiceProvider.ImportParameters(rsaParameters);
                encryptedData = rSACryptoServiceProvider.Encrypt(unicodeEncoding.GetBytes(str), false); // Encrypt
            }
            return encryptedData; // Return byte[]
        }

        /// <summary>
        /// Decrypts a <see cref="string"/> using RSA encryption.
        /// </summary>
        /// <param name="encrypted">The encrypted <see cref="string"/>.</param>
        /// <param name="rsaParameters">The RSA Key.</param>
        /// <returns>A <see cref="byte"/>[] value.</returns>
        public static byte[] DecryptRSA(byte[] encrypted, RSAParameters rsaParameters)
        {
            byte[] decryptedData;
            using (RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider())
            {
                rSACryptoServiceProvider.ImportParameters(rsaParameters);
                decryptedData = rSACryptoServiceProvider.Decrypt(encrypted, false); // Decrypt
            }
            return decryptedData; // Return byte[]
        }

        /// <summary>
        /// Converts <see cref="byte"/>[] into a <see cref="string"/>.
        /// </summary>
        /// <param name="bytesToConvert">The bytes to convert.</param>
        /// <returns>A <see cref="string"/> value.</returns>
        public static string ConvertBytesToString(byte[] bytesToConvert)
        {
            return Encoding.Unicode.GetString(bytesToConvert); // Return
        }

        /// <summary>
        /// Encrypt a <see cref="string"/> using AES ecnryption.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to encrypt.</param>
        /// <param name="key">The key.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>A <see cref="string"/> value.</returns>
        public static string EncryptAES(string str, string key)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(nameof(str), "The string cannot be null.");
            }

            byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int BlockSize = 128;

            byte[] bytes = Encoding.Unicode.GetBytes(str); // Convert


            SymmetricAlgorithm crypt = Aes.Create(); // Create AES
            HashAlgorithm hash = MD5.Create(); // Create MD5

            crypt.BlockSize = BlockSize; // Define block size
            crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(key)); // Create key
            crypt.IV = IV; // IV

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, crypt.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytes, 0, bytes.Length);
                }

                return Convert.ToBase64String(memoryStream.ToArray()); // Convert and return
            }
        }

        /// <summary>
        /// Decrypts a <see cref="string"/> using AES ecnryption.
        /// </summary>
        /// <param name="encrypted">The <see cref="string"/> to decrypt.</param>
        /// <param name="key">The key.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>A <see cref="string"/> value.</returns>
        public static string DecryptAES(string encrypted, string key)
        {
            if (string.IsNullOrEmpty(encrypted))
            {
                throw new ArgumentNullException(nameof(encrypted), "The string cannot be null.");
            }

            byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            byte[] bytes = Convert.FromBase64String(encrypted); // Convert string to byte[]

            SymmetricAlgorithm crypt = Aes.Create(); // Create AES
            HashAlgorithm hash = MD5.Create(); // Create MD5

            crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(key)); // Key
            crypt.IV = IV;

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                using (CryptoStream cryptoStream =
                   new CryptoStream(memoryStream, crypt.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    byte[] decryptedBytes = new byte[bytes.Length];
                    cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                    return Encoding.Unicode.GetString(decryptedBytes); // Return
                }
            }
        }
    }
}
