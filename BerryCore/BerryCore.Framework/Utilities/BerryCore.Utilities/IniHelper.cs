#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Utilities
* 项目描述 ：
* 类 名 称 ：IniHelper
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Utilities
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/7 23:44:03
* 更新时间 ：2019/5/7 23:44:03
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BerryCore.Utilities
{
    /// <summary>
    /// 功能描述    ：Ini文件操作帮助类
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/7 23:44:03 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/7 23:44:03 
    /// </summary>
    public sealed class IniHelper
    {
        /// <summary>
        /// 读
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern long GetString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 写
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32", EntryPoint = "WritePrivateProfileString")]
        private static extern long WrtieString(string section, string key, string val, string filePath);

        /// <summary>
        /// 查询所有区域名称或区域内所有key
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, byte[] lpReturnedString, uint nSize, string lpFileName);

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="kSection">节</param>
        /// <param name="kKey">键</param>
        /// <param name="kValue">默认值</param>
        /// <param name="kFtpCommitLogPath">文档绝对路径</param>
        /// <returns></returns>
        public static string IniRead(string kSection, string kKey, string kValue, string kFtpCommitLogPath)
        {
            int size = 1024;
            StringBuilder temp = new StringBuilder(size);
            GetString(kSection, kKey, kValue, temp, size, kFtpCommitLogPath);
            return temp.ToString();
        }

        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="kSection">节</param>
        /// <param name="kKey">键</param>
        /// <param name="kValue">值</param>
        /// <param name="kFtpCommitLogPath">文档绝对路径</param>
        public static void IniWrite(string kSection, string kKey, string kValue, string kFtpCommitLogPath)
        {
            WrtieString(kSection, kKey, kValue, kFtpCommitLogPath);
        }

        /// <summary>
        /// 读取section
        /// </summary>
        /// <param name="iniFilename"></param>
        /// <returns></returns>
        public static List<string> ReadSections(string iniFilename)
        {
            List<string> result = new List<string>();
            byte[] buf = new byte[65536];
            uint len = GetPrivateProfileString(null, null, null, buf, (uint)buf.Length, iniFilename);
            int j = 0;
            for (int i = 0; i < len; i++)
            {
                if (buf[i] == 0)
                {
                    result.Add(Encoding.Default.GetString(buf, j, i - j));
                    j = i + 1;
                }
            }
            return result;
        }

        /// <summary>
        /// 读取指定区域Keys列表。
        /// </summary>
        /// <param name="section"></param>
        /// <param name="iniFilename"></param>
        /// <returns></returns>
        public static List<string> ReadSingleSection(string section, string iniFilename)
        {
            List<string> result = new List<string>();
            byte[] buf = new byte[65536];
            uint lenf = GetPrivateProfileString(section, null, null, buf, (uint)buf.Length, iniFilename);
            int j = 0;
            for (int i = 0; i < lenf; i++)
            {
                if (buf[i] == 0)
                {
                    result.Add(Encoding.Default.GetString(buf, j, i - j));
                    j = i + 1;
                }
            }
            return result;
        }
    }
}
