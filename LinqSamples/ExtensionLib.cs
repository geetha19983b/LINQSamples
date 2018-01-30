using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSamples
{
    static class ExtensionLib
    {
        public static IEnumerable<T> DoubleUp<T>(this IEnumerable<T> source)
        {
            foreach(var s in source)
            {
                yield return s;
                yield return s;
            }
        }
    }
}
