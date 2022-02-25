using Quartz;
using System.Threading.Tasks;

namespace Frame.Scheduler
{
    public interface ISchedulerBuilder
    {
        Quartz.IScheduler scheduler { get; set; }

        Task Start();

        Task End();

        Task Add(string schedulerName, string triggerName, string schedulerGroupName);

        Task ResumeOrPause(string schedulerName, string triggerName, string schedulerGroupName);

        Task Remove(string schedulerName, string triggerName, string schedulerGroupName);
    }
}
