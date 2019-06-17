#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Entity.Base
* 项目描述 ：
* 类 名 称 ：BaseJsonResult4Page
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Entity.Base
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-05 10:39:08
* 更新时间 ：2019-06-05 10:39:08
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BerryCore.Code;

namespace BerryCore.Entity.Base
{
    /// <summary>
    /// 功能描述    ：标准Json基类 带分页  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-05 10:39:08 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-05 10:39:08 
    /// </summary>
    [Serializable]
    [DataContract]
    public class BaseJsonResult4Page<TData>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [DataMember]
        public JsonObjectStatus Status { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        [DataMember]
        public PageData<TData> Data { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        [DataMember]
        public string Message { get; set; }
    }

    /// <summary>
    /// 分页数据,Rows为实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PageData<T>
    {
        /// <summary>
        /// 总页数
        /// </summary>
        [DataMember]
        public int TotalPage { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        [DataMember]
        public int PageIndex { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        [DataMember]
        public int TotalRow { get; set; }

        /// <summary>
        /// 数据行
        /// </summary>
        [DataMember]
        public List<T> Rows { get; set; }
    }
}
