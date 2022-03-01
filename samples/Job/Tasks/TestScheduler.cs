using Quartz;
using System.Threading.Tasks;

namespace Job.Tasks
{
    public class TestScheduler: Frame.Scheduler.IScheduler
    {
        public async Task Execute(IJobExecutionContext context)
        {
            int aaaa = 1;

        }
    }
}
