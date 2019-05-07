using System;
using System.Collections.Generic;
using System.IO;
using BerryCore.Extensions;

namespace Berry.Cache.Core.Model
{
    public class RedisServerConfig
    {
        public static List<RedisServerModel> RedisServers { get; set; }

        public static string ConfigPath = "XmlConfig/RedisServiceConfig.json";

        static RedisServerConfig()
        {
            LoadConfig();
        }

        public static void LoadConfig()
        {
            ConfigPath = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, ConfigPath);
            if (File.Exists(ConfigPath))
            {
                string context = File.ReadAllText(ConfigPath);
                RedisServers = context.JsonToList<RedisServerModel>();
            }
        }
    }
}