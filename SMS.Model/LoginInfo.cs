using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Model
{
    [Serializable]
    public class LoginInfo
    {
        public int UserID { get; set; }

        public int CompID { get; set; }
        public string UserName { get; set; }

        public string UserAccount { get; set; }
    }
}
