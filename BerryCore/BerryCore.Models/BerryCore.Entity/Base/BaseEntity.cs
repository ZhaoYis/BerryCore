#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Entity.Base
* 项目描述 ：
* 类 名 称 ：BaseEntity
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Entity.Base
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/4 8:36:25
* 更新时间 ：2019/5/4 8:36:25
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using BerryCore.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerryCore.Entity.Base
{
    /// <summary>
    /// 功能描述    ：实体基类  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/4 8:36:25 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/4 8:36:25 
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// PK
        /// </summary>
        [NotMapped]
        protected virtual int PK { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        protected virtual string Id { get; set; }

        #region 扩展操作方法

        /// <summary>
        /// 新增调用
        /// </summary>
        protected virtual void Create()
        {
            this.Id = CommonHelper.GetGuid();
        }

        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="id">主键值</param>
        protected virtual void Modify(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// 查重
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        protected virtual bool DuplicateChecking(Func<bool> func)
        {
            return func.Invoke();
        }

        #endregion

    }
}
