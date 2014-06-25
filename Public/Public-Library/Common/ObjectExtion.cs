
using System;
using System.Collections.Generic;
using System.Linq;

namespace Public.Common
{
    public static class ObjectExtion
    {
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool In<T>(this T t, params T[] args)
        {
            return args.Any(i => i.Equals(t));
        }

        /// <summary>
        /// 是否存在（用于Int类型）
        /// </summary>
        /// <typeparam name="?"></typeparam>
        /// <param name="t"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool In(this int t, IEnumerable<int> args)
        {
            return args.Any<int>(c => c == t);
        }
        /// <summary>
        /// 是否存在（用于string类型）
        /// </summary>
        /// <typeparam name="?"></typeparam>
        /// <param name="t"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool In(this int t, IEnumerable<string> args)
        {
            bool bol = args.Any<string>
                (
                    c =>
                    {
                        var result = c == t.ToString() || c.Contains(t.ToString());

                        return result;

                    }
                );
            return bol;
        }
        /// <summary>
        /// 判断是否为Null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsNull<T>(this T t)
        {
            //if (t.GetType().IsValueType)
            //{
            //    return false;
            //}
            return t == null;
        }

        /// <summary>
        /// 判断不为Null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsNotNull<T>(this T t)
        {
            return !t.IsNull();
        }

        
    }
}
