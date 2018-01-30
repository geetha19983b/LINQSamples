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
        public static string Concat(this IEnumerable<string> strings, string separator)
        {
            return string.Join(separator, strings);
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
        public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(this IEnumerable<TSource> source,
                                                                                   Func<TSource, TKey> selector)
        {
            var counts = new Dictionary<TKey, int>();
            foreach (var item in source)
            {
                var key = selector(item);
                if (!counts.ContainsKey(key))
                {
                    counts[key] = 1;
                }
                else
                {
                    counts[key]++;
                }
            }
            return counts;
        }
    }
}
