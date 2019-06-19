using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryCore.WCF.DataContract
{
    /// <summary>
    /// WCF服务配置
    /// </summary>
    public class WcfServiceConfigEntity
    {
        /// <summary>
        /// 服务中文名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 服务契约命名空间
        /// </summary>
        public string ServiceContractNamespace { get; set; }
        /// <summary>
        /// 服务行为命名空间
        /// </summary>
        public string ServiceBehaviorNamespace { get; set; }
        /// <summary>
        /// 是否启用Http请求检索
        /// </summary>
        public string CanHttp { get; set; }
        /// <summary>
        /// 是否启用NetTcp请求检索
        /// </summary>
        public string CanNetTcp { get; set; }
        /// <summary>
        /// 是否启动此服务
        /// </summary>
        public string Enabled { get; set; }
    }
}