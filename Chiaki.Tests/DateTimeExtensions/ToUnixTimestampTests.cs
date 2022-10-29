using System;
using Xunit;

namespace Chiaki.Tests.DateTimeExtensions;

public class ToUnixTimestampTests
{
    [Fact]
    public void Scenario1()
    {
        // Arrange
        var date = new DateTime(2010, 11, 25);

        // Act
        double actual = date.ToUnixTimestamp();

        // Assert
        double expected = 1290643200;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Scenario2()
    {
        // Arrange
        var date = new DateTime(1995, 05, 31);

        // Act
        double actual = date.ToUnixTimestamp();

        // Assert
        double expected = 801878400;

        Assert.Equal(expected, actual);
    }
}