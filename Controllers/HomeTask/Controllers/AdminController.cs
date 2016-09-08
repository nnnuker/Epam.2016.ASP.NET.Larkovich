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

        [OnlyLocal]
        public ActionResult Edit(int id)
        {
            var user = Repository.Get().First(u=>u.Id == id);
            user.Age++;
            return RedirectToAction("User-List", "Customer");
        }

        [OnlyLocal]
        public ActionResult Delete(int id)
        {
            Repository.DeleteUser(id);
            return RedirectToAction("User-List", "Customer");
        }
    }
}