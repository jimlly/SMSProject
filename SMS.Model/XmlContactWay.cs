using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SMS.Model.Addr
{
    [Serializable]
    [XmlRoot("ContactWay")]
    public class XMLContactWayClass
    {
        [XmlElement(ElementName = "Way")]
        public XmlContactWay[] XmlContactWay { get; set; }
    }
    /// <summary>
    /// XmlContactWay xml联系方式
    /// </summary>
    [Serializable]
    public class XmlContactWay
    {
        /// <summary>
        /// 联系方式类型
        /// 1 手机 2 固话 3 邮箱
        /// </summary>
        [XmlElement(ElementName = "WayType")]
        public int ContactWayType { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        [XmlElement(ElementName = "WayField")]
        public string Way { get; set; }
    }


    [Serializable]
    [XmlRoot("ContactGroup")]
    public class XMLContactGroupClass
    {
        [XmlElement(ElementName = "Group")]
        public XmlContactGroup[] XmlContactGroup { get; set; }
    }
    /// <summary>
    /// XmlContactor xml联系组
    /// </summary>
    [Serializable]
    public class XmlContactGroup
    {
        /// <summary>
        /// 组ID
        /// </summary>
        [XmlElement(ElementName = "GroupID")]
        public int ContactorGroupID { get; set; }
    }


    [Serializable]
    [XmlRoot("ContactorInfo")]
    public class XMLContactorClass
    {
        [XmlElement(ElementName = "Contactor")]
        public XmlContactor[] XmlContactor { get; set; }
    }
    /// <summary>
    /// XmlContactor xml联系人
    /// </summary>
    [Serializable]
    public class XmlContactor
    {
        /// <summary>
        /// 联系人ID
        /// </summary>
        [XmlElement(ElementName = "ContactorID")]
        public int ContactorID { get; set; }
    }
}
