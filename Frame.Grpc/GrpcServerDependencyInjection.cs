namespace Microsoft.Extensions.DependencyInjection
{
    public static class GrpcServerDependencyInjection
    {
        public static IServiceCollection AddGrpcServer(this IServiceCollection services)
        {
            //services.AddGrpc();
            return services;
        }
    }
}
