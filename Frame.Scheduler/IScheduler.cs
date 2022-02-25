using Quartz;
using System.Threading.Tasks;

namespace Frame.Scheduler
{
    public interface IScheduler
    {
        Task Execute(IJobExecutionContext context);
    }
}
