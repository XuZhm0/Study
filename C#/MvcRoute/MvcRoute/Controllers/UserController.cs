using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRoute.Controllers {
	public class UserController : Controller {
		// GET: User
		public ActionResult Login() {
			return View();
		}

		[HttpPost]
		public ActionResult Login2() {
			string username = Request["username"];
			string pwd = Request["pwd"];
			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pwd)) {
				return Json(new {
					msg = "登录失败，用户名或密码不能为空！",
					status = 0
				});
			} else {
				Session.Add("username", username);
				Session.Add("pwd", pwd);

				return Json(new {
					msg = "登录成功！",
					status = 1
				});

			}
		}
	}

	public class UserAttribute : AuthorizeAttribute	{
		public override void OnAuthorization(AuthorizationContext filterContext) {
			if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute),false)){
				return;
			}
			var username =filterContext.HttpContext.Session["username"];
			var pwd =filterContext.HttpContext.Session["pwd"];
			 
			if (username == null|| pwd == null) {
				filterContext.Result = new RedirectResult($"/User/Login?oldUrl={filterContext.HttpContext.Request.Url.LocalPath}");
			}
		}
	}
}