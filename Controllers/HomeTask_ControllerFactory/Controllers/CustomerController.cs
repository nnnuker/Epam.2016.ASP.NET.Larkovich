using System.Threading.Tasks;
using System.Web.Mvc;
using HomeTask_ControllerFactory.Infrastructure;
using HomeTask_ControllerFactory.Models;

namespace HomeTask_ControllerFactory.Controllers
{
    //[Route("{values(User|Customer)}")]
    public class CustomerController : Controller
    {
        [HttpGet]
        [ActionName("Add-User")]
        public ActionResult AddUser()
        {
            return View("AddUser");
        }

        [HttpPost]
        [ActionName("Add-User")]
        public async Task<ActionResult> AddUser(UserModel user)
        {
            var users = await Repository.AddUser(user);
            return View("View", users);
        }

        [HttpGet]
        [ActionName("User-List")]
        public ActionResult UserList()
        {
            return View("View", Repository.Get());
        }

        [HttpPost]
        [ActionName("User-List")]
        public JsonResult UserList(string submit)
        {
            return Json("Some data", JsonRequestBehavior.AllowGet);
        }
    }
}