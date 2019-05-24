#region << 版 本 注 释 >>
/*
* 项目名称 ：Berry.Util.Encrypt
* 项目描述 ：
* 类 名 称 ：AESEncryptHelper
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：Berry.Util.Encrypt
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-04-18 19:02:30
* 更新时间 ：2019-04-18 19:02:30
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System;
using System.Security.Cryptography;
using System.Text;

namespace BerryCore.Utilities.Encrypt
{
    /// <summary>
    /// 功能描述    ：AES加密、解密
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-04-18 19:02:30 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-04-18 19:02:30 
    /// </summary>
    public class AESEncryptHelper
    {
        /// <summary>
        ///  AES 加密
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string Encrypt(string str, string key)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);

            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        ///  AES 解密
        /// </summary>
        /// <param name="str">待解密字符串</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string Decrypt(string str, string key)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            byte[] toEncryptArray = Convert.FromBase64String(str);

            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Encoding.UTF8.GetString(resultArray);
        }
    }
}
