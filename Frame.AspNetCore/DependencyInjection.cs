using Frame.AspNetCore.Exceptions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddMvcCore(op => {
                op.Filters.Add(typeof(ExceptionFilter));
            });

            return services;
        }
    }
}
