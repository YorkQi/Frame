using Frame.Scheduler;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Impl;

namespace Microsoft.AspNetCore.Builder
{
    public static class SchedulerApplicationBuilder
    {
        public static IApplicationBuilder UseScheduler(this IApplicationBuilder app)
        {

            StdSchedulerFactory factory = new StdSchedulerFactory();
            var scheduler = factory.GetScheduler().GetAwaiter().GetResult();

            var schedulerBuilder = app.ApplicationServices.GetService<ISchedulerBuilder>()
                ?? throw new System.ApplicationException("未取得ISchedulerBuilder");

            schedulerBuilder.Initialize(scheduler);
            schedulerBuilder.Start().GetAwaiter();
            return app;
        }
    }
}
