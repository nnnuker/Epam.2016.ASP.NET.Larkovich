using System.Linq;
using System.Web.Mvc;
using HomeTask_ControllerFactory.Infrastructure;

namespace HomeTask_ControllerFactory.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Edit(int id)
        {
            var user = Repository.Get().First(u=>u.Id == id);
            user.Age++;
            return RedirectToAction("User-List", "Customer");
        }

        public ActionResult Delete(int id)
        {
            Repository.DeleteUser(id);
            return RedirectToAction("User-List", "Customer");
        }
    }
}