using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Public.DB;
using Public.Log;
using Public.Result;
using Public.Xml;
using SMS.Model.Addr;
using SMS.Model.Result;
using SMS.IDAL;

namespace SMS.SQLServerDAL.Addr
{
    public class ContactorDAL : IContactorDAL
    {

        #region 字段

        private string _procName;
        private LogBuilder _log;
        private const string ClassName = "ContactorDAL";
        private readonly string _databaseName = "SMS";
        private string _methodName;
        private readonly MssqlDatabase _addrDatabase;

        // 执行过程中用到的
        private string _desc;
        private SqlDataReader _dr;
        private DataSet _ds;
        private int _result;

        public ContactorDAL()
        {
            _procName = "";
            _databaseName = "SMS";

            try
            {
                _addrDatabase = new MssqlDatabase();
            }
            catch (Exception ex)
            {
                _methodName = MethodBase.GetCurrentMethod().Name;
                _log = new LogBuilder
                {
                    Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                    Desc = "MssqlDatabase创建出现异常",
                    Exception = ex.Message
                };

                _log.Error();
            }
        }

        #endregion


        public BaseResult AddContactor(int userId, Contactor contactor, int compId)
        {
            var rs = new BaseResult { State = false, Value = -1, Desc = "数据操作层初始化" };

            if (userId <= 0)
            {
                rs.Failed(-101, "userId无效");
                return rs;
            }

            if (contactor.Equals(null))
            {
                rs.Failed(-101, "contactor无效");
                return rs;
            }

            _desc = "某个终端客户添加一个联系人，含分组，联系方式";
            _procName = "UP_Addr_Contactor_AddContactor";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("userId", userId);

            try
            {
                //联系方式xml
                var wayClass = new XMLContactWayClass
                    {
                        XmlContactWay =
                            contactor.CWays.Select(
                                way => new XmlContactWay { ContactWayType = way.ContactWayType, Way = way.Way }).ToArray()
                    };
                var wayData = XmlHelper.XmlSerializer<XMLContactWayClass>(wayClass);
                wayData = wayData.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");

                //分组xml
                var groupClass = new XMLContactGroupClass
                    {
                        XmlContactGroup =
                            contactor.CGroups.Select(
                                @group => new XmlContactGroup { ContactorGroupID = @group.ContactorGroupID }).ToArray()
                    };
                var groupData = XmlHelper.XmlSerializer<XMLContactGroupClass>(groupClass);
                groupData = groupData.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");

                var parameters = new[]
                    {
                        _addrDatabase.MakeInParam("@userId", SqlDbType.Int, 4, userId),
                        _addrDatabase.MakeInParam("@CompID", SqlDbType.Int, 4, compId),
                        _addrDatabase.MakeInParam("@Name", SqlDbType.VarChar, 20, contactor.ContactorName),
                        _addrDatabase.MakeInParam("@ContactWay", SqlDbType.Xml, int.MaxValue, wayData),
                        _addrDatabase.MakeInParam("@ContactGroup", SqlDbType.Xml, int.MaxValue, groupData),
                        _addrDatabase.MakeInParam("@ConfParticipatePhoneNo",SqlDbType.VarChar,50,contactor.ConfParticipatePhoneNo)
                    };
                _addrDatabase.ExecuteProc(_procName, parameters, out _result);
                if (_result != 0)
                {
                    rs.Failed(-2, "todo");
                    return rs;
                }
            }
            catch (Exception ex)
            {
                rs.Failed(-1, ex.ToString());

                _log.Exception = string.Format("{0},发生异常：{1}", _desc, ex.Message);
                _log.Error();

                return rs;
            }
            finally
            {
                _addrDatabase.Close();//仅显式关闭链接，不做其它操作
            }
            rs.Success();
            return rs;
        }

        public BaseResult DelContactors(int userId, List<Contactor> contactors, int compId)
        {
            var rs = new BaseResult { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (userId <= 0)
            {
                rs.Failed(-101, "userId无效");
                return rs;
            }

            if (contactors == null)
            {
                rs.Failed(-102, "contactors无效");
                return rs;
            }

            _desc = "某个终端客户删除某些联系人，从所有联系人、联系人分组中一并删除，批量操作";
            _procName = "UP_Addr_Contactor_DelFromAllContactors";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("userId", userId);

            try
            {
                var contactorIDList = contactors.Aggregate("", (current, contactorsId) => current + (contactorsId.ContactorID + ","));
                contactorIDList = contactorIDList.Substring(0, contactorIDList.Length - 1);

                var parameters = new[]
                    {
                        _addrDatabase.MakeInParam("@userId", SqlDbType.Int, 4, userId),
                        _addrDatabase.MakeInParam("@ContactorIDList", SqlDbType.VarChar, 256, contactorIDList),
                        _addrDatabase.MakeOutParam("@Result", SqlDbType.Int)
                    };
                _addrDatabase.ExecuteProc(_procName, parameters, out _result);
                if (_result != 1)
                {
                    rs.Failed(-2, "todo");
                    return rs;
                }
            }
            catch (Exception ex)
            {
                rs.Failed(-1, "todo");

                _log.Exception = string.Format("{0},发生异常：{1}", _desc, ex.Message);
                _log.Error();

                return rs;
            }
            finally
            {
                _addrDatabase.Close();//仅显式关闭链接，不做其它操作
            }
            rs.Success();
            return rs;
        }

        public BaseResult DelContactorsByGroup(int userId, List<Contactor> contactors, int compId, int groupId)
        {
            var rs = new BaseResult { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (userId <= 0)
            {
                rs.Failed(-101, "userId无效");
                return rs;
            }

            if (contactors == null)
            {
                rs.Failed(-102, "contactors无效");
                return rs;
            }

            if (groupId <= 0)
            {
                rs.Failed(-103, "groupId无效");
                return rs;
            }
            _desc = "某个终端客户删除某些联系人，从联系人分组中删除，批量操作";
            _procName = "UP_Addr_Contactor_DelFromSingleCGroup";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("userId", userId);

            try
            {
                var contactorIDList = contactors.Aggregate("", (current, contactorsId) => current + (contactorsId.ContactorID + ","));
                contactorIDList = contactorIDList.Substring(0, contactorIDList.Length - 1);

                var parameters = new[]
                    {
                        _addrDatabase.MakeInParam("@userId", SqlDbType.Int, 4, userId),
                        _addrDatabase.MakeInParam("@ContactorIDList", SqlDbType.VarChar, 256, contactorIDList),
                        _addrDatabase.MakeInParam("@ContactGroupID", SqlDbType.Int,4,groupId)
                    };
                _addrDatabase.ExecuteProc(_procName, parameters, out _result);
                if (_result != 1)
                {
                    rs.Failed(-2, "todo");
                    return rs;
                }
            }
            catch (Exception ex)
            {
                rs.Failed(-1, ex.ToString());

                _log.Exception = string.Format("{0},发生异常：{1}", _desc, ex.Message);
                _log.Error();

                return rs;
            }
            finally
            {
                _addrDatabase.Close();//仅显式关闭链接，不做其它操作
            }
            rs.Success();
            return rs;
        }

        public ResultContactorDetail GetDetail(int userId, int contactorID, int compId)
        {
            var rs = new ResultContactorDetail { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (userId <= 0)
            {
                rs.Failed(-101, "userId无效");
                return rs;
            }

            if (contactorID <= 0)
            {
                rs.Failed(-102, "compId无效");
                return rs;
            }

            _desc = "获取某个终端客户的某个联系人详细信息，含姓名、联系方式、所在分组。";
            _procName = "UP_Addr_Contactor_GetSingleFullInfo";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("userId", userId);
            _log.Append("contactorID", contactorID);

            try
            {
                var parameters = new[]
                    {
                        _addrDatabase.MakeInParam("@ContactorID", SqlDbType.Int, 4, contactorID)
                    };
                _addrDatabase.ExecuteProc(_procName, parameters, out _ds);

                if (_ds != null)
                {
                    if (rs.ContactorInfo == null)
                    {
                        rs.ContactorInfo = new Contactor();
                    }

                    var obj = new Contactor();
                    obj.ContactorID = Convert.ToInt32(SqlComponents.ReaderGetString(_ds.Tables[0].Rows[0]["ContactorID"]));
                    obj.ContactorName = SqlComponents.ReaderGetString(_ds.Tables[0].Rows[0]["Name"]);
                    obj.ConfParticipatePhoneNo = SqlComponents.ReaderGetString(_ds.Tables[0].Rows[0]["Field"]);

                    var dtWay = _ds.Tables[1]; //联系方式
                    var listWay = new List<ContactWay>();
                    //新版本读取联系方式
                    if (dtWay != null && dtWay.Rows.Count > 0)
                    {
                        for (var i = 0; i < dtWay.Rows.Count; i++)
                        {
                            var way = new ContactWay
                                {
                                    ContactWayID = Convert.ToInt32(dtWay.Rows[i]["SysID"]),
                                    ContactWayType = Convert.ToInt32(dtWay.Rows[i]["FieldType"]),
                                    Way = dtWay.Rows[i]["Field"].ToString()
                                };
                            listWay.Add(way);
                        }
                    }

                    obj.CWays = listWay;
                    obj.WayCount = listWay.Count > 0 ? listWay.Count : 0;

                    var dtGroup = _ds.Tables[2]; //所在分组
                    if (dtGroup != null)
                    {
                        var listGroup = new List<ContactorGroup>();
                        for (var i = 0; i < dtGroup.Rows.Count; i++)
                        {
                            var group = new ContactorGroup
                            {
                                ContactorCount = Convert.ToInt32(dtGroup.Rows[i]["MemberCount"]),
                                ContactorGroupID = Convert.ToInt32(dtGroup.Rows[i]["ContactGroupID"]),
                                ContactorGroupName = dtGroup.Rows[i]["GroupName"].ToString()
                            };
                            listGroup.Add(group);
                        }
                        obj.CGroups = listGroup;
                    }

                    rs.ContactorInfo = obj;
                }
                else
                {
                    rs.Failed(-2, "todo");
                    return rs;
                }

            }
            catch (Exception ex)
            {
                rs.Failed(-1, ex.ToString());

                _log.Exception = string.Format("{0},发生异常：{1}", _desc, ex.Message);
                _log.Error();

                return rs;
            }
            finally
            {
                _addrDatabase.Close();//仅显式关闭链接，不做其它操作
            }
            rs.Success();
            return rs;
        }

        public BaseResult SetContactorGroups(int userId, List<ContactorGroup> groups, int contactorID, int compId)
        {
            var rs = new BaseResult { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (userId <= 0)
            {
                rs.Failed(-101, "userId无效");
                return rs;
            }

            if (groups.Equals(null))
            {
                rs.Failed(-102, "groups无效");
                return rs;

            }
            if (contactorID <= 0)
            {
                rs.Failed(-102, "contactorID无效");
                return rs;
            }


            _desc = "更新单个联系人与多个联系组之间的所属关系(加入到组或从组中退出)";
            _procName = "UP_Addr_Contactor_AddSingleToCGroups";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("userId", userId);
            _log.Append(" List<MODEL.Addr.ContactorGroup>", groups);
            _log.Append("contactorID", contactorID);

            try
            {
                //分组xml
                var groupClass = new XMLContactGroupClass
                {
                    XmlContactGroup =
                        groups.Select(
                            @group => new XmlContactGroup { ContactorGroupID = @group.ContactorGroupID }).ToArray()
                };

                var groupData = XmlHelper.XmlSerializer<XMLContactGroupClass>(groupClass);
                groupData = groupData.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");


                var parameters = new[]
                    {
                        _addrDatabase.MakeInParam("@userId", SqlDbType.Int, 4, userId),
                        _addrDatabase.MakeInParam("@CompID", SqlDbType.Int, 4, compId),
                        _addrDatabase.MakeInParam("@ContactorID", SqlDbType.Int, 4, contactorID),
                        _addrDatabase.MakeInParam("@ContactorGroupIDList", SqlDbType.Xml, int.MaxValue, groupData)
                    };
                _addrDatabase.ExecuteProc(_procName, parameters, out _result);
                if (_result != 0)
                {
                    rs.Failed(-2, "todo");
                    return rs;
                }
            }
            catch (Exception ex)
            {
                rs.Failed(-1, ex.ToString());

                _log.Exception = string.Format("{0},发生异常：{1}", _desc, ex.Message);
                _log.Error();

                return rs;
            }
            finally
            {
                _addrDatabase.Close();//仅显式关闭链接，不做其它操作
            }
            rs.Success();
            return rs;
        }

        public BaseResult SetName(int userId, int contactorID, string name, int compId)
        {
            var rs = new BaseResult { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (userId <= 0)
            {
                rs.Failed(-101, "userId无效");
                return rs;
            }
            if (contactorID <= 0)
            {
                rs.Failed(-102, "contactorID无效");
                return rs;
            }
            if (string.IsNullOrEmpty(name))
            {
                rs.Failed(-103, "name无效");
                return rs;

            }

            _desc = "某个终端客户修改某个联系人的姓名";
            _procName = "UP_Addr_Contactor_SetName";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("userId", userId);
            _log.Append("contactorID", contactorID);
            _log.Append("name", name);


            try
            {
                SqlParameter[] parameters =
                    {
                        _addrDatabase.MakeInParam("@ContactorID", SqlDbType.BigInt, 4, contactorID),
                        _addrDatabase.MakeInParam("@ContactorName", SqlDbType.NVarChar, 20, name)
                    };

                _addrDatabase.ExecuteProc(_procName, parameters, out _result);

                if (_result != 0)
                {
                    rs.Failed(-2, "todo");
                    return rs;
                }
            }
            catch (Exception ex)
            {
                rs.Failed(-1, "todo");

                _log.Exception = string.Format("{0},发生异常：{1}", _desc, ex.Message);
                _log.Error();

                return rs;
            }
            finally
            {
                _addrDatabase.Close();//仅显式关闭链接，不做其它操作
            }
            rs.Success();
            return rs;
        }

        public BaseResult SetContactWay(int userId, int contactorID, List<ContactWay> cWay, int compId, string confParticipatePhoneNo)
        {
            var rs = new BaseResult { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (userId <= 0)
            {
                rs.Failed(-101, "userId无效");
                return rs;
            }
            if (contactorID <= 0)
            {
                rs.Failed(-102, "contactorID无效");
                return rs;
            }
            if (cWay.Equals(null))
            {
                rs.Failed(-103, "cWay无效");
                return rs;

            }

            _desc = "某个终端客户设置（修改）某个联系人的某个联系方式";
            _procName = "UP_Addr_Contactor_AddMutilField";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("userId", userId);
            _log.Append("contactorID", contactorID);
            _log.Append("ContactWay", cWay);

            try
            {
                XMLContactWayClass wayClass = new XMLContactWayClass();
                XmlContactWay xmlWay = null;
                List<XmlContactWay> list = new List<XmlContactWay>();
                foreach (ContactWay way in cWay)
                {
                    xmlWay = new XmlContactWay();
                    xmlWay.ContactWayType = way.ContactWayType;
                    xmlWay.Way = way.Way;
                    list.Add(xmlWay);
                }

                wayClass.XmlContactWay = list.ToArray();
                string wayData = XmlHelper.XmlSerializer<XMLContactWayClass>(wayClass);
                wayData = wayData.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");


                var parameters = new[]
                    {
                        _addrDatabase.MakeInParam("@userId", SqlDbType.Int, 4, userId),
                        _addrDatabase.MakeInParam("@CompID", SqlDbType.Int, 4, compId),
                        _addrDatabase.MakeInParam("@ContactorID", SqlDbType.BigInt, 4, contactorID),
                        _addrDatabase.MakeInParam("@ContactWay", SqlDbType.Xml, int.MaxValue, wayData),
                        _addrDatabase.MakeInParam("@ConfParticipatePhoneNo",SqlDbType.VarChar,50,confParticipatePhoneNo )
                    };
                _addrDatabase.ExecuteProc(_procName, parameters, out _result);
                if (_result != 0)
                {
                    rs.Failed(-2, "todo");
                    return rs;
                }
            }
            catch (Exception ex)
            {
                rs.Failed(-1, ex.ToString());

                _log.Exception = string.Format("{0},发生异常：{1}", _desc, ex.Message);
                _log.Error();

                return rs;
            }
            finally
            {
                _addrDatabase.Close();//仅显式关闭链接，不做其它操作
            }
            rs.Success();
            return rs;
        }

   
        
    }
}
