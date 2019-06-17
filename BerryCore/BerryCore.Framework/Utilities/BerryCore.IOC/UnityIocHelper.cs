#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.IOC
* 项目描述 ：
* 类 名 称 ：UnityIocHelper
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.IOC
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-04 15:05:00
* 更新时间 ：2019-06-04 15:05:00
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System;
using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace BerryCore.IOC
{
    /// <summary>
    /// 功能描述    ：UnityIoc帮助类  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-04 15:05:00 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-04 15:05:00 
    /// </summary>
    public sealed class UnityIocHelper : IServiceProvider
    {
        private readonly IUnityContainer _container;

        /// <summary>
        /// 获取DbContainer对象
        /// </summary>
        public static UnityIocHelper UnityIocInstance { get; } = new UnityIocHelper("DbContainer");

        /// <summary>
        /// 构造
        /// </summary>
        private UnityIocHelper(string containerName)
        {
            try
            {
                UnityConfigurationSection section = GetSection<UnityConfigurationSection>(UnityConfigurationSection.SectionName);
                _container = new UnityContainer();
                section.Configure(_container, containerName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 获取配置节点的mapTo
        /// </summary>
        /// <returns></returns>
        public static string GetMapToValue(string containerName, string type)
        {
            try
            {
                UnityConfigurationSection section = GetSection<UnityConfigurationSection>(UnityConfigurationSection.SectionName);
                ContainerElementCollection containers = section.Containers;

                foreach (var container in containers)
                {
                    if (container.Name == containerName)
                    {
                        RegisterElementCollection registrations = container.Registrations;
                        foreach (var registration in registrations)
                        {
                            if (string.IsNullOrEmpty(registration.Name) && registration.TypeName == type)
                            {
                                string mapToName = registration.MapToName;
                                return mapToName;
                            }
                        }
                        break;
                    }
                }
                return "";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <returns></returns>
        public static ResolverOverride GetParameterOverride(string parameterName, object parameterValue)
        {
            ResolverOverride resolver = new ParameterOverride(parameterName, parameterValue);
            return resolver;
        }

        /// <summary>
        /// 获取指定类型的服务对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetService<T>()
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        /// 获取指定类型的服务对象
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return _container.Resolve(serviceType);
        }

        /// <summary>
        /// 获取指定类型的服务对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetService<T>(params ResolverOverride[] parameter)
        {
            T res = _container.Resolve<T>(parameter);
            return res;
        }

        /// <summary>
        /// 获取指定类型的服务对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetService<T>(string name, params ResolverOverride[] obj)
        {
            return _container.Resolve<T>(name, obj);
        }

        /// <summary>
        /// 获取配置文件节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        private static T GetSection<T>(string sectionName) where T : class, new()
        {
            T res = ConfigurationManager.GetSection(sectionName) as T;
            return res;
        }
    }
}
