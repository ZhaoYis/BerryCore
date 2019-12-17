using Berry.Cache.Core.RegisterService;
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
        static BaseServiceUnitTest()
        {
            IRegisterService registerService = RegisterService.Start().UseRedisCache();
        }

        /// <summary>
        /// 测试执行T-SQL语句
        /// </summary>
        [TestMethod]
        public void TestMethod_ExecuteBySql_T()
        {
            string sql = "UPDATE [dbo].[B_Users] SET NAME = '大师兄' WHERE PK = @PK";
            BaseBLL<UserTestEntity> bll = new BaseBLL<UserTestEntity>();

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
            BaseBLL<UserTestEntity> bll = new BaseBLL<UserTestEntity>();

            IEnumerable<UserTestEntity> userEntities = bll.ExecuteBySqlAndReturnList<UserTestEntity>(sql, new { PK = 0 });
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
            BaseBLL<UserTestEntity> bll = new BaseBLL<UserTestEntity>();

            UserTestEntity userEntities = bll.ExecuteBySqlAndReturnObject<UserTestEntity>(sql, new { PK = 1 });
            Assert.IsTrue(userEntities != null);

            Console.WriteLine("获取到记录，JSON：{0}", userEntities.TryToJson());
        }

        /// <summary>
        /// 实体插入
        /// </summary>
        [TestMethod]
        public void TestMethod_Insert_T()
        {
            UserTestEntity user = new UserTestEntity
            {
                Name = "小师弟",
                Age = 18,
                Sex = 1,
                Description = "测试实体插入",
                Mobile = "15890909090"
            };
            user.Create();

            BaseBLL<UserTestEntity> bll = new BaseBLL<UserTestEntity>();
            int res = bll.Add(user);

            Console.WriteLine("执行结果：{0}", res);
        }

        /// <summary>
        /// 实体批量插入
        /// </summary>
        [TestMethod]
        public void TestMethod_BatchInsert_T()
        {
            List<UserTestEntity> userEntities = new List<UserTestEntity>();
            for (int i = 0; i < 100; i++)
            {
                UserTestEntity user = new UserTestEntity
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

            BaseBLL<UserTestEntity> bll = new BaseBLL<UserTestEntity>();
            int res = bll.AddList(userEntities);

            Console.WriteLine("执行结果：{0}", res);
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        [TestMethod]
        public void TestMethod_DeleteByCondition_T()
        {
            BaseBLL<UserTestEntity> bll = new BaseBLL<UserTestEntity>();
            int res = bll.Delete(u => u.Id != "");

            Console.WriteLine("执行结果：{0}", res);

            IEnumerable<UserTestEntity> userEntities = bll.GetList(u => u.Id != "");
            Console.WriteLine("删除后剩余记录数：{0}", userEntities.Count());
        }

        /// <summary>
        /// 根据条件更新
        /// </summary>
        [TestMethod]
        public void TestMethod_UpdateByCondition_T()
        {
            BaseBLL<UserTestEntity> bll = new BaseBLL<UserTestEntity>();
            int res = bll.Update(new
            {
                Name = "大师兄丶"
            }, u => u.Id != "");

            Console.WriteLine("执行结果：{0}", res);
        }
    }
}
