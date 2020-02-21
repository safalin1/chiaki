using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.EnumerableExtensions
{
    [TestClass]
    public class WhereNotNullTests
    {
        [TestMethod]
        public void WithNulls_ExcludesNulls()
        {
            // Arrange
            string[] input =
            {
                "test",
                "test2",
                null,
                null,
                "test4",
                null,
                "test5"
            };

            string[] expected =
            {
                "test",
                "test2",
                "test4",
                "test5"
            };

            // Act
            var actual = input.WhereNotNull().ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() == 4);
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void WithoutNulls_NoChange()
        {
            // Arrange
            string[] input =
            {
                "test",
                "test2",
                "test4",
                "test5"
            };

            string[] expected =
            {
                "test",
                "test2",
                "test4",
                "test5"
            };

            // Act
            var actual = input.WhereNotNull().ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() == 4);
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void WithAllNulls_EmptyResult()
        {
            // Arrange
            string[] input =
            {
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
            };

            string[] expected =
            {
            };

            // Act
            var actual = input.WhereNotNull().ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.Any());
            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}