using SMS.BLL.Addr;
using SMS.Model.Result;
using SMSWeb.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SMSWeb.Areas.Addr.Controllers
{
    public class ContactorController : BaseController
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

        public ActionResult Edit(string contactId, string groupId)
        {
          
            //ViewData["ContactorID"] = contactorId;
            //ViewData["GroupID"] = groupId;
            ViewBag.ContactorID = contactId;
            ViewBag.GroupID = groupId;
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

        [HttpPost]
        public ContentResult GetContactorList()
        {
            var _rcl = new ResultContactorList();
            var _cgm = new ContactorGroupManager();
            try
            {
                string str;
                int pageIndex = Convert.ToInt32(Request["pageindex"]);
                int pageSize = Convert.ToInt32(Request["pagesize"]);
                var searchContent =Request["search"];
                var groupId = Convert.ToInt32(Request["groupid"]);



                if (pageIndex == 0)
                {
                    pageIndex = 1;
                }

                if (groupId == -2) //未分组
                {
                    _rcl = _cgm.GetUnGroupedContactors(this.LoginInfo.UserID, LoginInfo.CompID, pageIndex, pageSize, searchContent);
                }
                else if (groupId == 0)//全部
                {
                    _rcl = _cgm.GetAllContactors(LoginInfo.UserID, LoginInfo.CompID, pageIndex, pageSize, searchContent);
                }
                else
                {
                    _rcl = _cgm.GetUserGroupContactors(LoginInfo.UserID, groupId, LoginInfo.CompID, pageIndex, pageSize, searchContent);
                }

                if (!_rcl.State)
                {
                  
                }
                else
                {
                    var sb = new StringBuilder();
                    foreach (var item in _rcl.Contactors)
                    {
                        var groupName = "";
                        var groupIds = "";
                        if (item.CGroups != null)
                        {
                            foreach (var contactorGroup in item.CGroups)
                            {
                                groupName += contactorGroup.ContactorGroupName + " ";
                                groupIds += contactorGroup.ContactorGroupID + " ";
                            }
                        }
                        sb.Append("<tr class=\"table-border-tr\">");
                        sb.Append("<td><input type='checkbox' name='cbItem' value='" + item.ContactorID + "' /></td>");
                        sb.Append("<td onclick=\"javascript:EditContact('" + item.ContactorID + "',this)\">" + item.ContactorName + "</td>");
                        sb.Append("<td onclick=\"javascript:EditContact('" + item.ContactorID + "',this)\">" + item.ConfParticipatePhoneNo + "</td>");
                        sb.Append("<td onclick=\"javascript:EditContact('" +
                                  item.ContactorID + "',this)\">" + groupName + "</td>");
                        sb.Append("<td id='adrTdGroup" + item.ContactorID + "' style='display:none'>" + groupIds + "</td></tr>");
                        sb.Append("<tr class=\"table-border-hover\">");
                        sb.Append("<td colspan='4' class=\"address-hidden pd-no\"  style=\"display: none;\" id='td" + item.ContactorID + "'></td></tr>");
                    }
                    str = sb.ToString();
                    return Content(str);
                }
            }
            catch (Exception ex)
            {
                //_log.Append("AddressPageHandler错误", ex.ToString());
            }
            return Content("");
        }
    }
}
