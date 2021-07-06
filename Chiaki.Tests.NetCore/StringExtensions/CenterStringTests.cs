using System;
using Xunit;

namespace Chiaki.Tests.StringExtensions
{
    public class CenterStringTests
    {
        [Fact]
        public void Scenario1()
        {
            // Arrange
            string input = "test";
            string expected = "   test   ";

            // Act
            string actual = input.CenterString(10);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThrowsArgumentNullException_WhenInputNull()
        {
            // Arrange
            string input = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => input.CenterString(10));
        }
    }
}