using Public.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Model.Result
{
    public class ResultSmsList : BaseResult
    {
        public int Total { get; set; }
        public List<SmsInfo> SmsList { get; set; }
    }
}
