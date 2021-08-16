using Xunit;

namespace Chiaki.Tests.StringExtensions
{
    public class TrimEndTests
    {
        [Fact]
        public void IfInputNullThenReturnsNull()
        {
            // Arrange
            string input = null;

            // Act
            string actual = input.TrimEnd("#");

            // Assert
            Assert.Null(actual);
        }

        [Fact]
        public void IfValueNullThenReturnsNoChange()
        {
            // Arrange
            string input = "test";

            // Act
            string actual = input.TrimEnd((string)null);

            // Assert
            Assert.Equal(input, actual);
        }

        [Fact]
        public void IfInputDoesNotEndWithValueReturnsNoChange()
        {
            // Arrange
            string input = "test_keep";

            // Act
            string actual = input.TrimEnd("remove");

            // Assert
            Assert.Equal(input, actual);
        }

        [Fact]
        public void IfInputEndsWithValueReturnsChange()
        {
            // Arrange
            string input = "test_remove";

            // Act
            string actual = input.TrimEnd("remove");

            // Assert
            Assert.Equal("test_", actual);
        }
    }
}