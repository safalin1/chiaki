using System;
using System.Linq;
using Xunit;

namespace Chiaki.Tests.EnumerableExtensions;

public class WhereIfTests
{
    [Fact]
    public void ConditionFalseReturnsAsIs()
    {
        // Arrange
        string[] input =
        {
            "test",
            "test2",
            ""
        };

        // Act
        var actual = input.WhereIf(condition: false, predicate: x => x.Length == 0);

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.Count() == 3);
    }

    [Fact]
    public void ConditionTrueReturnsWithFilter_NoElementIndex()
    {
        // Arrange
        string[] input =
        {
            "test",
            "test2",
            ""
        };

        // Act
        var actual = input.WhereIf(condition: true, predicate: x => x.Length == 0);

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.Count() == 1);
        Assert.True(actual.First() == string.Empty);
    }

    [Fact]
    public void ConditionTrueReturnsWithFilter_WithElementIndex()
    {
        // Arrange
        string[] input =
        {
            "test",
            "test2",
            ""
        };

        // Act
        var actual = input.WhereIf(condition: true, predicate: (x, idx) => x.Length == 0);

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.Count() == 1);
        Assert.True(actual.First() == string.Empty);
    }

    [Fact]
    public void ThrowsExceptionWhenNull_NoElementIndex()
    {
        // Arrange
        string[] input = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => input.WhereIf(true, x => x.Any()));
    }

    [Fact]
    public void ThrowsExceptionWhenNull_WithElementIndex()
    {
        // Arrange
        string[] input = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => input.WhereIf(true, (x, idx) => x.Any()));
    }
}