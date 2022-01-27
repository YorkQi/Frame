using Frame.Mysql.Operations;
using System.Data;

namespace Frame.Mysql
{
    public interface IMysqlConnectionBuilder
    {
        IDbConnection GetDbConnection(IOperation operation);
    }
}
