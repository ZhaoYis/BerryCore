#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.IBLL.SystemManage
* 项目描述 ：
* 类 名 称 ：IDataBaseLinkBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.IBLL.SystemManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:33:20
* 更新时间 ：2019-12-17 17:33:20
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Entity.SystemManage;
using System.Collections.Generic;

namespace BerryCore.IBLL.SystemManage
{
    /// <summary>
    /// 功能描述    ：IDataBaseLinkBLL
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:33:20
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:33:20
    /// </summary>
    public interface IDataBaseLinkBLL
    {
        #region 获取数据

        /// <summary>
        /// 库连接列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<DataBaseLinkEntity> GetDataBaseLinkList();

        /// <summary>
        /// 库连接实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        DataBaseLinkEntity GetDataBaseLinkEntity(string keyValue);

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 删除库连接
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveByKey(string keyValue);

        /// <summary>
        /// 保存库连接表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="databaseLinkEntity">库连接实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, DataBaseLinkEntity databaseLinkEntity);

        #endregion 提交数据
    }
}