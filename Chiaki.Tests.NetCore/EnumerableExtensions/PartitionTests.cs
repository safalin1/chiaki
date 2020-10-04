using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.EnumerableExtensions
{
    [TestClass]
    public class PartitionTests
    {
        [TestMethod]
        public void Size0ThrowsException()
        {
            // Arrange
            int[] input = { 1, 2, 3, 4, 5 };

            // Act
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => input.Partition(size: 0).ToArray());
        }

        [TestMethod]
        public void NegativeSizeThrowsException()
        {
            // Arrange
            int[] input = { 1, 2, 3, 4, 5 };

            // Act
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => input.Partition(size: -2).ToArray());
        }

        [TestMethod]
        public void PartitionSizeGreaterThanListSize()
        {
            // Arrange
            int[] input = { 1, 2, 3, 4, 5 };

            // Act
            var actual = input.Partition(size: 10).ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() == 1);
            CollectionAssert.AreEqual(actual.Single().ToArray(), new[]{ 1, 2, 3, 4, 5 });
        }

        [TestMethod]
        public void PartitionSizeLessThanListSizeTest1()
        {
            // Arrange
            int[] input = { 1, 3, 2, 5, 4 };

            // Act
            var actual = input.Partition(size: 1).ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() == 5);
            CollectionAssert.AreEqual(actual.ElementAt(0).ToArray(), 1.AsArray());
            CollectionAssert.AreEqual(actual.ElementAt(1).ToArray(), 3.AsArray());
            CollectionAssert.AreEqual(actual.ElementAt(2).ToArray(), 2.AsArray());
            CollectionAssert.AreEqual(actual.ElementAt(3).ToArray(), 5.AsArray());
            CollectionAssert.AreEqual(actual.ElementAt(4).ToArray(), 4.AsArray());
        }

        [TestMethod]
        public void PartitionSizeLessThanListSizeTest2()
        {
            // Arrange
            int[] input = { 1, 3, 2, 5, 4 };

            // Act
            var actual = input.Partition(size: 2).ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() == 3);
            CollectionAssert.AreEqual(actual.ElementAt(0).ToArray(), new[]{ 1, 3 });
            CollectionAssert.AreEqual(actual.ElementAt(1).ToArray(), new[]{ 2, 5 });
            CollectionAssert.AreEqual(actual.ElementAt(2).ToArray(), 4.AsArray());
        }

        [TestMethod]
        public void PartitionSizeLessThanListSizeTest3()
        {
            // Arrange
            int[] input = { 1, 3, 2, 5, 4 };

            // Act
            var actual = input.Partition(size: 3).ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() == 2);
            CollectionAssert.AreEqual(actual.ElementAt(0).ToArray(), new[]{ 1, 3, 2 });
            CollectionAssert.AreEqual(actual.ElementAt(1).ToArray(), new[]{ 5, 4});
        }
    }
}