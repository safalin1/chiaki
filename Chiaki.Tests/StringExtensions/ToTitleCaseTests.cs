using System;
using System.Globalization;
using Xunit;

namespace Chiaki.Tests.StringExtensions;

public class ToTitleCaseTests
{
    [Fact]
    public void Scenario1()
    {
        // Arrange
        string input = "this is a test";
        const string expected = "This Is A Test";

        // Act
        var actual = input.ToTitleCase();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ThrowsException_WhenStringIsNull_NoCultureSpecified()
    {
        // Arrange
        string input = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => input.ToTitleCase());
    }

    [Fact]
    public void ThrowsException_WhenStringIsNull_CultureSpecified()
    {
        // Arrange
        string input = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => input.ToTitleCase(CultureInfo.CurrentCulture));
    }

    [Fact]
    public void ThrowsException_WhenCultureIsNull()
    {
        // Arrange
        string input = "test";

        // Assert
        Assert.Throws<ArgumentNullException>(() => input.ToTitleCase(null));
    }
}