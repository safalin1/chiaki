using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.EnumerableExtensions
{
    [TestClass]
    public class ContainsAllTests
    {
        [TestMethod]
        public void ReturnsTrueIfEnumerableContainsMatchingItem()
        {
            // Arrange
            var a = new[] { 1, 2, 3 };
            var b = new[] { 3, 2, 1 };

            // Act
            var result = a.ContainsAll(b);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReturnsFalseIfEnumerableContainsNoMatchingItem()
        {
            // Arrange
            var a = new[] { 1, 2, 3 };
            var b = new[] { 6, 5, 4 };

            // Act
            var result = a.ContainsAll(b);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ThrowsExceptionWhenSourceIsNull()
        {
            // Arrange
            int[] a = null;
            var b = new[] { 6, 5, 4 };

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => a.ContainsAll(b));
        }

        [TestMethod]
        public void ThrowsExceptionWhenOtherIsNull()
        {
            // Arrange
            var a = new[] { 1, 2, 3 };
            int[] b = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => a.ContainsAll(b));
        }
    }
}