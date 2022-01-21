using System.Data;

namespace Frame.Mysql
{
    public abstract class MysqlDBContext : IDBContext
    {
        public IDbConnection? DbConnection { get; protected set; }
        public IDbTransaction? DbTransaction { get; protected set; }

        private readonly IMysqlBuilder _mysqlBuilder;
        public MysqlDBContext(IMysqlBuilder mysqlBuilder)
        {
            _mysqlBuilder = mysqlBuilder;
        }

        public void GetConnection()
        {
            if (_mysqlBuilder != null)
                DbConnection = _mysqlBuilder.GetDbConnection();
        }
    }
}
