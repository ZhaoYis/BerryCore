#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Utilities
* 项目描述 ：
* 类 名 称 ：Md5Helper
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Utilities
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/7 23:32:06
* 更新时间 ：2019/5/7 23:32:06
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System.Security.Cryptography;
using System.Text;

namespace BerryCore.Utilities
{
    /// <summary>
    /// 功能描述    ：MD5帮助类  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/7 23:32:06 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/7 23:32:06 
    /// </summary>
    public static class Md5Helper
    {
        /// <summary>
        /// 对字符串进行MD5计算
        /// </summary>
        /// <param name="source">加密字符</param>
        /// <param name="len">加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位</param>
        /// <returns></returns>
        public static string Md5(string source, string len = "x2")
        {
            if (string.IsNullOrEmpty(source))
            {
                return "";
            }

            byte[] sor = Encoding.UTF8.GetBytes(source);
            MD5 md5 = new MD5CryptoServiceProvider();//MD5.Create();
            byte[] result = md5.ComputeHash(sor);

            StringBuilder builder = new StringBuilder();
            foreach (byte s in result)
            {
                builder.Append(s.ToString(len));//加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位
            }
            return builder.ToString();
        }
    }
}
