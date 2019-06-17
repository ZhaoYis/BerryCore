#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Utilities.KetamaHash
* 项目描述 ：
* 类 名 称 ：RedisNodeCalculator
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Utilities.KetamaHash
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-12 15:39:58
* 更新时间 ：2019-06-12 15:39:58
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System.Collections.Generic;

namespace BerryCore.Utilities.KetamaHash
{
    /// <summary>
    /// 功能描述    ：Redis接点计算器 
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-12 15:39:58 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-12 15:39:58 
    /// </summary>
    public class RedisNodeCalculator
    {
        /// <summary>
        /// 服务节点
        /// </summary>
        private readonly List<string> nodeList = null;

        private KetamaNodeLocator ketamaNodeLocator = null;

        /// <summary>
        /// 服务器节点数
        /// </summary>
        private int NODE_COUNT
        {
            get { return nodeList.Count; }
        }

        /// <summary>
        /// 虚拟节点数
        /// </summary>
        private int VIRTUAL_NODE_COUNT
        {
            //为了解决数据倾斜问题，一致性哈希算法引入了虚拟节点机制，即对每一个服务节点计算多个哈希，每个计算结果位置都放置一个此服务节点，称为虚拟节点
            //通常将虚拟节点数设置为32甚至更大，因此即使很少的服务节点也能做到相对均匀的数据分布
            get { return this.NODE_COUNT * 32; }
        }

        public RedisNodeCalculator(List<string> node)
        {
            this.nodeList = node;
            this.ketamaNodeLocator = new KetamaNodeLocator(this.nodeList, VIRTUAL_NODE_COUNT);
        }

        /// <summary>
        /// 计算节点
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetNode(string key)
        {
            string node = ketamaNodeLocator.GetPrimary(key);
            return node;
        }
    }
}
