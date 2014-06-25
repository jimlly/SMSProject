
using SMS.Model.Addr;
using System.Collections.Generic;
using Public.Result;
namespace SMS.Model.Result
{
    /// <summary>
    /// 联系人集合返回类
    /// </summary>
   public class ResultContactList:BaseResult
   {
       /// <summary>
       /// 是否结束
       /// </summary>
       public bool IsEnd;
        /// <summary>
        /// 联系人集合
        /// </summary>
       public List<ContactInfo> ContactList { get; set; }
    }
}
