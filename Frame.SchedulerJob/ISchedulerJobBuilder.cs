using System.Threading.Tasks;

namespace Frame.SchedulerJob
{
    public interface ISchedulerJobBuilder
    {
        Task Start();

        Task End();

        Task Add(string schedulerName);

        Task ResumeOrPause(string schedulerName);

        Task Remove(string schedulerName);
    }
}
