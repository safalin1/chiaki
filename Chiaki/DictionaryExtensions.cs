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
        public static NameValueCollection ToNameValueCollection(this IDictionary<string, string> d)
        {
            var n = new NameValueCollection();

            foreach (var i in d)
            {
                n.Add(i.Key, i.Value);
            }

            return n;
        }
    }
}