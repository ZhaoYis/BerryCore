using BerryCore.BLL.Base;
using BerryCore.Entity.Test;
using BerryCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BerryCore.UnitTest
{
    /// <summary>
    /// 基类服务测试
    /// </summary>
    [TestClass]
    public partial class BaseServiceUnitTest
    {
        /// <summary>
        /// 测试执行T-SQL语句
        /// </summary>
        [TestMethod]
        public void TestMethod_ExecuteBySql_T()
        {
            string sql = "UPDATE [dbo].[B_Users] SET NAME = '大师兄' WHERE PK = @PK";
            BaseBLL<UserEntity> bll = new BaseBLL<UserEntity>();

            int count = bll.ExecuteBySql(sql, new { PK = 1 });
            Assert.IsTrue(count > 0);
            Console.WriteLine("执行结果：{0}", count);
        }

        /// <summary>
        /// 测试执行 SQL 语句返回集合
        /// </summary>
        [TestMethod]
        public void TestMethod_ExecuteBySqlAndReturnList_T()
        {
            string sql = "SELECT * FROM dbo.B_Users WHERE PK <> @PK";
            BaseBLL<UserEntity> bll = new BaseBLL<UserEntity>();

            IEnumerable<UserEntity> userEntities = bll.ExecuteBySqlAndReturnList<UserEntity>(sql, new { PK = 0 });
            Assert.IsTrue(userEntities.Any());

            Console.WriteLine("获取到{0}条记录。", userEntities.Count());
        }

        /// <summary>
        /// 测试执行 SQL 语句返回对象
        /// </summary>
        [TestMethod]
        public void TestMethod_ExecuteBySqlAndReturnObject_T()
        {
            string sql = "SELECT * FROM dbo.B_Users WHERE PK = @PK";
            BaseBLL<UserEntity> bll = new BaseBLL<UserEntity>();

            UserEntity userEntities = bll.ExecuteBySqlAndReturnObject<UserEntity>(sql, new { PK = 1 });
            Assert.IsTrue(userEntities != null);

            Console.WriteLine("获取到记录，JSON：{0}", userEntities.TryToJson());
        }

        /// <summary>
        /// 实体插入
        /// </summary>
        [TestMethod]
        public void TestMethod_Insert_T()
        {
            UserEntity user = new UserEntity
            {
                Name = "小师弟",
                Age = 18,
                Sex = 1,
                Description = "测试实体插入",
                Mobile = "15890909090"
            };
            user.Create();

            BaseBLL<UserEntity> bll = new BaseBLL<UserEntity>();
            int res = bll.Add(user);

            Console.WriteLine("执行结果：{0}", res);
        }

        /// <summary>
        /// 实体批量插入
        /// </summary>
        [TestMethod]
        public void TestMethod_BatchInsert_T()
        {
            List<UserEntity> userEntities = new List<UserEntity>();
            for (int i = 0; i < 100; i++)
            {
                UserEntity user = new UserEntity
                {
                    Name = "小师弟",
                    Age = 18,
                    Sex = 1,
                    Description = "测试实体插入",
                    Mobile = "15890909090"
                };
                user.Create();
                userEntities.Add(user);
            }

            BaseBLL<UserEntity> bll = new BaseBLL<UserEntity>();
            int res = bll.AddList(userEntities);

            Console.WriteLine("执行结果：{0}", res);
        }
        
    }
}
