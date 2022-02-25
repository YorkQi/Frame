using Frame.Scheduler;
using Quartz;
using Quartz.Impl;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SchedulerDependencyInjection
    {
        public static async Task<IServiceCollection> AddScheduler(this IServiceCollection services)
        {
            services.AddSingleton<ISchedulerBuilder, Frame.Scheduler.SchedulerBuilder>();

            return services;
        }
    }
}
