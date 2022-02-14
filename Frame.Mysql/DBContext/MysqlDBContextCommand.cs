using Dapper;
using Frame.Core;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Frame.Mysql
{
    public partial class MysqlDBContext //: IMysqlDBContext
    {
        public int? _commandTimeout = null;
        public CommandType? _commandType = null;

        //public IEnumerable<T> Query<T>(string sql, object? param = null) where T : IEntity
        //{
        //    return DbConnection.Query<T>(sql, param, DbTransaction, true, _commandTimeout, _commandType);
        //}
        //public Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null) where T : IEntity
        //{
        //    return DbConnection.QueryAsync<T>(sql, param, DbTransaction, _commandTimeout, _commandType);
        //}
        //public T Get<T>(IEntityPrimary Id) where T : IEntity
        //{
        //    return DbConnection.QueryFirst<T>(sql, param, DbTransaction, _commandTimeout, _commandType);
        //}
        //public  Task<T> GetAsync<T>(IEntityPrimary Id) where T : IEntity
        //{
        //    return DbConnection.QueryFirstAsync<T>(sql, param, DbTransaction, _commandTimeout, _commandType);
        //}
        //public  T Get<T>(string sql, object? param = null) where T : IEntity
        //{
        //    return DbConnection.QueryFirst<T>(sql, param, DbTransaction, _commandTimeout, _commandType);
        //}
        //public Task<T> GetAsync<T>(string sql, object? param = null) where T : IEntity
        //{
        //    return DbConnection.QueryFirstAsync<T>(sql, param, DbTransaction, _commandTimeout, _commandType);
        //}
        //public IEntityPrimary Insert<T>(T entity) where T : IEntity
        //{
        //    return DbConnection.Execute(sql, param, DbTransaction, _commandTimeout, _commandType);
        //}
        //public Task<IEntityPrimary> InsertAsync<T>(T entity) where T : IEntity
        //{
        //    return DbConnection.ExecuteAsync<T>(sql, param, DbTransaction, _commandTimeout, _commandType);
        //}
        //public void InsertBatch<T>(T entity) where T : IEntity
        //{
        //    return DbConnection.Execute<T>(sql, param, DbTransaction, _commandTimeout, _commandType);
        //}
        //public Task InsertBatchAsync<T>(IEnumerable<T> entity) where T : IEntity
        //{
        //    return DbConnection.ExecuteAsync<T>(sql, param, DbTransaction, _commandTimeout, _commandType);
        //}
        //public IEntityPrimary Update<T>(T entity) where T : IEntity
        //{
        //    return DbConnection.Execute<T>(sql, param, DbTransaction, _commandTimeout, _commandType);
        //}
        //public Task<IEntityPrimary> UpdateAsync<T>(T entity) where T : IEntity
        //{
        //    return DbConnection.ExecuteAsync<T>(sql, param, DbTransaction, _commandTimeout, _commandType);
        //}
        //public void UpdateBatch<T>(T entity) where T : IEntity

        //{
        //    return DbConnection.ExecuteAsync<T>(sql, param, DbTransaction, _commandTimeout, _commandType);
        //}
        //public Task UpdateBatchAsync<T>(IEnumerable<T> entity) where T : IEntity
        //{
        //    return DbConnection.ExecuteAsync<T>(sql, param, DbTransaction, _commandTimeout, _commandType);
        //}



    }
}
