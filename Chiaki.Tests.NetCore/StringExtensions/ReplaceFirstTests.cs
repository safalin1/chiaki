using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringExtensions
{
    [TestClass]
    public class ReplaceFirstTests
    {
        [TestMethod]
        public void MatchesFirstInStringAndReplaces()
        {
            // Arrange
            const string expected = "this_is_replacement_test";
            string input = "this_is_unchanged_test";

            // Act
            string actual = input.ReplaceFirst("unchanged", "replacement");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MatchesOnlyFirstInStringAndReplaces()
        {
            // Arrange
            const string expected = "this_is_replacement_test_unchanged";
            string input = "this_is_unchanged_test_unchanged";

            // Act
            string actual = input.ReplaceFirst("unchanged", "replacement");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MatchesNoneAndStaysUnchanged()
        {
            // Arrange
            const string expected = "this_is_unchanged_test_unchanged";
            string input = "this_is_unchanged_test_unchanged";

            // Act
            string actual = input.ReplaceFirst("replacement", "unchanged");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OnNullThrowsException()
        {
            // Arrange
            string input = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => input.ReplaceFirst("replacement", "unchanged"));
        }
    }
}