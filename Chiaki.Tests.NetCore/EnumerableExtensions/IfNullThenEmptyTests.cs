using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.EnumerableExtensions
{
    [TestClass]
    public class IfNullThenEmptyTests
    {
        [TestMethod]
        public void IfNullReturnsEmptyEnumerable()
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
        public void IfNotNullReturnsEnumerable()
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
    }
}