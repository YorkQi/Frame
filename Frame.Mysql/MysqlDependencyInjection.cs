using Frame.Mysql;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MysqlDependencyInjection
    {
        public static IServiceCollection AddMysql(this IServiceCollection services, Action<MysqlOptions> options)
        {
            services.AddSingleton(_ => options);
            services.AddSingleton<IMysqlConnectionBuilder, MysqlConnectionBuilder>();
            services.AddScoped<IMysqlDBContext, MysqlDBContext>();
            return services;
        }
    }
}
