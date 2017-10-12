using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtomicArcade.Controllers
{
    public class PortalController : Controller
    {
        public ActionResult Index()
        {
            var categoryService = new CategoryService();
            ViewBag.CategoryVM = categoryService.GetAllCategories();
            ViewBag.Current = "Index";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Category(int id)
        {
            var categoryService = new CategoryService();
            ViewBag.CategoryVM = categoryService.GetCategory(id);
            ViewBag.CategoryGameList = categoryService.GetGamesByCategory(id).ToList();
            ViewBag.Current = ViewBag.CategoryVM.Name;

            return View();
        }

        public ActionResult Copyright()
        {
            ViewBag.Message = "Copyright";

            return View();
        }
        public ActionResult Privacy()
        {
            ViewBag.Message = "Privacy";

            return View();
        }
        public ActionResult Terms()
        {
            ViewBag.Message = "Terms";

            return View();
        }
    }
}