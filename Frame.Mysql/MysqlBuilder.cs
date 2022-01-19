using MySqlConnector;
using System.Data;

namespace Frame.Mysql
{
    public class MysqlBuilder : IMysqlBuilder
    {
        public readonly string _connectionString;
        public MysqlBuilder(MysqlOptions options)
        {
            _connectionString = options.ConnectionString;
        }
        public IDbConnection GetDbConnection()
        {
            return new MySqlConnection(_connectionString); ;
        }
    }
}
