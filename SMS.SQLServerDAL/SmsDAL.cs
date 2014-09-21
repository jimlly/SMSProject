using Public.DB;
using Public.Log;
using Public.Result;
using SMS.IDAL;
using SMS.Model;
using SMS.Model.Result;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SMS.SQLServerDAL
{
    public class SmsDAL : ISMSDAL
    {
        #region 字段

        private string _procName;
        private LogBuilder _log;
        private const string ClassName = "ContactorDAL";
        private readonly string _databaseName = "SMS";
        private string _methodName;
        private readonly MssqlDatabase _smsDatabase;

        // 执行过程中用到的
        private string _desc;
        private SqlDataReader _dr;
        private DataSet _ds;
        private int _result;

        public SmsDAL()
        {
            _procName = "";
            _databaseName = "SMS";

            try
            {
                _smsDatabase = new MssqlDatabase();
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

        public BaseResult SendSms(SmsInfo sms)
        {
            var rs = new BaseResult { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (sms.UserID <= 0)
            {
                rs.Failed(-101, "userId无效");
                return rs;
            }

            if (sms == null)
            {
                rs.Failed(-102, "sms无效");
                return rs;
            }

            _desc = "发送短信";
            _procName = "UP_SMS_AddSms";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("userId", sms.UserID);

            try
            {

                StringBuilder smsDetailXML = new StringBuilder();
                smsDetailXML.Append("<SmsList>");
                sms.SmsDetailList.ForEach((item) => {
                    smsDetailXML.Append("<Sms>");
                    smsDetailXML.AppendFormat("<Mobile>{0}</Mobile>", item.Mobile);
                    smsDetailXML.AppendFormat("<Name>{0}</Name>", item.Name);
                    smsDetailXML.Append("</Sms>");
                });

                smsDetailXML.Append("</SmsList>");
                var parameters = new[]
                    {
                        _smsDatabase.MakeInParam("@UserId", SqlDbType.Int, 4, sms.UserID),
                        _smsDatabase.MakeInParam("@TaskName", SqlDbType.VarChar, sms.TaskName),
                        _smsDatabase.MakeInParam("@Sender", SqlDbType.VarChar, sms.Sender),
                        _smsDatabase.MakeInParam("@Priority", SqlDbType.Int,(int) sms.Priority),
                        _smsDatabase.MakeInParam("@InputType", SqlDbType.Int,(int) sms.InputType),
                        _smsDatabase.MakeInParam("@SendWay", SqlDbType.Int, (int)sms.SendWay),
                        _smsDatabase.MakeInParam("@SendTime", SqlDbType.DateTime, sms.SendTime),
                        _smsDatabase.MakeInParam("@SubmitTime", SqlDbType.DateTime, sms.SubmitTime),
                        _smsDatabase.MakeInParam("@Message", SqlDbType.VarChar, sms.Message),
                        _smsDatabase.MakeInParam("@SmsType", SqlDbType.VarChar, (int)sms.SmsType),
                        _smsDatabase.MakeInParam("@SmsDetailXML",SqlDbType.Xml,smsDetailXML.ToString()),
                        _smsDatabase.MakeOutParam("@MsgID", SqlDbType.VarChar,16)
                    };
                _smsDatabase.ExecuteProc(_procName, parameters, out _result);
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
                _smsDatabase.Close();//仅显式关闭链接，不做其它操作
            }
            rs.Success();
            return rs;
        }
        /// <summary>
        /// 获取短信主记录列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="taskName"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ResultSmsList GetSmsList(int userId,string taskName,DateTime startTime,DateTime endTime, int pageSize, int pageIndex)
        {
            var rs = new ResultSmsList { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (userId <= 0)
            {
                rs.Failed(-101, "userId无效");
                return rs;
            }

            _desc = "获取短信主记录列表";
            _procName = "UP_SMS_GetSmsList";
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
                var parameters = new[]
                    {
                        _smsDatabase.MakeInParam("@userId", SqlDbType.Int, 4, userId),
                        _smsDatabase.MakeInParam("@TaskName", SqlDbType.VarChar, taskName),
                        _smsDatabase.MakeInParam("@StartTime", SqlDbType.DateTime, startTime),
                        _smsDatabase.MakeInParam("@EndTime", SqlDbType.DateTime, endTime),
                        _smsDatabase.MakeInParam("@PageIndex", SqlDbType.Int, 4, pageIndex),
                        _smsDatabase.MakeInParam("@PageSize", SqlDbType.Int, 4, pageSize),
                        _smsDatabase.MakeOutParam("@Total", SqlDbType.Int)
                    };
                _smsDatabase.ExecuteProc(_procName, parameters, out _dr);
                if (_dr == null)
                {
                    rs.Failed(-2, "todo");
                    return rs;
                }
              
                while (_dr.Read())
                {
                    
                    if (rs.SmsList == null)
                    {
                        rs.SmsList = new List<SmsInfo>();
                    }

                    var obj = new SmsInfo();
                    obj.UserID = userId;
                    obj.TaskName = SqlComponents.ReaderGetString(_dr["TaskName"]);
                    obj.MsgID = SqlComponents.ReaderGetString(_dr["MsgID"]);
                    obj.Sender = SqlComponents.ReaderGetString(_dr["Sender"]);
                    obj.Message= SqlComponents.ReaderGetString(_dr["Message"]);
                    obj.InputType = (InputType)SqlComponents.ReaderGetInt32(_dr["InputType"]);
                    obj.SendWay = (SendWay)SqlComponents.ReaderGetInt32(_dr["SendWay"]);
                    obj.Priority= (SmsPriority)SqlComponents.ReaderGetByte(_dr["Priority"]);
                    obj.Status = (BatchState)SqlComponents.ReaderGetByte(_dr["Status"]);
                    obj.SmsType=(SmsType)SqlComponents.ReaderGetByte(_dr["SmsType"]);
                    obj.SubmitTime = SqlComponents.ReaderGetDateTime(_dr["SubmitTime"]);
                    obj.ApprovalTime = SqlComponents.ReaderGetDateTime(_dr["ApprovalTime"]);
                    obj.CompletedTime = SqlComponents.ReaderGetDateTime(_dr["CompletedTime"]);
                    obj.SuccessCount = SqlComponents.ReaderGetInt32(_dr["SuccessCount"]);
                    obj.FailCount = SqlComponents.ReaderGetInt32(_dr["FailCount"]);
                    obj.Amount = SqlComponents.ReaderGetLong(_dr["Amount"]);
                    obj.SendCount = SqlComponents.ReaderGetInt32(_dr["SendCount"]);
                    rs.SmsList.Add(obj);
                }
                _dr.Close();
                rs.Total = SqlComponents.ReaderGetInt32(parameters[6].Value);
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
                _smsDatabase.Close();//仅显式关闭链接，不做其它操作
            }
            rs.Success();
            return rs;
        }
        /// <summary>
        /// 获取短信明细记录
        /// </summary>
        /// <param name="MsgId"></param>
        /// <returns></returns>
        public ResultSmsDetailList GetSmsDetailList(string MsgId, int pageSize, int pageIndex)
        {
            var rs = new ResultSmsDetailList { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (string.IsNullOrEmpty(MsgId))
            {
                rs.Failed(-101, "MsgIdi不能为空");
                return rs;
            }

            _desc = "获取短信主记录列表";
            _procName = "UP_SMS_GetSmsDetailList";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("msgId", MsgId);

            try
            {
                var parameters = new[]
                    {
                        _smsDatabase.MakeInParam("@MsgID", SqlDbType.VarChar,MsgId),
                        _smsDatabase.MakeInParam("@PageIndex", SqlDbType.Int, 4, pageIndex),
                        _smsDatabase.MakeInParam("@PageSize", SqlDbType.Int, 4, pageSize),
                        _smsDatabase.MakeOutParam("@Total", SqlDbType.Int)
                    };
                _smsDatabase.ExecuteProc(_procName, parameters, out _dr);
                if (_dr == null)
                {
                    rs.Failed(-2, "todo");
                    return rs;
                }

                while (_dr.Read())
                {

                    if (rs.SmsDetailList == null)
                    {
                        rs.SmsDetailList = new List<SmsDetailInfo>();
                    }

                    var obj = new SmsDetailInfo();
                   
                    obj.Mobile = SqlComponents.ReaderGetString(_dr["Mobile"]);
                    obj.MsgID = SqlComponents.ReaderGetString(_dr["MsgID"]);
                    obj.Name = SqlComponents.ReaderGetString(_dr["Name"]);
                   
                    obj.Status = (SmsState)SqlComponents.ReaderGetByte(_dr["Status"]);
                    obj.MsgDetailId = SqlComponents.ReaderGetByte(_dr["SysID"]);
                    obj.SendTime = SqlComponents.ReaderGetDateTime(_dr["SendTime"]);
                   
                    obj.ChennelID = SqlComponents.ReaderGetInt32(_dr["ChennelID"]);
                   
                    rs.SmsDetailList.Add(obj);
                }
                _dr.Close();
                rs.Total = SqlComponents.ReaderGetInt32(parameters[3].Value);
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
                _smsDatabase.Close();//仅显式关闭链接，不做其它操作
            }
            rs.Success();
            return rs;
        }

        public ResultSmsInfo GetSmsInfo(string MsgId,int UserID)
        {
            var rs = new ResultSmsInfo { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (string.IsNullOrEmpty(MsgId))
            {
                rs.Failed(-101, "MsgIdi不能为空");
                return rs;
            }

            _desc = "获取短信主记录列表";
            _procName = "UP_SMS_GetSmsInfo";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("msgId", MsgId);

            try
            {
                var parameters = new[]
                    {
                        _smsDatabase.MakeInParam("@MsgID", SqlDbType.VarChar,MsgId),
                        _smsDatabase.MakeInParam("@UserID", SqlDbType.Int, 4, UserID)
                    };
                _smsDatabase.ExecuteProc(_procName, parameters, out _dr);
                if (_dr == null)
                {
                    rs.Failed(-2, "todo");
                    return rs;
                }

                if (_dr.Read())
                {

                   
                    var obj = new SmsInfo();

                   
                    obj.TaskName = SqlComponents.ReaderGetString(_dr["TaskName"]);
                    obj.MsgID = SqlComponents.ReaderGetString(_dr["MsgID"]);
                    obj.Sender = SqlComponents.ReaderGetString(_dr["Sender"]);
                    obj.Message = SqlComponents.ReaderGetString(_dr["Message"]);
                    obj.InputType = (InputType)SqlComponents.ReaderGetInt32(_dr["InputType"]);
                    obj.SendWay = (SendWay)SqlComponents.ReaderGetInt32(_dr["SendWay"]);
                    obj.Priority = (SmsPriority)SqlComponents.ReaderGetByte(_dr["Priority"]);
                    obj.Status = (BatchState)SqlComponents.ReaderGetByte(_dr["Status"]);
                    obj.SmsType = (SmsType)SqlComponents.ReaderGetByte(_dr["SmsType"]);
                    obj.SubmitTime = SqlComponents.ReaderGetDateTime(_dr["SubmitTime"]);
                    obj.ApprovalTime = SqlComponents.ReaderGetDateTime(_dr["ApprovalTime"]);
                    obj.CompletedTime = SqlComponents.ReaderGetDateTime(_dr["CompletedTime"]);
                    obj.SuccessCount = SqlComponents.ReaderGetInt32(_dr["SuccessCount"]);
                    obj.FailCount = SqlComponents.ReaderGetInt32(_dr["FailCount"]);
                    obj.Amount = SqlComponents.ReaderGetLong(_dr["Amount"]);
                    rs.SmsInfo = obj;
                }
                _dr.Close();
               
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
                _smsDatabase.Close();//仅显式关闭链接，不做其它操作
            }
            rs.Success();
            return rs;
        }

        public ResultSmsDetailInfo GetSmsDetailInfo(int MsgDetailId,string MsgId)
        {
            var rs = new ResultSmsDetailInfo { State = false, Value = -1, Desc = "数据操作层初始化" };
            if (string.IsNullOrEmpty(MsgId))
            {
                rs.Failed(-101, "MsgIdi不能为空");
                return rs;
            }
            if (MsgDetailId<=0)
            {
                rs.Failed(-102, "MsgDetailId必须大于0");
                return rs;
            }
            _desc = "获取短信明细";
            _procName = "UP_SMS_GetSmsDetaiInfo";
            _methodName = MethodBase.GetCurrentMethod().Name;

            _log = new LogBuilder
            {
                Method = string.Format("类[{0}]方法[{1}]", ClassName, _methodName),
                Desc = _desc,
                Database = _databaseName,
                StroreProcedure = _procName
            };
            _log.Append("msgId", MsgId);

            try
            {
                var parameters = new[]
                    {
                        _smsDatabase.MakeInParam("@MsgID", SqlDbType.VarChar,MsgId),
                        _smsDatabase.MakeInParam("@MsgDetailId", SqlDbType.Int, 4, MsgDetailId)
                    };
                _smsDatabase.ExecuteProc(_procName, parameters, out _dr);
                if (_dr == null)
                {
                    rs.Failed(-2, "todo");
                    return rs;
                }

                if (_dr.Read())
                {


                    var obj = new SmsDetailInfo();

                    obj.Mobile = SqlComponents.ReaderGetString(_dr["Mobile"]);
                    obj.MsgID = SqlComponents.ReaderGetString(_dr["MsgID"]);
                    obj.Name = SqlComponents.ReaderGetString(_dr["Name"]);

                    obj.Status = (SmsState)SqlComponents.ReaderGetByte(_dr["Status"]);
                    obj.MsgDetailId = SqlComponents.ReaderGetByte(_dr["SysID"]);
                    obj.SendTime = SqlComponents.ReaderGetDateTime(_dr["SendTime"]);

                    obj.ChennelID = SqlComponents.ReaderGetInt32(_dr["ChennelID"]);

                    rs.SmsDetailInfo = obj;
                }
                _dr.Close();
               
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
                _smsDatabase.Close();//仅显式关闭链接，不做其它操作
            }
            rs.Success();
            return rs;
        }
    }
}
