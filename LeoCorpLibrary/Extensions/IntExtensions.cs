using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary.Extensions
{
    public static class IntExtensions
    {
        public static bool IsEven(this int value)
        {
            string str = value.ToString(); // Convert to string

            if (str.EndsWith("0") || str.EndsWith("2") || str.EndsWith("4") || str.EndsWith("6") || str.EndsWith("8")) // Check if the latest number is even
            {
                return true; // The number is even
            }
            else
            {
                return false; // The number is odd
            }
        }
    }
}
