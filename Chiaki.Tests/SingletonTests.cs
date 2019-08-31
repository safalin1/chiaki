using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests
{
    [TestClass]
    public class SingletonTests
    {
        [TestMethod]
        public void Singleton_InstanceIsNotNull()
        {
            // Arrange

            // Act
            var instance = TestingClass.Instance;

            // Assert
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void Singleton_InstanceIsSameOnEachGet()
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
