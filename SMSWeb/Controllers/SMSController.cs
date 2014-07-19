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
            List<dynamic> list = new List<dynamic>();
           // ArrayList list = new ArrayList();
            for (int i = 0; i < 50; i++)
            {
                var data = new {ID= i, Name = "任务名称" + i, MsgID = DateTime.Now.Ticks.ToString(), Mobile = "138000" + new Random().Next(10000, 99999), Content = "测试内容" + i, SendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Amount = new Random().Next(1, 10), State = "" + new Random().Next(1, 3).ToString() + "",SendCount=new Random().Next(1, 100), SuccessCount = new Random().Next(1, 100), FailCount = new Random().Next(1, 100) };
                list.Add(data);
            }
            var draw = collection["draw"];
            var pageIndex = collection["start"];
            var pageSize = collection["length"];
            var temp = list.Skip(Convert.ToInt32(pageIndex)).Take(Convert.ToInt32(pageSize));

            var objdata = new { draw = draw, recordsTotal = list.Count, recordsFiltered = list.Count, data = temp };

            return Json(objdata, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SendDetail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendDetail(FormCollection collection)
        {
            List<dynamic> list = new List<dynamic>();
            // ArrayList list = new ArrayList();
            for (int i = 0; i < 50; i++)
            {
                var data = new { ID = i,Name="张三", MsgID = DateTime.Now.Ticks.ToString(), Mobile = "138000" + new Random().Next(10000, 99999), SendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Amount = new Random().Next(1, 10), State = "" + new Random().Next(1, 3).ToString() + "" };
                list.Add(data);
            }
            var draw = collection["draw"];
            var pageIndex = collection["start"];
            var pageSize = collection["length"];
            var temp = list.Skip(Convert.ToInt32(pageIndex)).Take(Convert.ToInt32(pageSize));

            var objdata = new { draw = draw, recordsTotal = list.Count, recordsFiltered = list.Count, data = temp };

            return Json(objdata, JsonRequestBehavior.AllowGet);
            return View();
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
