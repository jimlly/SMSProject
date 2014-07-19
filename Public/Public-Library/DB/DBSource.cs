

namespace Public.DB
{
    /// <summary>
    /// 数据库连接来源
    /// </summary>
    public enum DBSource
    {
        /// <summary>
        /// 中心数据库
        /// </summary>
        DBYuantel = 0,
        /// <summary>
        /// ytNetCC_DB中心数据库
        /// </summary>
        DBYtNetCC = 1,
        /// <summary>
        /// ytTeleConf_DB中心数据库
        /// </summary>
        DBYtConf = 2,
        /// <summary>
        /// 网络数据会议中心数据库
        /// </summary>
        DBYtDataConf = 3,
        /// <summary>
        /// ytFax_DB中心数据库
        /// </summary>
        DBYtFax=5,
        /// <summary>
        /// ytSms中心数据库
        /// </summary>
        DBYtSms=6,
        /// <summary>
        /// ytSysDB 中心数据库
        /// </summary>
        DBYtSys=8,
        /// <summary>
        /// AddressBoox 中心数据库
        /// </summary>
        DBYtAddressBook =9,

        /// <summary>
        /// DBYtMail 邮件数据库
        /// </summary>
        DBYtMail = 11,
    }
}