using System.Linq;
using Xunit;

namespace Chiaki.Tests.EnumerableExtensions;

public class AsArrayTests
{
    [Fact]
    public void AsArray_CreatesSingleItemArray()
    {
        // Arrange
        var item = new object();

        // Act
        var array = item.AsArray();

        // Assert
        Assert.NotNull(array);
        Assert.True(array.Length == 1);
        Assert.Same(item, array.First());
    }
}