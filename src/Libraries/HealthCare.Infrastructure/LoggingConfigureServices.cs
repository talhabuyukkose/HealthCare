using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Text;

namespace HealthCare.Infrastructure
{
    public static class LoggingConfigureServices
    {
        public static void AddLoggingInfrastructureBuilder(this ILoggingBuilder loggingCollection, IConfiguration configuration)
        {
            var logger = new LoggerConfiguration()
                .WriteTo.File($"{configuration["Log:path"].Trim('/')}/{configuration["Log:prefix"]}.log"
                    , Serilog.Events.LogEventLevel.Information
                    , "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {CorrelationId} {Level:u3} {Username} {Message:lj}{Exception}{NewLine}"
                    , formatProvider: default
                    , fileSizeLimitBytes: 1024 * 512 // 512KB
                    , levelSwitch: default
                    , buffered: default
                    , shared: false
                    , flushToDiskInterval: default
                    , rollingInterval: RollingInterval.Day
                    , rollOnFileSizeLimit: true
                    , retainedFileCountLimit: 31
                    , Encoding.UTF8
                    , hooks: default
                    , retainedFileTimeLimit: default)
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                //.WriteTo.Console(Serilog.Events.LogEventLevel.Information)
                .CreateLogger();

            loggingCollection.ClearProviders();
            loggingCollection.AddSerilog(logger);
        }
    }
}
