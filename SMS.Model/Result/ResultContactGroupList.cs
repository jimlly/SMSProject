
using SMS.Model.Addr;
using System.Collections.Generic;
using Public.Result;
namespace SMS.Model.Result
{
    /// <summary>
    /// 联系人组返回类
    /// </summary>
   public class ResultContactGroupList:BaseResult
    {
       /// <summary>
       /// 是否结束
       /// </summary>
       public bool IsEnd;

        /// <summary>
        /// 联系人组集合
        /// </summary>
       public List<ContactGroupInfo> GroupList { get; set; }
    }
}
