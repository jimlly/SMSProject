using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSWeb.Common;
namespace SMSWeb.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userAccount,string password,string code="")
        {
            var session = HttpContext.Session;
            session["LoginInfo"] = new SMS.Model.LoginInfo() { UserID = 1, CompID=0, UserAccount = "admin", UserName = "管理员" };
            return RedirectToAction("Index", "Home");
            
        }
        public ActionResult LoginOut()
        {
            //todo
            return RedirectToAction("Login");
        }
    }
}
