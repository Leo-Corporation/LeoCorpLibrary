using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] Append<T>(this T[] array, T item)
        {
            T[] items = { item };
            return new List<T>(array.Concat(items)).ToArray();
        }
    }
}
