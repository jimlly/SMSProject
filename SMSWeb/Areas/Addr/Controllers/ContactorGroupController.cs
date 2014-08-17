using Public.Common;
using Public.Log;
using Public.Result;
using SMS.BLL.Addr;
using SMS.Model.Addr;
using SMSWeb.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SMSWeb.Areas.Addr.Controllers
{
    public class ContactorGroupController : BaseController
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
        [HttpPost]
        [ActionName("AddGroup")]
        public int Create(string groupName)
        {
            var cgm = new ContactorGroupManager();

            var br = cgm.AddGroup(LoginInfo.UserID, groupName, LoginInfo.CompID);

            return br.Value;
        }

        //
        // POST: /Addr/CotactorGroup/Create

        [HttpPost]
        public ActionResult GetALLGroups()
        {
           

                var cgm = new ContactorGroupManager();
                var rcgl = cgm.GetGroups(LoginInfo.UserID, LoginInfo.CompID, 1, int.MaxValue, "");
                if (!rcgl.State)
                {
                   
                    return null;
                }

                if (rcgl.CGroups != null && rcgl.CGroups.Count > 0)
                {

                    return Json(rcgl.CGroups, JsonRequestBehavior.AllowGet);
                }
                return null;
        }

        //
        // POST: /Addr/CotactorGroup/Edit
        [HttpPost]
        public int Edit(int groupId, string groupName)
        {
            var cgm = new ContactorGroupManager();

            var br = cgm.SetGroupName(LoginInfo.UserID, groupId, groupName, LoginInfo.CompID);
            return br.Value;
        }

      

        //
        // GET: /Addr/CotactorGroup/Delete/5
       
        public bool SetContactGroupBySingle(string contactId, string groupIds)
        {

            contactId = contactId.Substring(1, contactId.Length - 2);
            groupIds = groupIds.Substring(1, groupIds.Length - 2);



            var cm = new ContactorManager();

            var ls = new List<ContactorGroup>();

            if (!string.IsNullOrEmpty(groupIds))
                ls.AddRange(groupIds.Split(',').Select(item => new ContactorGroup { ContactorGroupID = Convert.ToInt32(item) }));

            var br = cm.SetContactorGroups(LoginInfo.UserID, ls, Convert.ToInt32(contactId), LoginInfo.CompID);


            return br.State;


        }
        [HttpPost]
        public bool DelContactByGroup(List<int> contactIds, int groupId)
        {
           
                var cm = new ContactorManager();
                var ls = new List<Contactor>();

                if (contactIds.Count()>0)
                    ls.AddRange(contactIds.Select(item => new Contactor() { ContactorID = item }));

                BaseResult br = new BaseResult();
                if (groupId == 0)
                {
                    br = cm.DelContactors(LoginInfo.UserID, ls, LoginInfo.CompID);
                }
                else
                {
                    br = cm.DelContactorsByGroup(LoginInfo.UserID, ls, LoginInfo.CompID, groupId);
                }
                return br.State;
               
        }
        [HttpPost]
        public bool SetContactGroupByMulti(List<int> contactIds, List<int> groupIds)
        {


         
            var cgm = new ContactorGroupManager();




            var groupLs = new List<ContactorGroup>();
            if (groupIds.Count > 0)
                groupLs.AddRange(groupIds.Select(item => new ContactorGroup { ContactorGroupID = item }));

            var cLs = new List<Contactor>();
            if (contactIds.Count > 0)
                cLs.AddRange(contactIds.Select(item => new Contactor { ContactorID =item }));
            BaseResult br = null;
            if (contactIds.Count() == 1)
            {
                int contactId = contactIds[0];
                var cm = new ContactorManager();
                br = cm.SetContactorGroups(LoginInfo.UserID, groupLs, contactId, LoginInfo.CompID);
            }
            else
            {
                br = cgm.CopyContactorsToOtherGroups(LoginInfo.UserID, groupLs, cLs, LoginInfo.CompID);
            }

            return br.State;

        }
        //
        // POST: /Addr/CotactorGroup/Delete/5

        [HttpPost]
        public bool DelGroup(int groupId)
        {
            ContactorGroupManager cgm = new ContactorGroupManager();

            List<ContactorGroup> ls = new List<ContactorGroup>();

            ls.Add(new ContactorGroup() { ContactorGroupID = groupId });

            var br = cgm.DelGroups(LoginInfo.UserID, ls, LoginInfo.CompID);

            return br.State;
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

           // SMS.Model.Result.ResultContactorGroupList _rcg = new SMS.Model.Result.ResultContactorGroupList();
            var _conactorBll = new SMS.BLL.Addr.ContactorGroupManager();

          var  _rcg = _conactorBll.GetGroups(this.LoginInfo.UserID, 0, pageIndex, pageSize, search);
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
            var _conactorBll = new SMS.BLL.Addr.ContactorGroupManager();
            var _rcg = _conactorBll.GetContactorsCount(this.LoginInfo.UserID, Convert.ToInt32(groupId), 0, search);
            if (_rcg.State)
            {
                return Content(_rcg.Value.ToString());
            }

            return   Content("0");
        }
    }
}
