#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Utilities.KetamaHash.Test
* 项目描述 ：
* 类 名 称 ：HashAlgorithmTest
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Utilities.KetamaHash.Test
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-12 15:35:29
* 更新时间 ：2019-06-12 15:35:29
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace BerryCore.Utilities.KetamaHash.Test
{
    /// <summary>
    /// 功能描述    ：HashAlgorithmTest  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-12 15:35:29 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-12 15:35:29 
    /// </summary>
    public class HashAlgorithmTest
    {
        static Random ran = new Random();

        private const int EXE_TIMES = 5000;//键（Key）总数

        private const int NODE_COUNT = 1;//服务器节点数

        //为了解决数据倾斜问题，一致性哈希算法引入了虚拟节点机制，即对每一个服务节点计算多个哈希，每个计算结果位置都放置一个此服务节点，称为虚拟节点
        //通常将虚拟节点数设置为32甚至更大，因此即使很少的服务节点也能做到相对均匀的数据分布
        private const int VIRTUAL_NODE_COUNT = NODE_COUNT * 32;//虚拟节点数

        public static void Test()
        {
            HashAlgorithmTest test = new HashAlgorithmTest();

            /** Records the times of locating node*/
            Dictionary<string, int> nodeRecord = new Dictionary<string, int>();

            List<string> allNodes = test.getNodes(NODE_COUNT);
            KetamaNodeLocator locator = new KetamaNodeLocator(allNodes, VIRTUAL_NODE_COUNT);

            List<String> allKeys = test.getAllStrings();
            foreach (string key in allKeys)
            {
                //最终使用的节点
                string node = locator.GetPrimary(key);

                if (!nodeRecord.ContainsKey(node))
                {
                    nodeRecord[node] = 1;
                }
                else
                {
                    nodeRecord[node] = nodeRecord[node] + 1;
                }
            }

            Console.WriteLine("Nodes count : " + NODE_COUNT + ", Keys count : " + EXE_TIMES + ", Normal percent : " + (float)100 / NODE_COUNT + "%");
            Console.WriteLine("-------------------- boundary  ----------------------");
            foreach (string key in nodeRecord.Keys)
            {
                Console.WriteLine("Node name :" + key + " - Times : " + nodeRecord[key] + " - Percent : " + (float)nodeRecord[key] / EXE_TIMES * 100 + "%");
            }
            Console.ReadLine();
        }


        /**
         * Gets the mock node by the material parameter
         * 
         * @param nodeCount 
         * 		the count of node wanted
         * @return
         * 		the node list
         */
        private List<string> getNodes(int nodeCount)
        {
            List<string> nodes = new List<string>();

            for (int k = 1; k <= nodeCount; k++)
            {
                string node = "node" + k;
                nodes.Add(node);
            }

            //在应用时，这里会添入memcached server的IP端口地址
            //nodes.Add("10.0.4.114:11211");
            //nodes.Add("10.0.4.114:11212");
            //nodes.Add("10.0.4.114:11213");
            //nodes.Add("10.0.4.114:11214");
            //nodes.Add("10.0.4.114:11215");
            return nodes;
        }

        /**
         *	All the keys	
         */
        private List<String> getAllStrings()
        {
            List<string> allStrings = new List<string>(EXE_TIMES);

            for (int i = 0; i < EXE_TIMES; i++)
            {
                allStrings.Add(generateRandomString(ran.Next(50)));
            }

            return allStrings;
        }

        /**
         * To generate the random string by the random algorithm
         * <br>
         * The char between 32 and 127 is normal char
         * 
         * @param length
         * @return
         */
        private String generateRandomString(int length)
        {
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                sb.Append((char)(ran.Next(95) + 32));
            }

            return sb.ToString();
        }
    }
}
