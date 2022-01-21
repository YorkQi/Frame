using Frame.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Frame.Repository
{
    public class RepositoryExtentioncs
    {
        public readonly IServiceProvider _service;
        public RepositoryExtentioncs(IServiceProvider service)
        {
            _service = service;
        }

        /// <summary>
        /// 返回仓储实体
        /// </summary>
        /// <typeparam name="TRepository"></typeparam>
        /// <returns></returns>
        public TRepository GetRepository<TRepository>() where TRepository : IRepository<IEntity>, new()
        {
            var repository = _service.GetService<TRepository>();
            if (repository == null)
                repository = new TRepository();
            return repository;
        }
    }
}
