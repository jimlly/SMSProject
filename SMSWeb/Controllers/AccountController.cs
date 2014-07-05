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
        public ActionResult LoginOut()
        {
            //todo
            return RedirectToAction("Login");
        }
    }
}
