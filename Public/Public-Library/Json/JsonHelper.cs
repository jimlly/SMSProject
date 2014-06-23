using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Jayrock.Json.Conversion;
using Formatting = System.Xml.Formatting;


namespace Public.Json
{
    /// <summary>
    /// Json工具类
    /// </summary>
    public static class JsonHelper
    {

        private static Newtonsoft.Json.JsonSerializerSettings _jsonSettings;

        static JsonHelper()
        {
            Newtonsoft.Json.Converters.IsoDateTimeConverter datetimeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            datetimeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

            _jsonSettings = new Newtonsoft.Json.JsonSerializerSettings();
            _jsonSettings.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
            _jsonSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            _jsonSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            _jsonSettings.Converters.Add(datetimeConverter);
        }

        ///// <summary>  
        /// 将指定的对象序列化成 JSON 数据。  
        /// </summary>  
        /// <param name="obj">要序列化的对象。</param>  
        /// <returns></returns>  
        public static string SerObjectNft(object obj)
        {
            try
            {
                if (null == obj)
                    return null;

                return Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.None, _jsonSettings);
            }
            catch (Exception ex)
            {

                return "";
            }
        }

        /// <summary>  
        /// 将指定的 JSON 数据反序列化成指定对象。  
        /// </summary>  
        /// <typeparam name="T">对象类型。</typeparam>  
        /// <param name="json">JSON 数据。</param>  
        /// <returns></returns>  
        public static T DesObjectNft<T>( string json)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json, _jsonSettings);
            }
            catch (Exception ex)
            {

                return default(T);
            }
        }



        /// <summary>
        /// 序列化对象成json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObject(object obj)
        {
            var sb = new StringBuilder();
            JsonConvert.Export(obj, sb);
            return sb.ToString();
        }

        /// <summary>
        /// 反序列化json成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string json)
        {
            return JsonConvert.Import<T>(json);
        }


    //    /// <summary>
    //     /// 将指定的对象序列化成 JSON 数据。
    //    /// </summary>
    //    /// <param name="obj">实体对象</param>
    //    /// <returns>Json</returns>
    //    public static string GetJsonFromObject(object obj)
    //    {
    //        string str;
    //        StringBuilder builder = new StringBuilder();
    //        builder.Append("{");
    //        Type type = obj.GetType();
    //        PropertyInfo property = type.GetProperty("Values");
    //        PropertyInfo info2 = type.GetProperty("Keys");
    //        if ((property != null) || (info2 != null))
    //        {
    //            ICollection is2 = (ICollection)property.GetValue(obj, null);
    //            ICollection is3 = (ICollection)info2.GetValue(obj, null);
    //            str = string.Empty;
    //            List<string> list = new List<string>();
    //            foreach (object obj2 in is3)
    //            {
    //                list.Add(obj2.ToString());
    //            }
    //            int num = 0;
    //            str = string.Empty;
    //            foreach (object obj2 in is2)
    //            {
    //                Type type2 = obj2.GetType();
    //                if (((type2.ToString() == "System.String") || (type2.ToString() == "System.Int32")) || (type2.ToString() == "System.Boolean"))
    //                {
    //                    if (obj2 is string)
    //                    {
    //                        str = str + ",\"" + list[num] + "\":\"" + obj2.ToString().Replace(@"\", @"\\").Replace("\"", "\\\"").Replace("\n", @"\n").Replace("\r", @"\r") + "\"";
    //                    }
    //                    else
    //                    {
    //                        str = str + ",\"" + list[num] + "\":" + obj2.ToString();
    //                    }
    //                }
    //                else
    //                {
    //                    str = str + ",\"" + list[num] + "\":{" + ObjToJson(obj2) + "}";
    //                }
    //                num++;
    //            }
    //            if (str.Length > 0)
    //            {
    //                str = str.Substring(1);
    //                builder.Append(str);
    //            }
    //        }
    //        else
    //        {
    //            str = string.Empty;
    //            if ((obj is int) || (obj is bool))
    //            {
    //                str = str + ",\"" + type.Name + "\":" + obj.ToString();
    //            }
    //            else if (obj is string)
    //            {
    //                str = str + ",\"" + type.Name + "\":\"" + obj.ToString().Replace(@"\", @"\\").Replace("\"", "\\\"").Replace("\n", @"\n").Replace("\r", @"\r") + "\"";
    //            }
    //            else
    //            {
    //                foreach (PropertyInfo info3 in type.GetProperties())
    //                {
    //                    object obj3 = info3.GetValue(obj, null);
    //                    Type type3 = obj3.GetType();
    //                    if ((obj3 is int) || (obj3 is bool))
    //                    {
    //                        str = str + ",\"" + info3.Name + "\":" + obj3.ToString();
    //                    }
    //                    else if (obj3 is string)
    //                    {
    //                        str = str + ",\"" + info3.Name + "\":\"" + obj3.ToString().Replace(@"\", @"\\").Replace("\"", "\\\"").Replace("\n", @"\n").Replace("\r", @"\r") + "\"";
    //                    }
    //                    else
    //                    {
    //                        str = str + ",\"" + info3.Name + "\":{" + ObjToJson(obj3) + "}";
    //                    }
    //                }
    //            }
    //            if (str.Length > 0)
    //            {
    //                builder.Append(str.Substring(1));
    //            }
    //        }
    //        builder.Append("}");
    //        return builder.ToString();
    //    }

    //    /// <summary>
    //    /// 实体类转换Json
    //    /// </summary>
    //    /// <param name="obj">实体对象</param>
    //    /// <returns>Json</returns>
    //    private static string ObjToJson(object obj)
    //    {
    //        string str;
    //        Type type = obj.GetType();
    //        string str2 = string.Empty;
    //        PropertyInfo property = type.GetProperty("Values");
    //        PropertyInfo info2 = type.GetProperty("Keys");
    //        if ((property != null) && (info2 != null))
    //        {
    //            ICollection is2 = (ICollection)info2.GetValue(obj, null);
    //            ICollection is3 = (ICollection)property.GetValue(obj, null);
    //            str = string.Empty;
    //            List<string> list = new List<string>();
    //            foreach (object obj2 in is2)
    //            {
    //                list.Add(obj2.ToString());
    //            }
    //            int num = 0;
    //            str = string.Empty;
    //            foreach (object obj2 in is3)
    //            {
    //                Type type2 = obj2.GetType();
    //                if (((type2.ToString() == "System.String") || (type2.ToString() == "System.Int32")) || (type2.ToString() == "System.Boolean"))
    //                {
    //                    if (obj2 is string)
    //                    {
    //                        str = str + ",\"" + list[num] + "\":\"" + obj2.ToString().Replace(@"\", @"\\").Replace("\"", "\\\"").Replace("\n", @"\n").Replace("\r", @"\r") + "\"";
    //                    }
    //                    else
    //                    {
    //                        str = str + ",\"" + list[num] + "\":" + obj2.ToString();
    //                    }
    //                }
    //                else
    //                {
    //                    str = str + ",\"" + list[num] + "\":{" + ObjToJson(obj2) + "}";
    //                }
    //                num++;
    //            }
    //            if (str.Length > 0)
    //            {
    //                str = str.Substring(1);
    //                str2 = str2 + str;
    //            }
    //            return str2;
    //        }
    //        str = string.Empty;
    //        if ((obj is int) || (obj is bool))
    //        {
    //            str = str + ",\"" + type.Name + "\":" + obj.ToString();
    //        }
    //        else if (obj is string)
    //        {
    //            str = str + ",\"" + type.Name + "\":\"" + obj.ToString().Replace(@"\", @"\\").Replace("\"", "\\\"").Replace("\n", @"\n").Replace("\r", @"\r") + "\"";
    //        }
    //        else
    //        {
    //            foreach (PropertyInfo info3 in type.GetProperties())
    //            {
    //                object obj3 = info3.GetValue(obj, null);
    //                Type type3 = obj3.GetType();
    //                if ((obj3 is int) || (obj3 is bool))
    //                {
    //                    str = str + ",\"" + info3.Name + "\":" + obj3.ToString();
    //                }
    //                else if (obj3 is string)
    //                {
    //                    str = str + ",\"" + info3.Name + "\":\"" + obj3.ToString().Replace(@"\", @"\\").Replace("\"", "\\\"").Replace("\n", @"\n").Replace("\r", @"\r") + "\"";
    //                }
    //                else
    //                {
    //                    str = str + ",\"" + info3.Name + "\":{" + ObjToJson(obj3) + "}";
    //                }
    //            }
    //        }
    //        if (str.Length > 0)
    //        {
    //            str2 = str2 + str.Substring(1);
    //        }
    //        return str2;
    //    }



    }
}
