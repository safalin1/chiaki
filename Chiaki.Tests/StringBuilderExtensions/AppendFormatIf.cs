using System.Text;
using Xunit;

namespace Chiaki.Tests.StringBuilderExtensions
{
    public class AppendFormatIf
    {
        [Fact]
        public void SingleArgument_ConditionTrue()
        {
            // Arrange
            var builder = new StringBuilder("this has an ");
            var expected = "this has an appendfmt 1234 string here";

            // Act
            builder.AppendFormatIf(condition: 1 + 1 == 2, "appendfmt {0} string here", 1234);

            var actual = builder.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SingleArgument_ConditionFalse()
        {
            // Arrange
            var builder = new StringBuilder("this has an ");
            var expected = "this has an ";

            // Act
            builder.AppendFormatIf(condition: 1 + 1 == 1, "appendfmt {0} string here", 1234);

            var actual = builder.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoArguments_ConditionTrue()
        {
            // Arrange
            var builder = new StringBuilder("this has an ");
            var expected = "this has an appendfmt 1234 string here and 5678";

            // Act
            builder.AppendFormatIf(condition: 1 + 1 == 2, "appendfmt {0} string here and {1}", 1234, 5678);

            var actual = builder.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoArguments_ConditionFalse()
        {
            // Arrange
            var builder = new StringBuilder("this has an ");
            var expected = "this has an ";

            // Act
            builder.AppendFormatIf(condition: 1 + 1 == 1, "appendfmt {0} string here and {1}", 1234, 5678);

            var actual = builder.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeArguments_ConditionTrue()
        {
            // Arrange
            var builder = new StringBuilder("this has an ");
            var expected = "this has an appendfmt 1234 string here, 5678 and 91011";

            // Act
            builder.AppendFormatIf(condition: 1 + 1 == 2, "appendfmt {0} string here, {1} and {2}", 1234, 5678, 91011);

            var actual = builder.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeArguments_ConditionFalse()
        {
            // Arrange
            var builder = new StringBuilder("this has an ");
            var expected = "this has an ";

            // Act
            builder.AppendFormatIf(condition: 1 + 1 == 1, "appendfmt {0} string here, {1} and {2}", 1234, 5678, 91011);

            var actual = builder.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MultiArguments_ConditionTrue()
        {
            // Arrange
            var builder = new StringBuilder("this has an ");
            var expected = "this has an appendfmt 1234, 5678, 91011, 12394192513";

            // Act
            builder.AppendFormatIf(condition: 1 + 1 == 2, "appendfmt {0}, {1}, {2}, {3}", 1234, 5678, 91011, 12394192513);

            var actual = builder.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MultiArguments_ConditionFalse()
        {
            // Arrange
            var builder = new StringBuilder("this has an ");
            var expected = "this has an ";

            // Act
            builder.AppendFormatIf(condition: 1 + 1 == 1, "appendfmt {0}, {1}, {2}, {3}", 1234, 5678, 91011, 12394192513);

            var actual = builder.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}