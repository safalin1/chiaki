using System;
using System.Collections.Generic;
using Xunit;

namespace Chiaki.Tests.EnumerableExtensions;

public class ContainsAnyTests
{
    [Fact]
    public void ReturnsTrueIfEnumerableContainsMatchingItem()
    {
        // Arrange
        var a = new[] { 1, 2, 3 };
        var b = new[] { 5, 4, 3 };

        // Act
        var result = a.ContainsAny(b);

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
        var result = a.ContainsAny(b);

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
        Assert.Throws<ArgumentNullException>(() => a.ContainsAny(b));
    }

    [Fact]
    public void ThrowsExceptionWhenOtherIsNull()
    {
        // Arrange
        var a = new[] { 1, 2, 3 };
        int[] b = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => a.ContainsAny(b));
    }

    [Fact]
    public void ThrowExceptionWhenSourceNull()
    {
        // Arrange
        IList<int> input = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => input.ContainsAny(new[] { 1 }));
    }

    [Fact]
    public void ThrowExceptionWhenOtherNull()
    {
        // Arrange
        IEnumerable<int> input = new[] { 1 };

        // Assert
        Assert.Throws<ArgumentNullException>(() => input.ContainsAny(null));
    }
}