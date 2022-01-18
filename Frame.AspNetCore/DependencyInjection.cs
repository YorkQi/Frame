using Frame.AspNetCore.Exceptions;

using Microsoft.Extensions.DependencyInjection;


namespace Frame.AspNetCore
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
