#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Entity.Base
* 项目描述 ：
* 类 名 称 ：BaseJsonResult
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Entity.Base
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-05 10:37:33
* 更新时间 ：2019-06-05 10:37:33
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using BerryCore.Code;
using System;
using System.Runtime.Serialization;

namespace BerryCore.Entity.Base
{
    /// <summary>
    /// 功能描述    ：标准Json基类 不带分页  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-05 10:37:33 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-05 10:37:33 
    /// </summary>
    [Serializable]
    [DataContract]
    public class BaseJsonResult<TData>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [DataMember]
        public JsonObjectStatus Status { get; set; }

        /// <summary>
        /// 附带数据
        /// </summary>
        [DataMember]
        public TData Data { get; set; }

        /// <summary>
        /// 附带消息
        /// </summary>
        [DataMember]
        public string Message { get; set; }
    }
}
