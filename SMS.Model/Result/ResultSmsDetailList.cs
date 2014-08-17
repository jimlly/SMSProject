using Public.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Model.Result
{
   public class ResultSmsDetailList:BaseResult
    {
       public int Total { get; set; }
       public List<SmsDetailInfo> SmsDetailList { get; set; }
    }
}
