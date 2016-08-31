using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Static",
                url: "Home/Index/{custom}/{id}",
                defaults: new { controller = "Home", action = "Index", custom = "Custom", id = UrlParameter.Optional }, 
                constraints: new { custom = new AlphaRouteConstraint(), id = new RangeRouteConstraint(1, 200)},
                namespaces: new[] { "ClassLibraryJson" }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{custom}/{id}",
                defaults: new { controller = "Home", action = "Index", custom = "DefaultCustom", id = UrlParameter.Optional },
                namespaces: new[] { "WebApplication.Controllers" }
            );
        }
    }
}
