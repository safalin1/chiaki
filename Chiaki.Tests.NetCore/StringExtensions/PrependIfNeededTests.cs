using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringExtensions
{
    [TestClass]
    public class PrependIfNeededTests
    {
        [TestMethod]
        public void IfNullReturnsNullString()
        {
            // Arrange
            string input = null;

            // Act
            string actual = input.PrependIfNeeded("...");

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void NoPrependIfInputStartsWithSpecifiedString()
        {
            // Arrange
            string input = "...test";
            string expected = "...test";

            // Act
            string actual = input.PrependIfNeeded("...");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrependsIfInputDoesNotStartsWithSpecifiedString()
        {
            // Arrange
            string input = "test";
            string expected = "...test";

            // Act
            string actual = input.PrependIfNeeded("...");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IfNullReturnsNullChar()
        {
            // Arrange
            string input = null;

            // Act
            string actual = input.PrependIfNeeded('.');

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void NoPrependIfInputStartsWithSpecifiedChar()
        {
            // Arrange
            string input = "#test";
            string expected = "#test";

            // Act
            string actual = input.PrependIfNeeded('#');

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrependsIfInputDoesNotStartsWithSpecifiedChar()
        {
            // Arrange
            string input = "test";
            string expected = "#test";

            // Act
            string actual = input.PrependIfNeeded('#');

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
