using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRoute.Controllers {
	[User]
	public class HomeController : Controller {
		[AllowAnonymous]
		public ActionResult Index() {


			ViewBag.types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
			return View();
		}

		public ActionResult About() {
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact() {
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Ajax() {
			return View();
		}

		[HttpGet]
		public ActionResult Get() {
			var r = new {
				message = "get",
				status = 0
			};

			return Json(r);
		}


		[HttpPost]
		public ActionResult Post() {
			var r = new {
				id = Request["Id"],
				name = Request["Name"]
			};

			return Json(r);
		}



		public string Abort() {
			System.Threading.Thread.Sleep(100 * 1000);

			return "Abort";
		}
		
		[AllowAnonymous]
		public ActionResult ClearSession() {
			Session.Remove("username");
			Session.Remove("pwd");

			return Json(new { msg = "清理成功！" }, JsonRequestBehavior.AllowGet);
		}

	}
}