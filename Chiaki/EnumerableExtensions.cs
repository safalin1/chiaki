using System;
using System.Collections.Generic;
using System.Linq;

namespace Chiaki
{
    /// <summary>
    /// Provides extensions for <see cref="IEnumerable{T}"/>.
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

        /// <summary>
        /// Removes all matching items from an <see cref="IList{T}"/>.
        /// </summary>
        public static void RemoveAll<T>(this IList<T> list, Func<T, bool> predicate)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (predicate(list[i]))
                {
                    list.RemoveAt(i--);
                }
            }
        }

        /// <summary>
        /// Removes all matching items from an <see cref="ICollection{T}"/>.
        /// </summary>
        public static void RemoveAll<T>(this ICollection<T> list, Func<T, bool> predicate)
        {
            var matches = list.Where(predicate).ToArray();
            foreach (var match in matches)
            {
                list.Remove(match);
            }
        }

        /// <summary>
        /// If the IEnumerable is null, an empty instance of the IEnumerable will be returned. Otherwise, the existing instance will be returned.
        /// </summary>
        public static IEnumerable<T> IfNullThenEmpty<T>(this IEnumerable<T> input)
        {
            return input ?? Enumerable.Empty<T>();
        }

        /// <summary>
        /// Applies a filter on the sequence only if <paramref name="condition"/> is met.
        /// </summary>
        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate)
        {
            return condition
                ? source.Where(predicate)
                : source;
        }

        /// <summary>
        /// Applies a filter on the sequence only if <paramref name="condition"/> is met.
        /// </summary>
        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, int, bool> predicate)
        {
            return condition
                ? source.Where(predicate)
                : source;
        }

        /// <summary>
        /// Returns true if all items in the other enumerable exist in the source enumerable.
        /// </summary>
        public static bool ContainsAll<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (other == null) throw new ArgumentNullException(nameof(other));

            return !other.Except(source).Any();
        }

        /// <summary>
        /// Returns true if the source enumerable contains any of the items in the other enumerable.
        /// </summary>
        public static bool ContainsAny<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other)
        {
            return other.Any(source.Contains);
        }
    }
}
