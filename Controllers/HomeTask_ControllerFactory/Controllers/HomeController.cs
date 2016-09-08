using System.Web.Mvc;
using System.Web.SessionState;
using HomeTask_ControllerFactory.Infrastructure;

namespace HomeTask_ControllerFactory.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("View", Repository.Get());
        }
    }
}