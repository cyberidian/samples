using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AtomicArcade.Services;

namespace AtomicArcade.Tests
{
    /// <summary>
    /// Summary description for AdServiceTests
    /// </summary>
    [TestClass]
    public class AdServiceTests
    {

        [TestMethod]
        public void TestAdService_GetAds()
        {
            var adService = new AdService();
            var ads = adService.GetAds("home");

            Assert.AreEqual(ads[0].Name, "Retro Rocket");

        }
    }
}
