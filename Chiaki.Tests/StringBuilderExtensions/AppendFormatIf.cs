using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringBuilderExtensions
{
    [TestClass]
    public class AppendFormatIf
    {
        [TestMethod]
        public void SingleArgument_ConditionTrue()
        {
            // Arrange
            var builder = new StringBuilder("this has an ");
            var expected = "this has an appendfmt 1234 string here";

            // Act
            builder.AppendFormatIf(condition: 1 + 1 == 2, "appendfmt {0} string here", 1234);

            var actual = builder.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SingleArgument_ConditionFalse()
        {
            // Arrange
            var builder = new StringBuilder("this has an ");
            var expected = "this has an ";

            // Act
            builder.AppendFormatIf(condition: 1 + 1 == 1, "appendfmt {0} string here", 1234);

            var actual = builder.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoArguments_ConditionTrue()
        {
            // Arrange
            var builder = new StringBuilder("this has an ");
            var expected = "this has an appendfmt 1234 string here and 5678";

            // Act
            builder.AppendFormatIf(condition: 1 + 1 == 2, "appendfmt {0} string here and {1}", 1234, 5678);

            var actual = builder.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoArguments_ConditionFalse()
        {
            // Arrange
            var builder = new StringBuilder("this has an ");
            var expected = "this has an ";

            // Act
            builder.AppendFormatIf(condition: 1 + 1 == 1, "appendfmt {0} string here and {1}", 1234, 5678);

            var actual = builder.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}