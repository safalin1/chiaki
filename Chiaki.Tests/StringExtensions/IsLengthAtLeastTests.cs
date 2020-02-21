using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringExtensions
{
    [TestClass]
    public class IsLengthAtLeastTests
    {
        [TestMethod]
        public void MinLengthAsNegative()
        {
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => "".IsLengthAtLeast(-1));
        }

        [TestMethod]
        public void NullReturnsFalse()
        {
            // Arrange
            string input = null;

            // Act
            bool actual = input.IsLengthAtLeast(10);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void EmptyReturnsFalse()
        {
            // Arrange
            string input = string.Empty;

            // Act
            bool actual = input.IsLengthAtLeast(10);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void String5LengthReturnsTrue()
        {
            // Arrange
            string input = "AAAAA";

            // Act
            bool actual = input.IsLengthAtLeast(5);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void String10LengthReturnsTrue()
        {
            // Arrange
            string input = "AAAAAAAAAA";

            // Act
            bool actual = input.IsLengthAtLeast(5);

            // Assert
            Assert.IsTrue(actual);
        }
    }
}