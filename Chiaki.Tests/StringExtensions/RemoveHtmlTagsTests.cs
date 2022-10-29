using Xunit;

namespace Chiaki.Tests.StringExtensions;

public class RemoveHtmlTagsTests
{
    [Fact]
    public void RemovesParagraphTags()
    {
        // Arrange
        const string expected = "this is my content";
        string input = "<p>this is my content</p>";

        // Act
        string actual = input.RemoveHtmlTags();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OnNullReturnsNull()
    {
        // Arrange
        string input = null;

        // Assert
        string actual = input.RemoveHtmlTags();

        Assert.Null(actual);
    }
}