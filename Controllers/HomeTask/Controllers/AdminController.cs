using HomeTask.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeTask.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [OnlyLocal]
        public ActionResult Index()
        {
            return View();
        }
    }
}