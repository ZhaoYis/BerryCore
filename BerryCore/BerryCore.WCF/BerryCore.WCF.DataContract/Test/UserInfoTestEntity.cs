using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BerryCore.WCF.DataContract.Test
{
    /// <summary>
    /// 用于测试
    /// </summary>
    [DataContract(Name = "UserInfoTestEntity")]
    public class UserInfoTestEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
