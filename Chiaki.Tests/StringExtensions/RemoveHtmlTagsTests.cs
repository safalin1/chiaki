using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringExtensions
{
    [TestClass]
    public class RemoveHtmlTagsTests
    {
        [TestMethod]
        public void RemovesParagraphTags()
        {
            // Arrange
            const string expected = "this is my content";
            string input = "<p>this is my content</p>";

            // Act
            string actual = input.RemoveHtmlTags();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OnNullReturnsNull()
        {
            // Arrange
            string input = null;

            // Assert
            string actual = input.RemoveHtmlTags();

            Assert.IsNull(actual);
        }
    }
}