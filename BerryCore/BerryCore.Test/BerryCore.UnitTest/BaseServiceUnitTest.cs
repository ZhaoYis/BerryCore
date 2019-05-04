using BerryCore.BLL.Base;
using BerryCore.Entity.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerryCore.UnitTest
{
    /// <summary>
    /// 基类服务测试
    /// </summary>
    [TestClass]
    public class BaseServiceUnitTest
    {
        /// <summary>
        /// 测试执行T-SQL语句
        /// </summary>
        [TestMethod]
        public void TestMethod_ExecuteBySql_T()
        {
            string sql = "UPDATE [dbo].[B_Users] SET NAME = '大师兄' WHERE PK = 1";
            BaseBLL<UserEntity> bll = new BaseBLL<UserEntity>();

            int count = bll.ExecuteBySql(sql);
            Assert.IsTrue(count > 0);
            Console.WriteLine("执行结果：{0}", count);
        }

        /// <summary>
        /// 测试执行T-SQL语句
        /// </summary>
        [TestMethod]
        public void TestMethod_ExecuteBySql()
        {
            string sql = "UPDATE [dbo].[B_Users] SET NAME = '大师兄' WHERE PK = 1";
            BaseBLL bll = new BaseBLL();

            int count = bll.ExecuteBySql(sql);
            Assert.IsTrue(count > 0);
            Console.WriteLine("执行结果：{0}", count);
        }
    }
}
