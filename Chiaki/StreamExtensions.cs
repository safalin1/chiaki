using System.IO;

// ReSharper disable UnusedMember.Global

namespace Chiaki;

/// <summary>
/// Provides extensions for <see cref="Stream"/>
/// </summary>
public static class StreamExtensions
{
    /// <summary>
    /// Reads the entire contents of a Stream into a byte array.
    /// </summary>
    public static byte[] ReadToByteArray(this Stream input)
    {
        var buffer = new byte[16 * 1024];

        using (var ms = new MemoryStream())
        {
            int read;

            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }

            return ms.ToArray();
        }
    }
}