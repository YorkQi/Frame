using System.Data;

namespace Frame.Mysql
{
    public class MysqlDBTransaction: MysqlDBContext, IMysqlDBTransaction
    {
        public MysqlDBTransaction(IMysqlConnectionBuilder mysqlBuilder)
             : base(mysqlBuilder)
        {

        }

        public void BeginTransaction(IsolationLevel level)
        {
            ConnectionOpen();
            if (DbTransaction == null)
            {
                DbTransaction = DbConnection?.BeginTransaction(level);
            }
        }
        public void Commit()
        {
            if (DbConnection == null)
            {
                throw new DataException("没有数据库连接对象");
            }
            if (DbConnection.State == ConnectionState.Open)
            {
                if (DbTransaction != null)
                {
                    DbTransaction.Commit();
                    ConnectionClose();
                    DbTransaction.Dispose();
                }
            }
        }

        public void Rollback()
        {
            if (DbConnection == null)
            {
                throw new DataException("没有数据库连接对象");
            }
            if (DbConnection.State == ConnectionState.Open)
            {
                if (DbTransaction != null)
                {
                    DbTransaction.Rollback();
                    ConnectionClose();
                    DbTransaction.Dispose();
                }
            }
        }

        private void ConnectionOpen()
        {
            if (DbConnection == null)
            {
                throw new DataException("没有数据库连接对象");
            }
            if (DbConnection.State != ConnectionState.Closed)
            {
                DbConnection.Close();
            }
            DbConnection.Open();
        }

        private void ConnectionClose()
        {
            if (DbConnection == null)
            {
                throw new DataException("没有数据库连接对象");
            }
            if (DbConnection.State != ConnectionState.Closed)
            {
                DbConnection.Close();
            }
        }

    }
}
