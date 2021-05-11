using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.ObjectExtensions
{
    [TestClass]
    public class TryParseGuidTests
    {
        [TestMethod]
        public void GuidTypeDirectCastValue()
        {
            // Arrange
            object item = Guid.Parse("E36922E6-CD0A-42F4-9BEA-2947A07447DE");

            // Act
            var parsed = item.TryParseGuid();

            // Assert
            Assert.IsTrue(parsed.HasValue);
            Assert.AreEqual(parsed.Value, Guid.Parse("E36922E6-CD0A-42F4-9BEA-2947A07447DE"));
        }

        [TestMethod]
        public void StringTypeParseValid()
        {
            // Arrange
            object item = "E36922E6-CD0A-42F4-9BEA-2947A07447DE";

            // Act
            var parsed = item.TryParseGuid();

            // Assert
            Assert.IsTrue(parsed.HasValue);
            Assert.AreEqual(parsed.Value, Guid.Parse("E36922E6-CD0A-42F4-9BEA-2947A07447DE"));
        }
        
        [TestMethod]
        public void StringTypeParseInvalid()
        {
            // Arrange
            object item = "**E36922E6-CD0A-42F4-9BEA-2947A07447DE**";

            // Act
            var parsed = item.TryParseGuid();

            // Assert
            Assert.IsFalse(parsed.HasValue);
        }

        
        [TestMethod]
        public void StringTypeParseNull()
        {
            // Arrange
            object item = null;

            // Act
            // ReSharper disable once ExpressionIsAlwaysNull
            var parsed = item.TryParseGuid();

            // Assert
            Assert.IsFalse(parsed.HasValue);
        }
    }
}