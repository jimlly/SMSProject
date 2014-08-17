using Public.Helper;
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
using System.Text.RegularExpressions;

namespace SMS.BLL.Addr
{
    public class ContactorManager
    {
        public IContactorDAL ContactorDal { get; set; }

        private readonly FunctionLogBuilder _log;

        public ContactorManager()
        {
            ContactorDal =SMS.DALFactory.DataAccess.CreateContactorDAL();
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

        public BaseResult AddContactor(int userId, Contactor contactor, int compId)
        {
            var rs = new BaseResult();

            _log.Method = MethodBase.GetCurrentMethod().Name;
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                _log.Path = declaringType.FullName;
            }
            _log.Append("userId", userId);
            _log.Append("contactor", contactor);

            if (userId <= 0)
            {
                rs.Failed(-101, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }
            if (contactor == null)
            {
                rs.Failed(-102, "参数【contactor】为null");
                return rs;
            }
            if (string.IsNullOrEmpty(contactor.ContactorName))
            {
                rs.Failed(-103, "参数contactor.ContactorName为null");
                return rs;
            }
            if (contactor.CWays != null)
            {
                foreach (var contactWay in contactor.CWays)
                {
                    switch (contactWay.ContactWayType)
                    {
                        case 1:
                            var mobileExpression = ConfigHelper.GetConfigString("MobilezhRegex");
                            if (!Regex.IsMatch(contactWay.Way, mobileExpression))
                            {
                                rs.Failed(-104, "参数contactor的手机格式不正确");
                                return rs;
                            }
                            break;
                        case 2:
                            var teleExpression = ConfigHelper.GetConfigString("TelePhoneRegex"); 
                            if (!Regex.IsMatch(contactWay.Way, teleExpression))
                            {
                                rs.Failed(-104, "参数contactor的固话格式不正确");
                                return rs;
                            }
                            break;
                        case 3:
                            var emailExpression = ConfigHelper.GetConfigString("EmailRegex");
                            if (!Regex.IsMatch(contactWay.Way, emailExpression))
                            {
                                rs.Failed(-104, "参数contactor的邮箱格式不正确");
                                return rs;
                            }
                            break;
                        default:
                            rs.Failed(-104, "参数contactWay.ContactWayType的格式不正确");
                            return rs;
                    }
                }
            }

            try
            {
                var returnObj = ContactorDal.AddContactor(userId, contactor, compId);

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

        public BaseResult DelContactors(int userId, List<Contactor> contactors, int compId)
        {
            var rs = new BaseResult();

            _log.Method = MethodBase.GetCurrentMethod().Name;
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                _log.Path = declaringType.FullName;
            }
            _log.Append("userId", userId);
            _log.Append("List<Contactor>", contactors);

            if (userId <= 0)
            {
                rs.Failed(-101, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }
            if (contactors == null)
            {
                rs.Failed(-102, "参数【contactorID】无效");
                return rs;
            }

            try
            {
                var returnObj = ContactorDal.DelContactors(userId, contactors, compId);

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

        public BaseResult DelContactorsByGroup(int userId, List<Contactor> contactors, int compId, int groupId)
        {
            var rs = new BaseResult();

            _log.Method = MethodBase.GetCurrentMethod().Name;
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                _log.Path = declaringType.FullName;
            }
            _log.Append("userId", userId);
            _log.Append("List<Contactor>", contactors);
            _log.Append("groupId", groupId);

            if (userId <= 0)
            {
                rs.Failed(-101, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }
            if (contactors == null)
            {
                rs.Failed(-102, "参数【contactorID】无效");
                return rs;
            }
            if (groupId <= 0)
            {
                rs.Failed(-103, "参数【groupId】无效");
                return rs;
            }

            try
            {
                var returnObj = ContactorDal.DelContactorsByGroup(userId, contactors, compId, groupId);

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

        public ResultContactorDetail GetDetail(int userId, int contactorID, int compId)
        {
            var rs = new ResultContactorDetail();

            _log.Method = MethodBase.GetCurrentMethod().Name;
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                _log.Path = declaringType.FullName;
            }
            _log.Append("userId", userId);
            _log.Append("contactorID", contactorID);

            if (userId <= 0)
            {
                rs.Failed(-101, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }
            if (contactorID <= 0)
            {
                rs.Failed(-102, "参数【contactorID】无效");
                return rs;
            }

            try
            {
                rs = ContactorDal.GetDetail(userId, contactorID, compId);

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

        public BaseResult SetContactorGroups(int userId, List<ContactorGroup> groups, int contactorID, int compId)
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
            _log.Append("contactorID", contactorID);

            if (userId <= 0)
            {
                rs.Failed(-101, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }
            if (contactorID <= 0)
            {
                rs.Failed(-102, "参数【contactorID】无效");
                return rs;
            }

            if (groups == null)
            {
                rs.Failed(-103, "参数【groups】无效");
                return rs;

            }

            try
            {

                var returnObj = ContactorDal.SetContactorGroups(userId, groups, contactorID, compId);

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

        public BaseResult SetName(int userId, int contactorID, string name, int compId)
        {
            var rs = new BaseResult();

            _log.Method = MethodBase.GetCurrentMethod().Name;
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                _log.Path = declaringType.FullName;
            }
            _log.Append("userId", userId);
            _log.Append("contactorID", contactorID);
            _log.Append("contactWay", name);

            if (userId <= 0)
            {
                rs.Failed(-101, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }
            if (contactorID <= 0)
            {
                rs.Failed(-102, "参数【contactorID】无效");
                return rs;
            }

            if (string.IsNullOrEmpty(name))
            {
                rs.Failed(-103, "参数【name】无效");
                return rs;
            }



            try
            {

                var returnObj = ContactorDal.SetName(userId, contactorID, name, compId);

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

        public BaseResult SetContactWay(int userId, int contactorID, List<ContactWay> cWay, int compId, string confParticipatePhoneNo)
        {
            var rs = new BaseResult();

            _log.Method = MethodBase.GetCurrentMethod().Name;
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                _log.Path = declaringType.FullName;
            }
            _log.Append("userId", userId);
            _log.Append("contactor", contactorID);
            _log.Append("contactWay", cWay);

            if (userId <= 0)
            {
                rs.Failed(-101, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }
            if (contactorID <= 0)
            {
                rs.Failed(-102, "参数【contactorID】无效");
                return rs;
            }

            if (cWay == null)
            {
                rs.Failed(-103, "参数【cWays】为null");
                return rs;
            }
            foreach (var contactWay in cWay)
            {
                switch (contactWay.ContactWayType)
                {
                    case 1:
                        var mobileExpression = ConfigHelper.GetConfigString("MobilezhRegex");
                        if (!Regex.IsMatch(contactWay.Way, mobileExpression))
                        {
                            rs.Failed(-104, "参数contactor的手机格式不正确");
                            return rs;
                        }
                        break;
                    case 2:
                        var teleExpression = ConfigHelper.GetConfigString("TelePhoneRegex");
                        if (!Regex.IsMatch(contactWay.Way, teleExpression))
                        {
                            rs.Failed(-104, "参数contactor的固话格式不正确");
                            return rs;
                        }
                        break;
                    case 3:
                        var emailExpression = ConfigHelper.GetConfigString("EmailRegex");
                        if (!Regex.IsMatch(contactWay.Way, emailExpression))
                        {
                            rs.Failed(-104, "参数contactor的邮箱格式不正确");
                            return rs;
                        }
                        break;
                    default:
                        rs.Failed(-104, "参数contactWay.ContactWayType的格式不正确");
                        return rs;
                }
            }

            try
            {
                var returnObj = ContactorDal.SetContactWay(userId, contactorID, cWay, compId, confParticipatePhoneNo);

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


    }
}

