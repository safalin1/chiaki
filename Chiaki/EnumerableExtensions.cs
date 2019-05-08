using System;
using System.Collections.Generic;
using System.Linq;

namespace Chiaki
{
    /// <summary>
    /// Provides common extensions for IEnumerables.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Creates a new Array containing the <typeparamref name="T"/> item.
        /// </summary>
        public static T[] AsArray<T>(this T item)
        {
            return new[] { item };
        }

        /// <summary>
        /// Creates a new List containing the <typeparamref name="T"/> item.
        /// </summary>
        public static List<T> AsList<T>(this T item)
        {
            return new List<T> { item };
        }

        /// <summary>
        /// Performs a DistinctBy the specified key instead of using an IEqualityComparer.
        /// </summary>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            var seenKeys = new HashSet<TKey>();

            foreach (TSource element in source)
            {
                if (seenKeys.Add(selector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Orders the items in the IEnumerable in a random sequence.
        /// </summary>
        public static IEnumerable<T> OrderByRandom<T>(this IEnumerable<T> query)
        {
            return query.OrderBy(q => Guid.NewGuid());
        }
    }
}
