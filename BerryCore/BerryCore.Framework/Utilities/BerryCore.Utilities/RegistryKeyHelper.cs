#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Utilities
* 项目描述 ：
* 类 名 称 ：RegistryKeyHelper
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Utilities
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/7 23:47:18
* 更新时间 ：2019/5/7 23:47:18
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion


using Microsoft.Win32;

namespace BerryCore.Utilities
{
    /// <summary>
    /// 功能描述    ：注册表操作帮助类  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/7 23:47:18 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/7 23:47:18 
    /// </summary>
    public sealed class RegistryKeyHelper
    {
        /// <summary>
        /// 新增HKCU注册表键值
        /// </summary>
        /// <param name="keyName">键值名</param>
        /// <param name="subKey"></param>
        /// <param name="value">值</param>
        public static void AddCUKeyValue(string subKey, string keyName, object value)
        {
            RegistryKey hklm = Registry.CurrentUser;
            RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
            if (software != null)
            {
                RegistryKey aimdir = software.CreateSubKey(subKey);
                if (aimdir != null)
                {
                    aimdir.SetValue(keyName, value);
                }
            }
        }

        /// <summary>
        /// 编辑HKCU注册表键值
        /// </summary>
        /// <param name="path">路径名</param>
        /// <param name="keyName">键值名</param>
        /// <param name="value">值</param>
        public static void ModifyCUKeyValue(string path, string keyName, object value)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(path, true);
            if (registryKey == null)
            {
                return;
            }
            registryKey.SetValue(keyName, value);
            registryKey.Close();
        }

        /// <summary>
        /// 获取注册表键值
        /// </summary>
        /// <param name="path">路径名</param>
        /// <param name="keyName">键值名</param>
        /// <returns>对应键值</returns>
        public static object GetCUKeyValue(string path, string keyName)
        {
            RegistryKey hklm = Registry.CurrentUser;
            RegistryKey registryKey = hklm.OpenSubKey(path, true);
            return registryKey == null ? null : registryKey.GetValue(keyName);
        }

        /// <summary>
        /// 编辑HKLM注册表键值
        /// </summary>
        /// <param name="path">路径名</param>
        /// <param name="keyName">键值名</param>
        /// <param name="value">值</param>
        public static void ModifyLMKeyValue(string path, string keyName, object value)
        {
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(path, true);
            if (registryKey == null)
            {
                return;
            }
            registryKey.SetValue(keyName, value);
            registryKey.Close();
        }

        /// <summary>
        /// 新增HKLM注册表键值
        /// </summary>
        /// <param name="keyName">键值名</param>
        /// <param name="subKey"></param>
        /// <param name="value">值</param>
        public static void AddLMKeyValue(string subKey, string keyName, object value)
        {
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey software = hklm.OpenSubKey("SOFTWARE", true).OpenSubKey("Microsoft", true);
            RegistryKey aimdir = software.CreateSubKey(subKey);
            aimdir.SetValue(keyName, value);
        }

        /// <summary>
        /// 获取注册表键值
        /// </summary>
        /// <param name="path">路径名</param>
        /// <param name="keyName">键值名</param>
        /// <returns>对应键值</returns>
        public static object GetLMKeyValue(string path, string keyName)
        {
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(path);
            return registryKey == null ? null : registryKey.GetValue(keyName);
        }
    }
}
