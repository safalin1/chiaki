using Xunit;

namespace Chiaki.Tests.StringExtensions;

public class RemoveNewLinesTests
{
    [Fact]
    public void WithStringTest()
    {
        // Arrange
        string input = "testline1\r\ntestline2";
        string expected = "testline1testline2";

        // Act
        string actual = input.RemoveNewLines();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WithNullStringTest()
    {
        // Arrange
        string input = null;

        // Act
        string actual = input.RemoveNewLines();

        // Assert
        Assert.Null(actual);
    }
}