using Public.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Model.Result
{
    public class ResultSmsInfo : BaseResult
    {
        public SmsInfo SmsInfo { get; set; }
    }

    public class ResultSmsDetailInfo : BaseResult
    {
        public SmsDetailInfo SmsDetailInfo { get; set; }
    }
}
