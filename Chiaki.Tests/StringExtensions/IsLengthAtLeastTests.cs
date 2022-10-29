using System;
using Xunit;

namespace Chiaki.Tests.StringExtensions;

public class IsLengthAtLeastTests
{
    [Fact]
    public void MinLengthAsNegative()
    {
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => "".IsLengthAtLeast(-1));
    }

    [Fact]
    public void NullReturnsFalse()
    {
        // Arrange
        string input = null;

        // Act
        bool actual = input.IsLengthAtLeast(10);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void EmptyReturnsFalse()
    {
        // Arrange
        string input = string.Empty;

        // Act
        bool actual = input.IsLengthAtLeast(10);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void String5LengthReturnsTrue()
    {
        // Arrange
        string input = "AAAAA";

        // Act
        bool actual = input.IsLengthAtLeast(5);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void String10LengthReturnsTrue()
    {
        // Arrange
        string input = "AAAAAAAAAA";

        // Act
        bool actual = input.IsLengthAtLeast(5);

        // Assert
        Assert.True(actual);
    }
}