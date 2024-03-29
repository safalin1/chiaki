﻿using Xunit;

namespace Chiaki.Tests.StringExtensions;

public class ToHexadecimalTests
{
    [Fact]
    public void Scenario1()
    {
        // Arrange
        string input = "This is some test text";
        string expected = "5468697320697320736f6d6520746573742074657874";

        // Act
        string actual = input.ToHexadecimal();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Scenario2()
    {
        // Arrange
        string input = "This is a second instance of testing data";
        string expected = "546869732069732061207365636f6e6420696e7374616e6365206f662074657374696e672064617461";

        // Act
        string actual = input.ToHexadecimal();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Scenario3()
    {
        // Arrange
        string input = "3rd instance of TESTING sample data.";
        string expected = "33726420696e7374616e6365206f662054455354494e472073616d706c6520646174612e";

        // Act
        string actual = input.ToHexadecimal();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Scenario4()
    {
        // Arrange
        string input = "";
        string expected = "";

        // Act
        string actual = input.ToHexadecimal();

        // Assert
        Assert.Equal(expected, actual);
    }
}