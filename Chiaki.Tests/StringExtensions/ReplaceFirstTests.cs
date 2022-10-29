using System;
using Xunit;

namespace Chiaki.Tests.StringExtensions;

public class ReplaceFirstTests
{
    [Fact]
    public void MatchesFirstInStringAndReplaces()
    {
        // Arrange
        const string expected = "this_is_replacement_test";
        string input = "this_is_unchanged_test";

        // Act
        string actual = input.ReplaceFirst("unchanged", "replacement");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MatchesOnlyFirstInStringAndReplaces()
    {
        // Arrange
        const string expected = "this_is_replacement_test_unchanged";
        string input = "this_is_unchanged_test_unchanged";

        // Act
        string actual = input.ReplaceFirst("unchanged", "replacement");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MatchesNoneAndStaysUnchanged()
    {
        // Arrange
        const string expected = "this_is_unchanged_test_unchanged";
        string input = "this_is_unchanged_test_unchanged";

        // Act
        string actual = input.ReplaceFirst("replacement", "unchanged");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void OnNullThrowsException()
    {
        // Arrange
        string input = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => input.ReplaceFirst("replacement", "unchanged"));
    }
}