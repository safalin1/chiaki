using System;

namespace Chiaki
{
    /// <summary>
    /// Represents a singleton instance of a class
    /// </summary>
    /// <typeparam name="T">Type of the singleton</typeparam>
    public class Singleton<T> where T : new()
    {
        private static readonly Lazy<T> _instance = new Lazy<T>(() => new T());

        /// <summary>
        /// Gets a singleton instance of <typeparamref name="T"/>
        /// </summary>
        public static T Instance => _instance.Value;
    }
}