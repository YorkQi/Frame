using Frame.Mysql.Operations;
using System.Data;

namespace Frame.Mysql
{
    public abstract partial class MysqlDBContext//: IMysqlDBContext
    {
        //public IDbConnection? DbConnection { get; protected set; }
        //public IDbTransaction? DbTransaction { get; protected set; }

        //private readonly IMysqlConnectionBuilder _mysqlBuilder;
        //public MysqlDBContext(IMysqlConnectionBuilder mysqlBuilder)
        //{
        //    _mysqlBuilder = mysqlBuilder;
        //}

        //public void GetConnection()
        //{
        //    if (_mysqlBuilder != null)
        //        DbConnection = _mysqlBuilder.GetDbConnection(this);
        //}

        //public void BeginTransaction(IsolationLevel level)
        //{
        //    ConnectionOpen();
        //    if (DbTransaction == null)
        //    {
        //        DbTransaction = DbConnection?.BeginTransaction(level);
        //    }
        //}

        //public void Commit()
        //{
        //    if (DbConnection == null)
        //    {
        //        throw new DataException("没有数据库连接对象");
        //    }
        //    if (DbConnection.State == ConnectionState.Open)
        //    {
        //        if (DbTransaction != null)
        //        {
        //            DbTransaction.Commit();
        //            ConnectionClose();
        //            DbTransaction.Dispose();
        //        }
        //    }
        //}

        //public void Rollback()
        //{
        //    if (DbConnection == null)
        //    {
        //        throw new DataException("没有数据库连接对象");
        //    }
        //    if (DbConnection.State == ConnectionState.Open)
        //    {
        //        if (DbTransaction != null)
        //        {
        //            DbTransaction.Rollback();
        //            ConnectionClose();
        //            DbTransaction.Dispose();
        //        }
        //    }
        //}

        //private void ConnectionOpen()
        //{
        //    if (DbConnection == null)
        //    {
        //        throw new DataException("没有数据库连接对象");
        //    }
        //    if (DbConnection.State != ConnectionState.Closed)
        //    {
        //        DbConnection.Close();
        //    }
        //    DbConnection.Open();
        //}

        //private void ConnectionClose()
        //{
        //    if (DbConnection == null)
        //    {
        //        throw new DataException("没有数据库连接对象");
        //    }
        //    if (DbConnection.State != ConnectionState.Closed)
        //    {
        //        DbConnection.Close();
        //    }
        //}
    }
}
