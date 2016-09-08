using System.Web.Mvc;

namespace HomeTask_ControllerFactory.Controllers
{
    public class BaseController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            Response.Write("404 error");
            //base.HandleUnknownAction(actionName);
        }
    }
}