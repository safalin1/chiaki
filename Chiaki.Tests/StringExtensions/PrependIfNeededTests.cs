using Xunit;

namespace Chiaki.Tests.StringExtensions;

public class PrependIfNeededTests
{
    [Fact]
    public void IfNullReturnsNullString()
    {
        // Arrange
        string input = null;

        // Act
        string actual = input.PrependIfNeeded("...");

        // Assert
        Assert.Null(actual);
    }

    [Fact]
    public void NoPrependIfInputStartsWithSpecifiedString()
    {
        // Arrange
        string input = "...test";
        string expected = "...test";

        // Act
        string actual = input.PrependIfNeeded("...");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PrependsIfInputDoesNotStartsWithSpecifiedString()
    {
        // Arrange
        string input = "test";
        string expected = "...test";

        // Act
        string actual = input.PrependIfNeeded("...");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IfNullReturnsNullChar()
    {
        // Arrange
        string input = null;

        // Act
        string actual = input.PrependIfNeeded('.');

        // Assert
        Assert.Null(actual);
    }

    [Fact]
    public void NoPrependIfInputStartsWithSpecifiedChar()
    {
        // Arrange
        string input = "#test";
        string expected = "#test";

        // Act
        string actual = input.PrependIfNeeded('#');

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PrependsIfInputDoesNotStartsWithSpecifiedChar()
    {
        // Arrange
        string input = "test";
        string expected = "#test";

        // Act
        string actual = input.PrependIfNeeded('#');

        // Assert
        Assert.Equal(expected, actual);
    }
}