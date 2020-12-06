using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary.Core
{
    /// <summary>
    /// A class that can be used in <see cref="GuidGenerator.Generate()"/> as an argument.
    /// </summary>
    public class GuidGeneratorParameters
    {
        /// <summary>
        /// The constructor for <see cref="GuidGeneratorParameters"/>.
        /// </summary>
        public GuidGeneratorParameters()
        {
            Lenght = 32; // Set the default value
            WithHyphens = true; // Set the default value
            WithBraces = false; // Set the default value
            UseUpperCaseOnly = false; // Set the default value
        }

        /// <summary>
        /// Lenght of the Guid to generate.
        /// </summary>
        public int Lenght { get; set; }

        /// <summary>
        /// Include or not hyphens, such as: <c>00000000-0000-0000-0000-00000000</c>
        /// </summary>
        public bool WithHyphens { get; set; }

        /// <summary>
        /// Include or not braces, such as: <c>{00000000-0000-0000-0000-00000000}</c>
        /// </summary>
        public bool WithBraces { get; set; }

        /// <summary>
        /// Use only upper case if true. Uses only lower case if false.
        /// </summary>
        public bool UseUpperCaseOnly { get; set; }
    }
}
