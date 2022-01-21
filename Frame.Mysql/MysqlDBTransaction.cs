using System.Data;

namespace Frame.Mysql
{
    public class MysqlDBTransaction: IMysqlDBTransaction
    {
        private readonly IDbConnection _dbConnection;

        private  IDbTransaction? _tran;

        public MysqlDBTransaction(IDbTransaction? tran, IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

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
                    ConnectionClose();
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
                    ConnectionClose();
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

    }
}
