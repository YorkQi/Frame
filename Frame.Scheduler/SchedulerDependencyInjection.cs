using Frame.Scheduler;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SchedulerDependencyInjection
    {
        public static async Task<IServiceCollection> AddScheduler(this IServiceCollection services)
        {
            services.AddSingleton<ISchedulerBuilder, SchedulerBuilder>();

            return services;
        }
    }
}
