using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary.Exceptions
{
    /// <summary>
    /// Se produit lorsqu'une valeur HEX n'est pas valide.
    /// </summary>
    public class HEXInvalidValueException : Exception
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="HEXInvalidValueException"/>.
        /// </summary>
        public HEXInvalidValueException()
        {

        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="HEXInvalidValueException"/> avec un message d'erreur spécifié.
        /// </summary>
        /// <param name="message">Message d'erreur qui explique la raison de l'exception.</param>
        public HEXInvalidValueException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="HEXInvalidValueException"/> avec un message d'erreur spécifié.
        /// </summary>
        /// <param name="message">Message d'erreur qui explique la raison de l'exception.</param>
        /// <param name="innerException">Exception à l'origine de l'exception actuelle, ou une référence null (Nothing
        /// en Visual Basic) si aucune exception interne n'est spécifiée.</param>
        public HEXInvalidValueException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
