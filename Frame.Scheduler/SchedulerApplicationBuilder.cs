﻿using Frame.Scheduler;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Impl;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Builder
{
    public static class SchedulerApplicationBuilder
    {
        private static IEnumerable<SchedulerOption> options { get; set; }

        public static IApplicationBuilder AddScheduler(this IApplicationBuilder app, IEnumerable<SchedulerOption> option)
        {
            options = option;
            return app;
        }

        public static IApplicationBuilder SchedulerStart(this IApplicationBuilder app)
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            var scheduler = factory.GetScheduler().GetAwaiter().GetResult();

            var schedulerBuilder = app.ApplicationServices.GetService<ISchedulerBuilder>()
                ?? throw new System.ApplicationException("未取得ISchedulerBuilder");
            schedulerBuilder.Initialize(scheduler);
            foreach (var item in options)
            {
                schedulerBuilder.Add(item.SchedulerAssmbly, item.SchedulerGroupName);
            }
            schedulerBuilder.Start().GetAwaiter();
            return app;
        }
    }
}
