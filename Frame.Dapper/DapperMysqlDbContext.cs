using Dapper;
using Frame.Mysql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Frame.Dapper
{
    public class DapperMysqlDbContext : MysqlDBContext
    {
        public DapperMysqlDbContext(IMysqlBuilder mysqlBuilder)
            :base(mysqlBuilder)
        {

        }

        public int? _commandTimeout = null;
        public CommandType? _commandType= null;

        #region SqlCommand

        public IEnumerable<TResult> Query<TResult>(string sql, object? param = null)
        {
            return DbConnection.Query<TResult>(sql, param, DbTransaction, true, _commandTimeout, _commandType);
        }
        public Task<IEnumerable<TResult>> QueryAsync<TResult>(string sql, object? param = null)
        {
            return DbConnection.QueryAsync<TResult>(sql, param, DbTransaction, _commandTimeout, _commandType);
        }
        public TResult Get<TResult>(string sql, object? param = null)
        {
            return DbConnection.QueryFirst<TResult>(sql, param, DbTransaction, _commandTimeout, _commandType);
        }
        public Task<TResult> GetAsync<TResult>(string sql, object? param = null)
        {
            return DbConnection.QueryFirstAsync<TResult>(sql, param, DbTransaction, _commandTimeout, _commandType);
        }


        #endregion


        ~DapperMysqlDbContext()
        {
            if (DbConnection != null)
                DbConnection.Close();
        }
    }
}
