using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary.Core.Exceptions
{
    /// <summary>
    /// Is thrown when the lenght of a Guid is invalid
    /// </summary>
    public class InvalidGuidLenghtException : Exception
    {
        /// <summary>
        /// Initialize a new instance of the class <see cref="InvalidGuidLenghtException"/>.
        /// </summary>
        public InvalidGuidLenghtException()
        {

        }

        /// <summary>
        /// Initialize a new instance of the class <see cref="InvalidGuidLenghtException"/> with a specified error message.
        /// </summary>
        /// <param name="message">Message of the error</param>
        public InvalidGuidLenghtException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initialize a new instance of the class <see cref="InvalidGuidLenghtException"/> with a specified error message.
        /// </summary>
        /// <param name="message">Message of the error</param>
        /// <param name="innerException">The inner exception that cause this exception.</param>
        public InvalidGuidLenghtException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
