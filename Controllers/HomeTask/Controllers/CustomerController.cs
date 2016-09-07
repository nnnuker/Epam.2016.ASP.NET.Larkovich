using HomeTask.Infrastructure;
using HomeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HomeTask.Controllers
{
    public class CustomerController : Controller
    {
        private Repository repository = new Repository();

        [HttpPost]
        [ActionName("Add-User")]
        public async Task<ActionResult> AddUser(UserModel user)
        {
            var users = await repository.AddUser(user);
            return View(users);
        }

        [HttpGet]
        [ActionName("User-List")]
        public ActionResult UserList()
        {
            return View();
        }

        [HttpPost]
        [ActionName("User-List")]
        public JsonResult UserList(string submit)
        {
            return Json("Some data", JsonRequestBehavior.AllowGet);
        }
    }
}