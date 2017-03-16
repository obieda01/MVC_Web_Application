using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Capstone.Web.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void HomeController_IndexAction_ReturnIndexView()
        {
            /*TEST
             * 
             * Test if the index action return index view (the right view)
            */

            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Index() as ViewResult; // cast ViewAction to ViewResult

            //Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod()]
        public void HomeController_ParkListAction_ReturnParkListView()
        {
            /*TEST
             * 
             * Test if the ParkList Action return ParkList view (the right view)
            */

            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.ParkList() as ViewResult; // cast ViewAction to ViewResult

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ParkList", result.ViewName);
        }
    }
}