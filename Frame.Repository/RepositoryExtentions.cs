using Frame.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Frame.Repository
{
    public class RepositoryExtentions
    {
        public readonly IServiceProvider _service;
        public RepositoryExtentions(IServiceProvider service)
        {
            _service = service;
        }

        /// <summary>
        /// 返回仓储实体
        /// </summary>
        /// <typeparam name="TRepository"></typeparam>
        /// <returns></returns>
        public TRepository GetRepository<TRepository>()
            where TRepository : IRepository, new()
        {
            var repository = _service.GetService<TRepository>();

            return repository ?? new TRepository();
        }
    }
}
