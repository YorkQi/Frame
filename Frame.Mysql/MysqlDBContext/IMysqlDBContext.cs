using Frame.Core;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Frame.Mysql
{
    public interface IMysqlDBContext
    {
        IEnumerable<T> Query<T>(string sql, object? param = null) where T : IEntity;
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null) where T : IEntity;
        T Get<T>(IEntityPrimary Id) where T : IEntity;
        Task<T> GetAsync<T>(IEntityPrimary Id) where T : IEntity;
        T Get<T>(string sql, object? param = null) where T : IEntity;
        Task<T> GetAsync<T>(string sql, object? param = null) where T : IEntity;
        IEntityPrimary Insert<T>(T entity) where T : IEntity;
        Task<IEntityPrimary> InsertAsync<T>(T entity) where T : IEntity;
        void InsertBatch<T>(T entity) where T : IEntity;
        Task InsertBatchAsync<T>(IEnumerable<T> entity) where T : IEntity;
        IEntityPrimary Update<T>(T entity) where T : IEntity;
        Task<IEntityPrimary> UpdateAsync<T>(T entity) where T : IEntity;
        void UpdateBatch<T>(T entity) where T : IEntity;
        Task UpdateBatchAsync<T>(IEnumerable<T> entity) where T : IEntity;
    }
}
