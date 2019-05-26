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
    }
}
