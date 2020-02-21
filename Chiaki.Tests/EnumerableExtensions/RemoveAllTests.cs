using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.EnumerableExtensions
{
    [TestClass]
    public class RemoveAllTests
    {
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

        [TestMethod]
        public void ThrowExceptionWhenNull()
        {
            // Arrange
            IList<int> input = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => input.RemoveAll(x => x > 0));
        }

        [TestMethod]
        public void RemovesOnlyItemsMatchingPredicate()
        {
            // Arrange
            IList<int> input = new List<int>
            {
                1,
                3,
                6,
                12,
                15,
                20
            };

            // Act
            input.RemoveAll(x => x > 10);

            // Assert
            Assert.IsTrue(input.Count == 3);
            CollectionAssert.AllItemsAreNotNull(input.ToList());
            CollectionAssert.AreEqual(new[] { 1, 3, 6 }, input.ToList());
        }
    }
}