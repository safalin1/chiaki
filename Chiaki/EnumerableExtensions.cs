using System;
using System.Collections.Generic;
using System.Linq;

namespace Chiaki;

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
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }

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
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        var matches = list.Where(predicate).ToArray();
        foreach (var match in matches)
        {
            list.Remove(match);
        }
    }

    /// <summary>
    /// If <paramref name="input"/> is null, an empty instance of <see cref="IEnumerable{T}"/> will be returned. Otherwise, the existing instance will be returned.
    /// </summary>
    public static IEnumerable<T> IfNullThenEmpty<T>(this IEnumerable<T> input)
    {
        return input ?? Enumerable.Empty<T>();
    }

    /// <summary>
    /// Applies a filter on a sequence only if <paramref name="condition"/> is met.
    /// </summary>
    public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return condition
            ? source.Where(predicate)
            : source;
    }

    /// <summary>
    /// Applies a filter on a sequence only if <paramref name="condition"/> is met.
    /// </summary>
    public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, int, bool> predicate)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return condition
            ? source.Where(predicate)
            : source;
    }

    /// <summary>
    /// Bypasses a specified number of items in a sequence only if <paramref name="condition"/> is met.
    /// </summary>
    public static IEnumerable<TSource> SkipIf<TSource>(this IEnumerable<TSource> source, bool condition, int count)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return condition
            ? source.Skip(count)
            : source;
    }

    /// <summary>
    /// Returns true if all items in the other enumerable exist in the source enumerable.
    /// </summary>
    public static bool ContainsAll<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        return !other.Except(source).Any();
    }

    /// <summary>
    /// Returns true if the source enumerable contains any of the items in the other enumerable.
    /// </summary>
    public static bool ContainsAny<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        return other.Any(source.Contains);
    }

    /// <summary>
    /// Splits the source enumerable into a series of partitions.
    /// </summary>
    /// <param name="source">IEnumerable instance to split</param>
    /// <param name="size">Size of each partition.</param>
    public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> source, int size)
    {
        if (size <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be greater than 0.");
        }

        var chunk = new List<T>(size);

        foreach (var x in source) 
        {
            chunk.Add(x);

            if (chunk.Count < size) 
            {
                continue;
            }

            yield return chunk;

            chunk = new List<T>(size);
        }

        if (chunk.Any()) 
        {
            yield return chunk;
        }
    }

    /// <summary>
    /// Filters a sequence to ignore items which are null.
    /// </summary>
    /// <returns>A filtered sequence, where all items are not null.</returns>
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> source)
        where T : class
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return source.Where(x => x != null);
    }
}