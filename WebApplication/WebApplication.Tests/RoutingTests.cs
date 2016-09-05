using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Machine.Specifications;
using System.Web.Routing;
using Moq;
using It = Machine.Specifications.It;

namespace WebApplication.Tests
{
    [Subject("routing")]
    public class When_routing
    {
        private static Mock<HttpContextBase> httpContextMock;
        private static RouteCollection routes;
        private static string url = "~/Home/Index/Custom/100";
        private static RouteData routeData;

        Establish establish = () =>
        {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            httpContextMock = new Mock<HttpContextBase>();
            httpContextMock.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                .Returns(url);
        };

        Because of = () => { routeData = routes.GetRouteData(httpContextMock.Object); };

        It should_not_be_null = () =>
        {
            routeData.ShouldNotBeNull();
        };

        It should_be_true = () =>
        {
            routeData.Values.ContainsKey("custom").ShouldBeTrue();
        };

        It should_equal_custom = () =>
        {
            routeData.Values["custom"].ShouldEqual("Custom");
        };

        It should_be_true_id = () =>
        {
            routeData.Values.ContainsKey("id").ShouldBeTrue();
        };

        It should_equal_id = () =>
        {
            routeData.Values["id"].ShouldEqual("100");
        };
    }

    [Subject("default routing")]
    public class When_default_routing
    {
        private static Mock<HttpContextBase> httpContextMock;
        private static RouteCollection routes;
        private static string url = "~/";
        private static RouteData routeData;

        Establish establish = () =>
        {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            httpContextMock = new Mock<HttpContextBase>();
            httpContextMock.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                .Returns(url);
        };

        Because of = () => { routeData = routes.GetRouteData(httpContextMock.Object); };

        It should_not_be_null = () =>
        {
            routeData.ShouldNotBeNull();
        };

        It should_be_true = () =>
        {
            routeData.Values.ContainsKey("custom").ShouldBeTrue();
        };

        It should_equal_custom = () =>
        {
            routeData.Values["custom"].ShouldEqual("DefaultCustom");
        };

        It should_be_true_id = () =>
        {
            routeData.Values.ContainsKey("id").ShouldBeTrue();
        };
    }
}
