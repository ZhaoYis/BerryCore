#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.IBLL.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：IModuleFormInstanceBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.IBLL.AuthorizeManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:37:29
* 更新时间 ：2019-12-17 17:37:29
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Entity.AuthorizeManage;

namespace BerryCore.IBLL.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：IModuleFormInstanceBLL
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:37:29
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:37:29
    /// </summary>
    public interface IModuleFormInstanceBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取一个实体类
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        ModuleFormInstanceEntity GetModuleFormInstanceEntityByObjectId(string objectId);

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 保存一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        int SaveEntity(string keyValue, ModuleFormInstanceEntity entity);

        #endregion 提交数据
    }
}