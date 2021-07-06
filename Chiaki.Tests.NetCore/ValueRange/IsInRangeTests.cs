using Xunit;

namespace Chiaki.Tests.ValueRange
{
    public class IsInRangeTests
    {
        [Fact]
        public void ReturnsTrueWhenRangeInboundsOfOtherRange()
        {
            // Arrange
            var a = new ValueRange<int>(0, 10);
            var b = new ValueRange<int>(5, 7);

            // Act
            var actual = b.IsInRange(a);

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void ReturnsFalseWhenRangeOutboundsOfOtherRange()
        {
            // Arrange
            var a = new ValueRange<int>(0, 10);
            var b = new ValueRange<int>(24, 32);

            // Act
            var actual = a.IsInRange(b);

            // Assert
            Assert.False(actual);
        }
    }
}