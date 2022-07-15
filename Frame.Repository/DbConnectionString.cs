using System.Collections.Generic;

namespace Frame.Repository
{
    public class DbConnectionString
    {
        /// <summary>
        /// 数据库查询连接池
        /// </summary>
        public List<string> QueryString { get; set; }

        /// <summary>
        /// 数据库操作连接池
        /// </summary>
        public List<string> CommandString { get; set; }
    }
}
