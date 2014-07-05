using Public.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SMSWeb.Areas.Addr.Controllers
{
    public class CotactorGroupController : Controller
    {
        //
        // GET: /Addr/CotactorGroup/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Addr/CotactorGroup/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Addr/CotactorGroup/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Addr/CotactorGroup/Create

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
        // GET: /Addr/CotactorGroup/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Addr/CotactorGroup/Edit/5

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
        // GET: /Addr/CotactorGroup/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Addr/CotactorGroup/Delete/5

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
        [HttpPost]
        public ContentResult GetList()
        {
            int pageIndex = 1;
            int pageSize = int.MaxValue;
            string search = "";
            string str = "";
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            var sb = new StringBuilder();

            SMS.Model.Result.ResultContactorGroupList _rcg = new SMS.Model.Result.ResultContactorGroupList();
            if (_rcg != null && _rcg.CGroups != null && _rcg.CGroups.Count > 0)
            {


                int y = 0;
                foreach (var obj in _rcg.CGroups)
                {
                    var currentPage = Math.Floor(Convert.ToDouble(y / 10)) + 1;
                    sb.Append("<li page='" + currentPage + "'  id='li" + obj.ContactorGroupID + "' style='cursor: pointer'><div id='divShowGroup" + obj.ContactorGroupID + "' class='group-user-show' onclick=\"li_click('li" + obj.ContactorGroupID + "','" + obj.ContactorGroupName + "')\"><a>" + obj.ContactorGroupName + "</a><span id='spCount" + obj.ContactorGroupID + "' class='badge badge-hover3'>" + obj.ContactorCount + "</span><span class='badge badge-hover2' title='编辑' onclick=\"javascript:li_dblclick('" + obj.ContactorGroupID + "','" + obj.ContactorGroupName + "')\"><span><i class='icon-pencil icon-white'></i></span></span><span class='badge badge-hover' title='删除' onclick=\"javascript:li_delclick('li" + obj.ContactorGroupID + "')\" ><span><i class='icon-trash icon-white'></i></span></span></div><div style='position:relative' id='divEditGroup" + obj.ContactorGroupID + "' class='group-user-edit form-inline'><div style='padding-right:130px'><input type='text' id='txtEdit" + obj.ContactorGroupID + "' class='input-small' value='" + obj.ContactorGroupName + "'  style='width:100%;' /></div><div style='position: absolute;right:2px;top: 4px;'><input type='button' id='btnOK' onclick=\"SaveGroupByLeft('" + obj.ContactorGroupID + "')\" value='确定' class='btn btn-primary' />&nbsp;<input type='button' id='btnCancel' onclick=\"CloseGroupByLeft('" + obj.ContactorGroupID + "')\" value='取消' class='btn' /></div></div></li>");

                    y++;

                }
                str = sb.ToString();
            }
            return Content(str);
        }
        [HttpPost]
        public ContentResult GetGroupCount()
        {
            string groupId = QueryString.F("groupId");
            string search =  QueryString.F("search");
            return Content("10");
        }
    }
}
