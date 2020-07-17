using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringExtensions
{
    [TestClass]
    public class RemoveWhitespaceTests
    {
        [TestMethod]
        public void SpacesAreRemoved()
        {
            // Arrange
            const string expected = "thisisateststring";
            string input = "this is a test string";

            // Act
            string actual = input.RemoveWhitespace();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OnNullThrowsException()
        {
            // Arrange
            string input = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => input.RemoveWhitespace());
        }
    }
}