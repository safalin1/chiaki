using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringExtensions
{
    [TestClass]
    public class CenterStringTests
    {
        [TestMethod]
        public void Scenario1()
        {
            // Arrange
            string input = "test";
            string expected = "   test   ";

            // Act
            string actual = input.CenterString(10);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenInputNull()
        {
            // Arrange
            string input = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => input.CenterString(10));
        }
    }
}