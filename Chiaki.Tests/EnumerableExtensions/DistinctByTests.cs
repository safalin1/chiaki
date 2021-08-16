using System.Linq;
using Xunit;

namespace Chiaki.Tests.EnumerableExtensions
{
    public class DistinctByTests
    {
        [Fact]
        public void Scenario1()
        {
            // Arrange
            var input = new[]
            {
                1,
                2,
                3,
                4,
                4,
                4,
                5,
                5,
                6,
                7,
                8,
                8,
                8,
                8,
                8,
                9,
                9,
                9,
                9,
            };

            var expected = new[]
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
            };

            // Act
            var actual = input.DistinctBy(x => x).ToArray();

            // Assert
            Assert.NotNull(input);
            Assert.Equal(expected, actual);
        }
    }
}