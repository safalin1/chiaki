using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.ObjectExtensions
{
    [TestClass]
    public class TryParseBooleanTests
    {
        [TestMethod]
        public void BoolTypeDirectCastValueFalse()
        {
            // Arrange
            object item = false;

            // Act
            var parsed = item.TryParseBoolean();

            // Assert
            Assert.IsTrue(parsed.HasValue);
            Assert.IsFalse(parsed.Value);
        }

        [TestMethod]
        public void BoolTypeDirectCastTrue()
        {
            // Arrange
            object item = true;

            // Act
            var parsed = item.TryParseBoolean();

            // Assert
            Assert.IsTrue(parsed.HasValue);
            Assert.IsTrue(parsed.Value);
        }
        
        [TestMethod]
        public void StringTypeParseTrue()
        {
            // Arrange
            object item = "true";

            // Act
            var parsed = item.TryParseBoolean();

            // Assert
            Assert.IsTrue(parsed.HasValue);
            Assert.IsTrue(parsed.Value);
        }
        
        [TestMethod]
        public void StringTypeParseFalse()
        {
            // Arrange
            object item = "false";

            // Act
            var parsed = item.TryParseBoolean();

            // Assert
            Assert.IsTrue(parsed.HasValue);
            Assert.IsFalse(parsed.Value);
        }

        [TestMethod]
        public void StringTypeParseNull()
        {
            // Arrange
            object item = null;

            // Act
            // ReSharper disable once ExpressionIsAlwaysNull
            var parsed = item.TryParseBoolean();

            // Assert
            Assert.IsFalse(parsed.HasValue);
        }

        
        [TestMethod]
        public void StringTypeParseGuidFail()
        {
            // Arrange
            object item = "C690A9EA-84F4-497A-AD68-95FD78A78F69";

            // Act
            // ReSharper disable once ExpressionIsAlwaysNull
            var parsed = item.TryParseBoolean();

            // Assert
            Assert.IsFalse(parsed.HasValue);
        }
    }
}