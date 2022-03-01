using System.Threading.Tasks;

namespace Frame.Scheduler
{
    public interface ISchedulerBuilder
    {
        Quartz.IScheduler _scheduler { get; set; }

        void Initialize(Quartz.IScheduler scheduler);

        Task Start();

        Task End();

        Task Add(string schedulerName, string schedulerGroupName);

        Task ResumeOrPause(string schedulerName, string schedulerGroupName);

        Task Remove(string schedulerName, string schedulerGroupName);
    }
}
