using System;
using Xunit;

namespace Chiaki.Tests.EnumerableExtensions;

public class ContainsAllTests
{
    [Fact]
    public void ReturnsTrueIfEnumerableContainsMatchingItem()
    {
        // Arrange
        var a = new[] { 1, 2, 3 };
        var b = new[] { 3, 2, 1 };

        // Act
        var result = a.ContainsAll(b);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ReturnsFalseIfEnumerableContainsNoMatchingItem()
    {
        // Arrange
        var a = new[] { 1, 2, 3 };
        var b = new[] { 6, 5, 4 };

        // Act
        var result = a.ContainsAll(b);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ThrowsExceptionWhenSourceIsNull()
    {
        // Arrange
        int[] a = null;
        var b = new[] { 6, 5, 4 };

        // Assert
        Assert.Throws<ArgumentNullException>(() => a.ContainsAll(b));
    }

    [Fact]
    public void ThrowsExceptionWhenOtherIsNull()
    {
        // Arrange
        var a = new[] { 1, 2, 3 };
        int[] b = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => a.ContainsAll(b));
    }
}