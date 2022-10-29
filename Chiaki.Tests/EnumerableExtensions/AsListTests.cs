using System.Linq;
using Xunit;

namespace Chiaki.Tests.EnumerableExtensions;

public class AsListTests
{
    [Fact]
    public void CreatesSingleItemList()
    {
        // Arrange
        var item = new object();

        // Act
        var list = item.AsList();

        // Assert
        Assert.NotNull(list);
        Assert.True(list.Count == 1);
        Assert.Same(item, list.First());
    }
}