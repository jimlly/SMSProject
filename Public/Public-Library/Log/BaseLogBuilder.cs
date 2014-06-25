using System.Collections.Generic;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using Public.Json;

namespace Public.Log
{
    /// <summary>
    ///     参数输入输出方向枚举
    /// </summary>
    public enum ParamDirection
    {
        /// <summary>
        /// 输入参数
        /// </summary>
        In ,
        /// <summary>
        /// 输出参数
        /// </summary>
        Out ,
        /// <summary>
        /// 输入输出参数
        /// </summary>
        InOut
    };

    /// <summary>
    /// 
    /// </summary>
    public class BaseLogBuilder
    {
        protected string _desc = "";
        protected List<JsonObject> _params = new List<JsonObject>();

        /// <summary>
        /// 
        /// </summary>
        public BaseLogBuilder()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="path"></param>
        public BaseLogBuilder(string method, string path)
        {
            Method = method;
            Path = path;
        }

        /// <summary>
        ///     描述
        /// </summary>
        //   [JsonDataMember(Name = "Desc")]
        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }
        /// <summary>
        ///     代码路径 命名空间+类名称
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        ///     所在的方法
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        ///     异常消息
        /// </summary>
        public string Exception { get; set; }

        /// <summary>
        ///     其它参数列表值
        /// </summary>
        public List<JsonObject> Params
        {
            get { return _params; }
            set { _params = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public bool IsErrorEnabled
        {
            get { return LogHelper.GetLogLevelEnable("error"); }
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public bool IsDebugEnabled
        {
            get { return LogHelper.GetLogLevelEnable("debug"); }
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public bool IsWarnEnabled
        {
            get { return LogHelper.GetLogLevelEnable("warn"); }
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public bool IsInfoEnabled
        {
            get { return LogHelper.GetLogLevelEnable("info"); }
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public bool IsFatalEnabled
        {
            get { return LogHelper.GetLogLevelEnable("fatal"); }
        }
        //
        /// <summary>
        ///     当前LogBuilder类变量转换成JSON格式字符串
        /// </summary>
        /// <returns></returns>
        public string ToJsonString()
        {
            return JsonHelper.SerializeObject(this);
        }

        /// <summary>
        ///     错误日志
        /// </summary>
        public void Error()
        {
            if (IsErrorEnabled)
            {
                //MyLog.logger.Error(ToJsonString());
                LogHelper.Error(ToJsonString());
            }
        }

        /// <summary>
        ///     错误日志
        /// </summary>
        /// <param name="json">json字符串</param>
        public void Error(string json)
        {
            if (IsErrorEnabled)
            {
                //MyLog.logger.Error(json);
                LogHelper.Error(json);
            }
        }

        /// <summary>
        ///     调试日志
        /// </summary>
        public void Debug()
        {
            if (IsDebugEnabled)
            {
                //MyLog.logger.Debug(ToJsonString());
                LogHelper.Debug(ToJsonString());
            }
        }

        /// <summary>
        ///     调试日志
        /// </summary>
        /// <param name="json">json字符串</param>
        public void Debug(string json)
        {
            if (IsDebugEnabled)
            {
                //MyLog.logger.Debug(json);
                LogHelper.Debug(json);
            }
        }

        /// <summary>
        ///     警告日志
        /// </summary>
        public void Warn()
        {
            if (IsWarnEnabled)
            {
                //MyLog.logger.Warn(ToJsonString());
                LogHelper.Warn(ToJsonString());
            }
        }

        /// <summary>
        ///     警告日志
        /// </summary>
        /// <param name="json">json字符串</param>
        public void Warn(string json)
        {
            if (IsWarnEnabled)
            {
                //MyLog.logger.Warn(json);
                LogHelper.Warn(json);
            }
        }

        /// <summary>
        ///     信息日志
        /// </summary>
        public void Info()
        {
            if (IsInfoEnabled)
            {
                //MyLog.logger.Info(ToJsonString());
                LogHelper.Warn(ToJsonString());
            }
        }

        /// <summary>
        ///     信息日志
        /// </summary>
        /// <param name="json">json字符串</param>
        public void Info(string json)
        {
            if (IsInfoEnabled)
            {
                //MyLog.logger.Info(json);
                LogHelper.Info(json);
            }
        }

        /// <summary>
        ///     Fatal日志
        /// </summary>
        public void Fatal()
        {
            if (IsFatalEnabled)
            {
                LogHelper.Fatal(ToJsonString());
            }
        }

        /// <summary>
        ///     Fatal日志
        /// </summary>
        /// <param name="json">json字符串</param>
        public void Fatal(string json)
        {
            if (IsFatalEnabled)
            {
                LogHelper.Fatal(json);
            }
        }
        /// <summary>
        ///     添加一个参数
        /// </summary>
        /// <param name="name"> 参数名 </param>
        /// <param name="value"> 参数值 </param>
        /// <param name="iDirection"> 参数的输入输出方面 </param>
        public void Append(string name, object value, ParamDirection iDirection = ParamDirection.In)
        {
            var obj = new JsonObject();
            obj[name] = value;
            obj["Direction"] = iDirection;

            _params.Add(obj);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Parameter
    {
        // 参数名字
        private ParamDirection _direction = 0;
        private string _name = "";

        //参数值
        private object _value = "";

        // 参数方向

        //构造函数
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="iDirection"></param>
        public Parameter(string name, object value, ParamDirection iDirection)
        {
            _name = name;
            _value = value;
            _direction = iDirection;
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonDataMember(Name = "Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonDataMember(Name = "Value")]
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        //参数方向,0 输入参数(IN) 1 输出参数(OUT) 2 输入输出参数(INOUT)
        /// <summary>
        /// 
        /// </summary>
        [JsonDataMember(Name = "Direction")]
        public ParamDirection Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
    }
}