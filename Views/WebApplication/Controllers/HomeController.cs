using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var data = new string[] {"orange", "apple", "grapes" };
            return View(data);
        }

        public ActionResult CustomData()
        {
            ViewData.Add("viewDataKey", "viewDataValue");
            return View("CustomData");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}