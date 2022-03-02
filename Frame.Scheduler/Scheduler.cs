using Quartz;
using System.Threading.Tasks;

namespace Frame.Scheduler
{

    public class Scheduler : IScheduler, IJob
    {
        public IScheduler _scheduler { get; private set; }

        public void InitializeScheduler(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _scheduler.Execute(context);
        }
    }
}
