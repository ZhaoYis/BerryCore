#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Utilities
* 项目描述 ：
* 类 名 称 ：CommonHelper
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Utilities
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/4 8:38:32
* 更新时间 ：2019/5/4 8:38:32
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Runtime.InteropServices;

namespace BerryCore.Utilities
{
    /// <summary>
    /// 功能描述    ：全局公用帮助类  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/4 8:38:32 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/4 8:38:32 
    /// </summary>
    public static class CommonHelper
    {
        #region 获取全局唯一GUID

        /// <summary>
        /// 获取全局唯一GUID
        /// </summary>
        /// <param name="needReplace">是否需要替换-</param>
        /// <param name="format">格式化</param>
        /// <example>N：38bddf48f43c48588e0d78761eaa1ce6</example>>
        /// <example>P：(778406c2-efff-4262-ab03-70a77d09c2b5)</example>>
        /// <example>B：{09f140d5-af72-44ba-a763-c861304b46f8}</example>>
        /// <example>D：57d99d89-caab-482a-a0e9-a0a803eed3ba</example>>
        /// <returns></returns>
        public static string GetGuid(bool needReplace = true, string format = "N")
        {
            Guid res = NewSequentialGuid();//Guid.NewGuid();

            return needReplace ? res.ToString(format) : res.ToString();
        }

        [DllImport("rpcrt4.dll", SetLastError = true)]
        static extern int UuidCreateSequential(byte[] buffer);
        /// <summary>
        /// 创建有序GUID
        /// </summary>
        /// <returns></returns>
        private static Guid NewSequentialGuid()
        {
            byte[] raw = new byte[16];
            if (UuidCreateSequential(raw) != 0)
            {
                throw new System.ComponentModel.Win32Exception(System.Runtime.InteropServices.Marshal.GetLastWin32Error());
            }

            byte[] fix = new byte[16];

            // 反转 0..3
            fix[0x0] = raw[0x3];
            fix[0x1] = raw[0x2];
            fix[0x2] = raw[0x1];
            fix[0x3] = raw[0x0];

            // 反转 4 & 5
            fix[0x4] = raw[0x5];
            fix[0x5] = raw[0x4];

            // 反转 6 & 7
            fix[0x6] = raw[0x7];
            fix[0x7] = raw[0x6];

            // 后8位不做操作，实际为当前MAC地址
            fix[0x8] = raw[0x8];
            fix[0x9] = raw[0x9];
            fix[0xA] = raw[0xA];
            fix[0xB] = raw[0xB];
            fix[0xC] = raw[0xC];
            fix[0xD] = raw[0xD];
            fix[0xE] = raw[0xE];
            fix[0xF] = raw[0xF];

            return new Guid(fix);
        }

        #endregion 获取全局唯一GUID

        #region 检测本机是否联网

        [DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int connectionDescription, int reservedValue);
        /// <summary> 
        /// 检测本机是否联网 
        /// </summary> 
        /// <returns></returns> 
        public static bool IsConnectedInternet()
        {
            return InternetGetConnectedState(out _, 0);
        }

        #endregion
    }
}
