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

        public static TimeSpan Sum(this IEnumerable<TimeSpan> times)
        {
            var total = TimeSpan.Zero;
            foreach (var time in times)
            {
                total += time;
            }
            return total;
        }
        public static string Concat(this IEnumerable<string> strings, string separator)
        {
            return string.Join(separator, strings);
        }
    }
}
