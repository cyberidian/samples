using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AtomicArcade;
using AtomicArcade.Controllers;

namespace AtomicArcade.Tests.Controllers
{
    [TestClass]
    public class PortalControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            PortalController controller = new PortalController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            PortalController controller = new PortalController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Cards()
        {
            // Arrange
            PortalController controller = new PortalController();

            // Act
            ViewResult result = controller.Cards() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Casino()
        {
            // Arrange
            PortalController controller = new PortalController();

            // Act
            ViewResult result = controller.Casino() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Puzzles()
        {
            // Arrange
            PortalController controller = new PortalController();

            // Act
            ViewResult result = controller.Puzzles() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Copyright()
        {
            // Arrange
            PortalController controller = new PortalController();

            // Act
            ViewResult result = controller.Copyright() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Privacy()
        {
            // Arrange
            PortalController controller = new PortalController();

            // Act
            ViewResult result = controller.Privacy() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Terms()
        {
            // Arrange
            PortalController controller = new PortalController();

            // Act
            ViewResult result = controller.Terms() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
