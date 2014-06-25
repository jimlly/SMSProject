using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Public.Xml;
using SMS.Model.Addr;
using SMS.Model.Result;
using Public.DB;
using Public.Log;
using Public.Result;

namespace SMS.SQLServerDAL.Addr
{
    public class ContactorGroupDAL //: IContactorGroupDAL
    {


        #region 字段

        private string _procName;
        private LogBuilder _log;
        private const string ClassName = "ContactorGroupDAL";
        private readonly string _databaseName = "AddressBook";
        private string _methodName;
        private readonly MssqlDatabase _addrDatabase;
        const int SharedFlag = 0; //共享标识 0 – 所有的（默认）


        // 执行过程中用到的
        private string _desc;
        private SqlDataReader _dr;
        private DataSet _ds;
        private int _result;

        public ContactorGroupDAL()
        {
            _procName = "";
            _databaseName = "AddressBook";

            try
            {
                _addrDatabase = new MssqlDatabase(DBSource.DBYtAddressBook);
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

        public ResultContactorGroupList GetGroups(int seqNo, int compId, int pageIndex, int pageSize,string search)
        {
            var rs = new ResultContactorGroupList { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (seqNo <= 0)
            {
                rs.Failed(-101, "seqNo无效");
                return rs;
            }

            _desc = "获取某个终端客户的所有联系人分组(不包含所有联系人、未分组联系人）";
            _procName = "UP_Addr_ContactorGroupManager_GetCGroupsListPage";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("SeqNo", seqNo);

            try
            {
                var parameters = new[]
                    {
                        _addrDatabase.MakeInParam("@SeqNo", SqlDbType.Int, 4, seqNo),
                        _addrDatabase.MakeInParam("@CompID", SqlDbType.Int, 4, compId),
                        _addrDatabase.MakeInParam("@SharedFlag", SqlDbType.Int, 4, SharedFlag),
                        _addrDatabase.MakeInParam("@PageIndex", SqlDbType.Int, 4, pageIndex),
                        _addrDatabase.MakeInParam("@PageSize", SqlDbType.Int, 4, pageSize),
                        _addrDatabase.MakeInParam("@SearchGroup", SqlDbType.VarChar, 200, search)
                    };
                _addrDatabase.ExecuteProc(_procName, parameters, out _dr);
                if (_dr == null)
                {
                    rs.Failed(-2, "没有查询记录");
                    return rs;
                }
                while (_dr.Read())
                {
                    if (rs.CGroups == null)
                    {
                        rs.CGroups = new List<ContactorGroup>();
                    }

                    var dataConfObj = new ContactorGroup();
                    dataConfObj.ContactorCount = Convert.ToInt32(SqlComponents.ReaderGetString(_dr["MemberCount"]));
                    dataConfObj.ContactorGroupID = Convert.ToInt32(SqlComponents.ReaderGetString(_dr["ContactGroupID"]));
                    dataConfObj.ContactorGroupName = SqlComponents.ReaderGetString(_dr["GroupName"]);
                    rs.CGroups.Add(dataConfObj);
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

        public BaseResult AddGroup(int seqNo, string groupName, int compId)
        {
            var rs = new BaseResult { State = false, Value = -1, Desc = "数据操作层初始化" };
            var groupId = 0;
            if (seqNo <= 0)
            {
                rs.Failed(-101, "seqNo无效");
                return rs;
            }
            if (string.IsNullOrEmpty(groupName))
            {
                rs.Failed(-102, "groupName无效");
                return rs;
            }


            _desc = "某个终端客户新建联系人分组";
            _procName = "Addr_SP_ContactGroup_CreateSingleCGroup";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("SeqNo", seqNo);
            _log.Append("groupName", groupName);

            try
            {
                const int shareFlag = 0; //0 不共享 1 共享
                const string remark = "";

                var parameters = new[]
                    {
                        _addrDatabase.MakeInParam("@SeqNo", SqlDbType.Int, 4, seqNo),
                        _addrDatabase.MakeInParam("@CompID", SqlDbType.Int, 4, compId),
                        _addrDatabase.MakeInParam("@SharedFlag", SqlDbType.Int, 4, shareFlag),
                        _addrDatabase.MakeInParam("@GroupName", SqlDbType.VarChar, 50, groupName),
                        _addrDatabase.MakeInParam("@Remark", SqlDbType.VarChar, 1024, remark),
                        _addrDatabase.MakeOutParam("@ContactorGroupID", SqlDbType.Int)
                    };
                _addrDatabase.ExecuteProc(_procName, parameters, out _result);
                groupId = Convert.ToInt32(SqlComponents.ReaderGetString(parameters[5].Value));
                if (_result == -1)
                {
                    rs.Failed(-3, "存在同名的未删除的组");
                    return rs;
                }
                if (_result != 1)
                {
                    rs.Failed(-2, "添加组失败");
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
            rs.Value = groupId;
            return rs;
        }

        public BaseResult SetGroupName(int seqNo, int groupID, string groupName, int compId)
        {
            var rs = new BaseResult { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (seqNo <= 0)
            {
                rs.Failed(-101, "seqNo无效");
                return rs;
            }
            if (groupID <= 0)
            {
                rs.Failed(-102, "groupID无效");
                return rs;
            }
            if (string.IsNullOrEmpty(groupName))
            {
                rs.Failed(-103, "groupName无效");
                return rs;
            }


            _desc = "某个终端客户设置（修改）某个联系人分组名称";
            _procName = "Addr_SP_ContactGroup_UpdateCGroupInfo";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("SeqNo", seqNo);
            _log.Append("groupID", groupID);
            _log.Append("groupName", groupName);

            try
            {
                const int shareFlag = 0; //0 不共享 1 共享
                const string remark = "";

                var parameters = new[]
                    {
                        _addrDatabase.MakeInParam("@SeqNo", SqlDbType.Int, 4, seqNo),
                        _addrDatabase.MakeInParam("@CompID", SqlDbType.Int, 4, compId),
                        _addrDatabase.MakeInParam("@Shared", SqlDbType.Int, 4, shareFlag),
                        _addrDatabase.MakeInParam("@GroupName", SqlDbType.VarChar, 50, groupName),
                        _addrDatabase.MakeInParam("@Remark", SqlDbType.VarChar, 1024, remark),
                        _addrDatabase.MakeInParam("@ContactGroupID", SqlDbType.Int,4,groupID)
                    };
                _addrDatabase.ExecuteProc(_procName, parameters, out _result);
                if (_result == -1)
                {
                    rs.Failed(-3, "存在同名的未删除的组");
                    return rs;
                }
                if (_result != 1)
                {
                    rs.Failed(-2, "修改组名失败");
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

        public BaseResult DelGroups(int seqNo, List<ContactorGroup> groups, int compId)
        {
            var rs = new BaseResult { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (seqNo <= 0)
            {
                rs.Failed(-101, "seqNo无效");
                return rs;
            }

            if (groups.Equals(null))
            {
                rs.Failed(-102, "groups无效");
                return rs;

            }

            _desc = "某个终端客户删除联系人分组，支持批量操作。";
            _procName = "UP_ContactGroup_DeleteCGroups";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("SeqNo", seqNo);
            _log.Append("List<ContactorGroup>", groups);

            try
            {
                string groupIdList = groups.Aggregate("", (current, contactorGroup) => current + (contactorGroup.ContactorGroupID + ","));
                groupIdList = groupIdList.Substring(0, groupIdList.Length - 1);

                var parameters = new[]
                    {
                        _addrDatabase.MakeInParam("@SeqNo", SqlDbType.Int, 4, seqNo),
                        _addrDatabase.MakeInParam("@CompID", SqlDbType.Int, 4, compId),
                        _addrDatabase.MakeInParam("@ContactGroupIDsList", SqlDbType.VarChar, 256, groupIdList),
                        _addrDatabase.MakeOutParam("@Result", SqlDbType.Int)
                    };
                _addrDatabase.ExecuteProc(_procName, parameters, out _result);
                if (_result != 1)
                {
                    rs.Failed(-2, "删除失败");
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

        public BaseResult CopyContactorsToOtherGroups(int seqNo, List<ContactorGroup> groups, List<Contactor> contactors, int compId)
        {
            var rs = new BaseResult { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (seqNo <= 0)
            {
                rs.Failed(-101, "seqNo无效");
                return rs;
            }

            if (groups.Equals(null))
            {
                rs.Failed(-102, "groups无效");
                return rs;

            }

            if (contactors.Equals(null))
            {
                rs.Failed(-103, "contactors无效");
                return rs;

            }

            _desc = "某个终端客户从某个分组中选择几个联系人并修改这些联系人所在的分组（仅拷贝到其它组，不涉及移除出本组/*如果所选分组不包含当前组，那么将从当前组中移除*/）。";
            _procName = "Addr_SP_Contactor_AddMultiContactorToMultiGroup";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("SeqNo", seqNo);
            _log.Append("List<ContactorGroup>", groups);
            _log.Append(" List<Contactor>", contactors);

            try
            {
                //联系人xml
                var contactorClass = new XMLContactorClass
                    {
                        XmlContactor =
                            contactors.Select(contactor => new XmlContactor { ContactorID = contactor.ContactorID }).ToArray()
                    };
                string contactorData = XmlHelper.XmlSerializer<XMLContactorClass>(contactorClass);
                contactorData = contactorData.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");

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
                        _addrDatabase.MakeInParam("@CompID", SqlDbType.Int, 4, compId),
                        _addrDatabase.MakeInParam("@SeqNo", SqlDbType.Int, 4, seqNo),
                        _addrDatabase.MakeInParam("@ContactorList", SqlDbType.Xml, int.MaxValue, contactorData),
                        _addrDatabase.MakeInParam("@GroupList", SqlDbType.Xml, int.MaxValue, groupData),
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

        public BaseResult RemoveContactors(int seqNo, List<ContactorGroup> groups, List<Contactor> contactors, int compId)
        {
            var rs = new BaseResult { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (seqNo <= 0)
            {
                rs.Failed(-101, "seqNo无效");
                return rs;
            }

            if (groups.Equals(null))
            {
                rs.Failed(-102, "groups无效");
                return rs;

            }

            if (contactors.Equals(null))
            {
                rs.Failed(-103, "contactors无效");
                return rs;

            }

            _desc = "某个终端客户将几个联系人移除出某个分组。";
            _procName = "UP_Addr_CopyContactorsToOtherGroups";//todo
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("SeqNo", seqNo);
            _log.Append("List<ContactorGroup>", groups);
            _log.Append(" List<Contactor>", contactors);

            try
            {
                var parameters = new[]
                                                {
                     _addrDatabase.MakeInParam("@SeqNo",SqlDbType.Int,4,seqNo),//todo;
                   
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

        public ResultContactorList GetAllContactors(int seqNo, int compId, int pageIndex, int pageSize, string searchContent)
        {
            var rs = new ResultContactorList { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (seqNo <= 0)
            {
                rs.Failed(-101, "seqNo无效");
                return rs;
            }

            _desc = "获取某个终端客户的所有联系人分组(不包含所有联系人、未分组联系人）";
            _procName = "UP_Addr_ContactorGroupManager_GetContactorsList";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("SeqNo", seqNo);

            try
            {
                var parameters = new[]
                    {
                        _addrDatabase.MakeInParam("@SeqNo", SqlDbType.Int, 4, seqNo),
                        _addrDatabase.MakeInParam("@CompID", SqlDbType.Int, 4, compId),
                        _addrDatabase.MakeInParam("@SharedFlag", SqlDbType.Int, 4, SharedFlag),
                        _addrDatabase.MakeInParam("@PageIndex", SqlDbType.Int, 4, pageIndex),
                        _addrDatabase.MakeInParam("@PageSize", SqlDbType.Int, 4, pageSize),
                        _addrDatabase.MakeInParam("@SearchContent", SqlDbType.VarChar, 200, searchContent)
                    };
                _addrDatabase.ExecuteProc(_procName, parameters, out _dr);
                if (_dr == null)
                {
                    rs.Failed(-2, "查询结果为空值");
                    return rs;
                }
                while (_dr.Read())
                {
                    if (rs.Contactors == null)
                    {
                        rs.Contactors = new List<Contactor>();
                    }

                    var obj = new Contactor();
                    obj.ContactorID = Convert.ToInt32(SqlComponents.ReaderGetString(_dr["ContactorID"]));
                    obj.ContactorName = SqlComponents.ReaderGetString(_dr["Name"]);
                    obj.WayCount = Convert.ToInt32(SqlComponents.ReaderGetString(_dr["WayCount"]));

                    rs.Contactors.Add(obj);
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

        public ResultContactorList GetUnGroupedContactors(int seqNo, int compId, int pageIndex, int pageSize, string searchContent)
        {
            var rs = new ResultContactorList { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (seqNo <= 0)
            {
                rs.Failed(-101, "seqNo无效");
                return rs;
            }

            _desc = "获取某个终端客户的未分组联系人";
            _procName = "UP_Addr_ContactorGroupManager_GetUnGroupedContactors";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("SeqNo", seqNo);

            try
            {
                var parameters = new[]
                    {
                        _addrDatabase.MakeInParam("@SeqNo", SqlDbType.Int, 4, seqNo),
                        _addrDatabase.MakeInParam("@CompID", SqlDbType.Int, 4, compId),
                        _addrDatabase.MakeInParam("@SharedFlag", SqlDbType.Int, 4, SharedFlag),
                        _addrDatabase.MakeInParam("@PageIndex", SqlDbType.Int, 4, pageIndex),
                        _addrDatabase.MakeInParam("@PageSize", SqlDbType.Int, 4, pageSize),
                        _addrDatabase.MakeInParam("@SearchContent", SqlDbType.VarChar, 200, searchContent)
                    };
                _addrDatabase.ExecuteProc(_procName, parameters, out _dr);
                if (_dr == null)
                {
                    rs.Failed(-2, "todo");
                    return rs;
                }
                while (_dr.Read())
                {
                    if (rs.Contactors == null)
                    {
                        rs.Contactors = new List<Contactor>();
                    }

                    var obj = new Contactor();
                    obj.ContactorID = Convert.ToInt32(SqlComponents.ReaderGetString(_dr["ContactorID"]));
                    obj.ContactorName = SqlComponents.ReaderGetString(_dr["Name"]);
                    obj.WayCount = Convert.ToInt32(SqlComponents.ReaderGetString(_dr["WayCount"]));

                    rs.Contactors.Add(obj);
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

        public ResultContactorList GetUserGroupContactors(int seqNo, int groupID, int compId, int pageIndex, int pageSize, string searchContent)
        {
            var rs = new ResultContactorList { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (seqNo <= 0)
            {
                rs.Failed(-101, "seqNo无效");
                return rs;
            }

            _desc = "获取某个终端客户的指定组的联系人";
            _procName = "UP_Addr_ContactorGroupManager_GetUserGroupContactors";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("SeqNo", seqNo);

            try
            {
                var parameters = new[]
                    {
                        _addrDatabase.MakeInParam("@SeqNo", SqlDbType.Int, 4, seqNo),
                        _addrDatabase.MakeInParam("@CompID", SqlDbType.Int, 4, compId),
                        _addrDatabase.MakeInParam("@GroupID", SqlDbType.Int, 4, groupID),
                        _addrDatabase.MakeInParam("@SharedFlag", SqlDbType.Int, 4, SharedFlag),
                        _addrDatabase.MakeInParam("@PageIndex", SqlDbType.Int, 4, pageIndex),
                        _addrDatabase.MakeInParam("@PageSize", SqlDbType.Int, 4, pageSize),
                        _addrDatabase.MakeInParam("@SearchContent", SqlDbType.VarChar, 200, searchContent)
                    };
                _addrDatabase.ExecuteProc(_procName, parameters, out _dr);
                if (_dr == null)
                {
                    rs.Failed(-2, "todo");
                    return rs;
                }
                while (_dr.Read())
                {
                    if (rs.Contactors == null)
                    {
                        rs.Contactors = new List<Contactor>();
                    }

                    var obj = new Contactor();
                    obj.ContactorID = Convert.ToInt32(SqlComponents.ReaderGetString(_dr["ContactorID"]));
                    obj.ContactorName = SqlComponents.ReaderGetString(_dr["Name"]);
                    obj.WayCount = Convert.ToInt32(SqlComponents.ReaderGetString(_dr["WayCount"]));

                    rs.Contactors.Add(obj);
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

        public BaseResult GetContactorsCount(int seqNo, int groupID, int compId, string searchContent)
        {
            var rs = new ResultContactorList { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (seqNo <= 0)
            {
                rs.Failed(-101, "seqNo无效");
                return rs;
            }

            _desc = "获取联系人数量";
            _procName = "UP_Addr_ContactorGroupManager_GetUserContactorsCount";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("SeqNo", seqNo);

            int count;
            try
            {
                var parameters = new[]
                    {
                        _addrDatabase.MakeInParam("@SeqNo", SqlDbType.Int, 4, seqNo),
                        _addrDatabase.MakeInParam("@CompID", SqlDbType.Int, 4, compId),
                        _addrDatabase.MakeInParam("@GroupID", SqlDbType.Int, 4, groupID),
                        _addrDatabase.MakeInParam("@SharedFlag", SqlDbType.Int, 4, SharedFlag),
                        _addrDatabase.MakeInParam("@SearchContent", SqlDbType.VarChar, 200, searchContent),
                        _addrDatabase.MakeOutParam("@Count", SqlDbType.Int)
                    };
                _addrDatabase.ExecuteProc(_procName, parameters, out _result);
                count = Convert.ToInt32(SqlComponents.ReaderGetString(parameters[5].Value));
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
            rs.Value = count;
            return rs;
        }
    }
}
