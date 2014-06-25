////==========================================================================
////类名:Yuantel.Common\LogBuilder.cs
////
////功能描述：Yuantel--Common--封装参数,转为JSON格式
////历史记录：
//// NO        日期          版本       姓名            内容
////--------------------------------------------------------------------------
//// 1         2011-12-26    V1.0      陈洪弟           
//// 2         2011-12-30    V1.0      骆进           修改
//// 3         2013-10-13    V1.1      陈洪弟         拆分为基类和继承类
////==========================================================================

namespace Public.Log
{
    /// <summary>
    /// 使用之前
    /// 1、复制配置文件log4Net.Config到bin目录（可以针对文件配置为：始终复制）
    /// 2、使用之前需要在App_Start之类的方法中调用LogHelper.InitConfigWebApp(fileName);
    /// </summary>
    public class LogBuilder:BaseLogBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        public LogBuilder()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="path"></param>
        public LogBuilder(string method, string path):base(method,path)
        {
        }

        /// <summary>
        ///     使用的数据库
        /// </summary>
        //  [JsonDataMember(Name = "Database")]
        public string Database { get; set; }

        /// <summary>
        ///     调用的存储过程
        /// </summary>
        public string StroreProcedure { get; set; }
    }
}