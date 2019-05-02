using System.IO;
using System.Runtime.Serialization;
using System.Xml;
// ReSharper disable UnusedMember.Global

namespace Chiaki
{
    public static class XmlSerializer
    {
        public static byte[] Serialize<T>(T obj) => Serialize(obj, new DataContractSerializer(typeof(T)));

        public static byte[] Serialize<T>(T obj, DataContractSerializer serializer)
        {
            var stream = new MemoryStream();

            using (var writer = XmlDictionaryWriter.CreateTextWriter(stream))
            {
                serializer.WriteObject(writer, obj);
            }

            return stream.ToArray();
        }

        public static T Deserialize<T>(byte[] data) => Deserialize<T>(data, new DataContractSerializer(typeof(T)));

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