
using System.Runtime.Serialization;

namespace SMS.Model.Addr
{
    [DataContract]
    public class ContactInfo
    {
        /// <summary>
        ///  用户编号
        /// </summary>
        [DataMember]
        public int SeqNo { get; set; }

        /// <summary>
        ///  企业编号
        /// </summary>
        [DataMember]
        public int CompID { get; set; }

        /// <summary>
        /// 联系人ID
        /// </summary>
        [DataMember]
        public int ContactorID { get; set; }

        /// <summary>
        /// 组ID
        /// </summary>
        [DataMember]
        public string GroupID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 办公电话
        /// </summary>
        [DataMember]
        public string JobPhone
        {
            get;
            set;
        }

        /// <summary>
        /// 商务传真
        /// </summary>
        [DataMember]
        public string JobFax
        {
            get;
            set;
        }

        /// <summary>
        /// 移动电话
        /// </summary>
        [DataMember]
        public string Mobile
        {
            get;
            set;
        }

        /// <summary>
        /// 家庭电话
        /// </summary>
        [DataMember]
        public string HomePhone
        {
            get;
            set;
        }

        [DataMember]
        public int DefConfPhoneIdx
        {
            get;
            set;
        }


        [DataMember]
        public int WayCount { get; set; }
        
    }
}
