using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryCore.WCF.DataContract
{
    /// <summary>
    /// 可运行项
    /// </summary>
    public class WcfServiceCanRunMember
    {
        /// <summary>
        /// 服务名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 服务契约类型
        /// </summary>
        public Type ServiceContract { get; set; }
        /// <summary>
        /// 服务行为类型
        /// </summary>
        public Type ServiceBehavior { get; set; }
        /// <summary>
        /// 是否启用Http请求检索
        /// </summary>
        public bool CanHttp { get; set; }
        /// <summary>
        /// 是否启用NetTcp请求检索
        /// </summary>
        public bool CanNetTcp { get; set; }
    }
}
