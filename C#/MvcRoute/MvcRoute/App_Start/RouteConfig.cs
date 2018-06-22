using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcRoute {
	public class RouteConfig {
		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
			
			routes.MapRoute(
				name: "Default2",
				url: "{controller}/{action}",
				defaults: new { controller = "Home", action = "Index" }
			);

		}
		public static void InitRoutes(){
			Assembly assembly = Assembly.GetExecutingAssembly();


		}
	}
}
