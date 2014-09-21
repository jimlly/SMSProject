using Public.Log;
using Public.Result;
using SMS.IDAL;
using SMS.Model;
using SMS.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SMS.BLL
{
   public class SmsManager
    {
         public ISMSDAL SmsDal { get; set; }

        private readonly FunctionLogBuilder _log;

        public SmsManager()
        {
            SmsDal =  SMS.DALFactory.DataAccess.CreateSmsDAL();
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
        public BaseResult SendSms(SmsInfo sms)
        {

            var rs = new BaseResult();

            _log.Method = MethodBase.GetCurrentMethod().Name;
            var declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            if (declaringType != null)
            {
                _log.Path = declaringType.FullName;
            }
            _log.Append("SmsInfo", sms);
            if (sms == null)
            {
                rs.Failed(-101, "参数【sms】为null");
                return rs;
            }
            if (sms.UserID <= 0)
            {
                rs.Failed(-102, "参数【userId】没通过【security.CheckUser方法】验证");
                return rs;
            }
            
            if (string.IsNullOrEmpty(sms.TaskName))
            {
                rs.Failed(-103, "参数sms.TaskName为null");
                return rs;
            }
            if (sms.SmsDetailList== null)
            {
                rs.Failed(-103, "参数sms.SmsDetailList为null");
                return rs;
               
            }

            try
            {
                var returnObj = SmsDal.SendSms(sms);

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

        public ResultSmsList GetSmsList(int userId, string taskName, DateTime startTime, DateTime endTime, int pageSize, int pageIndex)
        {
            return SmsDal.GetSmsList(userId, taskName, startTime, endTime, pageSize, pageIndex);
        }
        public ResultSmsDetailList GetSmsDetailList(string msgId, int pageSize, int pageIndex)
        {
            return SmsDal.GetSmsDetailList(msgId, pageSize, pageIndex);
        }
        public ResultSmsInfo GetSmsInfo(string msgId, int userId)
        {
            return SmsDal.GetSmsInfo(msgId, userId);
        }
        public ResultSmsDetailInfo GetSmsDetailInfo(int msgDetailId, string msgId)
        {
            return SmsDal.GetSmsDetailInfo(msgDetailId, msgId);
        }
    }
}
