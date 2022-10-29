using System;
using System.Linq;
using Xunit;

namespace Chiaki.Tests.StringExtensions;

public class SplitByCamelCaseTests
{
    [Fact]
    public void Scenario1()
    {
        // Arrange
        string input = "ThisIsATest";
        var expected = new[] { "This", "Is", "A", "Test" };

        // Act
        var actual = input.SplitByCamelCase().ToArray();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ThrowsException_WhenInputNull()
    {
        // Arrange
        string input = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => input.SplitByCamelCase().ToArray());
    }
}