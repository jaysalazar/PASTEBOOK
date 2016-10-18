using System.Web.Mvc;
using System.Web.Routing;

namespace PastebookWebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //site/username
            //routes.MapRoute(
            //   name: "Pastebook",
            //   url: "/{id}",
            //   defaults: new { controller = "Pastebook", action = "LogIn", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Pastebook", action = "LogIn", id = UrlParameter.Optional }
            );
        }
    }
}
