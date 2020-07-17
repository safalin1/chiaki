using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.ValueRange
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void CreatesInstanceWithMinAndMax()
        {
            // Arrange
            int min = 0;
            int max = 10;

            // Act
            var instance = new ValueRange<int>(min, max);

            // Assert
            Assert.AreEqual(expected: 0, actual: instance.Minimum);
            Assert.AreEqual(expected: 10, actual: instance.Maximum);
        }
    }
}
