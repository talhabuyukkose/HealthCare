using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace HealthCare.Infrastructure.Quartz
{
    public class MyScheduler
    {
        private readonly ISchedulerFactory schedulerFactory;
        private readonly IJobFactory jobFactory;
        private IScheduler scheduler { get; set; }

        public MyScheduler(ISchedulerFactory schedulerFactory, IJobFactory jobFactory)
        {
            this.schedulerFactory = schedulerFactory;
            this.jobFactory = jobFactory;
        }
        public async Task Start()
        {
            scheduler = await schedulerFactory.GetScheduler();

            if (!scheduler.IsStarted)
            {
                await scheduler.Start();
            }

            scheduler.JobFactory = jobFactory;

            var serviceJobKey = new JobKey(Guid.NewGuid().ToString());

            IJobDetail jobDetail = JobBuilder
                .Create<SendEmailOrSmsJob>()
                .WithIdentity("SendEmailOrSmsJob")
                .Build();

            var simpleTrigger = (ICronTrigger)TriggerBuilder
                .Create()
                .WithIdentity("SendEmailOrSmsJob")
                .StartNow()
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(7, 00))
                .Build();

            await scheduler.ScheduleJob(jobDetail, simpleTrigger);
        }
        public async Task Stop()
        {
            scheduler = await schedulerFactory.GetScheduler();

            if (!scheduler.IsShutdown)
            {
                scheduler.Shutdown();
            }
        }
    }
}
