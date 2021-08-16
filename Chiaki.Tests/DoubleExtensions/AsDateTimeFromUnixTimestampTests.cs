using System;
using Xunit;

namespace Chiaki.Tests.DoubleExtensions
{
    public class AsDateTimeFromUnixTimestampTests
    {
        [Fact]
        public void Scenario1()
        {
            // Arrange
            double unixTimestamp = 1290643200;

            // Act
            DateTime actual = unixTimestamp.AsDateTimeFromUnixTimestamp();

            // Assert
            var expected = new DateTime(2010, 11, 25);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Scenario2()
        {
            // Arrange
            double unixTimestamp = 801878400;

            // Act
            DateTime actual = unixTimestamp.AsDateTimeFromUnixTimestamp();

            // Assert
            var expected = new DateTime(1995, 05, 31);

            Assert.Equal(expected, actual);
        }
    }
}
