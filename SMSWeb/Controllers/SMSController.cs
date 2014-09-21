using Public.Helper;
using SMS.Model;
using SMSWeb.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSWeb.Controllers
{
    public class SMSController : BaseController
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
            return View(new SmsInfo());
        }

        //
        // POST: /SMS/Send

        [HttpPost]
        public JsonResult Send(SmsInfo sms)
        {
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
           var Mobiles = StringHelper.GetStrArray(sms.Sender, ';', false);
           var SmsDetailList = new List<SmsDetailInfo>();
           foreach (var m in Mobiles)
           {
               var smsDetail = new SmsDetailInfo();
              var s = StringHelper.GetStrArray(m, ',', false);
              smsDetail.Mobile = s[0];
              if (s.Count > 1)
              {
                  smsDetail.Name = s[1];
              }
              SmsDetailList.Add(smsDetail);
           }
           SmsDetailList.Distinct(new MobileComparer());
           if (sms.SendWay == SendWay.Immed) {
               sms.SendTime = DateTime.Now;
           }
           sms.SubmitTime = DateTime.Now;
           sms.Priority = SmsPriority.Normal;
           sms.Sender = this.LoginInfo.UserName;
           sms.CreateTime = DateTime.Now;
           sms.SmsDetailList = SmsDetailList;
           sms.UserID = this.LoginInfo.UserID;

          var rs =  this.SmsManager.SendSms(sms);
         
          

          return Json(rs);
        }
        public class MobileComparer : IEqualityComparer<SmsDetailInfo>
        {
            

            public bool Equals(SmsDetailInfo x, SmsDetailInfo y)
            {
                return x.Mobile != y.Mobile;
            }

            public int GetHashCode(SmsDetailInfo obj)
            {
                return obj.GetHashCode();
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
           // List<dynamic> list = new List<dynamic>();
           //// ArrayList list = new ArrayList();
           // for (int i = 0; i < 50; i++)
           // {
           //     var data = new {ID= i, Name = "任务名称" + i, MsgID = DateTime.Now.Ticks.ToString(), Mobile = "138000" + new Random().Next(10000, 99999), Content = "测试内容" + i, SendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Amount = new Random().Next(1, 10), State = "" + new Random().Next(1, 3).ToString() + "",SendCount=new Random().Next(1, 100), SuccessCount = new Random().Next(1, 100), FailCount = new Random().Next(1, 100) };
           //     list.Add(data);
           // }
            var taskName = "";
            var startTime = DateTime.Now.AddDays(-7);
            var endTime = DateTime.Now;
            var draw = collection["draw"];
            var pageIndex = Convert.ToInt32(collection["start"]) == 0 ? Convert.ToInt32(collection["start"]) + 1 : Convert.ToInt32(collection["start"]);
            var pageSize = Convert.ToInt32(collection["length"]);
           // var temp = list.Skip(Convert.ToInt32(pageIndex)).Take(Convert.ToInt32(pageSize));
            var rs = this.SmsManager.GetSmsList(this.LoginInfo.UserID, taskName, startTime, endTime, pageSize, pageIndex);
            var objdata = new { draw = draw, recordsTotal = rs.Total, recordsFiltered = rs.Total, data = rs.SmsList };

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
        public ActionResult UpLoadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpLoadFile(FormCollection collection)
        {
            var file = Request.Files["file0"];
            file.SaveAs(@"d:\wcf\" + file.FileName);
            return Json(new { result = 1, info = "上传成功" }); 
            
        }
        public ActionResult SendOk()
        {
            return View();
        }

    }
}
