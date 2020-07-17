using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringExtensions
{
    [TestClass]
    public class RemoveNewLinesTests
    {
        [TestMethod]
        public void WithStringTest()
        {
            // Arrange
            string input = "testline1\r\ntestline2";
            string expected = "testline1testline2";

            // Act
            string actual = input.RemoveNewLines();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WithNullStringTest()
        {
            // Arrange
            string input = null;

            // Act
            string actual = input.RemoveNewLines();

            // Assert
            Assert.IsNull(actual);
        }
    }
}