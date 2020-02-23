using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.ValueRange
{
    [TestClass]
    public class IsValidTests
    {
        [TestMethod]
        public void ReturnsTrueWhenRangeValid()
        {
            // Arrange
            int min = 0;
            int max = 10;

            // Act
            var instance = new ValueRange<int>(min, max);
            var actual = instance.IsValid();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ReturnsFalseWhenRangeInvalid()
        {
            // Arrange
            int min = 10;
            int max = 0;

            // Act
            var instance = new ValueRange<int>(min, max);
            var actual = instance.IsValid();

            // Assert
            Assert.IsFalse(actual);
        }
    }
}