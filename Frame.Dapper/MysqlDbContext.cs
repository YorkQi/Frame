using Dapper;
using Frame.Mysql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Frame.Dapper
{
    public class MysqlDbContext : IMysqlDBContext
    {
        public MysqlDbContext(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        private IDbTransaction? _tran;
        public IDbConnection _dbConnection;

        public int? _commandTimeout = null;
        public CommandType? _commandType= null;

        #region SqlCommand

        public IEnumerable<TResult> Query<TResult>(string sql, object? param = null)
        {
            return _dbConnection.Query<TResult>(sql, param, _tran, true, _commandTimeout, _commandType);
        }
        public Task<IEnumerable<TResult>> QueryAsync<TResult>(string sql, object? param = null)
        {
            return _dbConnection.QueryAsync<TResult>(sql, param, _tran, _commandTimeout, _commandType);
        }
        public TResult Get<TResult>(string sql, object? param = null)
        {
            return _dbConnection.QueryFirst<TResult>(sql, param, _tran, _commandTimeout, _commandType);
        }
        public Task<TResult> GetAsync<TResult>(string sql, object? param = null)
        {
            return _dbConnection.QueryFirstAsync<TResult>(sql, param, _tran, _commandTimeout, _commandType);
        }


        #endregion


        ~MysqlDbContext()
        {
            _dbConnection.Close();
        }
    }
}
