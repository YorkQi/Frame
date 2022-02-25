using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frame.Scheduler
{
    public class SchedulerBuilder : ISchedulerBuilder
    {
        public enum SchedulerState
        {
            Starting = 1,
            Closing = 2
        }
        public Quartz.IScheduler scheduler { get; set; }

        private SchedulerState State { get; set; }

        SchedulerBuilder()
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            scheduler = factory.GetScheduler().GetAwaiter().GetResult(); ;
        }

        public async Task Start()
        {
            await scheduler.Start();
        }

        public async Task End()
        {
            await scheduler.Shutdown();
        }

        public async Task Add(string schedulerName, string triggerName, string schedulerGroupName)
        {
            IJobDetail job = JobBuilder.Create<Scheduler>()
                .WithIdentity(schedulerName, schedulerGroupName)
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity(triggerName, schedulerGroupName)
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
                .Build();
            await scheduler.ScheduleJob(job, trigger);
        }

        public async Task ResumeOrPause(string schedulerName, string triggerName, string schedulerGroupName)
        {
            var (jobKey, trigger) = await GetScheduler(schedulerName, triggerName, schedulerGroupName);
            if (State == SchedulerState.Starting)
            {
                await scheduler.PauseTrigger(trigger.Key);
            }
            else
            {
                await scheduler.ResumeTrigger(trigger.Key);
            }
        }

        public async Task Remove(string schedulerName, string triggerName, string schedulerGroupName)
        {
            var (jobKey, trigger) = await GetScheduler(schedulerName, triggerName, schedulerGroupName);

            await scheduler.DeleteJob(jobKey);
        }

        private async Task<(JobKey?, ITrigger?)> GetScheduler(string schedulerName, string triggerName, string schedulerGroupName)
        {

            JobKey? retJobKey = null;
            ITrigger? retTrigger = null;
            List<JobKey> jobKeys = scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(schedulerGroupName)).Result.ToList();
            if (jobKeys == null || jobKeys.Count() == 0)
            {
                return (retJobKey, retTrigger);
            }

            JobKey jobKey = jobKeys.Where(s => s.Name == triggerName).FirstOrDefault();
            if (jobKey == null)
            {
                return (retJobKey, retTrigger);
            }

            var triggers = await scheduler.GetTriggersOfJob(jobKey);
            ITrigger trigger = triggers.Where(x => (x as CronTriggerImpl).Name == triggerName).FirstOrDefault();
            if (trigger == null)
            {
                return (retJobKey, retTrigger);
            }
            return (jobKey, trigger);
        }

        ~SchedulerBuilder()
        {
            scheduler.Shutdown();
        }
    }
}
