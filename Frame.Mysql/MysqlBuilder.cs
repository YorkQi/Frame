using MySqlConnector;
using System.Data;

namespace Frame.Mysql
{
    public class MysqlBuilder : IMysqlBuilder
    {
        public readonly string _connectionString;
        public MysqlBuilder(MysqlOptions options)
        {
            if (options.ConnectionString==null)
            { 
                throw new System.ArgumentNullException("数据库连接字符串为空");
            }
            _connectionString = options.ConnectionString;
        }

        public IDbConnection GetDbConnection()
        {
            if (_connectionString == null)
            {
                throw new System.ArgumentNullException("数据库连接字符串为空");
            }
            return new MySqlConnection(_connectionString); ;
        }
    }
}
