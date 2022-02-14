using Frame.AspNetCore.Exceptions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AspNetCoreDependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddMvcCore(op =>
            {
                op.Filters.Add(typeof(ExceptionFilter));
            });
            services.AddRepository();
            //services.AddMysql(
            //    op =>
            //    {
            //        op.QueryConnectionString?.Add(
            //            @"Database=test;Data Source=154.8.192.215,5566;User Id=root;Password=york123;pooling=true;
            //            CharSet=utf8;port=3306;Allow User Variables=True;");
            //    });
            return services;
        }
    }
}
