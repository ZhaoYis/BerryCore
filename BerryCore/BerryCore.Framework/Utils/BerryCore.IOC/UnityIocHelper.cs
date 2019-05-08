#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.IOC
* 项目描述 ：
* 类 名 称 ：UnityIocHelper
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.IOC
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/3 21:55:04
* 更新时间 ：2019/5/3 21:55:04
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using BerryCore.Utilities;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;

namespace BerryCore.IOC
{
    /// <summary>
    /// 功能描述    ：UnityIoc帮助类  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/3 21:55:04 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/3 21:55:04 
    /// </summary>
    public sealed class UnityIocHelper : IServiceProvider
    {
        private readonly IUnityContainer _container;

        private static readonly UnityIocHelper iocHelper = new UnityIocHelper("DbContainer");

        /// <summary>
        /// 获取DbContainer对象
        /// </summary>
        public static UnityIocHelper UnityIocInstance
        {
            get { return iocHelper; }
        }

        /// <summary>
        /// 构造
        /// </summary>
        private UnityIocHelper(string containerName)
        {
            try
            {
                UnityConfigurationSection section = ConfigHelper.GetSection<UnityConfigurationSection>(UnityConfigurationSection.SectionName);
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
        public static string GetmapToByName(string containerName, string itype)
        {
            try
            {
                UnityConfigurationSection section = ConfigHelper.GetSection<UnityConfigurationSection>(UnityConfigurationSection.SectionName);
                ContainerElementCollection containers = section.Containers;

                foreach (var container in containers)
                {
                    if (container.Name == containerName)
                    {
                        RegisterElementCollection registrations = container.Registrations;
                        foreach (var registration in registrations)
                        {
                            if (string.IsNullOrEmpty(registration.Name) && registration.TypeName == itype)
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

    }
}
