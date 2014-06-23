using System;
using System.Text;
using System.Security.Cryptography;

namespace Public.DEncrypt
{
    /// <summary>
    ///哈希加密 
    /// </summary>
    public class HashEncode
    {
        public HashEncode()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 得到随机哈希加密字符串
        /// </summary>
        /// <returns></returns>
        public static string GetSecurity()
        {
            string Security = HashEncoding(GetRandomValue());
            return Security;
        }
        /// <summary>
        /// 得到一个随机数值
        /// </summary>
        /// <returns></returns>
        public static string GetRandomValue()
        {
            Random Seed = new Random();
            string RandomVaule = Seed.Next(1, int.MaxValue).ToString();
            return RandomVaule;
        }
        /// <summary>
        /// 哈希加密一个字符串
        /// </summary>
        /// <param name="Security"></param>
        /// <returns></returns>
        public static string HashEncoding(string Security)
        {
            byte[] Value;
            SHA512Managed Arithmetic = null;
            try
            {
                UnicodeEncoding Code = new UnicodeEncoding();
                byte[] Message = Code.GetBytes(Security);

                Arithmetic = new SHA512Managed();
                Value = Arithmetic.ComputeHash(Message);
                Security = "";
                foreach (byte o in Value)
                {
                    Security += (int)o + "O";
                }

                return Security;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (Arithmetic!=null)
                {
                    Arithmetic.Clear();
                }
            }
           
        }
    }
}
