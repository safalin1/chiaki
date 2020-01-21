using System.Collections.Generic;
using System.Collections.Specialized;

namespace Chiaki
{
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
    }
}