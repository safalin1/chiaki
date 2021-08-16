using Xunit;

namespace Chiaki.Tests.Singleton
{
    public class Tests
    {
        [Fact]
        public void InstanceIsNotNull()
        {
            // Arrange

            // Act
            var instance = TestingClass.Instance;

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void InstanceIsSameOnEachGet()
        {
            // Arrange
            var expected = TestingClass.Instance;

            // Act
            var actual = TestingClass.Instance;

            // Assert
            Assert.Same(expected, actual);
        }

        private class TestingClass : Singleton<TestingClass>
        {
            public string Test => "12345";
        }
    }
}
