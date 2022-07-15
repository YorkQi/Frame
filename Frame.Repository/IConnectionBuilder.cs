using System.Data;

namespace Frame.Repository
{
    /// <summary>
    /// 构建连接对象实例接口
    /// </summary>
    public interface IConnectionBuilder
    {
        IDbConnection GetDbConnection(DbOprationType operation);
    }
}
