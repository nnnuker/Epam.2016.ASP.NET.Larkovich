using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeTask.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public ActionResult Index()
        {
            return View();
        }

        protected override void HandleUnknownAction(string actionName)
        {
            
            //base.HandleUnknownAction(actionName);
        }
    }
}