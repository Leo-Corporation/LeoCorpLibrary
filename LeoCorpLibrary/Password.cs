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

namespace LeoCorpLibrary
{
    /// <summary>
    /// Class that contains method to generate passwords.
    /// </summary>
    public static class Password
    {
        /// <summary>
        /// Generates a password.
        /// </summary>
        /// <param name="lenght">Lenght of the password.</param>
        /// <param name="chars">Characters that can be in the generated password.</param>
        /// <param name="separator">Separator of the characters.</param>
        /// <exception cref="Exception"></exception>
        /// <returns>A <see cref="string"/> value.</returns>
        public static string Generate(int lenght, string chars, string separator)
        {
            string[] usableChars = { };
            if (chars.Contains(separator)) // Si les caractères contiennent le séparateur
            {
                usableChars = chars.Split(new string[] { separator }, StringSplitOptions.None); // Séparer les valeurs dans un tableau
            }
            else
            {
                throw new Exception("The parameter 'chars' (string) does not contain the specified seperator.");
            }
            string finalPassword = ""; // Mot de passe final
            Random random = new Random(); // Nombre aléatoire
            int number = 0;
            if (lenght > 0)
            {
                for (int i = 1; i < lenght; i++) // Génération du mot de passe
                {
                    number = random.Next(0, usableChars.Length); // Génération d'un nombre aléatoire
                    finalPassword = finalPassword + usableChars[number];
                }
            }
            else
            {
                throw new Exception("The parameter 'lenght' (int) must be higher than 0.");
            }
            return finalPassword; // Retourne le mot de passe final
        }

        /// <summary>
        /// Generates a password asynchronously.
        /// </summary>
        /// <param name="lenght">Lenght of the password.</param>
        /// <param name="chars">Characters that can be in the generated password.</param>
        /// <param name="separator">Separator of the characters.</param>
        /// <returns>A <see cref="Task{TResult}"/> value.</returns>
        public static Task<string> GenerateAsync(int lenght, string chars, string separator)
        {
            Task<string> task = new Task<string>(() => Generate(lenght, chars, separator));
            task.Start();
            return task;
        }
    }
}
