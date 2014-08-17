using Public.Log;
using Public.Result;
using SMS.IDAL;
using SMS.Model.Addr;
using SMS.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SMS.BLL.Addr
{
    public class ContactorGroupManager
    {
        public IContactorGroupDAL ContactorGroupDal { get; set; }
        public IContactorDAL ContactorDal { get; set; }

        private readonly FunctionLogBuilder _log;

        public ContactorGroupManager()
        {
            ContactorGroupDal = DALFactory.DataAccess.CreateContactorGroupDAL();
            ContactorDal = DALFactory.DataAccess.CreateContactorDAL();
            _log = new FunctionLogBuilder();
        }

        /// <summary>
        /// 错误时，添加错误值到logbuilder中
        /// </summary>
        /// <param name="rs"></param>
        private void AppendResult(BaseResult rs)
        {
            _log.Append("BaseResult.Value", rs.Value);
            _log.Append("BaseResult.Desc", rs.Desc);
        }
        public ResultContactorGroupList GetGroups(int userId, int compId, int pageIndex, int pageSize, string search)
        {



            var rs = new ResultContactorGroupList();

            _log.Method = MethodBase.GetCurrentMethod().Name;
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                _log.Path = declaringType.FullName;
            }
            _log.Append("userId", userId);

            if (userId <= 0)
            {
                rs.Failed(-101, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }



            try
            {

                rs = ContactorGroupDal.GetGroups(userId, compId, pageIndex, pageSize, search);

                if (!rs.State)
                {
                    _log.Desc = "数据层操作返回错误";
                    _log.Append("Value", rs.Value);
                    _log.Error();
                    rs.Failed(-2, _log.Desc);
                    return rs;
                }

            }
            catch (Exception ex)
            {
                rs.Failed(-1, ex.ToString(), "todo！");

                //错误值
                _log.Exception = ex.ToString();
                AppendResult(rs);
                _log.Error();

                return rs;
            }

            rs.Success();
            _log.Debug();

            return rs;

        }
        public BaseResult AddGroup(int userId, string groupName, int compId)
        {
            var rs = new BaseResult();

            _log.Method = MethodBase.GetCurrentMethod().Name;
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                _log.Path = declaringType.FullName;
            }
            _log.Append("userId", userId);
            _log.Append("groupName", groupName);

            if (userId <= 0)
            {
                rs.Failed(-101, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }
            if (string.IsNullOrEmpty(groupName))
            {
                rs.Failed(-102, "参数【groupName】为空");
                return rs;
            }

            try
            {

                var returnObj = ContactorGroupDal.AddGroup(userId, groupName, compId);

                if (!returnObj.State)
                {
                    _log.Desc = "数据层操作返回错误";
                    _log.Append("Value", returnObj.Value);
                    _log.Error();
                    return returnObj;
                }
                rs = returnObj;

            }
            catch (Exception ex)
            {
                rs.Failed(-1, "todo.", "todo！");

                //错误值
                _log.Exception = ex.ToString();
                AppendResult(rs);
                _log.Error();

                return rs;
            }

            _log.Debug();

            return rs;
        }
        public BaseResult SetGroupName(int userId, int groupID, string groupName, int compId)
        {
            var rs = new BaseResult();

            _log.Method = MethodBase.GetCurrentMethod().Name;
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                _log.Path = declaringType.FullName;
            }
            _log.Append("userId", userId);
            _log.Append("groupID", groupID);
            _log.Append("groupName", groupName);

            if (userId <= 0)
            {
                rs.Failed(-101, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }
            if (groupID <= 0)
            {
                rs.Failed(-102, "参数【groupID】无效");
                return rs;
            }
            if (string.IsNullOrEmpty(groupName))
            {
                rs.Failed(-103, "参数【groupName】为null");
                return rs;
            }

            try
            {

                var returnObj = ContactorGroupDal.SetGroupName(userId, groupID, groupName, compId);

                if (!returnObj.State)
                {
                    _log.Desc = "数据层操作返回错误";
                    _log.Append("Value", returnObj.Value);
                    _log.Error();
                    return returnObj;
                }

            }
            catch (Exception ex)
            {
                rs.Failed(-1, "todo.", "todo！");

                //错误值
                _log.Exception = ex.ToString();
                AppendResult(rs);
                _log.Error();

                return rs;
            }

            rs.Success();
            _log.Debug();

            return rs;
        }
        public BaseResult DelGroups(int userId, List<ContactorGroup> groups, int compId)
        {
            var rs = new BaseResult();

            _log.Method = MethodBase.GetCurrentMethod().Name;
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                _log.Path = declaringType.FullName;
            }
            _log.Append("userId", userId);
            _log.Append("groups", groups);

            if (userId <= 0)
            {
                rs.Failed(-101, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }
            if (groups == null)
            {
                rs.Failed(-102, "参数【groups】无效");
                return rs;
            }

            try
            {

                var returnObj = ContactorGroupDal.DelGroups(userId, groups, compId);

                if (!returnObj.State)
                {
                    _log.Desc = "数据层操作返回错误";
                    _log.Append("Value", returnObj.Value);
                    _log.Error();
                    rs.Failed(-2, _log.Desc);
                    return rs;
                }
                //rs = ConfSubDal.DelGroups(userId, groups);
            }
            catch (Exception ex)
            {
                rs.Failed(-1, "todo.", "todo！");

                //错误值
                _log.Exception = ex.ToString();
                AppendResult(rs);
                _log.Error();

                return rs;
            }

            rs.Success();
            _log.Debug();

            return rs;
        }
        public BaseResult CopyContactorsToOtherGroups(int userId, List<ContactorGroup> groups, List<Contactor> contactors, int compId)
        {
            var rs = new BaseResult();

            _log.Method = MethodBase.GetCurrentMethod().Name;
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                _log.Path = declaringType.FullName;
            }
            _log.Append("userId", userId);
            _log.Append("groups", groups);
            _log.Append("contactors", contactors);

            if (userId <= 0)
            {
                rs.Failed(-101, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }
            if (groups == null)
            {
                rs.Failed(-102, "参数【groups】无效");
                return rs;
            }
            if (contactors == null)
            {
                rs.Failed(-103, "参数【contactors】无效");
                return rs;
            }

            try
            {

                var returnObj = ContactorGroupDal.CopyContactorsToOtherGroups(userId, groups, contactors, compId);

                if (!returnObj.State)
                {
                    _log.Desc = "数据层操作返回错误";
                    _log.Append("Value", returnObj.Value);
                    _log.Error();
                    rs.Failed(-2, _log.Desc);
                    return rs;
                }

            }
            catch (Exception ex)
            {
                rs.Failed(-1, "todo.", "todo！");

                //错误值
                _log.Exception = ex.ToString();
                AppendResult(rs);
                _log.Error();

                return rs;
            }

            rs.Success();
            _log.Debug();

            return rs;
        }
        public BaseResult RemoveContactors(int userId, List<ContactorGroup> groups, List<Contactor> contactors, int compId)
        {
            var rs = new BaseResult();

            _log.Method = MethodBase.GetCurrentMethod().Name;
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                _log.Path = declaringType.FullName;
            }
            _log.Append("userId", userId);
            _log.Append("groups", groups);
            _log.Append("contactors", contactors);

            if (userId <= 0)
            {
                rs.Failed(-101, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }
            if (groups == null)
            {
                rs.Failed(-102, "参数【groups】无效");
                return rs;
            }
            if (contactors == null)
            {
                rs.Failed(-103, "参数【contactors】无效");
                return rs;
            }

            try
            {

                var returnObj = ContactorGroupDal.RemoveContactors(userId, groups, contactors, compId);

                if (!returnObj.State)
                {
                    _log.Desc = "数据层操作返回错误";
                    _log.Append("Value", returnObj.Value);
                    _log.Error();
                    rs.Failed(-2, _log.Desc);
                    return rs;
                }
                // rs = ConfSubDal.RemoveContactors(userId, groups, contactors);
            }
            catch (Exception ex)
            {
                rs.Failed(-1, "todo.", "todo！");

                //错误值
                _log.Exception = ex.ToString();
                AppendResult(rs);
                _log.Error();

                return rs;
            }

            rs.Success();
            _log.Debug();

            return rs;
        }
        public ResultContactorList GetAllContactors(int userId, int compId, int pageIndex, int pageSize, string searchContent)
        {
            var rs = new ResultContactorList();

            _log.Method = MethodBase.GetCurrentMethod().Name;
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                _log.Path = declaringType.FullName;
            }
            _log.Append("userId", userId);

            if (userId <= 0)
            {
                rs.Failed(-101, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }

            try
            {
                //获取所有联系人基本信息
                rs = ContactorGroupDal.GetAllContactors(userId, compId, pageIndex, pageSize, searchContent);

                if (!rs.State)
                {
                    _log.Desc = "数据层操作返回错误";
                    _log.Append("Value", rs.Value);
                    _log.Error();
                    rs.Failed(-2, _log.Desc);
                    return rs;
                }

                //获取联系人联系方式、分组
                var contactorList = rs.Contactors.Select(contactor => (ContactorDal.GetDetail(userId, contactor.ContactorID, compId).ContactorInfo)).ToList();
                rs.Contactors = contactorList;
            }
            catch (Exception ex)
            {
                rs.Failed(-1, ex.ToString(), "todo！");

                //错误值
                _log.Exception = ex.ToString();
                AppendResult(rs);
                _log.Error();

                return rs;
            }

            rs.Success();
            _log.Debug();

            return rs;
        }
        public ResultContactorList GetUnGroupedContactors(int userId, int compId, int pageIndex, int pageSize, string searchContent)
        {
            var rs = new ResultContactorList();

            _log.Method = MethodBase.GetCurrentMethod().Name;
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                _log.Path = declaringType.FullName;
            }
            _log.Append("userId", userId);

            if (userId <= 0)
            {
                rs.Failed(-101, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }

            try
            {

                rs = ContactorGroupDal.GetUnGroupedContactors(userId, compId, pageIndex, pageSize, searchContent);

                if (!rs.State)
                {
                    _log.Desc = "数据层操作返回错误";
                    _log.Append("Value", rs.Value);
                    _log.Error();
                    rs.Failed(-2, _log.Desc);
                    return rs;
                }
                //获取联系人联系方式、分组
                var contactorList = rs.Contactors.Select(contactor => (ContactorDal.GetDetail(userId, contactor.ContactorID, compId).ContactorInfo)).ToList();
                rs.Contactors = contactorList;

            }
            catch (Exception ex)
            {
                rs.Failed(-1, "todo.", "todo！");

                //错误值
                _log.Exception = ex.ToString();
                AppendResult(rs);
                _log.Error();

                return rs;
            }

            rs.Success();
            _log.Debug();

            return rs;
        }
        public ResultContactorList GetUserGroupContactors(int userId, int groupID, int compId, int pageIndex, int pageSize, string searchContent)
        {
            var rs = new ResultContactorList();

            _log.Method = MethodBase.GetCurrentMethod().Name;
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                _log.Path = declaringType.FullName;
            }
            _log.Append("userId", userId);

            if (userId <= 0)
            {
                rs.Failed(-101, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }
            if (groupID < 0)
            {
                rs.Failed(-102, "参数【groupID】无效");
                return rs;
            }

            try
            {

                rs = ContactorGroupDal.GetUserGroupContactors(userId, groupID, compId, pageIndex, pageSize, searchContent);

                if (!rs.State)
                {
                    _log.Desc = "数据层操作返回错误";
                    _log.Append("Value", rs.Value);
                    _log.Error();
                    rs.Failed(-2, _log.Desc);
                    return rs;
                }
                //获取联系人联系方式、分组
                var contactorList = rs.Contactors.Select(contactor => (ContactorDal.GetDetail(userId, contactor.ContactorID, compId).ContactorInfo)).ToList();
                rs.Contactors = contactorList;

            }
            catch (Exception ex)
            {
                rs.Failed(-1, "todo.", ex.ToString());

                //错误值
                _log.Exception = ex.ToString();
                AppendResult(rs);
                _log.Error();

                return rs;
            }

            rs.Success();
            _log.Debug();

            return rs;
        }
        public BaseResult GetContactorsCount(int userId, int groupID, int compId, string searchContent)
        {
            var rs = new BaseResult();

            _log.Method = MethodBase.GetCurrentMethod().Name;
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                _log.Path = declaringType.FullName;
            }
            _log.Append("userId", userId);
            _log.Append("groupID", groupID);
            _log.Append("compId", compId);
            _log.Append("searchContent", searchContent);

            if (userId <= 0)
            {
                rs.Failed(-101, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }

            try
            {

                rs = ContactorGroupDal.GetContactorsCount(userId, groupID, compId, searchContent);

                if (!rs.State)
                {
                    _log.Desc = "数据层操作返回错误";
                    _log.Append("Value", rs.Value);
                    _log.Error();
                    return rs;
                }

            }
            catch (Exception ex)
            {
                rs.Failed(-1, "todo.", ex.ToString());

                //错误值
                _log.Exception = ex.ToString();
                AppendResult(rs);
                _log.Error();

                return rs;
            }

            _log.Debug();

            return rs;
        }
    }
}
