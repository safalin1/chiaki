﻿using Xunit;

namespace Chiaki.Tests.StringExtensions;

public class MaskTests
{
    [Fact]
    public void ExposedUsingMaskDefaultChar()
    {
        // Arrange
        const string expected = "*****2345";
        string input = "test12345";

        // Act
        string actual = input.Mask(4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CompleteMaskUsingDefaultChar()
    {
        // Arrange
        const string expected = "*****";
        string input = "test1";

        // Act
        string actual = input.Mask();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CompleteMaskUsingDefaultCharAlphaNumericOnly()
    {
        // Arrange
        const string expected = "*****!";
        string input = "test1!";

        // Act
        string actual = input.Mask(EStringMaskStyle.AlphaNumericOnly);

        // Assert
        Assert.Equal(expected, actual);
    }


    [Fact]
    public void CompleteMask()
    {
        // Arrange
        const string expected = "*********";
        string input = "test12345";
        char mask = '*';

        // Act
        string actual = input.Mask(mask);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ExposedMask()
    {
        // Arrange
        const string expected = "*****2345";
        string input = "test12345";
        char mask = '*';

        // Act
        string actual = input.Mask(mask, 4);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ExposedMaskWithCustomMaskChar()
    {
        // Arrange
        const string expected = "???????21";
        string input = "test54321";
        char mask = '?';

        // Act
        string actual = input.Mask(mask, 2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ExposedMaskWithCustomMaskCharAlphaNumericOnly()
    {
        // Arrange
        const string expected = "?????????$@#";
        string input = "test54321$@#";
        char mask = '?';

        // Act
        string actual = input.Mask(mask, 2, EStringMaskStyle.AlphaNumericOnly);

        // Assert
        Assert.Equal(expected, actual);
    }

        
    [Fact]
    public void ExposedMaskAlphaNumericOnly()
    {
        // Arrange
        const string expected = "*********$@#";
        string input = "test54321$@#";

        // Act
        string actual = input.Mask(2, EStringMaskStyle.AlphaNumericOnly);

        // Assert
        Assert.Equal(expected, actual);
    }
}