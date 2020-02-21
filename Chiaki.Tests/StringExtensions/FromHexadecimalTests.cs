using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringExtensions
{
    [TestClass]
    public class FromHexadecimalTests
    {
        [TestMethod]
        public void Scenario1()
        {
            // Arrange
            string input = "5468697320697320736f6d6520746573742074657874";
            string expected = "This is some test text";

            // Act
            string actual = input.FromHexadecimal();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario2()
        {
            // Arrange
            string input = "546869732069732061207365636f6e6420696e7374616e6365206f662074657374696e672064617461";
            string expected = "This is a second instance of testing data";

            // Act
            string actual = input.FromHexadecimal();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario3()
        {
            // Arrange
            string input = "33726420696e7374616e6365206f662054455354494e472073616d706c6520646174612e";
            string expected = "3rd instance of TESTING sample data.";

            // Act
            string actual = input.FromHexadecimal();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}