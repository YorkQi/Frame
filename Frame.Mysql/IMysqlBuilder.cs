using System.Data;

namespace Frame.Mysql
{
    public interface IMysqlBuilder
    {
        IDbConnection GetDbConnection();
    }
}
