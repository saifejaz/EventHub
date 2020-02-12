using EventHub.Areas.Security.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EventHub.Tests.Controllers
{
    [TestClass]
    public class RegisterControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            RegisterController controller = new RegisterController();
            string viewName = "Index";

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(viewName, result.ViewName);
        }
    }
}
