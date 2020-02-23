using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.ValueRange
{
    [TestClass]
    public class ContainsValueTests
    {
        [TestMethod]
        public void ReturnsTrueWhenValueInRange()
        {
            // Arrange
            int min = 0;
            int max = 10;

            // Act
            var instance = new ValueRange<int>(min, max);
            var actual = instance.ContainsValue(5);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ReturnsFalseWhenValueOutOfBounds()
        {
            // Arrange
            int min = 10;
            int max = 0;

            // Act
            var instance = new ValueRange<int>(min, max);
            var actual = instance.ContainsValue(20);

            // Assert
            Assert.IsFalse(actual);
        }
    }
}