using Xunit;

namespace Chiaki.Tests.StringExtensions
{
    public class IsNumericTests
    {
        [Fact]
        public void WithNumberReturnsTrue()
        {
            // Arrange
            string input = "12345";

            // Act
            bool actual = input.IsNumeric();

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void WithStringReturnsFalse()
        {
            // Arrange
            string input = "test";

            // Act
            bool actual = input.IsNumeric();

            // Assert
            Assert.False(actual);
        }
    }
}