using Xunit;

namespace Chiaki.Tests.StringExtensions
{
    public class TruncateToTests
    {
        [Fact]
        public void MaxLength0ReturnsAsIs()
        {
            // Arrange
            string input = "This is a string";
            string expected = "This is a string";

            // Act
            string actual = input.TruncateTo(maxLength: 0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MaxLength20NoSuffixChange()
        {
            // Arrange
            string input = "This is a really long string";
            string expected = "This is a really...";

            // Act
            string actual = input.TruncateTo(maxLength: 20);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MaxLength40WithSuffixChange()
        {
            // Arrange
            string input = "This is a really long string with lots of characters in it";
            string expected = "This is a really long string with lots??";

            // Act
            string actual = input.TruncateTo(maxLength: 40, suffix: "??");

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}