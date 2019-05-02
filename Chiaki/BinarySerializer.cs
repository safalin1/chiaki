using System.IO;
using System.Runtime.Serialization;
using System.Xml;
// ReSharper disable UnusedMember.Global

namespace Chiaki
{
    public static class BinarySerializer
    {
        /// <summary>
        /// Serializes an instance of an object to binary - useful for writing to the filesystem or over the network.
        /// </summary>
        /// <returns>Byte array containing serialized <typeparamref name="T"/></returns>
        public static byte[] Serialize<T>(T obj)
        {
            var serializer = new DataContractSerializer(typeof(T));
            var stream = new MemoryStream();

            using (var writer = XmlDictionaryWriter.CreateBinaryWriter(stream))
            {
                serializer.WriteObject(writer, obj);
            }

            return stream.ToArray();
        }

        /// <summary>
        /// Deserializes an object instances from a byte array.
        /// </summary>
        /// <returns>Deserialized instance of <typeparamref name="T"/></returns>
        public static T Deserialize<T>(byte[] data)
        {
            var serializer = new DataContractSerializer(typeof(T));

            using (var stream = new MemoryStream(data))
            using (var reader = XmlDictionaryReader.CreateBinaryReader(stream, XmlDictionaryReaderQuotas.Max))
            {
                return (T)serializer.ReadObject(reader);
            }
        }
    }
}