using System;
using System.Collections.Generic;
using System.Text;
using SMS.Model.Addr;
using Public.Result;

namespace SMS.Model.Result
{
    public class ResultContactorDetail:BaseResult
    {
        /// <summary>
        /// 联系人详细信息
        /// </summary>
        public Contactor ContactorInfo { get; set; }
    }
}
