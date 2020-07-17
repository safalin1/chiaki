using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringExtensions
{
    [TestClass]
    public class IsNumericTests
    {
        [TestMethod]
        public void WithNumberReturnsTrue()
        {
            // Arrange
            string input = "12345";

            // Act
            bool actual = input.IsNumeric();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void WithStringReturnsFalse()
        {
            // Arrange
            string input = "test";

            // Act
            bool actual = input.IsNumeric();

            // Assert
            Assert.IsFalse(actual);
        }
    }
}