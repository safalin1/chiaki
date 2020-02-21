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
    }
}