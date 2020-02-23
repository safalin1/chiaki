using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.ValueRange
{
    [TestClass]
    public class ToStringTests
    {
        [TestMethod]
        public void ReturnsRangeInHumanReadableFormat()
        {
            // Arrange
            int min = 0;
            int max = 10;

            // Act
            var instance = new ValueRange<int>(min, max);
            var actual = instance.ToString();

            // Assert
            Assert.AreEqual(expected: "0 - 10", actual: actual);
        }
    }
}