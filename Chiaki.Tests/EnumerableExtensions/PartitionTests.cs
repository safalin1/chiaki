using System;
using System.Linq;
using Xunit;

namespace Chiaki.Tests.EnumerableExtensions;

public class PartitionTests
{
    [Fact]
    public void Size0Throws()
    {
        // Arrange
        int[] input = { 1, 2, 3, 4, 5 };

        // Act
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => input.Partition(size: 0).ToArray());
    }

    [Fact]
    public void NegativeSizeThrows()
    {
        // Arrange
        int[] input = { 1, 2, 3, 4, 5 };

        // Act
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => input.Partition(size: -2).ToArray());
    }

    [Fact]
    public void PartitionSizeGreaterThanListSize()
    {
        // Arrange
        int[] input = { 1, 2, 3, 4, 5 };

        // Act
        var actual = input.Partition(size: 10).ToArray();

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.Count() == 1);
        Assert.Equal(actual.Single().ToArray(), new[]{ 1, 2, 3, 4, 5 });
    }

    [Fact]
    public void PartitionSizeLessThanListSizeTest1()
    {
        // Arrange
        int[] input = { 1, 3, 2, 5, 4 };

        // Act
        var actual = input.Partition(size: 1).ToArray();

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.Count() == 5);
        Assert.Equal(actual.ElementAt(0).ToArray(), 1.AsArray());
        Assert.Equal(actual.ElementAt(1).ToArray(), 3.AsArray());
        Assert.Equal(actual.ElementAt(2).ToArray(), 2.AsArray());
        Assert.Equal(actual.ElementAt(3).ToArray(), 5.AsArray());
        Assert.Equal(actual.ElementAt(4).ToArray(), 4.AsArray());
    }

    [Fact]
    public void PartitionSizeLessThanListSizeTest2()
    {
        // Arrange
        int[] input = { 1, 3, 2, 5, 4 };

        // Act
        var actual = input.Partition(size: 2).ToArray();

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.Count() == 3);
        Assert.Equal(actual.ElementAt(0).ToArray(), new[]{ 1, 3 });
        Assert.Equal(actual.ElementAt(1).ToArray(), new[]{ 2, 5 });
        Assert.Equal(actual.ElementAt(2).ToArray(), 4.AsArray());
    }

    [Fact]
    public void PartitionSizeLessThanListSizeTest3()
    {
        // Arrange
        int[] input = { 1, 3, 2, 5, 4 };

        // Act
        var actual = input.Partition(size: 3).ToArray();

        // Assert
        Assert.NotNull(actual);
        Assert.True(actual.Count() == 2);
        Assert.Equal(actual.ElementAt(0).ToArray(), new[]{ 1, 3, 2 });
        Assert.Equal(actual.ElementAt(1).ToArray(), new[]{ 5, 4});
    }
}