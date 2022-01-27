using Frame.Mysql.Operations;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace Frame.Mysql
{
    public class MysqlConnectionBuilder : IMysqlConnectionBuilder
    {
        public readonly MysqlOptions Options;

        public MysqlConnectionBuilder(MysqlOptions options)
        {
            if (options.QueryConnectionString == null)
            {
                throw new ArgumentNullException("数据库连接字符串为空");
            }
            if (options.CommandConnectionString == null)
            {
                throw new ArgumentNullException("数据库连接字符串为空");
            }
            Options = options;
        }

        public IDbConnection GetDbConnection(IOperation operation)
        {
            if (operation is IQueryOperation)
            {
                return new MySqlConnection(GetConnectionString(Options.QueryConnectionString));
            }
            else if (operation is ICommandOperation)
            {
                return new MySqlConnection(GetConnectionString(Options.CommandConnectionString));
            }
            else
            {
                throw new ArgumentNullException("无法解析IOperation操作");
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
