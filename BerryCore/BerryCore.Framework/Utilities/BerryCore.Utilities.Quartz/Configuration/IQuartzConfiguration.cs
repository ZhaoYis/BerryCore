using Quartz;

namespace BerryCore.Utilities.Quartz.Configuration
{
    public interface IQuartzConfiguration
    {
        IScheduler Scheduler { get; }
    }
}