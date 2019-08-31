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
    }
}
