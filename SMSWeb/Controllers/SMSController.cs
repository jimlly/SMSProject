using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSWeb.Controllers
{
    public class SMSController : Controller
    {
        //
        // GET: /SMS/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SendDetail()
        {
            return View();
        }
        //
        // GET: /SMS/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /SMS/Create

        public ActionResult Send()
        {
            return View();
        }

        //
        // POST: /SMS/Create

        [HttpPost]
        public ActionResult Send(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult SendList()
        {
            return View();
        }
        //
      

        //
        // GET: /SMS/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /SMS/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
