using System.Collections.Generic;
using System.Collections.Specialized;

namespace Chiaki;

/// <summary>
/// Provides extensions for <see cref="Dictionary{TKey,TValue}"/>
/// </summary>
public static class DictionaryExtensions
{
    /// <summary>
    /// Converts a dictionary instance to a NameValueCollection.
    /// </summary>
    public static NameValueCollection ToNameValueCollection(this IDictionary<string, string> input)
    {
        var collection = new NameValueCollection();

        foreach (var item in input)
        {
            collection.Add(item.Key, item.Value);
        }

        return collection;
    }

    /// <summary>
    /// Adds items from a <see cref="IEnumerable{T}"/> to the <see cref="Dictionary{TKey,TValue}"/>.
    /// </summary>
    public static void AddMany<TKey, TValue>(this Dictionary<TKey, TValue> input, IEnumerable<KeyValuePair<TKey, TValue>> items)
    {
        foreach (KeyValuePair<TKey, TValue> item in items)
        {
            input.Add(item.Key, item.Value);
        }
    }
}