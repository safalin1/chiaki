using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests
{
    [TestClass]
    public class StringExtensionTests
    {
        [TestMethod]
        public void PrependIfNeeded_IfNullReturnsNullString()
        {
            // Arrange
            string input = null;

            // Act
            string actual = input.PrependIfNeeded("...");

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void PrependIfNeeded_NoPrependIfInputStartsWithSpecifiedString()
        {
            // Arrange
            string input = "...test";
            string expected = "...test";

            // Act
            string actual = input.PrependIfNeeded("...");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrependIfNeeded_PrependsIfInputDoesNotStartsWithSpecifiedString()
        {
            // Arrange
            string input = "test";
            string expected = "...test";

            // Act
            string actual = input.PrependIfNeeded("...");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrependIfNeeded_IfNullReturnsNullChar()
        {
            // Arrange
            string input = null;

            // Act
            string actual = input.PrependIfNeeded('.');

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void PrependIfNeeded_NoPrependIfInputStartsWithSpecifiedChar()
        {
            // Arrange
            string input = "#test";
            string expected = "#test";

            // Act
            string actual = input.PrependIfNeeded('#');

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrependIfNeeded_PrependsIfInputDoesNotStartsWithSpecifiedChar()
        {
            // Arrange
            string input = "test";
            string expected = "#test";

            // Act
            string actual = input.PrependIfNeeded('#');

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AppendIfNeeded_IfNullReturnsNullString()
        {
            // Arrange
            string input = null;

            // Act
            string actual = input.AppendIfNeeded("...");

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void AppendIfNeeded_NoAppendIfInputEndsWithSpecifiedString()
        {
            // Arrange
            string input = "test...";
            string expected = "test...";

            // Act
            string actual = input.AppendIfNeeded("...");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AppendIfNeeded_AppendsIfInputDoesNotEndWithSpecifiedString()
        {
            // Arrange
            string input = "test";
            string expected = "test...";

            // Act
            string actual = input.AppendIfNeeded("...");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AppendIfNeeded_IfNullReturnsNullChar()
        {
            // Arrange
            string input = null;

            // Act
            string actual = input.AppendIfNeeded('.');

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void AppendIfNeeded_NoAppendIfInputEndsWithSpecifiedChar()
        {
            // Arrange
            string input = "test#";
            string expected = "test#";

            // Act
            string actual = input.AppendIfNeeded('#');

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AppendIfNeeded_AppendsIfInputDoesNotEndWithSpecifiedChar()
        {
            // Arrange
            string input = "test";
            string expected = "test#";

            // Act
            string actual = input.AppendIfNeeded('#');

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TrimEnd_IfInputNullThenReturnsNull()
        {
            // Arrange
            string input = null;

            // Act
            string actual = input.TrimEnd("#");

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void TrimEnd_IfValueNullThenReturnsNoChange()
        {
            // Arrange
            string input = "test";

            // Act
            string actual = input.TrimEnd((string)null);

            // Assert
            Assert.AreEqual(input, actual);
        }

        [TestMethod]
        public void TrimEnd_IfInputDoesNotEndWithValueReturnsNoChange()
        {
            // Arrange
            string input = "test_keep";

            // Act
            string actual = input.TrimEnd("remove");

            // Assert
            Assert.AreEqual(input, actual);
        }

        [TestMethod]
        public void TrimEnd_IfInputEndsWithValueReturnsChange()
        {
            // Arrange
            string input = "test_remove";

            // Act
            string actual = input.TrimEnd("remove");

            // Assert
            Assert.AreEqual("test_", actual);
        }

        [TestMethod]
        public void TrimStart_IfInputNullThenReturnsNull()
        {
            // Arrange
            string input = null;

            // Act
            string actual = input.TrimStart("#");

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void TrimStart_IfValueNullThenReturnsNull()
        {
            // Arrange
            string input = "test";

            // Act
            string actual = input.TrimStart((string)null);

            // Assert
            Assert.AreEqual(input, actual);
        }

        [TestMethod]
        public void TrimStart_IfInputDoesNotStartWithValueReturnsNoChange()
        {
            // Arrange
            string input = "keep_test";

            // Act
            string actual = input.TrimStart("remove");

            // Assert
            Assert.AreEqual(input, actual);
        }

        [TestMethod]
        public void TrimStart_IfInputStartsWithValueReturnsChange()
        {
            // Arrange
            string input = "remove_test";

            // Act
            string actual = input.TrimStart("remove");

            // Assert
            Assert.AreEqual("_test", actual);
        }

        [TestMethod]
        public void Mask_CompleteMask()
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
        public void Mask_ExposedMask()
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
        public void Mask_ExposedMaskWithCustomMaskChar()
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
        public void Mask_ExposedMaskWithCustomMaskCharAlphaNumericOnly()
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

        [TestMethod]
        public void ReplaceFirst_MatchesFirstInStringAndReplaces()
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
        public void ReplaceFirst_MatchesOnlyFirstInStringAndReplaces()
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
        public void ReplaceFirst_MatchesNoneAndStaysUnchanged()
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
        public void ReplaceFirst_OnNullThrowsException()
        {
            // Arrange
            string input = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => input.ReplaceFirst("replacement", "unchanged"));
        }

        [TestMethod]
        public void RemoveWhitespace_SpacesAreRemoved()
        {
            // Arrange
            const string expected = "thisisateststring";
            string input = "this is a test string";

            // Act
            string actual = input.RemoveWhitespace();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveWhitespace_OnNullThrowsException()
        {
            // Arrange
            string input = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => input.RemoveWhitespace());
        }

        [TestMethod]
        public void RemoveHtmlTags_RemovesParagraphTags()
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
        public void RemoveHtmlTags_OnNullReturnsNull()
        {
            // Arrange
            string input = null;

            // Assert
            string actual = input.RemoveHtmlTags();

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void IsNumeric_WithNumberReturnsTrue()
        {
            // Arrange
            string input = "12345";

            // Act
            bool actual = input.IsNumeric();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsNumeric_WithStringReturnsFalse()
        {
            // Arrange
            string input = "test";

            // Act
            bool actual = input.IsNumeric();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void RemoveNewLines_WithStringTest()
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
        public void RemoveNewLines_WithNullStringTest()
        {
            // Arrange
            string input = null;

            // Act
            string actual = input.RemoveNewLines();

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void TruncateTo_MaxLength20NoSuffixChange()
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
        public void TruncateTo_MaxLength40WithSuffixChange()
        {
            // Arrange
            string input = "This is a really long string with lots of characters in it";
            string expected = "This is a really long string with lots??";

            // Act
            string actual = input.TruncateTo(maxLength: 40, suffix: "??");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsLengthAtLeast_MinLengthAsNegative()
        {
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => "".IsLengthAtLeast(-1));
        }

        [TestMethod]
        public void IsLengthAtLeast_NullReturnsFalse()
        {
            // Arrange
            string input = null;

            // Act
            bool actual = input.IsLengthAtLeast(10);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsLengthAtLeast_EmptyReturnsFalse()
        {
            // Arrange
            string input = string.Empty;

            // Act
            bool actual = input.IsLengthAtLeast(10);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsLengthAtLeast_String5LengthReturnsTrue()
        {
            // Arrange
            string input = "AAAAA";

            // Act
            bool actual = input.IsLengthAtLeast(5);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsLengthAtLeast_String10LengthReturnsTrue()
        {
            // Arrange
            string input = "AAAAAAAAAA";

            // Act
            bool actual = input.IsLengthAtLeast(5);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Formatted_Test1()
        {
            // Arrange
            string input = "this is a test {0} with a formatted argument";
            string expected = "this is a test method with a formatted argument";

            // Act
            string actual = input.Formatted("method");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Formatted_Test2()
        {
            // Arrange
            string input = "this is a test {0} with {1} formatted {2}";
            string expected = "this is a test method with multiple formatted arguments";

            // Act
            string actual = input.Formatted("method", "multiple", "arguments");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FromHexadecimal_Test1()
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
        public void FromHexadecimal_Test2()
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
        public void FromHexadecimal_Test3()
        {
            // Arrange
            string input = "33726420696e7374616e6365206f662054455354494e472073616d706c6520646174612e";
            string expected = "3rd instance of TESTING sample data.";

            // Act
            string actual = input.FromHexadecimal();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToHexadecimal_Test1()
        {
            // Arrange
            string input = "This is some test text";
            string expected = "5468697320697320736f6d6520746573742074657874";

            // Act
            string actual = input.ToHexadecimal();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToHexadecimal_Test2()
        {
            // Arrange
            string input = "This is a second instance of testing data";
            string expected = "546869732069732061207365636f6e6420696e7374616e6365206f662074657374696e672064617461";

            // Act
            string actual = input.ToHexadecimal();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToHexadecimal_Test3()
        {
            // Arrange
            string input = "3rd instance of TESTING sample data.";
            string expected = "33726420696e7374616e6365206f662054455354494e472073616d706c6520646174612e";

            // Act
            string actual = input.ToHexadecimal();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
