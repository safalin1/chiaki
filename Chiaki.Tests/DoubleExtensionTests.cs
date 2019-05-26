using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests
{
    [TestClass]
    public class DoubleExtensionTests
    {
        [TestMethod]
        public void AsDateTimeFromUnixTimestamp_Scenario1()
        {
            // Arrange
            double unixTimestamp = 1290643200;

            // Act
            DateTime actual = unixTimestamp.AsDateTimeFromUnixTimestamp();

            // Assert
            var expected = new DateTime(2010, 11, 25);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AsDateTimeFromUnixTimestamp_Scenario2()
        {
            // Arrange
            double unixTimestamp = 801878400;

            // Act
            DateTime actual = unixTimestamp.AsDateTimeFromUnixTimestamp();

            // Assert
            var expected = new DateTime(1995, 05, 31);

            Assert.AreEqual(expected, actual);
        }
    }
}
