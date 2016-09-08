using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using HomeTask_ControllerFactory.Controllers;

namespace HomeTask_ControllerFactory.Infrastructure
{
    public class CustomControllerFactory:IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type targetType = null;
            switch (controllerName)
            {
                case "Home":
                    targetType = typeof(HomeController);
                    break;
                case "Customer":
                    targetType = typeof(CustomerController);
                    break;
                case "User":
                    targetType = typeof(CustomerController);
                    break;
                case "Admin":
                    if (requestContext.HttpContext.Request.IsLocal)
                    {
                        targetType = typeof(AdminController);
                    }
                    break;
                case "Base":
                    targetType = typeof(BaseController);
                    break;
                default:
                    requestContext.RouteData.Values["controller"] = "Home";
                    targetType = typeof(HomeController);
                    break;
            }

            return targetType == null ? null : (IController)DependencyResolver.Current.GetService(targetType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return controllerName == "Home" ? SessionStateBehavior.Disabled : SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            disposable?.Dispose();
        }
    }
}