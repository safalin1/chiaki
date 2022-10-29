using Xunit;

namespace Chiaki.Tests.StringExtensions;

public class GetUtf8BytesTests
{
    [Fact]
    public void BasicTest()
    {
        // Arrange
        string input = "test";
        byte[] expected =
        {
            116,
            101,
            115,
            116
        };

        // Act
        var actual = input.GetUtf8Bytes();

        // Assert
        Assert.Equal(expected, actual);
    }
}