using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringExtensions
{
    [TestClass]
    public class MaskTests
    {
        [TestMethod]
        public void CompleteMask()
        {
            // Arrange
            const string expected = "*********";
            string input = "test12345";
            char mask = '*';

            // Act
            string actual = input.Mask(mask);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExposedMask()
        {
            // Arrange
            const string expected = "*****2345";
            string input = "test12345";
            char mask = '*';

            // Act
            string actual = input.Mask(mask, 4);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExposedMaskWithCustomMaskChar()
        {
            // Arrange
            const string expected = "???????21";
            string input = "test54321";
            char mask = '?';

            // Act
            string actual = input.Mask(mask, 2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExposedMaskWithCustomMaskCharAlphaNumericOnly()
        {
            // Arrange
            const string expected = "?????????$@#";
            string input = "test54321$@#";
            char mask = '?';

            // Act
            string actual = input.Mask(mask, 2, StringMaskStyle.AlphaNumericOnly);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}