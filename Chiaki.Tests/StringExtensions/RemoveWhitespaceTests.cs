using System;
using Xunit;

namespace Chiaki.Tests.StringExtensions
{
    public class RemoveWhitespaceTests
    {
        [Fact]
        public void SpacesAreRemoved()
        {
            // Arrange
            const string expected = "thisisateststring";
            string input = "this is a test string";

            // Act
            string actual = input.RemoveWhitespace();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OnNullThrowsException()
        {
            // Arrange
            string input = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => input.RemoveWhitespace());
        }
    }
}