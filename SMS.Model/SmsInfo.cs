using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SMS.Model
{
   public class SmsInfo
    {
       /// <summary>
        /// TaskName
        /// </summary>
       [Display(Name="任务名称")]
       [Required]
		public string TaskName { get; set; }
		/// <summary>
        /// MsgID
        /// </summary>
		public string MsgID { get; set; }
		/// <summary>
        /// UserID
        /// </summary>
		public int UserID { get; set; }
		/// <summary>
        /// Sender
        /// </summary>
        [Display(Name = "手机号码")]
        [Required]
		public string Sender { get; set; }
		/// <summary>
        /// Priority
        /// </summary>
		public SmsPriority Priority { get; set; }
		/// <summary>
        /// 1 手工录入 2 文本导入 3 excel导入
        /// </summary>
		public InputType InputType { get; set; }
		/// <summary>
        /// 1 即时 2 定时
        /// </summary>
		public SendWay SendWay { get; set; }
		/// <summary>
        /// SendTime
        /// </summary>
        [Display(Name = "定时发送")]
       
		public DateTime SendTime { get; set; }
		/// <summary>
        /// SubmitTime
        /// </summary>
		public DateTime SubmitTime { get; set; }
		/// <summary>
        /// Message
        /// </summary>
        [Display(Name = "短信内容")]
        [Required]
		public string Message { get; set; }
		/// <summary>
        /// Status
        /// </summary>
		public BatchState Status { get; set; }
		/// <summary>
        /// CompletedTime
        /// </summary>
		public DateTime CompletedTime { get; set; }
		/// <summary>
        /// IsDelete
        /// </summary>
		public bool IsDelete { get; set; }
		/// <summary>
        /// SendCount
        /// </summary>
		public int SendCount { get; set; }
		/// <summary>
        /// SuccessCount
        /// </summary>
		public int SuccessCount { get; set; }
		/// <summary>
        /// FailCount
        /// </summary>
		public int FailCount { get; set; }
		/// <summary>
        /// 1 普通短信 2 长短信 3 免费短信
        /// </summary>
        [Display(Name = "类别")]
        [Required]
		public SmsType SmsType { get; set; }
		/// <summary>
        /// Amount
        /// </summary>
		public long Amount { get; set; }
		/// <summary>
        /// ApprovalTimeApprovalTime
        /// </summary>
		public DateTime ApprovalTime { get; set; }
		/// <summary>
        /// MsgType
        /// </summary>
		public int MsgType { get; set; }
		/// <summary>
        /// CreateTime
        /// </summary>
		public DateTime CreateTime { get; set; }

        public List<SmsDetailInfo> SmsDetailList { get; set; }
    }
}
