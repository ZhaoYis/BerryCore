#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Log
* 项目描述 ：
* 类 名 称 ：BaseLogger
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Log
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/3 22:15:08
* 更新时间 ：2019/5/3 22:15:08
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryCore.Log
{
    /// <summary>
    /// 功能描述    ：BaseLogger  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/3 22:15:08 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/3 22:15:08 
    /// </summary>
    public class BaseLogger : ILogger
    {
        /// <summary>
        /// 利用Action委托封装Log4net对日志的处理
        /// </summary>
        /// <param name="type"></param>
        /// <param name="desc">方法名称（描述）</param>
        /// <param name="tryHandel">调试代码</param>
        /// <param name="catchHandel">异常处理方式</param>
        /// <param name="finallyHandel">最终处理方式</param>
        public void Logger(Type type, string desc, Action tryHandel, Action<Exception> catchHandel = null, Action finallyHandel = null)
        {
            LogHelper.Logger(type, desc, tryHandel, catchHandel, finallyHandel);
        }

        /// <summary>
        /// 记录日志信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="desc"></param>
        /// <param name="level"></param>
        public void Logger(Type type, string desc, LoggerLevel level = LoggerLevel.Info)
        {
            LogHelper.Logger(type, desc, level);
        }
    }
}
