using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringExtensions
{
    [TestClass]
    public class TruncateToTests
    {
        [TestMethod]
        public void MaxLength20NoSuffixChange()
        {
            // Arrange
            string input = "This is a really long string";
            string expected = "This is a really...";

            // Act
            string actual = input.TruncateTo(maxLength: 20);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MaxLength40WithSuffixChange()
        {
            // Arrange
            string input = "This is a really long string with lots of characters in it";
            string expected = "This is a really long string with lots??";

            // Act
            string actual = input.TruncateTo(maxLength: 40, suffix: "??");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}