#region << 版 本 注 释 >>

/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Data.ExMessage
* 项目描述 ：
* 类 名 称 ：CustomException
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Data.ExMessage
* 机器名称 ：MRZHAOYI
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/3 23:01:37
* 更新时间 ：2019/5/3 23:01:37
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/

#endregion << 版 本 注 释 >>

using System;

namespace BerryCore.Data.ExMessage
{
    /// <summary>
    /// 功能描述    ：CustomException
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/3 23:01:37
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/3 23:01:37
    /// </summary>
    public class CustomException : Exception
    {
        /// <summary>
        ///  使用异常消息与一个内部异常实例化一个 类的新实例
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="inner">用于封装在DalException内部的异常实例</param>
        public CustomException(string message, Exception inner)
            : base(message, inner) { }

        /// <summary>
        ///  向调用层抛出数据访问层异常
        /// </summary>
        /// <param name="msg"> 自定义异常消息 </param>
        /// <param name="e"> 实际引发异常的异常实例 </param>
        public static CustomException ThrowBusinessException(Exception e, string msg = "")
        {
            if (!string.IsNullOrEmpty(msg))
            {
                return new CustomException(msg, e);
            }
            return new CustomException("业务逻辑层异常，详情请查看日志信息。", e);
        }

        /// <summary>
        ///  向调用层抛出数据访问层异常
        /// </summary>
        /// <param name="msg"> 自定义异常消息 </param>
        /// <param name="e"> 实际引发异常的异常实例 </param>
        public static CustomException ThrowDataAccessException(Exception e, string msg = "")
        {
            if (!string.IsNullOrEmpty(msg))
            {
                return new CustomException(msg, e);
            }
            return new CustomException("数据访问层异常，详情请查看日志信息。", e);
        }

        /// <summary>
        /// 向调用层抛出组件异常
        /// </summary>
        /// <param name="msg"> 自定义异常消息 </param>
        /// <param name="e"> 实际引发异常的异常实例 </param>
        public static CustomException ThrowComponentException(Exception e, string msg = "")
        {
            if (!string.IsNullOrEmpty(msg))
            {
                return new CustomException(msg, e);
            }
            return new CustomException("组件异常，详情请查看日志信息。", e);
        }
    }
}