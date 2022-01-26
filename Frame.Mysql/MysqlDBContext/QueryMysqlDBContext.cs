using Frame.Mysql.Operations;
using System.Data;

namespace Frame.Mysql
{
    public abstract class QueryMysqlDBContext: IQueryOperation
    {
        public IDbConnection? DbConnection { get; protected set; }
        public IDbTransaction? DbTransaction { get; protected set; }

        private readonly IMysqlConnectionBuilder _mysqlBuilder;
        public QueryMysqlDBContext(IMysqlConnectionBuilder mysqlBuilder)
        {
            _mysqlBuilder = mysqlBuilder;
        }

        public void GetConnection()
        {
            if (_mysqlBuilder != null)
                DbConnection = _mysqlBuilder.GetDbConnection(this);
        }
    }
}
