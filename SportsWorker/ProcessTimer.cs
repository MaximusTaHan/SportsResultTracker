using Coravel.Invocable;
using SportsResultTracker;

namespace SportsWorker
{
    public class ProcessTimer : IInvocable
    {
        private readonly ILogger<ProcessTimer> logger;
        public ProcessTimer(ILogger<ProcessTimer> logger)
        {
            this.logger = logger;
        }

        public Task Invoke()
        {
            var dateTime = DateTime.Now;
            logger.LogInformation($"Starting job. Time: {dateTime}");

            SportsSender.Main();

            return Task.FromResult(true);
        }
    }
}
