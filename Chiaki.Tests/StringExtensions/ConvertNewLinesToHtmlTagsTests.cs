using Xunit;

namespace Chiaki.Tests.StringExtensions;

public class ConvertNewLinesToHtmlTagsTests
{
    [Fact]
    public void ReplacesNewLinesWithBrTags()
    {
        // Arrange
        string input = "This is\r\na test";
        string expected = "This is<br />a test";

        // Act
        string actual = input.ConvertNewLinesToHtmlTags();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void NullThenReturnsNull()
    {
        // Arrange
        string input = null;

        // Act
        string actual = input.ConvertNewLinesToHtmlTags();

        // Assert
        Assert.Null(actual);
    }

    [Fact]
    public void EmptyThenReturnsEmpty()
    {
        // Arrange
        string input = string.Empty;

        // Act
        string actual = input.ConvertNewLinesToHtmlTags();

        // Assert
        Assert.Equal(expected: string.Empty, actual: actual);
    }
}