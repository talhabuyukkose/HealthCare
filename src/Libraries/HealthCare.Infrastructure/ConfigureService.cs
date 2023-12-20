using HealthCare.Core.Interfaces.Cache;
using HealthCare.Infrastructure.Quartz;
using HealthCare.Infrastructure.Services.ActionFilter;
using HealthCare.Infrastructure.Services.Cache;
using HealthCare.Infrastructure.Services.ExceptionFilter;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace HealthCare.Infrastructure
{
    public static class ConfigureService
    {
        public static void AddInfrastructureConfigureService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();

            serviceCollection.AddScoped<IMemoryService, MemoryService>();

            serviceCollection.AddControllers(option =>
            {
                option.Filters.Add<CustomExceptionFilter>();
                option.Filters.Add<CustomActionFilter>();
            });

            serviceCollection.Configure<QuartzOptions>(options =>
            {
                options.Scheduling.IgnoreDuplicates = true; // default: false
                options.Scheduling.OverWriteExistingData = true; // default: true
            });

            serviceCollection.AddQuartz(q =>
            {
                q.SchedulerId = "SendEmailOrSmsJob";
                q.SchedulerName = "SendEmailOrSmsJob";
                q.UseJobFactory<JobFactory>();
                q.UseMicrosoftDependencyInjectionJobFactory();
                //q.UseMicrosoftDependencyInjectionScopedJobFactory();
            });

            serviceCollection.AddTransient<MyScheduler>();
        }
    }
}
