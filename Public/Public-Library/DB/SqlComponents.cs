using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Public.DB
{
    /// <summary>
    /// SqlComponents 数据处理
    /// </summary>
    public class SqlComponents
    {
        private SqlComponents()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// SQL中字符串数据
        /// '转意符变换为''
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public string getSQLData(string str)
        {
            return str.Replace("'", "''");
        }
        /// <summary>
        /// SQL 中包含LIKE 的数据转换
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public string getSQLLikeData(string str)
        {
            str = str.Replace("'", "''");
            str = str.Replace("[", "[[]");
            str = str.Replace("%", "[%]");
            return str.Replace("_", "[_]");

        }
        /// <summary>
        /// 把最小的时间值==>空对象
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        static public Object getSQLData(DateTime d)
        {
            if (d == DateTime.MinValue) return null;
            return d;
        }

        /// <summary>
        /// Reader的字段对象字符串值
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        static public string ReaderGetString(Object o)
        {
            return Convert.IsDBNull(o) ? "" : Convert.ToString(o);
        }

        /// <summary>
        /// Reader的字段对象字符串值
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        static public int ReaderGetInt32(Object o)
        {
            if (Convert.IsDBNull(o)) return 0;
            return Convert.ToInt32(o);
        }
        //add 2008-4-9 by 倪凤超
        //添加读取的字段为long类型的字符串的值
        static public long ReaderGetLong(Object o)
        {
            if (Convert.IsDBNull(o)) return 0;
            return Convert.ToInt64(o);

        }
        static public int ReaderGetByte(Object o)
        {
            if (Convert.IsDBNull(o)) return 0;
            return Convert.ToInt32(o);
        }

        static public bool IsDBNull(Object o)
        {
            return Convert.IsDBNull(o);

        }

        static public DateTime ReaderGetDateTime(Object o)
        {
            if (Convert.IsDBNull(o)) return DateTime.MinValue;
            return Convert.ToDateTime(o);

        }

        static public bool ReadBool(Object o)
        {
            if (Convert.IsDBNull(o)) return false;
            return Convert.ToBoolean(o);
        }

     
        static public Double ReaderGetDouble(Object o)
        {
            if (Convert.IsDBNull(o)) return 0.0d;
            return Convert.ToDouble(o);
        }

        static public Decimal ReaderGetDecimal(Object o)
        {
            if (Convert.IsDBNull(o)) return 0.0m;
            return Convert.ToDecimal(o);
        }

        public static Guid ReaderGetGuid(object o)
        {
            if (Convert.IsDBNull(o)) return Guid.NewGuid();
            return (Guid)o;
        }

       


    }
}
