using Xunit;

namespace Chiaki.Tests.StringExtensions;

public class TrimStartTests
{
    [Fact]
    public void IfInputNullThenReturnsNull()
    {
        // Arrange
        string input = null;

        // Act
        string actual = input.TrimStart("#");

        // Assert
        Assert.Null(actual);
    }

    [Fact]
    public void IfValueNullThenReturnsNull()
    {
        // Arrange
        string input = "test";

        // Act
        string actual = input.TrimStart((string)null);

        // Assert
        Assert.Equal(input, actual);
    }

    [Fact]
    public void IfInputDoesNotStartWithValueReturnsNoChange()
    {
        // Arrange
        string input = "keep_test";

        // Act
        string actual = input.TrimStart("remove");

        // Assert
        Assert.Equal(input, actual);
    }

    [Fact]
    public void IfInputStartsWithValueReturnsChange()
    {
        // Arrange
        string input = "remove_test";

        // Act
        string actual = input.TrimStart("remove");

        // Assert
        Assert.Equal("_test", actual);
    }
}