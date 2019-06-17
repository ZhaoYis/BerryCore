using System;

namespace BerryCore.Utilities.JWT
{
    /// <summary>
    /// 忽略Token验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class IgnoreTokenAttribute : Attribute
    {
        public bool Ignore { get; private set; }

        /// <summary>
        /// 忽略验证.默认忽略
        /// </summary>
        /// <param name="ignore"></param>
        public IgnoreTokenAttribute(bool ignore = false)
        {
            this.Ignore = ignore;
        }
    }
}