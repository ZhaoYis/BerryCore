using System;
using System.Collections.Generic;
using System.Net;
using RedLock;

namespace BerryCore.DistributedLockManager
{
    /// <summary>
    /// 分布式锁帮助类
    /// </summary>
    public class DistributedLockHelper
    {
        private readonly List<RedisLockEndPoint> redisLockEndPoints;

        public DistributedLockHelper()
        {
            redisLockEndPoints = new List<RedisLockEndPoint>
            {
                new RedisLockEndPoint
                {
                    EndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6379)
                }
            };
        }

        /// <summary>
        /// 阻塞式调用，事情最终会被调用（等待时间内）
        /// </summary>
        /// <param name="resource">锁定资源的标识</param>
        /// <param name="expiryTime">锁过期时间</param>
        /// <param name="waitTime">等待时间</param>
        /// <param name="work"></param>
        public bool BlockingWork(string resource, TimeSpan expiryTime, TimeSpan waitTime, Action work)
        {
            resource = this.CreateKey(resource);
            using (var redisLockFactory = new RedisLockFactory(redisLockEndPoints))
            {
                using (var redisLock = redisLockFactory.Create(resource, expiryTime, waitTime, TimeSpan.FromSeconds(1)))
                {
                    if (redisLock.IsAcquired)
                    {
                        work.Invoke();
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 跳过式调用，如果事情正在被调用，直接跳过
        /// </summary>
        /// <param name="resource">锁定资源的标识</param>
        /// <param name="expiryTime">锁过期时间</param>
        /// <param name="work"></param>
        public bool OverlappingWork(string resource, TimeSpan expiryTime, Action work)
        {
            resource = this.CreateKey(resource);
            using (var redisLockFactory = new RedisLockFactory(redisLockEndPoints))
            {
                using (var redisLock = redisLockFactory.Create(resource, expiryTime))
                {
                    if (redisLock.IsAcquired)
                    {
                        work.Invoke();
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 重新设置键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string CreateKey(string key)
        {
            return string.Join("_", "LOCK", key);
        }
    }
}