using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringExtensions
{
    [TestClass]
    public class SplitByCamelCaseTests
    {
        [TestMethod]
        public void Scenario1()
        {
            // Arrange
            string input = "ThisIsATest";
            var expected = new[] { "This", "Is", "A", "Test" };

            // Act
            var actual = input.SplitByCamelCase().ToArray();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThrowsException_WhenInputNull()
        {
            // Arrange
            string input = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => input.SplitByCamelCase().ToArray());
        }
    }
}