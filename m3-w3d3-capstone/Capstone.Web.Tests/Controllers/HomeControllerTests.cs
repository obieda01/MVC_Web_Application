using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Web;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Capstone.Web.Controllers;
using Moq;
using System.Web.Routing;

namespace Capstone.Web.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void HomeController_ParkListAction_ReturnParkListView()
        {
            /*TEST
             *
             * Test if the ParkList Action return ParkList view (the right view)
            */

            //Arrange
            Mock<ParkSqlDAL> mockDal = new Mock<ParkSqlDAL>();
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.ParkList() as ViewResult; // cast ViewAction to ViewResult

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ParkList", result.ViewName);
            Assert.IsNotNull(result.Model as Park);
        }
        [TestMethod()]
        public void HomeController_ParkDetailAction_ReturnParDetailView()
        {
            /*TEST
             *
             * Test if the ParkDetails Action returns ParkDetails view (the right view)
            */

            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.ParkDetails("CVNP") as ViewResult; // cast ViewAction to ViewResult

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ParkDetails", result.ViewName);
        }

        [TestMethod()]
        public void HomeController_WeatherAction_ReturnsWeatherView()
        {
            /*TEST
             *
             * Test if the Weather Action return Weather view (the right view)
            */

            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Weather("CVNP") as ViewResult; // cast ViewAction to ViewResult

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Weather", result.ViewName);
        }
        [TestMethod()]
        public void HomeController_Change_F_to_C_Test()
        {
            HomeController controller = new HomeController();
          
            Assert.AreEqual(18, controller.ChangeFaranheightToCelcius(66.0, "C"));
            Assert.AreEqual(-1, controller.ChangeFaranheightToCelcius(30.0, "C"));
        }
    }
}