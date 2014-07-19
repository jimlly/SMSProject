
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