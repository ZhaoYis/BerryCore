using System;

namespace BerryCore.SOA.API.Caching
{
    public class ThrottleEntry
    {
        public ThrottleEntry()
        {
            PeriodStart = DateTime.UtcNow;
            Requests = 0;
        }

        /// <summary>
        /// 第一次请求开始时间
        /// </summary>
        public DateTime PeriodStart { get; private set; }

        /// <summary>
        /// 请求次数
        /// </summary>
        public long Requests { get; set; }

    }
}