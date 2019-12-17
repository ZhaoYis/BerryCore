namespace BerryCore.Code.Operator
{
    /// <summary>
    /// 用户数据权限
    /// </summary>
    public class AuthorizeDataModel
    {
        /// <summary>
        /// 功能模块主键
        /// </summary>
        public string ModuleId { get; set; }

        /// <summary>
        /// 获得有权限的数据列表SQL语句
        /// </summary>
        public string ReadAuthorize { get; set; }

        /// <summary>
        /// 可读用户ID
        /// </summary>
        public string ReadAuthorizeUserId { get; set; }

        /// <summary>
        /// 可写数据权限SQL语句
        /// </summary>
        public string WriteAuthorize { get; set; }

        /// <summary>
        /// 可写数据权限
        /// </summary>
        public string WriteAuthorizeUserId { get; set; }
    }
}