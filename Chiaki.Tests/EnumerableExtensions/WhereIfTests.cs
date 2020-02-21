using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.EnumerableExtensions
{
    [TestClass]
    public class WhereIfTests
    {
        [TestMethod]
        public void ConditionFalseReturnsAsIs()
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
        public void ConditionTrueReturnsWithFilter_NoElementIndex()
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
        public void ConditionTrueReturnsWithFilter_WithElementIndex()
        {
            // Arrange
            string[] input =
            {
                "test",
                "test2",
                ""
            };

            // Act
            var actual = input.WhereIf(condition: true, predicate: (x, idx) => x.Length == 0);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() == 1);
            Assert.IsTrue(actual.First() == string.Empty);
        }
    }
}