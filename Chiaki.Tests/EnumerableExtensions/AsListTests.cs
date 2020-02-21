using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.EnumerableExtensions
{
    [TestClass]
    public class AsListTests
    {
        [TestMethod]
        public void CreatesSingleItemList()
        {
            // Arrange
            var item = new object();

            // Act
            var list = item.AsList();

            // Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count == 1);
            Assert.AreSame(item, list.First());
        }
    }
}