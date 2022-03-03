using Frame.Scheduler;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SchedulerDependencyInjection
    {
        public static IServiceCollection AddScheduler(this IServiceCollection services)
        {
            //services.AddSingleton<ISchedulerJob, QuartzSchedulerJob>();
            //services.AddSingleton<IQuartzBuilder, QuartzBuilder>();
            return services;
        }
    }
}
