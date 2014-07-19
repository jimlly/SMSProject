
using System.IO;
using log4net;

namespace Public.Log
{
    /// <summary>
    /// 
    /// </summary>
    public class LogHelper
    {
        private static readonly ILog Log = LogManager.GetLogger("FileDefault");

        /// <summary>
        /// 初始化配置文件，"Log4Net.Config"需要放置在根目录下（同Web.config）；方法在log4net使用之前调用一次
        /// </summary>
        public static void InitConfigWebApp(string fileName)
        {
            var configFile = new FileInfo(fileName);
            log4net.Config.XmlConfigurator.ConfigureAndWatch(configFile);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="debug"></param>
        public static void Debug(string debug)
        {
            Log.Debug(debug);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        public static void Error(string error)
        {
            Log.Error(error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public static void Info(string info)
        {
            Log.Info(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="warn"></param>
        public static void Warn(string warn)
        {
            Log.Warn(warn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fatal"></param>
        public static void Fatal(string fatal)
        {
            Log.Fatal(fatal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static bool GetLogLevelEnable(string level)
        {
            switch (level.ToLower())
            {
                case "error":
                    return Log.IsErrorEnabled;
                case "debug":
                    return Log.IsDebugEnabled;
                case "fatal":
                    return Log.IsFatalEnabled;
                case "info":
                    return Log.IsInfoEnabled;
                case "warn":
                    return Log.IsWarnEnabled;
                default:
                    return false;
            }
        }
    }
}