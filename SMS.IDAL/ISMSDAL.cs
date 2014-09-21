using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Model;
using SMS.Model.Result;
using Public.Result;
namespace SMS.IDAL
{
   public interface ISMSDAL
    {
       /// <summary>
       /// 发送短信
       /// </summary>
       /// <param name="sms"></param>
       /// <returns></returns>
       BaseResult SendSms(SmsInfo sms);
       /// <summary>
       /// 获取短信主记录列表
       /// </summary>
       /// <param name="userId"></param>
       /// <param name="pageSize"></param>
       /// <param name="pageIndex"></param>
       /// <returns></returns>
       ResultSmsList GetSmsList(int userId, string taskName,DateTime startTime,DateTime endTime, int pageSize, int pageIndex);
       /// <summary>
       /// 获取短信明细列表
       /// </summary>
       /// <param name="MsgId"></param>
       /// <returns></returns>
       ResultSmsDetailList GetSmsDetailList(string MsgId, int pageSize, int pageIndex);

       /// <summary>
       /// 获取单条信息
       /// </summary>
       /// <param name="MsgId"></param>
       /// <returns></returns>
       ResultSmsInfo GetSmsInfo(string MsgId,int UserId);
       /// <summary>
       /// 获取单条名细信息
       /// </summary>
       /// <param name="MsgDetailId"></param>
       /// <returns></returns>
       ResultSmsDetailInfo GetSmsDetailInfo(int MsgDetailId,string MsgId);
    }
}
