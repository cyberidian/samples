using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;

namespace AtomicArcade.Tests.ServicesTests
{
    /// <summary>
    /// Summary description for CategoryServiceTest
    /// </summary>
    [TestClass]
    public class CategoryServiceTest
    {

        [TestMethod]
        public void TestCategoryService_GetGamesByCategory()
        {

            var categoryService = new CategoryService();
            var games = categoryService.GetGamesByCategory(2);

            Assert.AreEqual(games[0].Name, "Halloween Slider 1");
        }

        [TestMethod]
        public void TestCategoryService_GetAllCategories()
        {

            var categoryService = new CategoryService();
            var categories = categoryService.GetAllCategories();

            Assert.AreEqual(categories[0].Name, "Card Games");
        }

        [TestMethod]
        public void TestCategoryService_GetAllCategoriesDetails()
        {

            var categoryService = new CategoryService();
            var categories = categoryService.GetAllCategoriesDetails();

            Assert.AreEqual(categories[0].Name, "Card Games");
        }


        [TestMethod]
        public void TestCategoryService_GetCategory()
        {

            var categoryService = new CategoryService();
            var category = categoryService.GetCategory(3);

            Assert.AreEqual(category.Name, "Casino");
        }

    }
}
