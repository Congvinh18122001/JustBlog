using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JustBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Tag",
               url: "Tag/{id}",
               defaults: new { controller = "Blog", action = "Tag", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Category",
               url: "Category/{id}",
               defaults: new { controller = "Blog", action = "Category", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Blog", action = "Posts", id = UrlParameter.Optional }
            );
        }
    }
}
