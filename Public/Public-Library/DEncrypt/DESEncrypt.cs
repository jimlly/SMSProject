using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Public.DEncrypt
{
    /// <summary>
    /// 提供DES加密/解密服务
    /// </summary>
    public class DESEncrypt
    {
        public DESEncrypt()
        {
        }

        #region ========加密========

        /// <summary>
        
        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text">明文</param> 
        /// <param name="sKey">密钥</param> 
        /// <returns>密文</returns> 
        public static string Encrypt(string Text, string sKey)
        {
            
            DESCryptoServiceProvider des = null;
            StringBuilder ret = null;
            try
            {
                des = new DESCryptoServiceProvider();

                byte[] inputByteArray = Encoding.Default.GetBytes(Text);
                des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
                des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));

                MemoryStream ms = new System.IO.MemoryStream();

                CryptoStream cStream = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                    
                        

                        cStream.Write(inputByteArray, 0, inputByteArray.Length);
                        cStream.FlushFinalBlock();

                        foreach (byte b in ms.ToArray())
                        {
                            ret.AppendFormat("{0:X2}", b);
                        }
                        return ret.ToString();
                    
                
                
                
            }
            finally
            {
               
                ret = null;

                if (des!=null)
                {
                    des.Clear();
                    
                }
            }
           
        }
        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text">明文</param> 
        /// <param name="sKey">密钥</param> 
        /// <param name="iv">对称算法的初始化向量</param>
        /// <returns>密文</returns> 
        public static string Encrypt(string Text, out string key, out string iv)
        {
            key = "";
            iv = "";
            
            DESCryptoServiceProvider des = null;
            StringBuilder ret = null;
            try
            {
                des = new DESCryptoServiceProvider();
                byte[]  inputByteArray = Encoding.Default.GetBytes(Text);
                des.GenerateIV();
                des.GenerateKey();
                iv = new UnicodeEncoding().GetString(des.IV);
                key = new UnicodeEncoding().GetString(des.Key);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                    
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        ret = new StringBuilder();
                        foreach (byte b in ms.ToArray())
                        {
                            ret.AppendFormat("{0:X2}", b);
                        }

                        return ret.ToString();
                    
                
            }
            finally
            {
                ret = null;

                if (des != null)
                {
                    des.Clear();
                }
            }
            
           
        }
        #endregion

        #region ========解密========


       
        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Decrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = null;
            try
            {
                des = new DESCryptoServiceProvider();
                int len = Text.Length / 2;
                byte[] inputByteArray = new byte[len];
                int x, i;

                for (x = 0; x < len; x++)
                {
                    i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                    inputByteArray[x] = (byte)i;
                }
                des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
                des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        return Encoding.Default.GetString(ms.ToArray());
                    }
                
               
            }
            finally
            {
                if (des!=null)
                {
                    des.Clear();
                   
                }
                
            }
           
        }
        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Decrypt(string Text, string key, string iv)
        {
          
            DESCryptoServiceProvider des =null;
            try
            {
                byte[] keyBuffer = new UnicodeEncoding().GetBytes(key);
                byte[] ivBuffer = new UnicodeEncoding().GetBytes(iv);
                            des = new DESCryptoServiceProvider();
                            int len = Text.Length / 2;
                            byte[] inputByteArray = new byte[len];
                            int x, i;
                            for (x = 0; x < len; x++)
                            {
                                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                                inputByteArray[x] = (byte)i;
                            }
                            des.Key = keyBuffer;
                            des.IV = ivBuffer;
                            System.IO.MemoryStream ms = new System.IO.MemoryStream();
                            
                                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                                {
                                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                                    cs.FlushFinalBlock();
                                    return Encoding.Default.GetString(ms.ToArray());
                                }
                            

                            
            }
            finally
            {
                if (des != null)
                {
                    des.Clear();

                }
            }
            
            
        }
        #endregion


    }
}
