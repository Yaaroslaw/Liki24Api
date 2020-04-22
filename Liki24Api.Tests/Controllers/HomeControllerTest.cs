using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Liki24Api;
using Liki24Api.Controllers;

namespace Liki24Api.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
