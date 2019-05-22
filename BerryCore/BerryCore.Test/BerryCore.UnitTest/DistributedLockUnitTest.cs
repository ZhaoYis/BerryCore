using System;
using BerryCore.DistributedLockManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerryCore.UnitTest
{
    [TestClass]
    public class DistributedLockUnitTest
    {
        [TestMethod]
        public void TestMethod_BlockingWork()
        {
            DistributedLockHelper lockHelper = new DistributedLockHelper();
            bool isWork = lockHelper.BlockingWork("TestLockName", TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5), () =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    Console.WriteLine(i);
                }
            });

            if (isWork)
            {
                Console.WriteLine("执行成功");
            }
            else
            {
                Console.WriteLine("执行失败");
            }
        }
    }
}
