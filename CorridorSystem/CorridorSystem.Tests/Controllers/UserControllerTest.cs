using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorridorSystem;
using CorridorSystem.Controllers;
using System.Web.Http.Results;

namespace CorridorSystem.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void GetUser()
        {
            // Arrange
            UserController controller = new UserController();

            // Act
            IHttpActionResult result = controller.Get(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void GetAllUsers()
        {
            // Arrange
            UserController controller = new UserController();

            // Act
            IHttpActionResult result = controller.Get1(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkResult));
            var res = result.GetType().GetProperty("Id").GetValue(result, null);
            Assert.IsNotNull(res);
        }
    }
}
