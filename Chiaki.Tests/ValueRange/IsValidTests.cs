using Xunit;

namespace Chiaki.Tests.ValueRange
{
    public class IsValidTests
    {
        [Fact]
        public void ReturnsTrueWhenRangeValid()
        {
            // Arrange
            int min = 0;
            int max = 10;

            // Act
            var instance = new ValueRange<int>(min, max);
            var actual = instance.IsValid();

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void ReturnsFalseWhenRangeInvalid()
        {
            // Arrange
            int min = 10;
            int max = 0;

            // Act
            var instance = new ValueRange<int>(min, max);
            var actual = instance.IsValid();

            // Assert
            Assert.False(actual);
        }
    }
}