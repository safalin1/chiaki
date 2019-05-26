using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests
{
    [TestClass]
    public class EnumerableExtensionTests
    {
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
