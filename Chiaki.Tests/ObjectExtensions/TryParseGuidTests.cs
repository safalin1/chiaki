using System;
using Xunit;

namespace Chiaki.Tests.ObjectExtensions
{
    public class TryParseGuidTests
    {
        [Fact]
        public void GuidTypeDirectCastValue()
        {
            // Arrange
            object item = Guid.Parse("E36922E6-CD0A-42F4-9BEA-2947A07447DE");

            // Act
            var parsed = item.TryParseGuid();

            // Assert
            Assert.True(parsed.HasValue);
            Assert.Equal(parsed.Value, Guid.Parse("E36922E6-CD0A-42F4-9BEA-2947A07447DE"));
        }

        [Fact]
        public void StringTypeParseValid()
        {
            // Arrange
            object item = "E36922E6-CD0A-42F4-9BEA-2947A07447DE";

            // Act
            var parsed = item.TryParseGuid();

            // Assert
            Assert.True(parsed.HasValue);
            Assert.Equal(parsed.Value, Guid.Parse("E36922E6-CD0A-42F4-9BEA-2947A07447DE"));
        }
        
        [Fact]
        public void StringTypeParseInvalid()
        {
            // Arrange
            object item = "**E36922E6-CD0A-42F4-9BEA-2947A07447DE**";

            // Act
            var parsed = item.TryParseGuid();

            // Assert
            Assert.False(parsed.HasValue);
        }

        
        [Fact]
        public void StringTypeParseNull()
        {
            // Arrange
            object item = null;

            // Act
            // ReSharper disable once ExpressionIsAlwaysNull
            var parsed = item.TryParseGuid();

            // Assert
            Assert.False(parsed.HasValue);
        }
    }
}