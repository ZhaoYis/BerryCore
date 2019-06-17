#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Utilities.KetamaHash.Test
* 项目描述 ：
* 类 名 称 ：HashAlgorithmPercentTest
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Utilities.KetamaHash.Test
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-12 15:34:10
* 更新时间 ：2019-06-12 15:34:10
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerryCore.Utilities.KetamaHash.Test
{
    /// <summary>
    /// 功能描述    ：HashAlgorithmPercentTest  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-12 15:34:10 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-12 15:34:10 
    /// </summary>
    public class HashAlgorithmPercentTest
    {
        static Random ran = new Random();

        /** key's count */
        private const int EXE_TIMES = 1000;

        private const int NODE_COUNT = 100;

        private const int VIRTUAL_NODE_COUNT = 100;

        static List<String> allKeys = null;

        //static {
        //    allKeys = getAllStrings();
        //}

        public static void Test()
        {

            allKeys = GetAllStrings();
            Dictionary<string, List<string>> mapData = GenerateRecord();

            List<string> allNodes = getNodes(NODE_COUNT);
            Console.WriteLine("Normal case : nodes count : " + allNodes.Count());
            call(allNodes, mapData);

            allNodes = getNodes(NODE_COUNT + 8);
            Console.WriteLine("Added case : nodes count : " + allNodes.Count());
            call(allNodes, mapData);

            allNodes = getNodes(NODE_COUNT - 10);
            Console.WriteLine("Reduced case : nodes count : " + allNodes.Count());
            call(allNodes, mapData);

            int addCount = 0;
            int reduceCount = 0;
            foreach (string key in mapData.Keys)
            {
                List<string> list = mapData[key];
                if (list.Count == 3)
                {
                    if (list[0] == list[1])
                    {
                        addCount++;
                    }
                    if (list[0] == list[2])
                    {
                        reduceCount++;
                    }
                }
                else
                {
                    Console.WriteLine("It's wrong size of list, key is " + key + ", size is " + list.Count);
                }
            }

            Console.WriteLine(addCount + "   ---   " + reduceCount);

            //上面三行分别是正常情况，节点增加，节点删除情况下的节点数目。下面两行表示在节点增加和删除情况下，同一个key分配在相同节点上的比例(命中率)。 
            //多次测试后发现，命中率与结点数目和增减的节点数量有关。同样增删结点数目情况下，结点多时命中率高。同样节点数目，增删结点越少，命中率越高。这些都与实际情况相符。 
            Console.WriteLine("Same percent in added case : " + (float)addCount * 100 / EXE_TIMES + "%");
            Console.WriteLine("Same percent in reduced case : " + (float)reduceCount * 100 / EXE_TIMES + "%");
            Console.ReadLine();
        }

        private static void call(List<string> nodes, Dictionary<string, List<string>> map)
        {
            KetamaNodeLocator locator = new KetamaNodeLocator(nodes, VIRTUAL_NODE_COUNT);

            foreach (string key in map.Keys)
            {
                string node = locator.GetPrimary(key);

                if (node != null)
                {
                    List<string> list = map[key];
                    list.Add(node);
                }
            }
        }

        private static Dictionary<string, List<string>> GenerateRecord()
        {
            Dictionary<string, List<string>> record = new Dictionary<string, List<string>>(EXE_TIMES);

            foreach (string key in allKeys)
            {
                //List<string> list = record[key];
                //if (list == null)
                //{
                List<string> list = new List<string>();
                record[key] = list;
                //}
            }

            return record;
        }


        /**
         * Gets the mock node by the material parameter
         * 
         * @param nodeCount 
         * 		the count of node wanted
         * @return
         * 		the node list
         */
        private static List<string> getNodes(int nodeCount)
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
        private static List<String> GetAllStrings()
        {
            List<string> allStrings = new List<string>(EXE_TIMES);

            for (int i = 0; i < EXE_TIMES; i++)
            {
                allStrings.Add(GenerateRandomString(ran.Next(50)));
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
        private static String GenerateRandomString(int length)
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
