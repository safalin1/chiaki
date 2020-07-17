using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.ValueRange
{
    [TestClass]
    public class ContainsRangeTests
    {
        [TestMethod]
        public void ReturnsTrueWhenRangeInboundsOfOtherRange()
        {
            // Arrange
            var a = new ValueRange<int>(0, 10);
            var b = new ValueRange<int>(5, 7);

            // Act
            var actual = a.ContainsRange(b);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ReturnsFalseWhenRangeOutboundsOfOtherRange()
        {
            // Arrange
            var a = new ValueRange<int>(0, 10);
            var b = new ValueRange<int>(24, 32);

            // Act
            var actual = a.ContainsRange(b);

            // Assert
            Assert.IsFalse(actual);
        }
    }
}