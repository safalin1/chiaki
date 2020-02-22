using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.EnumerableExtensions
{
    [TestClass]
    public class RemoveAllTests
    {
        [TestMethod]
        public void ThrowExceptionWhenNull()
        {
            // Arrange
            IList<int> input = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => input.RemoveAll(x => x > 0));
        }

        [TestMethod]
        public void RemovesOnlyItemsMatchingPredicate_List()
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

        [TestMethod]
        public void RemovesOnlyItemsMatchingPredicate_Collection()
        {
            // Arrange
            var input = new Collection<int>
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
            CollectionAssert.AllItemsAreNotNull(input);
            CollectionAssert.AreEqual(new[] { 1, 3, 6 }, input);
        }
    }
}