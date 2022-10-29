using System.Text;
using Xunit;

namespace Chiaki.Tests.StringBuilderExtensions;

public class AppendIfTests
{
    [Fact]
    public void StringOverload_ConditionTrue()
    {
        // Arrange
        var builder = new StringBuilder("this has an appended");
        var expected = "this has an appended string value";

        // Act
        builder.AppendIf(condition: 1 + 1 == 2, " string value");

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void StringOverload_ConditionFalse()
    {
        // Arrange
        var builder = new StringBuilder("this has no appended");
        var expected = "this has no appended";

        // Act
        builder.AppendIf(condition: 1 + 1 == 1, " string value");

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IntOverload_ConditionTrue()
    {
        // Arrange
        var builder = new StringBuilder("this has an appended ");
        var expected = "this has an appended 500";

        // Act
        builder.AppendIf(condition: 1 + 1 == 2, 500);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IntOverload_ConditionFalse()
    {
        // Arrange
        var builder = new StringBuilder("this has no appended");
        var expected = "this has no appended";

        // Act
        builder.AppendIf(condition: 1 + 1 == 1, 500);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void BoolOverload_ConditionTrue()
    {
        // Arrange
        var builder = new StringBuilder("this has an appended ");
        var expected = "this has an appended True";

        // Act
        builder.AppendIf(condition: 1 + 1 == 2, true);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void BoolOverload_ConditionFalse()
    {
        // Arrange
        var builder = new StringBuilder("this has no appended");
        var expected = "this has no appended";

        // Act
        builder.AppendIf(condition: 1 + 1 == 1, true);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CharOverload_ConditionTrue()
    {
        // Arrange
        var builder = new StringBuilder("this has an appended ");
        var expected = "this has an appended b";

        // Act
        builder.AppendIf(condition: 1 + 1 == 2, 'b');

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CharOverload_ConditionFalse()
    {
        // Arrange
        var builder = new StringBuilder("this has no appended");
        var expected = "this has no appended";

        // Act
        builder.AppendIf(condition: 1 + 1 == 1, 'b');

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SByteOverload_ConditionTrue()
    {
        // Arrange
        var builder = new StringBuilder("this has an appended ");
        var expected = "this has an appended 2";

        // Act
        builder.AppendIf(condition: 1 + 1 == 2, (sbyte)2);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SByteOverload_ConditionFalse()
    {
        // Arrange
        var builder = new StringBuilder("this has no appended");
        var expected = "this has no appended";

        // Act
        builder.AppendIf(condition: 1 + 1 == 1, (sbyte)2);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ByteOverload_ConditionTrue()
    {
        // Arrange
        var builder = new StringBuilder("this has an appended ");
        var expected = "this has an appended 2";

        // Act
        builder.AppendIf(condition: 1 + 1 == 2, (byte)2);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ByteOverload_ConditionFalse()
    {
        // Arrange
        var builder = new StringBuilder("this has no appended");
        var expected = "this has no appended";

        // Act
        builder.AppendIf(condition: 1 + 1 == 1, (byte)2);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShortOverload_ConditionTrue()
    {
        // Arrange
        var builder = new StringBuilder("this has an appended ");
        var expected = "this has an appended 5";

        // Act
        builder.AppendIf(condition: 1 + 1 == 2, (short)5);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShortOverload_ConditionFalse()
    {
        // Arrange
        var builder = new StringBuilder("this has no appended");
        var expected = "this has no appended";

        // Act
        builder.AppendIf(condition: 1 + 1 == 1, (short)5);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LongOverload_ConditionTrue()
    {
        // Arrange
        var builder = new StringBuilder("this has an appended ");
        var expected = "this has an appended 532";

        // Act
        builder.AppendIf(condition: 1 + 1 == 2, (long)532);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void LongOverload_ConditionFalse()
    {
        // Arrange
        var builder = new StringBuilder("this has no appended");
        var expected = "this has no appended";

        // Act
        builder.AppendIf(condition: 1 + 1 == 1, (long)532);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FloatOverload_ConditionTrue()
    {
        // Arrange
        var builder = new StringBuilder("this has an appended ");
        var expected = "this has an appended 3.41";

        // Act
        builder.AppendIf(condition: 1 + 1 == 2, (float)3.41);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FloatOverload_ConditionFalse()
    {
        // Arrange
        var builder = new StringBuilder("this has no appended");
        var expected = "this has no appended";

        // Act
        builder.AppendIf(condition: 1 + 1 == 1, (float)3.41);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DoubleOverload_ConditionTrue()
    {
        // Arrange
        var builder = new StringBuilder("this has an appended ");
        var expected = "this has an appended 3.41";

        // Act
        builder.AppendIf(condition: 1 + 1 == 2, (double)3.41);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DoubleOverload_ConditionFalse()
    {
        // Arrange
        var builder = new StringBuilder("this has no appended");
        var expected = "this has no appended";

        // Act
        builder.AppendIf(condition: 1 + 1 == 1, (double)3.41);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DecimalOverload_ConditionTrue()
    {
        // Arrange
        var builder = new StringBuilder("this has an appended ");
        var expected = "this has an appended 3.41";

        // Act
        builder.AppendIf(condition: 1 + 1 == 2, (decimal)3.41);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DecimalOverload_ConditionFalse()
    {
        // Arrange
        var builder = new StringBuilder("this has no appended");
        var expected = "this has no appended";

        // Act
        builder.AppendIf(condition: 1 + 1 == 1, (decimal)3.41);

        var actual = builder.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }
}