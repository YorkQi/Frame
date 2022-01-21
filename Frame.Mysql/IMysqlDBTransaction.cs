using System.Data;

namespace Frame.Mysql
{
    public interface IMysqlDBTransaction
    {
        void BeginTransaction(IsolationLevel level);

        void Commit();

        void Rollback();

    }
}
