using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyTool
{
    public class MD5Util
    {
        #region MD5加密解密

        /// <summary>

        /// 16位MD5加密

        /// </summary>

        /// <param name="source">需要加密的明文字符串</param>

        /// <returns></returns>

        public static string MD5Encrypt16(string source)

        {

            MD5 md5 = MD5.Create();

            string cipherText =
    BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(source)), 4, 8);

            cipherText = cipherText.Replace("-", "");

            return cipherText;

        }



        /// <summary>

        /// 32位MD5加密

        /// </summary>

        /// <param name="source">需要加密的明文字符串</param>

        /// <returns>32位MD5加密密文字符串</returns>

        public static string MD5Encrypt32(string source)

        {

            string rule = "";

            MD5 md5 = MD5.Create();

            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(source));

            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得

            for (int i = 0; i < s.Length; i++)

            {

                rule = rule + s[i].ToString("x2"); // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 

            }



            return rule;

        }



        /// <summary>

        /// 64位MD5加密

        /// </summary>

        /// <param name="source">需要加密的明文字符串</param>

        /// <returns>64位MD5加密密文字符串</returns>

        public static string MD5Encrypt64(string source)

        {

            MD5 md5 = MD5.Create();

            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(source));



            return Convert.ToBase64String(s);

        }



        /// <summary>

        ///  Md5密钥加密

        /// </summary>

        /// <param name="pToEncrypt">要加密的string字符串</param>

        /// <param name="keys">秘钥</param>

        /// <returns></returns>

        public static string Md5Encrypt_Key(string pToEncrypt, string keys)

        {

            var des = DES.Create();

            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);



            if (keys.Length != 8)

            {

                return "key必须为8位";

            }



            des.Key = Encoding.ASCII.GetBytes(keys);

            des.IV = Encoding.ASCII.GetBytes(keys);

            MemoryStream ms = new MemoryStream();

            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(),
    CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);

            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();

            foreach (byte b in ms.ToArray())

            {

                ret.AppendFormat("{0:X2}", b);

            }

            var s = ret.ToString();



            return s;

        }



        /// <summary>

        ///  Md5解密

        /// </summary>

        /// <param name="pToDecrypt">解密string</param>

        /// <param name="keys">秘钥</param>

        /// <returns></returns>

        public static string Md5Decrypt(string pToDecrypt, string keys)

        {

            var des = DES.Create();

            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];

            for (int x = 0; x < pToDecrypt.Length / 2; x++)

            {

                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));

                inputByteArray[x] = (byte)i;

            }

            des.Key = Encoding.ASCII.GetBytes(keys);

            des.IV = Encoding.ASCII.GetBytes(keys);

            MemoryStream ms = new MemoryStream();

            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(),
    CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);

            try

            {

                cs.FlushFinalBlock();

            }

            catch (Exception)

            {

                return "无效秘钥";

            }



            return Encoding.Default.GetString(ms.ToArray());

        }



        /// <summary>

        /// MD5流加密

        /// </summary>

        /// <param name="inputStream">输入流</param>

        /// <returns></returns>

        public static string GenerateMD5(Stream inputStream)

        {

            using (MD5 mi = MD5.Create())

            {

                byte[] newBuffer = mi.ComputeHash(inputStream);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < newBuffer.Length; i++)

                {

                    sb.Append(newBuffer[i].ToString("x2"));

                }

                return sb.ToString();
            }

        }

        #endregion
    }
}
