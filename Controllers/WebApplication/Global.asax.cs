using System.Web.Mvc;
using System.Web.Routing;
using WebApplication.Infrastructure;

namespace WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());
            //ControllerBuilder.Current.DefaultNamespaces.Add("");

            //ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory(new CustomControllerActivator()));

            
        }
    }
}
