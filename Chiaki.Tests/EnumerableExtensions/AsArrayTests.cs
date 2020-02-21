using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.EnumerableExtensions
{
    [TestClass]
    public class AsArrayTests
    {
        [TestMethod]
        public void AsArray_CreatesSingleItemArray()
        {
            // Arrange
            var item = new object();

            // Act
            var array = item.AsArray();

            // Assert
            Assert.IsNotNull(array);
            Assert.IsTrue(array.Length == 1);
            Assert.AreSame(item, array.First());
        }
    }
}
