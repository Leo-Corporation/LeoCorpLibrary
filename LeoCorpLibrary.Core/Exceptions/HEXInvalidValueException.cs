using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary.Core.Exceptions
{
    /// <summary>
    /// Is thrown when an HEX color is invalid.
    /// </summary>
    public class HEXInvalidValueException : Exception
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="HEXInvalidValueException"/> class.
        /// </summary>
        public HEXInvalidValueException()
        {

        }

        /// <summary>
        /// Initialize a new instance of the <see cref="HEXInvalidValueException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">Message of the error</param>
        public HEXInvalidValueException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initialize a new instance of the <see cref="HEXInvalidValueException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">Message of the error.</param>
        /// <param name="innerException">The inner exception that cause this exception.</param>
        public HEXInvalidValueException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
