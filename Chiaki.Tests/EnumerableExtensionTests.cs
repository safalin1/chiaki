using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests
{
    [TestClass]
    public class EnumerableExtensionTests
    {
        [TestMethod]
        public void AsArray_CreatesSingleItemArray()
        {
            // Arrange
            var item = new object();

            // Act
            var array = item.AsArray();

            // Assert
            Assert.IsNotNull(array);
            Assert.IsTrue(array.Length == 1);
            Assert.AreSame(item, array.First());
        }

        [TestMethod]
        public void AsList_CreatesSingleItemList()
        {
            // Arrange
            var item = new object();

            // Act
            var list = item.AsList();

            // Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count == 1);
            Assert.AreSame(item, list.First());
        }

        [TestMethod]
        public void DistinctBy_Test()
        {
            // Arrange
            var input = new[]
            {
                1,
                2,
                3,
                4,
                4,
                4,
                5,
                5,
                6,
                7,
                8,
                8,
                8,
                8,
                8,
                9,
                9,
                9,
                9,
            };

            var expected = new[]
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
            };

            // Act
            var actual = input.DistinctBy(x => x).ToArray();

            // Assert
            Assert.IsNotNull(input);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IfNullThenEmpty_IfNullReturnsEmptyEnumerable()
        {
            // Arrange
            string[] input = null;

            // Act
            var actual = input.IfNullThenEmpty();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.Any());
        }

        [TestMethod]
        public void IfNullThenEmpty_IfNotNullReturnsEnumerable()
        {
            // Arrange
            string[] input =
            {
                "test",
                "test2"
            };

            // Act
            var actual = input.IfNullThenEmpty();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() == 2);
        }

        [TestMethod]
        public void WhereIf_ConditionFalseReturnsAsIs()
        {
            // Arrange
            string[] input =
            {
                "test",
                "test2",
                ""
            };

            // Act
            var actual = input.WhereIf(condition: false, predicate: x => x.Length == 0);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() == 3);
        }


        [TestMethod]
        public void WhereIf_ConditionTrueReturnsWithFilter()
        {
            // Arrange
            string[] input =
            {
                "test",
                "test2",
                ""
            };

            // Act
            var actual = input.WhereIf(condition: true, predicate: x => x.Length == 0);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() == 1);
            Assert.IsTrue(actual.First() == string.Empty);
        }

        [TestMethod]
        public void RemoveAll_ThrowExceptionWhenNull()
        {
            // Arrange
            IList<int> input = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => input.RemoveAll(x => x > 0));
        }

        [TestMethod]
        public void RemoveAll_RemovesOnlyItemsMatchingPredicate()
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
        public void ContainsAny_ReturnsTrueIfEnumerableContainsMatchingItem()
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
        public void ContainsAny_ReturnsFalseIfEnumerableContainsNoMatchingItem()
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
        public void RemoveAll_ThrowExceptionWhenSourceNull()
        {
            // Arrange
            IList<int> input = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => input.ContainsAny(new[] { 1 }));
        }

        [TestMethod]
        public void RemoveAll_ThrowExceptionWhenOtherNull()
        {
            // Arrange
            IEnumerable<int> input = new[] { 1 };

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => input.ContainsAny(null));
        }
    }
}
