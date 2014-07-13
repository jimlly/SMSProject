using System;
using System.Collections;
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
        [HttpPost]
        public ActionResult GetSendList(FormCollection collection)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                var data = new { Name = "任务名称"+i, Mobile = "138000" + new Random().Next(10000, 99999), Content = "测试内容"+i, DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), State = "" + new Random().Next(1, 3).ToString() + "" };
                list.Add(data);
            }
           
            var objdata = new {draw=1,recordsTotal=100,recordsFiltered=100, data=list};

            return Json(objdata, JsonRequestBehavior.AllowGet);
        }

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
