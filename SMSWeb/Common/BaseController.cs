using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSWeb.Common
{
    public class BaseController : Controller
    {

        public LoginInfo LoginInfo {
            get {
                
                var session = HttpContext.Session;
                if (session != null)
                {
                    var logininfo = HttpContext.Session["LoginInfo"];
                    if (logininfo != null)
                    {
                        return (LoginInfo)logininfo;
                    }
                }
                return null;
            }
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            
            if (this.LoginInfo == null)
            {
                filterContext.Result = RedirectToAction("Login", "Account", new { area = "" });
                return;
            }
            
        }
    }
}