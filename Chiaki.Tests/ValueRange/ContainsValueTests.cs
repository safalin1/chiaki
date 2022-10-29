using Xunit;

namespace Chiaki.Tests.ValueRange;

public class ContainsValueTests
{
    [Fact]
    public void ReturnsTrueWhenValueInRange()
    {
        // Arrange
        int min = 0;
        int max = 10;

        // Act
        var instance = new ValueRange<int>(min, max);
        var actual = instance.ContainsValue(5);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void ReturnsFalseWhenValueOutOfBounds()
    {
        // Arrange
        int min = 10;
        int max = 0;

        // Act
        var instance = new ValueRange<int>(min, max);
        var actual = instance.ContainsValue(20);

        // Assert
        Assert.False(actual);
    }
}