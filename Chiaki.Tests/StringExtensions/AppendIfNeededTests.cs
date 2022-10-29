using Xunit;

namespace Chiaki.Tests.StringExtensions;

public class AppendIfNeededTests
{
    [Fact]
    public void IfNullReturnsNullString()
    {
        // Arrange
        string input = null;

        // Act
        string actual = input.AppendIfNeeded("...");

        // Assert
        Assert.Null(actual);
    }

    [Fact]
    public void NoAppendIfInputEndsWithSpecifiedString()
    {
        // Arrange
        string input = "test...";
        string expected = "test...";

        // Act
        string actual = input.AppendIfNeeded("...");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AppendsIfInputDoesNotEndWithSpecifiedString()
    {
        // Arrange
        string input = "test";
        string expected = "test...";

        // Act
        string actual = input.AppendIfNeeded("...");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IfNullReturnsNullChar()
    {
        // Arrange
        string input = null;

        // Act
        string actual = input.AppendIfNeeded('.');

        // Assert
        Assert.Null(actual);
    }

    [Fact]
    public void NoAppendIfInputEndsWithSpecifiedChar()
    {
        // Arrange
        string input = "test#";
        string expected = "test#";

        // Act
        string actual = input.AppendIfNeeded('#');

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AppendsIfInputDoesNotEndWithSpecifiedChar()
    {
        // Arrange
        string input = "test";
        string expected = "test#";

        // Act
        string actual = input.AppendIfNeeded('#');

        // Assert
        Assert.Equal(expected, actual);
    }
}