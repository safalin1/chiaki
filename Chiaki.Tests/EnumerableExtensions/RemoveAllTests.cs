using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace Chiaki.Tests.EnumerableExtensions;

public class RemoveAllTests
{
    [Fact]
    public void ThrowExceptionWhenNull()
    {
        // Arrange
        IList<int> input = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => input.RemoveAll(x => x > 0));
    }

    [Fact]
    public void RemovesOnlyItemsMatchingPredicate_List()
    {
        // Arrange
        IList<int> input = new List<int>
        {
            1,
            3,
            6,
            12,
            15,
            20
        };

        // Act
        input.RemoveAll(x => x > 10);

        // Assert
        Assert.True(input.Count == 3);
        Assert.Equal(new[] { 1, 3, 6 }, input.ToList());
    }

    [Fact]
    public void RemovesOnlyItemsMatchingPredicate_Collection()
    {
        // Arrange
        var input = new Collection<int>
        {
            1,
            3,
            6,
            12,
            15,
            20
        };

        // Act
        input.RemoveAll(x => x > 10);

        // Assert
        Assert.True(input.Count == 3);
        Assert.Equal(new[] { 1, 3, 6 }, input);
    }
}