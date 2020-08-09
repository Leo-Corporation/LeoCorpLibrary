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

namespace LeoCorpLibrary.Exceptions
{
    /// <summary>
    /// Se produit lorsqu'une valeur RGB n'est pas valide.
    /// </summary>
    public class RGBInvalidValueException : Exception
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="RGBInvalidValueException"/>.
        /// </summary>
        public RGBInvalidValueException()
        {

        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="RGBInvalidValueException"/> avec un message d'erreur spécifié.
        /// </summary>
        /// <param name="message">Message d'erreur qui explique la raison de l'exception.</param>
        public RGBInvalidValueException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="RGBInvalidValueException"/> avec un message d'erreur spécifié.
        /// </summary>
        /// <param name="message">Message d'erreur qui explique la raison de l'exception.</param>
        /// <param name="innerException">Exception à l'origine de l'exception actuelle, ou une référence null (Nothing
        /// en Visual Basic) si aucune exception interne n'est spécifiée.</param>
        public RGBInvalidValueException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
