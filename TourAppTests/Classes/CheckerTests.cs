using Microsoft.VisualStudio.TestTools.UnitTesting;
using TourApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourApp.Classes.Tests
{
    [TestClass()]
    public class CheckerTests
    {
        [TestMethod()]
        public void Check_8Symbols_ReturnsTrue()
        {
            // Arrange
            string password = "Aq/1hhhhh";
            bool expected = true;

            // Act
            bool actual = Classes.Checker.CheckPassword(password);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}