using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chiaki.Tests
{
    [TestClass]
    public class DateTimeExtensionTests
    {
        [TestMethod]
        public void ToUnixTimestamp_Scenario1()
        {
            // Arrange
            var date = new DateTime(2010, 11, 25);

            // Act
            double actual = date.ToUnixTimestamp();

            // Assert
            double expected = 1290643200;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToUnixTimestamp_Scenario2()
        {
            // Arrange
            var date = new DateTime(1995, 05, 31);

            // Act
            double actual = date.ToUnixTimestamp();

            // Assert
            double expected = 801878400;

            Assert.AreEqual(expected, actual);
        }
    }
}