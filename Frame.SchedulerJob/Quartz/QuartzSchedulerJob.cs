using Quartz;
using System.Threading.Tasks;

namespace Frame.SchedulerJob
{
    public class QuartzSchedulerJob : ISchedulerJob
    {
        public ISchedulerJob SchedulerJob { get; private set; }

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
