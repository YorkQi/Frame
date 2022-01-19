using Frame.Mysql;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MysqlDependencyInjection
    {
        public static IServiceCollection AddMysql(this IServiceCollection services,Action<MysqlOptions> options)
        {
            services.AddScoped(op => { return options; });

            services.AddSingleton<IMysqlBuilder>();

            return services;
        }
    }
}
