using System.Linq;
using Xunit;

namespace Chiaki.Tests.EnumerableExtensions
{
    public class IfNullThenEmptyTests
    {
        [Fact]
        public void IfNullReturnsEmptyEnumerable()
        {
            // Arrange
            string[] input = null;

            // Act
            var actual = input.IfNullThenEmpty();

            // Assert
            Assert.NotNull(actual);
            Assert.False(actual.Any());
        }

        [Fact]
        public void IfNotNullReturnsEnumerable()
        {
            // Arrange
            string[] input =
            {
                "test",
                "test2"
            };

            // Act
            var actual = input.IfNullThenEmpty();

            // Assert
            Assert.NotNull(actual);
            Assert.True(actual.Count() == 2);
        }
    }
}