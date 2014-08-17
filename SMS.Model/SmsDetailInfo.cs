using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Model
{
    public class SmsDetailInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int MsgDetailId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MsgID { get; set; }
        ///<summary>
        ///Mobile
        ///</summary>
        public string Mobile { get; set; }
        ///<summary>
        ///Name
        ///</summary>
        public string Name { get; set; }
        ///<summary>
        ///SendTime
        ///</summary>
        public DateTime SendTime { get; set; }
        ///<summary>
        ///Status
        ///</summary>
        public SmsState Status { get; set; }
        ///<summary>
        ///ChennelID
        ///</summary>
        public int ChennelID { get; set; }
    }
}
