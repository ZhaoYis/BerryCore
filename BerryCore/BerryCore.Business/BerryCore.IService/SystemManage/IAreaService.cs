#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.IService.SystemManage
* 项目描述 ：
* 类 名 称 ：IAreaService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.IService.SystemManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:02:37
* 更新时间 ：2019-12-17 17:02:37
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Entity.SystemManage;
using System.Collections.Generic;

namespace BerryCore.IService.SystemManage
{
    /// <summary>
    /// 功能描述    ：IAreaService
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:02:37
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:02:37
    /// </summary>
    public interface IAreaService
    {
        #region 获取数据

        /// <summary>
        /// 区域列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<AreaEntity> GetAreaList();

        /// <summary>
        /// 区域列表
        /// </summary>
        /// <param name="parentId">节点Id</param>
        /// <param name="keyword">关键字查询</param>
        /// <returns></returns>
        IEnumerable<AreaEntity> GetAreaList(string parentId, string keyword);

        /// <summary>
        /// 区域实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        AreaEntity GetAreaEntity(string keyValue);

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 删除区域
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveByKey(string keyValue);

        /// <summary>
        /// 保存区域表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="areaEntity">区域实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, AreaEntity areaEntity);

        #endregion 提交数据
    }
}