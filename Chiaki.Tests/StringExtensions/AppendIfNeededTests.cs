using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringExtensions
{
    [TestClass]
    public class AppendIfNeededTests
    {
        [TestMethod]
        public void IfNullReturnsNullString()
        {
            // Arrange
            string input = null;

            // Act
            string actual = input.AppendIfNeeded("...");

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void NoAppendIfInputEndsWithSpecifiedString()
        {
            // Arrange
            string input = "test...";
            string expected = "test...";

            // Act
            string actual = input.AppendIfNeeded("...");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AppendsIfInputDoesNotEndWithSpecifiedString()
        {
            // Arrange
            string input = "test";
            string expected = "test...";

            // Act
            string actual = input.AppendIfNeeded("...");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IfNullReturnsNullChar()
        {
            // Arrange
            string input = null;

            // Act
            string actual = input.AppendIfNeeded('.');

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void NoAppendIfInputEndsWithSpecifiedChar()
        {
            // Arrange
            string input = "test#";
            string expected = "test#";

            // Act
            string actual = input.AppendIfNeeded('#');

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AppendsIfInputDoesNotEndWithSpecifiedChar()
        {
            // Arrange
            string input = "test";
            string expected = "test#";

            // Act
            string actual = input.AppendIfNeeded('#');

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}