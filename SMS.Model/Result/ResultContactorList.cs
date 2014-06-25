using System;
using System.Collections.Generic;
using System.Text;
using SMS.Model.Addr;
using Public.Result;

namespace SMS.Model.Result
{
    public class ResultContactorList:BaseResult
    {
        /// <summary>
        /// 联系人List集合
        /// </summary>
        public List<Contactor> Contactors { get; set; }
    }
}
