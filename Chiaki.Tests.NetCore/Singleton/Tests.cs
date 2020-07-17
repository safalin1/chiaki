using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests.Singleton
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void InstanceIsNotNull()
        {
            // Arrange

            // Act
            var instance = TestingClass.Instance;

            // Assert
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void InstanceIsSameOnEachGet()
        {
            // Arrange
            var expected = TestingClass.Instance;

            // Act
            var actual = TestingClass.Instance;

            // Assert
            Assert.AreSame(expected, actual);
        }

        private class TestingClass : Singleton<TestingClass>
        {
            public string Test => "12345";
        }
    }
}
