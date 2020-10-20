using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary.Extensions
{
    public static class StringExtensions
    {
        public static int CountWord(this string value)
        {
            string[] words = value.Split(new string[] { " ", ",", ";", ".", ":", "!", "?" }, StringSplitOptions.RemoveEmptyEntries); // Get all the words
            return words.Length; // Number of words
        }
    }
}
