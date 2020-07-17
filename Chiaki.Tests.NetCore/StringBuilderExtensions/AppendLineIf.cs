using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.StringBuilderExtensions
{
    [TestClass]
    public class AppendLineIf
    {
        [TestMethod]
        public void SingleArgument_ConditionTrue()
        {
            // Arrange
            var builder = new StringBuilder();
            var expected = "my string\r\n";

            // Act
            builder.AppendLineIf(condition: 1 + 1 == 2, "my string");

            var actual = builder.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SingleArgument_ConditionFalse()
        {
            // Arrange
            var builder = new StringBuilder();
            var expected = "";

            // Act
            builder.AppendLineIf(condition: 1 + 1 == 1, "my string");

            var actual = builder.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoArguments_ConditionTrue()
        {
            // Arrange
            var builder = new StringBuilder("test");
            var expected = "test\r\n";

            // Act
            builder.AppendLineIf(condition: 1 + 1 == 2);

            var actual = builder.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoArguments_ConditionFalse()
        {
            // Arrange
            var builder = new StringBuilder("test");
            var expected = "test";

            // Act
            builder.AppendLineIf(condition: 1 + 1 == 1);

            var actual = builder.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}