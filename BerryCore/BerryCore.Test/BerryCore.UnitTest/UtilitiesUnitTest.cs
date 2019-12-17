using System;
using BerryCore.Entity.Test;
using BerryCore.Extensions;
using BerryCore.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerryCore.UnitTest
{
    [TestClass]
    public class UtilitiesUnitTest
    {
        [TestMethod]
        public void TestMethod_()
        {
            UserTestEntity user1 = new UserTestEntity
            {
                Name = "dsx"
            };
            UserTestEntity user2 = new UserTestEntity();

            int hash1 = user1.GetHashCode();
            int hash2 = user2.GetHashCode();

            string md51 = user1.TryToJson().GetMd5Code();
            string md52 = user2.TryToJson().GetMd5Code();

            bool isEqual = md51 == md52;

            Console.WriteLine("比较结果：{0}", isEqual);
        }
    }
}
