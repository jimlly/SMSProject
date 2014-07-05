using Public.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSWeb.Common
{
    public class UserContext
    {

        private static UserContext _current;
        public static UserContext Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new UserContext();
                }
                return _current;
            }
        }

        public string MobilezhRegex
        {
            get {
                return ConfigHelper.GetConfigString("MobilezhRegex");
            }
        }
        public string TelePhoneRegex
        {
            get
            {
                return ConfigHelper.GetConfigString("TelePhoneRegex");
            }
        }
        public string EmailRegex
        {
            get
            {
                return ConfigHelper.GetConfigString("EmailRegex");
            }
        }
        public string UserNameRegex
        {
            get
            {
                return ConfigHelper.GetConfigString("UserNameRegex");
            }
        }
        
    }
}