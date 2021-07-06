using Xunit;

namespace Chiaki.Tests.ValueRange
{
    public class ConstructorTests
    {
        [Fact]
        public void CreatesInstanceWithMinAndMax()
        {
            // Arrange
            int min = 0;
            int max = 10;

            // Act
            var instance = new ValueRange<int>(min, max);

            // Assert
            Assert.Equal(expected: 0, actual: instance.Minimum);
            Assert.Equal(expected: 10, actual: instance.Maximum);
        }
    }
}
