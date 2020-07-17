using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.EnumerableExtensions
{
    [TestClass]
    public class ContainsAnyTests
    {
        [TestMethod]
        public void ReturnsTrueIfEnumerableContainsMatchingItem()
        {
            // Arrange
            var a = new[] { 1, 2, 3 };
            var b = new[] { 5, 4, 3 };

            // Act
            var result = a.ContainsAny(b);

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
            var result = a.ContainsAny(b);

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
            Assert.ThrowsException<ArgumentNullException>(() => a.ContainsAny(b));
        }

        [TestMethod]
        public void ThrowsExceptionWhenOtherIsNull()
        {
            // Arrange
            var a = new[] { 1, 2, 3 };
            int[] b = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => a.ContainsAny(b));
        }

        [TestMethod]
        public void ThrowExceptionWhenSourceNull()
        {
            // Arrange
            IList<int> input = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => input.ContainsAny(new[] { 1 }));
        }

        [TestMethod]
        public void ThrowExceptionWhenOtherNull()
        {
            // Arrange
            IEnumerable<int> input = new[] { 1 };

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => input.ContainsAny(null));
        }
    }
}