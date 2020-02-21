using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.EnumerableExtensions
{
    [TestClass]
    public class SkipIfTests
    {
        [TestMethod]
        public void ConditionFalseReturnsAsIs()
        {
            // Arrange
            string[] input =
            {
                "test1",
                "test2",
                "test3",
                "test4",
                "test5",
                "test6",
            };

            var expected = "test1";

            // Act
            var actual = input
                .SkipIf(condition: false, count: 3)
                .First();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConditionTrueReturnsWithFilter()
        {
            // Arrange
            string[] input =
            {
                "test1",
                "test2",
                "test3",
                "test4",
                "test5",
                "test6",
            };

            var expected = "test4";

            // Act
            var actual = input
                .SkipIf(condition: true, count: 3)
                .First();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }
    }
}