using BerryCore.BLL.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerryCore.UnitTest
{
    /// <summary>
    /// 基类服务测试
    /// </summary>
    public partial class BaseServiceUnitTest
    {
        /// <summary>
        /// 测试执行T-SQL语句
        /// </summary>
        [TestMethod]
        public void TestMethod_ExecuteBySql()
        {
            string sql = "UPDATE [dbo].[B_Users] SET NAME = '大师兄' WHERE PK = @PK";
            BaseBLL bll = new BaseBLL();

            int count = bll.ExecuteBySql(sql, new { PK = 1 });
            Assert.IsTrue(count > 0);
            Console.WriteLine("执行结果：{0}", count);
        }

    }
}
