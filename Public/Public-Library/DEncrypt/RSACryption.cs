using System;
using System.Text;
using System.Security.Cryptography;


namespace Public.DEncrypt
{
    /// <summary> 
    /// RSA加密解密及RSA签名和验证
    /// </summary> 
    public class RSACryption
    {
        public RSACryption()
        {
        }


        #region RSA 加密解密

        #region RSA 的密钥产生

        /// <summary>
        /// RSA 的密钥产生 产生私钥 和公钥 
        /// </summary>
        /// <param name="xmlKeys"></param>
        /// <param name="xmlPublicKey"></param>
        public void RSAKey(out string xmlKeys, out string xmlPublicKey)
        {
            System.Security.Cryptography.RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            try
            {
                xmlKeys = rsa.ToXmlString(true);
                xmlPublicKey = rsa.ToXmlString(false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (rsa!=null)
                {
                    rsa.Clear();
                }
            }
        }
        #endregion

        #region RSA的加密函数
     
        /// <summary>
        /// RSA方式加密
        /// </summary>
        /// <param name="xmlPublicKey">XML格式Key</param>
        /// <param name="m_strEncryptString">明文</param>
        /// <returns>密文</returns>
        public string RSAEncrypt(string xmlPublicKey, string m_strEncryptString)
        {

            byte[] PlainTextBArray;
            byte[] CypherTextBArray;
            string Result;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            try
            {
                rsa.FromXmlString(xmlPublicKey);
                PlainTextBArray = (new UnicodeEncoding()).GetBytes(m_strEncryptString);
                CypherTextBArray = rsa.Encrypt(PlainTextBArray, false);
                Result = Convert.ToBase64String(CypherTextBArray);
                return Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                rsa.Clear();
            }
           
           

        }
       
        /// <summary>
        /// RSA的加密函数
        /// </summary>
        /// <param name="xmlPublicKey">XML格式Key</param>
        /// <param name="EncryptString">明文</param>
        /// <returns>密文</returns>
        public string RSAEncrypt(string xmlPublicKey, byte[] EncryptString)
        {

            byte[] CypherTextBArray;
            string Result;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            try
            {
              
                rsa.FromXmlString(xmlPublicKey);
                CypherTextBArray = rsa.Encrypt(EncryptString, false);
                Result = Convert.ToBase64String(CypherTextBArray);
                return Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                rsa.Clear();
            }
          

        }
        #endregion

        #region RSA的解密函数
     
       /// <summary>
        /// RSA的解密函数
       /// </summary>
       /// <param name="xmlPrivateKey">XML格式KEY</param>
       /// <param name="m_strDecryptString">密文</param>
       /// <returns>明文</returns>
        public string RSADecrypt(string xmlPrivateKey, string m_strDecryptString)
        {
            byte[] PlainTextBArray;
            byte[] DypherTextBArray;
            string Result;
            System.Security.Cryptography.RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            try
            {
                rsa.FromXmlString(xmlPrivateKey);
                PlainTextBArray = Convert.FromBase64String(m_strDecryptString);
                DypherTextBArray = rsa.Decrypt(PlainTextBArray, false);
                Result = (new UnicodeEncoding()).GetString(DypherTextBArray);
                return Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                rsa.Clear();
            }
           

        }

      
        /// <summary>
        /// RSA的解密函数
        /// </summary>
        /// <param name="xmlPrivateKey">XML格式KEY</param>
        /// <param name="DecryptString">密文</param>
        /// <returns>明文</returns>
        public string RSADecrypt(string xmlPrivateKey, byte[] DecryptString)
        {
            byte[] DypherTextBArray;
            string Result;
            System.Security.Cryptography.RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            try
            {
                rsa.FromXmlString(xmlPrivateKey);
                DypherTextBArray = rsa.Decrypt(DecryptString, false);
                Result = (new UnicodeEncoding()).GetString(DypherTextBArray);
                return Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                rsa.Clear();
            }
         

        }
        #endregion

        #endregion

        #region RSA数字签名

        #region 获取Hash描述表
        
        /// <summary>
        /// 获取Hash描述表 
        /// </summary>
        /// <param name="m_strSource">明文</param>
        /// <param name="HashData">Hash值</param>
        /// <returns>执行结果</returns>
        public bool GetHash(string m_strSource, ref byte[] HashData)
        {
            //从字符串中取得Hash描述 
            byte[] Buffer;
            System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5");
            try
            {
                Buffer = System.Text.Encoding.GetEncoding("GB2312").GetBytes(m_strSource);
                HashData = MD5.ComputeHash(Buffer);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                MD5.Clear();
            }
         
            
            return true;
        }

        /// <summary>
        /// 获取Hash描述表 
        /// </summary>
        /// <param name="m_strSource">明文</param>
        /// <param name="strHashData">Hash字符串</param>
        /// <returns>执行结果</returns>
        public bool GetHash(string m_strSource, ref string strHashData)
        {

            //从字符串中取得Hash描述 
            byte[] Buffer;
            byte[] HashData;
            System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5");
            try
            {
                Buffer = System.Text.Encoding.GetEncoding("GB2312").GetBytes(m_strSource);
                HashData = MD5.ComputeHash(Buffer);

                strHashData = Convert.ToBase64String(HashData);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                MD5.Clear();
            }
         

        }

        /// <summary>
        /// 获取Hash描述表 
        /// </summary>
        /// <param name="objFile">文件流</param>
        /// <param name="HashData">Hash值</param>
        /// <returns>执行结果</returns>
        public bool GetHash(System.IO.FileStream objFile, ref byte[] HashData)
        {

            //从文件中取得Hash描述 
            System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5");
            try
            {
                HashData = MD5.ComputeHash(objFile);
                objFile.Close();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                MD5.Clear();
            }
          

        }

        /// <summary>
        /// 获取Hash描述表
        /// </summary>
        /// <param name="objFile">文件流</param>
        /// <param name="strHashData">Hash字符串</param>
        /// <returns>执行结果</returns>
        public bool GetHash(System.IO.FileStream objFile, ref string strHashData)
        {

            //从文件中取得Hash描述 
            byte[] HashData;
            System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5");
            try
            {
                HashData = MD5.ComputeHash(objFile);
                objFile.Close();

                strHashData = Convert.ToBase64String(HashData);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                MD5.Clear();
            }
           

        }
        #endregion

        #region RSA签名
        /// <summary>
        /// RSA签名
        /// </summary>
        /// <param name="p_strKeyPrivate"></param>
        /// <param name="HashbyteSignature"></param>
        /// <param name="EncryptedSignatureData"></param>
        /// <returns></returns>
 
        public bool SignatureFormatter(string p_strKeyPrivate, byte[] HashbyteSignature, ref byte[] EncryptedSignatureData)
        {

            System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
            try
            {
                RSA.FromXmlString(p_strKeyPrivate);
                System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA);
                //设置签名的算法为MD5 
                RSAFormatter.SetHashAlgorithm("MD5");
                //执行签名 
                EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                RSA.Clear();
            }
           

        }

        /// <summary>
        /// RSA签名 
        /// </summary>
        /// <param name="p_strKeyPrivate"></param>
        /// <param name="HashbyteSignature"></param>
        /// <param name="m_strEncryptedSignatureData"></param>
        /// <returns></returns>
        public bool SignatureFormatter(string p_strKeyPrivate, byte[] HashbyteSignature, ref string m_strEncryptedSignatureData)
        {

            byte[] EncryptedSignatureData;

            System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
            try
            {
                RSA.FromXmlString(p_strKeyPrivate);
                System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA);
                //设置签名的算法为MD5 
                RSAFormatter.SetHashAlgorithm("MD5");
                //执行签名 
                EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature);

                m_strEncryptedSignatureData = Convert.ToBase64String(EncryptedSignatureData);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                RSA.Clear();
            }
           

        }

        //RSA签名 
        public bool SignatureFormatter(string p_strKeyPrivate, string m_strHashbyteSignature, ref byte[] EncryptedSignatureData)
        {

            byte[] HashbyteSignature;

            HashbyteSignature = Convert.FromBase64String(m_strHashbyteSignature);
            System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
            try
            {
                RSA.FromXmlString(p_strKeyPrivate);
                System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA);
                //设置签名的算法为MD5 
                RSAFormatter.SetHashAlgorithm("MD5");
                //执行签名 
                EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                RSA.Clear();
            }
           

        }

        //RSA签名 
        public bool SignatureFormatter(string p_strKeyPrivate, string m_strHashbyteSignature, ref string m_strEncryptedSignatureData)
        {

            byte[] HashbyteSignature;
            byte[] EncryptedSignatureData;

            HashbyteSignature = Convert.FromBase64String(m_strHashbyteSignature);
            System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
            try
            {
                RSA.FromXmlString(p_strKeyPrivate);
                System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA);
                //设置签名的算法为MD5 
                RSAFormatter.SetHashAlgorithm("MD5");
                //执行签名 
                EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature);

                m_strEncryptedSignatureData = Convert.ToBase64String(EncryptedSignatureData);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                RSA.Clear();
            }
          

        }
        #endregion

        #region RSA 签名验证
        /// <summary>
        ///  RSA 签名验证
        /// </summary>
        /// <param name="p_strKeyPublic"></param>
        /// <param name="HashbyteDeformatter"></param>
        /// <param name="DeformatterData"></param>
        /// <returns></returns>
        public bool SignatureDeformatter(string p_strKeyPublic, byte[] HashbyteDeformatter, byte[] DeformatterData)
        {

            System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
            try
            {
                RSA.FromXmlString(p_strKeyPublic);
                System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA);
                //指定解密的时候HASH算法为MD5 
                RSADeformatter.SetHashAlgorithm("MD5");

                if (RSADeformatter.VerifySignature(HashbyteDeformatter, DeformatterData))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                RSA.Clear();
            }
           

        }

        /// <summary>
        ///  RSA 签名验证
        /// </summary>
        /// <param name="p_strKeyPublic"></param>
        /// <param name="p_strHashbyteDeformatter"></param>
        /// <param name="DeformatterData"></param>
        /// <returns></returns>
        public bool SignatureDeformatter(string p_strKeyPublic, string p_strHashbyteDeformatter, byte[] DeformatterData)
        {

            byte[] HashbyteDeformatter;

            HashbyteDeformatter = Convert.FromBase64String(p_strHashbyteDeformatter);

            System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
            try
            {
                RSA.FromXmlString(p_strKeyPublic);
                System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA);
                //指定解密的时候HASH算法为MD5 
                RSADeformatter.SetHashAlgorithm("MD5");

                if (RSADeformatter.VerifySignature(HashbyteDeformatter, DeformatterData))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
            

        }
        /// <summary>
        ///  RSA 签名验证
        /// </summary>
        /// <param name="p_strKeyPublic"></param>
        /// <param name="HashbyteDeformatter"></param>
        /// <param name="p_strDeformatterData"></param>
        /// <returns></returns>
        public bool SignatureDeformatter(string p_strKeyPublic, byte[] HashbyteDeformatter, string p_strDeformatterData)
        {

            byte[] DeformatterData;

            System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
            try
            {
                RSA.FromXmlString(p_strKeyPublic);
                System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA);
                //指定解密的时候HASH算法为MD5 
                RSADeformatter.SetHashAlgorithm("MD5");

                DeformatterData = Convert.FromBase64String(p_strDeformatterData);

                if (RSADeformatter.VerifySignature(HashbyteDeformatter, DeformatterData))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                RSA.Clear();
            }
           

        }

        /// <summary>
        ///  RSA 签名验证
        /// </summary>
        /// <param name="p_strKeyPublic"></param>
        /// <param name="p_strHashbyteDeformatter"></param>
        /// <param name="p_strDeformatterData"></param>
        /// <returns></returns>
        public bool SignatureDeformatter(string p_strKeyPublic, string p_strHashbyteDeformatter, string p_strDeformatterData)
        {

            byte[] DeformatterData;
            byte[] HashbyteDeformatter;

            HashbyteDeformatter = Convert.FromBase64String(p_strHashbyteDeformatter);
            System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
            try
            {
                RSA.FromXmlString(p_strKeyPublic);
                System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA);
                //指定解密的时候HASH算法为MD5 
                RSADeformatter.SetHashAlgorithm("MD5");

                DeformatterData = Convert.FromBase64String(p_strDeformatterData);

                if (RSADeformatter.VerifySignature(HashbyteDeformatter, DeformatterData))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                RSA.Clear();
            }
           

        }


        #endregion


        #endregion

    }
}
