using Quartz;
using System.Threading.Tasks;

namespace Frame.Scheduler
{
    public class QuartzSchedulerJob : ISchedulerJob
    {
        public IScheduler SchedulerJob { get; private set; }

        public void InitializeJob(IScheduler schedulerJob)
        {
            SchedulerJob = schedulerJob;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await SchedulerJob.Execute(context);
        }
    }
}
