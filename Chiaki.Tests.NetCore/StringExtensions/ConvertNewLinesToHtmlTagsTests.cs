using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringExtensions
{
    [TestClass]
    public class ConvertNewLinesToHtmlTagsTests
    {
        [TestMethod]
        public void ReplacesNewLinesWithBrTags()
        {
            // Arrange
            string input = "This is\r\na test";
            string expected = "This is<br />a test";

            // Act
            string actual = input.ConvertNewLinesToHtmlTags();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NullThenReturnsNull()
        {
            // Arrange
            string input = null;

            // Act
            string actual = input.ConvertNewLinesToHtmlTags();

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void EmptyThenReturnsEmpty()
        {
            // Arrange
            string input = string.Empty;

            // Act
            string actual = input.ConvertNewLinesToHtmlTags();

            // Assert
            Assert.AreEqual(expected: string.Empty, actual: actual);
        }
    }
}