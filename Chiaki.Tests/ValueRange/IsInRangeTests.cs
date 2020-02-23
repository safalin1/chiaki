using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.ValueRange
{
    [TestClass]
    public class IsInRangeTests
    {
        [TestMethod]
        public void ReturnsTrueWhenRangeInboundsOfOtherRange()
        {
            // Arrange
            var a = new ValueRange<int>(0, 10);
            var b = new ValueRange<int>(5, 7);

            // Act
            var actual = b.IsInRange(a);

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
            var actual = a.IsInRange(b);

            // Assert
            Assert.IsFalse(actual);
        }
    }
}