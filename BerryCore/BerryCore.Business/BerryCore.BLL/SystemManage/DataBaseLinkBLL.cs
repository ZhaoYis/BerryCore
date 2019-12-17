#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.BLL.SystemManage
* 项目描述 ：
* 类 名 称 ：DataBaseLinkBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.BLL.SystemManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 18:33:34
* 更新时间 ：2019-12-17 18:33:34
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BerryCore.Entity.SystemManage;
using BerryCore.IBLL.SystemManage;
using BerryCore.IService.SystemManage;
using BerryCore.Service.SystemManage;

namespace BerryCore.BLL.SystemManage
{
    /// <summary>
    /// 功能描述    ：DataBaseLinkBLL  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 18:33:34 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 18:33:34 
    /// </summary>
    public class DataBaseLinkBLL : IDataBaseLinkBLL
    {
        private readonly IDataBaseLinkService service = new DataBaseLinkService();

        /// <summary>
        /// 库连接列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataBaseLinkEntity> GetDataBaseLinkList()
        {
            return service.GetDataBaseLinkList();
        }

        /// <summary>
        /// 库连接实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataBaseLinkEntity GetDataBaseLinkEntity(string keyValue)
        {
            return service.GetDataBaseLinkEntity(keyValue);
        }

        /// <summary>
        /// 删除库连接
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveByKey(string keyValue)
        {
            service.RemoveByKey(keyValue);
        }

        /// <summary>
        /// 保存库连接表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="databaseLinkEntity">库连接实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, DataBaseLinkEntity databaseLinkEntity)
        {
            #region 测试连接数据库

            DbConnection dbConnection = null;
            string serverAddress = "";
            switch (databaseLinkEntity.DbType)
            {
                case "SqlServer":
                    dbConnection = new SqlConnection(databaseLinkEntity.DbConnection);
                    serverAddress = dbConnection.DataSource;
                    break;

                default:
                    break;
            }
            if (dbConnection != null) dbConnection.Close();
            databaseLinkEntity.ServerAddress = serverAddress;

            #endregion 测试连接数据库

            service.SaveForm(keyValue, databaseLinkEntity);
        }
    }
}
