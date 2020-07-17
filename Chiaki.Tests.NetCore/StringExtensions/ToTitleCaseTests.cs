using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringExtensions
{
    [TestClass]
    public class ToTitleCaseTests
    {
        [TestMethod]
        public void Scenario1()
        {
            // Arrange
            string input = "this is a test";
            var expected = "This Is A Test";

            // Act
            var actual = input.ToTitleCase();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThrowsException_WhenStringIsNull_NoCultureSpecified()
        {
            // Arrange
            string input = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => input.ToTitleCase());
        }

        [TestMethod]
        public void ThrowsException_WhenStringIsNull_CultureSpecified()
        {
            // Arrange
            string input = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => input.ToTitleCase(CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void ThrowsException_WhenCultureIsNull()
        {
            // Arrange
            string input = "test";

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => input.ToTitleCase(null));
        }
    }
}