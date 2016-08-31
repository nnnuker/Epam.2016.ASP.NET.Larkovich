using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ClassLibraryJson
{
    public class HomeController : Controller
    {
        public JsonResult Index()
        {
            var id = RouteData.Values.ContainsKey("id") ? RouteData.Values["id"] : 0;
            var custom = RouteData.Values.ContainsKey("custom") ? RouteData.Values["custom"] : "custom";
            return Json($"Json result: {custom}, {id}", JsonRequestBehavior.AllowGet);
        }
    }
}
