using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Model
{
    public enum SendWay : byte
    {
        /// <summary>
        /// /即时
        /// </summary>
        Immed = 1,
        /// <summary>
        /// 定时
        /// </summary>
        Timing = 2 //定时
    }
    /// <summary>
    /// 录入方式
    /// </summary>
    public enum InputType : int
    {
        /// <summary>
        /// 手工
        /// </summary>
        Manual=1,//手工
        /// <summary>
        /// 文本导入
        /// </summary>
        Text=2,//文本导入
        /// <summary>
        /// Excel
        /// </summary>
        Excel=3//Excel导入
    }
    /// <summary>
    /// 短信状态
    /// </summary>
    public enum SmsState : byte
    {
        /// <summary>
        /// 缺省状态
        /// </summary>
        Default = 0,        // 缺省状态
        /// <summary>
        /// 正在发送
        /// </summary>
        Sending = 1,        // 正在发送
        /// <summary>
        /// 发送成功
        /// </summary>
        Success = 2,        // 发送成功
        /// <summary>
        /// 发送失败
        /// </summary>
        Failed = 9          // 发送失败
    }
    /// <summary>
    /// 信息优先级
    /// </summary>
    public enum SmsPriority : byte
    {
        /// <summary>
        /// 较低
        /// </summary>
        Lower = 0,
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 1,
        /// <summary>
        /// 高
        /// </summary>
        High = 2,
    }

    /// <summary>
    /// 批次状态
    /// </summary>
    public enum BatchState : byte
    {
        Default = 0,        // 提交的缺省状态，等待审核
        Checking = 1,       // 正在审核
        Denied = 2,         // 审核未通过
        Paying = 3,         // 正在计费
        LessBalance = 4,    // 余额不足
        Sending = 5,        // 正在发送
        Completed = 9       // 完成
    }
    /// <summary>
    /// 短信类型
    /// </summary>
    public enum SmsType : int
    {
         //1 普通短信 2 长短信 3 免费短信
        /// <summary>
        /// 普通短信
        /// </summary>
        Ordinary=1,
        /// <summary>
        /// 长短信
        /// </summary>
        Long=2,
        /// <summary>
        /// 免费短信
        /// </summary>
        Free=3
    }
}
