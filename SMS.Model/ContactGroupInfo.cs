#region -   Copyright信息  -
//********************************************************************************************************
//Copyright © 2013  Clrs 
//
//作  者：Clrs
//日　期：2013/10/29 11:35:31
//描　述：联系人组信息
//版　本：1.00
//修改历史记录
//版　本　　　　　修改时间　　　　　　修改人　　　　　变更内容
//1.00         2013/10/29 11:35:31        Clrs             新增
//********************************************************************************************************
#endregion

using System.Runtime.Serialization;
namespace SMS.Model.Addr
{
    /// <summary>
    /// 联系人组信息
    /// </summary>
    [DataContract]
    public class ContactGroupInfo
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
        /// 组ID
        /// </summary>
        [DataMember]
        public int GroupID { get; set; }
        /// <summary>
        /// 组名称
        /// </summary>
        [DataMember]
        public string GroupName { get; set; }
        /// <summary>
        /// 成员数
        /// </summary>
        [DataMember]
        public int MemberCount { get; set; }

    }
}
