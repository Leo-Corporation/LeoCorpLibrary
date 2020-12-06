using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary.Core.Exceptions
{
    /// <summary>
    /// Is thrown when a RGB color is invalid.
    /// </summary>
    public class RGBInvalidValueException : Exception
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="RGBInvalidValueException"/> class.
        /// </summary>
        public RGBInvalidValueException()
        {

        }

        /// <summary>
        /// Initialize a new instance of the <see cref="RGBInvalidValueException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">Message of the error.</param>
        public RGBInvalidValueException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initialize a new instance of the <see cref="RGBInvalidValueException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">Message of the error.</param>
        /// <param name="innerException">The inner exception that cause this exception.</param>
        public RGBInvalidValueException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
