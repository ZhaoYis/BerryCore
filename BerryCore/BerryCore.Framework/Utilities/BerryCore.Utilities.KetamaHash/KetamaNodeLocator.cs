#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Utilities.KetamaHash
* 项目描述 ：
* 类 名 称 ：KetamaNodeLocator
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Utilities.KetamaHash
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-12 15:32:28
* 更新时间 ：2019-06-12 15:32:28
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BerryCore.Utilities.KetamaHash
{
    /// <summary>
    /// 功能描述    ：Hash一致性算法  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-12 15:32:28 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-12 15:32:28 
    /// </summary>
    public class KetamaNodeLocator
    {
        private readonly SortedList<long, string> _ketamaNodes = new SortedList<long, string>();

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="nodes">服务器节点</param>
        /// <param name="nodeCopies">虚拟节点总数</param>
        public KetamaNodeLocator(List<string> nodes, int nodeCopies)
        {
            //对所有节点，生成nCopies个虚拟结点
            foreach (string node in nodes)
            {
                //每四个虚拟结点为一组
                for (int i = 0; i < nodeCopies / 4; i++)
                {
                    //getKeyForNode方法为这组虚拟结点得到惟一名称 
                    byte[] digest = this.ComputeMd5(node + i);
                    /** Md5是一个16字节长度的数组，将16字节的数组每四个字节一组，分别对应一个虚拟结点，这就是为什么上面把虚拟结点四个划分一组的原因*/
                    for (int h = 0; h < 4; h++)
                    {
                        long m = this.Hash(digest, h);
                        _ketamaNodes[m] = node;
                    }
                }
            }
        }

        /// <summary>
        /// 获取主节点
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        public string GetPrimary(string cacheKey)
        {
            byte[] digest = this.ComputeMd5(cacheKey);
            string rv = this.GetNodeForKey(this.Hash(digest, 0));
            return rv;
        }

        /// <summary>
        /// 根据hash值获取节点
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        private string GetNodeForKey(long hash)
        {
            long key = hash;
            //如果找到这个节点，直接取节点，返回   
            if (!_ketamaNodes.ContainsKey(key))
            {
                //得到大于当前key的那个子Map，然后从中取出第一个key，就是大于且离它最近的那个key 说明详见: http://www.javaeye.com/topic/684087
                var tailMap = from coll in _ketamaNodes
                              where coll.Key > hash
                              select new { coll.Key };

                if (tailMap == null || tailMap.Count() == 0)
                {
                    key = _ketamaNodes.FirstOrDefault().Key;
                }
                else
                {
                    key = tailMap.FirstOrDefault().Key;
                }
            }

            string rv = _ketamaNodes[key];
            return rv;
        }

        /// <summary>
        /// 计算Hash值
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="nTime"></param>
        /// <returns></returns>
        private long Hash(byte[] digest, int nTime)
        {
            long rv = ((long)(digest[3 + nTime * 4] & 0xFF) << 24)
                      | ((long)(digest[2 + nTime * 4] & 0xFF) << 16)
                      | ((long)(digest[1 + nTime * 4] & 0xFF) << 8)
                      | ((long)digest[0 + nTime * 4] & 0xFF);

            return rv & 0xffffffffL; /* Truncate to 32-bits */
        }

        /// <summary>
        /// 计算MD5
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private byte[] ComputeMd5(string key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] keyBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
            md5.Clear();

            return keyBytes;
        }
    }
}
