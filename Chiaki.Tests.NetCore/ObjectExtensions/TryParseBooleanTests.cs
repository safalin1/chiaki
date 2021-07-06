using Xunit;

namespace Chiaki.Tests.ObjectExtensions
{
    public class TryParseBooleanTests
    {
        [Fact]
        public void BoolTypeDirectCastValueFalse()
        {
            // Arrange
            object item = false;

            // Act
            var parsed = item.TryParseBoolean();

            // Assert
            Assert.True(parsed.HasValue);
            Assert.False(parsed.Value);
        }

        [Fact]
        public void BoolTypeDirectCastTrue()
        {
            // Arrange
            object item = true;

            // Act
            var parsed = item.TryParseBoolean();

            // Assert
            Assert.True(parsed.HasValue);
            Assert.True(parsed.Value);
        }
        
        [Fact]
        public void StringTypeParseTrue()
        {
            // Arrange
            object item = "true";

            // Act
            var parsed = item.TryParseBoolean();

            // Assert
            Assert.True(parsed.HasValue);
            Assert.True(parsed.Value);
        }
        
        [Fact]
        public void StringTypeParseFalse()
        {
            // Arrange
            object item = "false";

            // Act
            var parsed = item.TryParseBoolean();

            // Assert
            Assert.True(parsed.HasValue);
            Assert.False(parsed.Value);
        }

        [Fact]
        public void StringTypeParseNull()
        {
            // Arrange
            object item = null;

            // Act
            // ReSharper disable once ExpressionIsAlwaysNull
            var parsed = item.TryParseBoolean();

            // Assert
            Assert.False(parsed.HasValue);
        }

        [Fact]
        public void StringTypeParseGuidFail()
        {
            // Arrange
            object item = "C690A9EA-84F4-497A-AD68-95FD78A78F69";

            // Act
            // ReSharper disable once ExpressionIsAlwaysNull
            var parsed = item.TryParseBoolean();

            // Assert
            Assert.False(parsed.HasValue);
        }
    }
}