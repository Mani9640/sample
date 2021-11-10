using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStoreMVCWenApp
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      //https://localhost:44320/Soccer/List/Page1orpage2or3
      routes.MapRoute("categorypage","{category}/Page{page}", new{ controller="Product", action = "List" }, new { page = @"\d+" });


      // https://localhost:44320/Product/List/page1or2or3
      routes.MapRoute(
        name: "page",
        url: "Page{page}",
        defaults: new { controller = "Product", action = "List" },
        constraints: new { page = @"\d+" });




      // https://localhost:44320/Soccer
      routes.MapRoute("category", "{category}", new
      {
        controller =
       "Product",
        action = "List", page=1
      });



      routes.MapRoute(
          name: "Default",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
      );
      // default Route
      //routes.MapRoute(
      //    name: "Default",
      //    url: "{controller}/{action}/{id}",
      //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
      //);
    }
  }
}
