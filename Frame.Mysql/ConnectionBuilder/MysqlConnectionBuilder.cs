using Frame.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace Frame.Mysql
{
    public class MysqlConnectionBuilder : IConnectionBuilder
    {
        public readonly DbConnectionString _connectionString;

        public MysqlConnectionBuilder(DbConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetDbConnection(DbOprationType operation)
        {
            if (operation == DbOprationType.Query)
            {
                return new MySqlConnection(GetConnectionString(_connectionString.QueryString));
            }
            else if (operation == DbOprationType.Command)
            {
                return new MySqlConnection(GetConnectionString(_connectionString.CommandString));
            }
            else
            {
                throw new ArgumentNullException("无法解析操作用户操作类型");
            }
        }

        /// <summary>
        /// 在数据库池中取得一条连接字符串
        /// 轮询、权重(目前随机)
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private string GetConnectionString(List<string>? connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException("数据库连接字符串为空");
            }
            return connectionString[new Random().Next(0, (connectionString.Count - 1))];
        }
    }
}
