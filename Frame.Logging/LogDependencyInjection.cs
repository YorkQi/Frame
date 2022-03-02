using Frame.Logging;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LogDependencyInjection
    {
        public static IServiceCollection AddLog(this IServiceCollection services, LogOption option)
        {
            switch (option.frame)
            {
                case LogFrameEnums.Nlog:
                    services.AddTransient<ILog,Nlog>(); 
                    break;
                default:
                    services.AddTransient<ILog, Nlog>();
                    break;
            }
            return services;
        }
    }
}
