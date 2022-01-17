using Dapper;
using Frame.Mysql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Frame.Dapper
{
    public class MysqlDbContext : IMysqlDbContext
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

        #region SqlConnection
        public void BeginTransaction(IsolationLevel level)
        {
            ConnectionOpen();
            if (_tran == null)
            {
                _tran = _dbConnection.BeginTransaction(level);
            }
        }
        public void Commit()
        {
            if (_dbConnection.State == ConnectionState.Open)
            {
                if (_tran != null)
                {
                    _tran.Commit();
                    _dbConnection.Close();
                    _tran.Dispose();
                }
            }
        }

        public void Rollback()
        {
            if (_dbConnection.State == ConnectionState.Open)
            {
                if (_tran != null)
                {
                    _tran.Rollback();
                    _dbConnection.Close();
                    _tran.Dispose();
                }
            }
        }

        private void ConnectionOpen()
        {
            if (_dbConnection == null)
            {
                throw new DataException("没有数据库连接对象");
            }
            if (_dbConnection.State != ConnectionState.Closed)
            {
                _dbConnection.Close();
            }
            _dbConnection.Open();
        }

        private void ConnectionClose()
        {
            if (_dbConnection == null)
            {
                throw new DataException("没有数据库连接对象");
            }
            if (_dbConnection.State != ConnectionState.Closed)
            {
                _dbConnection.Close();
            }
        }

        #endregion

        ~MysqlDbContext()
        {
            _dbConnection.Close();
        }
    }
}
