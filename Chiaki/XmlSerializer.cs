using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
// ReSharper disable UnusedMember.Global

namespace Chiaki
{
    /// <summary>
    /// Provides the ability to serialise an object instance to and from XML.
    /// </summary>
    public static class XmlSerializer
    {
        /// <summary>
        /// Serialise an object instance to an XML string, using the default DataContractSerializer for the type.
        /// </summary>
        /// <returns>String containing the serialized data.</returns>
        public static string SerializeToXmlString<T>(T obj) => Encoding.UTF8.GetString(Serialize(obj));

        /// <summary>
        /// Serialise an object instance to an XML string, allowing for a DataContractSerializer to be specified.
        /// </summary>
        /// <returns>String containing the serialized data.</returns>
        public static string SerializeToXmlString<T>(T obj, DataContractSerializer serializer) => Encoding.UTF8.GetString(Serialize(obj, serializer));

        /// <summary>
        /// Serialise an object instance to XML, using the default DataContractSerializer for the type.
        /// </summary>
        /// <returns>Byte array containing the serialized data.</returns>
        public static byte[] Serialize<T>(T obj) => Serialize(obj, new DataContractSerializer(typeof(T)));

        /// <summary>
        /// Serialise an object instance to XML, allowing for a DataContractSerializer to be specified.
        /// </summary>
        /// <returns>Byte array containing the serialized data.</returns>
        public static byte[] Serialize<T>(T obj, DataContractSerializer serializer)
        {
            var stream = new MemoryStream();

            using (var writer = XmlDictionaryWriter.CreateTextWriter(stream))
            {
                serializer.WriteObject(writer, obj);
            }

            return stream.ToArray();
        }

        /// <summary>
        /// Deserializes an object from a byte array containing XML data.
        /// </summary>
        /// <returns>Instance of the deserialized object.</returns>
        public static T Deserialize<T>(byte[] data) => Deserialize<T>(data, new DataContractSerializer(typeof(T)));

        /// <summary>
        /// Deserializes an object from a byte array containing XML data, using an existing DataContractSerializer.
        /// </summary>
        /// <returns>Instance of the deserialized object.</returns>
        public static T Deserialize<T>(byte[] data, DataContractSerializer serializer)
        {
            using (var stream = new MemoryStream(data))
            using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(stream, XmlDictionaryReaderQuotas.Max))
            {
                return (T)serializer.ReadObject(reader);
            }
        }
    }
}