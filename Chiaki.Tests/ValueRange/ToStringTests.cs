using Xunit;

namespace Chiaki.Tests.ValueRange;

public class ToStringTests
{
    [Fact]
    public void ReturnsRangeInHumanReadableFormat()
    {
        // Arrange
        int min = 0;
        int max = 10;

        // Act
        var instance = new ValueRange<int>(min, max);
        var actual = instance.ToString();

        // Assert
        Assert.Equal(expected: "0 - 10", actual: actual);
    }
}