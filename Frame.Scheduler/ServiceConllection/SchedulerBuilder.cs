using Quartz;
using System;
using System.Threading.Tasks;

namespace Frame.Scheduler
{
    public class SchedulerBuilder : ISchedulerBuilder
    {
        public Quartz.IScheduler _scheduler { get; set; }

        public JobDataMap Jobs { get; private set; } = new JobDataMap();

        public void Initialize(Quartz.IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public async Task Start()
        {
            await _scheduler.Start();
        }

        public async Task End()
        {
            await _scheduler.Shutdown();
        }

        /// <summary>
        /// 添加的计划
        /// </summary>
        /// <param name="schedulerName">调度器【唯一】</param>
        /// <param name="schedulerGroupName">调度器组别</param>
        /// <returns></returns>
        public async Task Add(string schedulerName, string schedulerGroupName)
        {
            IJobDetail job = JobBuilder.Create<Scheduler>()
                .WithIdentity(schedulerName, schedulerGroupName)
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity($"{schedulerName}.trigger", schedulerGroupName)
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
                .Build();

            Jobs.Add($"{schedulerName}-{schedulerGroupName}", SchedulerStateEnum.Starting);
            await _scheduler.ScheduleJob(job, trigger);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedulerName"></param>
        /// <param name="schedulerGroupName"></param>
        /// <returns></returns>
        public async Task ResumeOrPause(string schedulerName, string schedulerGroupName)
        {
            var schedulerState = Jobs.Get($"{schedulerName}-{schedulerGroupName}");
            if (schedulerState != null)
            {
                var (jobDetail, trigger) = await GetScheduler(schedulerName, schedulerGroupName);
                if (jobDetail != null && trigger != null)
                {
                    if ((SchedulerStateEnum)schedulerState == SchedulerStateEnum.Starting)
                    {
                        await _scheduler.PauseJob(jobDetail.Key);
                        await _scheduler.PauseTrigger(trigger.Key);
                    }
                    else
                    {
                        await _scheduler.ResumeJob(jobDetail.Key);
                        await _scheduler.ResumeTrigger(trigger.Key);
                    }
                }
                else
                {
                    throw new Exception($"内存中未查询的到{schedulerName}计划,无法暂停或启动");
                }
            }
            else
            {
                throw new Exception($"未查询的到{schedulerName}计划,无法暂停或启动");
            }
        }


        public async Task Remove(string schedulerName, string schedulerGroupName)
        {
            var schedulerState = Jobs.Get($"{schedulerName}-{schedulerGroupName}");
            if (schedulerState != null)
            {
                var (jobDetail, trigger) = await GetScheduler(schedulerName, schedulerGroupName);
                if (jobDetail != null && trigger != null)
                {
                    await _scheduler.DeleteJob(jobDetail.Key);
                }
                else
                {
                    throw new Exception($"内存中未查询的到{schedulerName}计划,无法删除");
                }
            }
            else
            {
                throw new Exception($"未查询的到{schedulerName}计划,无法删除");
            }
        }


        private async Task<(IJobDetail?, ITrigger?)> GetScheduler(string schedulerName, string schedulerGroupName)
        {
            var jobDetail = await _scheduler.GetJobDetail(new JobKey(schedulerName, schedulerGroupName.ToString()));
            var trigger = await _scheduler.GetTrigger(new TriggerKey($"{schedulerName}.trigger", schedulerGroupName.ToString()));
            return (jobDetail, trigger);
        }
    }
}
