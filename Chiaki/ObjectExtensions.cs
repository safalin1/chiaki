using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Chiaki
{
    /// <summary>
    /// Provides miscellaneous extensions for <see cref="object"/>
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns a deep clone of an object.
        /// </summary>
        public static T DeepClone<T>(this T input)
            where T : ISerializable
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, input);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
