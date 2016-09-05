using HomeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeTask.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [ActionName("Add-User")]
        public ActionResult AddUser()
        {
            return null;
        }

        [HttpPost]
        [ActionName("Add-User")]
        public ActionResult AddUser(UserModel user)
        {
            return null;
        }

        [HttpGet]
        [ActionName("User-List")]
        public ActionResult UserList()
        {
            return null;
        }

        [HttpPost]
        [ActionName("User-List")]
        public JsonResult UserList(string submit)
        {
            return Json("Data", JsonRequestBehavior.AllowGet);
        }
    }
}