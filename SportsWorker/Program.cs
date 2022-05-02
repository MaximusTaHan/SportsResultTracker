using SportsWorker;
using Coravel;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScheduler();
        services.AddTransient<ProcessTimer>();
    })
    .Build();

host.Services.UseScheduler(scheduler =>
{
    var jobSchedule = scheduler.Schedule<ProcessTimer>();
    jobSchedule.DailyAtHour(8);
});
await host.RunAsync();
