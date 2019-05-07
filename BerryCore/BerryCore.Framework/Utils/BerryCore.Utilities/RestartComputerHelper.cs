#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Utilities
* 项目描述 ：
* 类 名 称 ：RestartComputerHelper
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Utilities
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/7 23:48:38
* 更新时间 ：2019/5/7 23:48:38
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BerryCore.Utilities
{
    /// <summary>
    /// 功能描述    ：重启计算机  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/7 23:48:38 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/7 23:48:38 
    /// </summary>
    public sealed class RestartComputerHelper
    {
        private const int SE_PRIVILEGE_ENABLED = 0x00000002;

        private const int TOKEN_QUERY = 0x00000008;

        private const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;

        private const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";

        private const int EWX_LOGOFF = 0x00000000;

        private const int EWX_SHUTDOWN = 0x00000001;

        private const int EWX_REBOOT = 0x00000002;

        private const int EWX_FORCE = 0x00000004;

        private const int EWX_POWEROFF = 0x00000008;

        private const int EWX_FORCEIFHUNG = 0x00000010;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool ExitWindowsEx(int flg, int rea);

        /// <summary>
        /// 重启电脑
        /// </summary>
        public static void Restart()
        {
            try
            {
                TokPriv1Luid tp;
                IntPtr hproc = GetCurrentProcess();
                IntPtr htok = IntPtr.Zero;
                bool ok = OpenProcessToken(hproc, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok);
                tp.Count = 1;
                tp.Luid = 0;
                tp.Attr = SE_PRIVILEGE_ENABLED;
                ok = LookupPrivilegeValue(null, SE_SHUTDOWN_NAME, ref tp.Luid);
                ok = AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);
                ok = ExitWindowsEx(EWX_REBOOT | EWX_FORCE, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
