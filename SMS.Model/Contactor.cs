using System.Collections.Generic;

namespace SMS.Model.Addr
{
    public class Contactor
    {
        public int ContactorID { get; set; }
        public string ContactorName { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public List<ContactWay> CWays { get; set; }
        /// <summary>
        /// 所在联系人分组
        /// </summary>
        public List<ContactorGroup> CGroups { get; set; }

        /// <summary>
        /// 电话会议参会号码
        /// </summary>
        public string ConfParticipatePhoneNo { get; set; }
        /// <summary>
        /// 联系方式数量
        /// </summary>
        public int WayCount { get; set; }
    }
}
