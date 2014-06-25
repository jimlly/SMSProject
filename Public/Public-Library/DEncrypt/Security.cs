using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Public.DEncrypt
{
    public class Security
    {
        public static byte[] DESKey = new byte[] { 0x82, 0xBC, 0xA1, 0x6A, 0xF5, 0x87, 0x3B, 0xE6, 0x59, 0x6A, 0x32, 0x64, 0x7F, 0x3A, 0x2A, 0xBB, 0x2B, 0x68, 0xE2, 0x5F, 0x06, 0xFB, 0xB8, 0x2D, 0x67, 0xB3, 0x55, 0x19, 0x4E, 0xB8, 0xBF, 0xDD };
        /// <summary>
        /// 字符串倒置函数
        /// </summary>
        /// <param name="s">原字符串</param>
        /// <returns>倒置后的字符串</returns>
        public static string Reverse(string s)
        {
            //Char[] arrChar = new Char(s);
            Char[] arrChar = s.ToCharArray();
            string sRte = "";
            for (int i = arrChar.Length - 1; i > -1; i--)
            {
                sRte = sRte + arrChar[i].ToString();
            }
            return sRte;
        }
        public static string base64decode(string str)
        {//解密
            int c1, c2, c3, c4;
            int i, len;
            string Out;
            int[] base64DecodeChars = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 62, -1, -1, -1, 63, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, -1, -1, -1, -1, -1, -1, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, -1, -1, -1, -1, -1, -1, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, -1, -1, -1, -1, -1 };//对应ASICC字符的位置

            len = str.Length;
            i = 0; Out = "";
            while (i < len)
            {
                do
                {
                    c1 = base64DecodeChars[str[i++] & 0xff];
                } while (i < len && c1 == -1);
                if (c1 == -1) break;
                do
                {
                    c2 = base64DecodeChars[str[i++] & 0xff];
                } while (i < len && c2 == -1);
                if (c2 == -1) break;
                Out += (char)((c1 << 2) | ((c2 & 0x30) >> 4));
                do
                {
                    c3 = str[i++] & 0xff;
                    if (c3 == 61) return Out;
                    c3 = base64DecodeChars[c3];
                } while (i < len && c3 == -1);
                if (c3 == -1) break;
                Out += (char)(((c2 & 0XF) << 4) | ((c3 & 0x3C) >> 2));
                do
                {
                    c4 = str[i++] & 0xff;
                    if (c4 == 61) return Out;
                    c4 = base64DecodeChars[c4];
                } while (i < len && c4 == -1);
                if (c4 == -1) break;
                Out += (char)(((c3 & 0x03) << 6) | c4);
            }
            return Out;
        }
        public static string base64encode(string str)
        { //加密
            string base64EncodeChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";//编码后的字符集

            string Out = "";
            int i = 0, len = str.Length;
            char c1, c2, c3;
            while (i < len)
            {
                c1 = Convert.ToChar(str[i++] & 0xff);
                if (i == len)
                {
                    Out += base64EncodeChars[c1 >> 2];
                    Out += base64EncodeChars[(c1 & 0x3) << 4];
                    Out += "==";
                    break;
                }
                c2 = str[i++];
                if (i == len)
                {
                    Out += base64EncodeChars[c1 >> 2];
                    Out += base64EncodeChars[((c1 & 0x3) << 4) | ((c2 & 0xF0) >> 4)];
                    Out += base64EncodeChars[(c2 & 0xF) << 2];
                    Out += "=";
                    break;
                }
                c3 = str[i++];
                Out += base64EncodeChars[c1 >> 2];
                Out += base64EncodeChars[((c1 & 0x3) << 4) | ((c2 & 0xF0) >> 4)];
                Out += base64EncodeChars[((c2 & 0xF) << 2) | ((c3 & 0xC0) >> 6)];
                Out += base64EncodeChars[c3 & 0x3F];
            }
            return Out;
        }
        public static string Md5To32(string str)
        {
            string pwd = "";
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            for (int i = 0; i < s.Length; i++)
            {
                pwd = pwd + s[i].ToString("X");
            }
            return pwd;
        }
        #region   简单加密 解密

        public static string SetKey(string str)
        {
            str = EncodingSMS(str);
            string setkey = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(str)).Replace("+", "%2Bwcg");
            return setkey;
        }
        public static string GetKey(string str)
        {

            string getkey = System.Text.Encoding.Default.GetString(Convert.FromBase64String(str.Replace("%2Bwcg", "+")));
            getkey = DecodingSMS(getkey);
            return getkey;

        }


        /// <summary>
        /// 加码函数
        /// </summary>
        /// <param name="s">加码前</param>
        /// <returns>加码后</returns>
        public static string EncodingSMS(string s)
        {
            string result = string.Empty;

            byte[] arrByte = System.Text.Encoding.GetEncoding("GB2312").GetBytes(s);
            for (int i = 0; i < arrByte.Length; i++)
            {
                result += System.Convert.ToString(arrByte[i], 16);        //Convert.ToString(byte, 16)把byte转化成十六进制string 
            }

            return result;
        }
        /// <summary>
        /// 解码函数
        /// </summary>
        /// <param name="s">解码前</param>
        /// <returns>解码后</returns>
        public static string DecodingSMS(string s)
        {
            string result = string.Empty;

            byte[] arrByte = new byte[s.Length / 2];
            int index = 0;
            for (int i = 0; i < s.Length; i += 2)
            {
                arrByte[index++] = Convert.ToByte(s.Substring(i, 2), 16);        //Convert.ToByte(string,16)把十六进制string转化成byte 
            }
            result = System.Text.Encoding.Default.GetString(arrByte);

            return result;

        }

        #endregion
        #region DES加密解密
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="strSource">待加密字串</param>
        /// <param name="key">32位Key值</param>
        /// <returns>加密后的字符串</returns>
        public static string DESEncrypt(string strSource)
        {
            return DESEncrypt(strSource, DESKey);
        }
        public static string DESEncrypt(string strSource, byte[] key)
        {
            SymmetricAlgorithm sa = Rijndael.Create();
            sa.Key = key;
            sa.Mode = CipherMode.ECB;
            sa.Padding = PaddingMode.Zeros;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, sa.CreateEncryptor(), CryptoStreamMode.Write);
            byte[] byt = Encoding.Unicode.GetBytes(strSource);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="strSource">待解密的字串</param>
        /// <param name="key">32位Key值</param>
        /// <returns>解密后的字符串</returns>
        public static string DESDecrypt(string strSource)
        {
            return DESDecrypt(strSource, DESKey);
        }
        public static string DESDecrypt(string strSource, byte[] key)
        {
            SymmetricAlgorithm sa = Rijndael.Create();
            sa.Key = key;
            sa.Mode = CipherMode.ECB;
            sa.Padding = PaddingMode.Zeros;
            ICryptoTransform ct = sa.CreateDecryptor();
            byte[] byt = Convert.FromBase64String(strSource);
            MemoryStream ms = new MemoryStream(byt);
            CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs, Encoding.Unicode);
            return sr.ReadToEnd();
        }
        #endregion
    }
}
