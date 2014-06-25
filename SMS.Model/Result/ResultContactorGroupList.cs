using System;
using System.Collections.Generic;
using System.Text;
using SMS.Model.Addr;
using Public.Result;

namespace SMS.Model.Result
{
    public class ResultContactorGroupList:BaseResult
    {
        /// <summary>
        /// 联系组List
        /// </summary>
        public List<ContactorGroup> CGroups { get; set; }
    }
}
