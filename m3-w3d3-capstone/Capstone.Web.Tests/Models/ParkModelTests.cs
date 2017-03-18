using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Capstone.Web.Tests.Models
{
    [TestClass]
    public class ParkModelTests
    {
        [TestMethod]
        public void ParkModelTests_ParkCodeProperty_Test()
        {
            Type type = typeof(Park);
            PropertyInfo property = type.GetProperty("ParkCode");

            Assert.IsNotNull(property);
            Assert.IsTrue(property.CanWrite);
            Assert.IsTrue(property.CanRead);
            Assert.AreEqual(typeof(string), property.PropertyType);
        }

        [TestMethod]
        public void ParkModelTests_ParkNameProperty_Test()
        {
            Type type = typeof(Park);
            PropertyInfo property = type.GetProperty("ParkName");

            Assert.IsNotNull(property);
            Assert.IsTrue(property.CanWrite);
            Assert.IsTrue(property.CanRead);
            Assert.AreEqual(typeof(string), property.PropertyType);
        }
    }
}