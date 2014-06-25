using System;
using System.Reflection;
namespace Public.Log
{
    /// <summary>
    /// 
    /// </summary>
    public class FunctionLogBuilder:BaseLogBuilder
    {    
        /// <summary>
        /// 使用之前
        /// 1、复制配置文件log4Net.Config到bin目录（可以针对文件配置为：始终复制）
        /// 2、使用之前需要在App_Start之类的方法中调用LogHelper.InitConfigWebApp(fileName);
        /// </summary>
        public FunctionLogBuilder()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="path"></param>
        public FunctionLogBuilder(string method, string path) : base(method, path)
        {
            
        }

        /// <summary>
        /// 设置方法信息
        /// </summary>
        /// <param name="method"></param>
        public  void SetMethodInfo(MethodBase method)
        {
            if (method==null) return;
            Method = method.Name;
            var declaringType = method.DeclaringType;

           
            if (declaringType != null) Path = declaringType.FullName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public void SetErrorInfo(Exception ex)
        {
            Method = ex.TargetSite.Name;
            Path = ex.StackTrace;
            Exception = ex.Message;
            Error();
        }
    }
}
