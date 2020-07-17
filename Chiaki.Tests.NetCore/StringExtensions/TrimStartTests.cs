using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringExtensions
{
    [TestClass]
    public class TrimStartTests
    {
        [TestMethod]
        public void IfInputNullThenReturnsNull()
        {
            // Arrange
            string input = null;

            // Act
            string actual = input.TrimStart("#");

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void IfValueNullThenReturnsNull()
        {
            // Arrange
            string input = "test";

            // Act
            string actual = input.TrimStart((string)null);

            // Assert
            Assert.AreEqual(input, actual);
        }

        [TestMethod]
        public void IfInputDoesNotStartWithValueReturnsNoChange()
        {
            // Arrange
            string input = "keep_test";

            // Act
            string actual = input.TrimStart("remove");

            // Assert
            Assert.AreEqual(input, actual);
        }

        [TestMethod]
        public void IfInputStartsWithValueReturnsChange()
        {
            // Arrange
            string input = "remove_test";

            // Act
            string actual = input.TrimStart("remove");

            // Assert
            Assert.AreEqual("_test", actual);
        }
    }
}