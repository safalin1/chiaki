using System;
using System.Linq;
using Xunit;

namespace Chiaki.Tests.EnumerableExtensions;

public class WhereNotNullTests
{
    [Fact]
    public void WithNulls_ExcludesNulls()
    {
        // Arrange
        string[] input =
        {
            "test",
            "test2",
            null,
            null,
            "test4",
            null,
            "test5"
        };

        string[] expected =
        {
            "test",
            "test2",
            "test4",
            "test5"
        };

        // Act
        var actual = input.WhereNotNull().ToArray();

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.Count() == 4);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WithoutNulls_NoChange()
    {
        // Arrange
        string[] input =
        {
            "test",
            "test2",
            "test4",
            "test5"
        };

        string[] expected =
        {
            "test",
            "test2",
            "test4",
            "test5"
        };

        // Act
        var actual = input.WhereNotNull().ToArray();

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.Count() == 4);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WithAllNulls_EmptyResult()
    {
        // Arrange
        string[] input =
        {
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
        };

        string[] expected =
        {
        };

        // Act
        var actual = input.WhereNotNull().ToArray();

        // Assert
        Assert.NotNull(actual);
        Assert.False(actual.Any());
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ThrowsExceptionWhenNull()
    {
        // Arrange
        string[] input = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => input.WhereNotNull());
    }
}