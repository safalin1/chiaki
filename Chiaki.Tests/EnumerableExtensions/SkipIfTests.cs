using System;
using System.Linq;
using Xunit;

namespace Chiaki.Tests.EnumerableExtensions;

public class SkipIfTests
{
    [Fact]
    public void ConditionFalseReturnsAsIs()
    {
        // Arrange
        string[] input =
        {
            "test1",
            "test2",
            "test3",
            "test4",
            "test5",
            "test6",
        };

        var expected = "test1";

        // Act
        var actual = input
            .SkipIf(condition: false, count: 3)
            .First();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConditionTrueReturnsWithFilter()
    {
        // Arrange
        string[] input =
        {
            "test1",
            "test2",
            "test3",
            "test4",
            "test5",
            "test6",
        };

        var expected = "test4";

        // Act
        var actual = input
            .SkipIf(condition: true, count: 3)
            .First();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ThrowsExceptionWhenNull()
    {
        // Arrange
        string[] input = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => input.SkipIf(true, 1));
    }
}