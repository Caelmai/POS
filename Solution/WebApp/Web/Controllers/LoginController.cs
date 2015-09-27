using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApp.DataManagers;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login]/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Login(string email, string password)
        {
            var loginResult = LoginDataManager.Instance.CheckPassword(email, password);

            if (loginResult.Success)
            {
                FormsAuthentication.SetAuthCookie(email, false);
            }

            var resp = Json(loginResult, JsonRequestBehavior.AllowGet);
            return resp;
        }


    }
}
