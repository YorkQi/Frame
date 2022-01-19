using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Frame.Mysql
{
    public interface IMysqlDbContext
    {
        IEnumerable<TResult> Query<TResult>(string sql, object? param = null);
        Task<IEnumerable<TResult>> QueryAsync<TResult>(string sql, object? param = null);
        TResult Get<TResult>(string sql, object? param = null);
        Task<TResult> GetAsync<TResult>(string sql, object? param = null);
        void BeginTransaction(IsolationLevel level= IsolationLevel.Unspecified);
        void Commit();
        void Rollback();
    }
}
