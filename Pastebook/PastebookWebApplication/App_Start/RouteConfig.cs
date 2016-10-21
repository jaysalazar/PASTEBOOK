using System.Web.Mvc;
using System.Web.Routing;

namespace PastebookWebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // source: http://stackoverflow.com/questions/21337823/change-route-url-in-asp-net-mvc
            //routes.MapRoute(
            //    name: "Profile",
            //    url: "{id}",
            //    defaults: new { controller = "Profile", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "LogIn", id = UrlParameter.Optional }
            );
        }
    }
}
