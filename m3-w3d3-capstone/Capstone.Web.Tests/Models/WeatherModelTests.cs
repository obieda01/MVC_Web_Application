using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Capstone.Web.Tests.Models
{
    [TestClass]
    public class WeatherModelTests
    {
        [TestMethod]
        public void WeatherModelTests_ParkCodeProperty_Test()
        {
            Type type = typeof(Weather);
            PropertyInfo property = type.GetProperty("ParkCode");

            Assert.IsTrue(property.CanRead);
            Assert.IsTrue(property.CanWrite);
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsNotNull(property);
        }
    }
}