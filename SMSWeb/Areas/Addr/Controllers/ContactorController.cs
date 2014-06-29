using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSWeb.Areas.Addr.Controllers
{
    public class ContactorController : Controller
    {
        //
        // GET: /Addr/Contactor/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Addr/Contactor/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Addr/Contactor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Addr/Contactor/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        //
        // GET: /Addr/Contactor/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Addr/Contactor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Addr/Contactor/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Addr/Contactor/Delete/5

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
