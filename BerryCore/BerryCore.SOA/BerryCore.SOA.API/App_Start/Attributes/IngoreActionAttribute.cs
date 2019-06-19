using System;

namespace BerryCore.SOA.API.Attributes
{
    /// <summary>
    /// 忽略特殊Action方法
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class IgnoreActionAttribute : Attribute
    {

    }
}