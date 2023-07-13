using HealthCare.Infrastructure.Services.ActionFilter;
using HealthCare.Infrastructure.Services.ExceptionFilter;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCare.Infrastructure
{
    public static class ConfigureService
    {
        public static void AddInfrastructureConfigureService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers(option =>
            {
                option.Filters.Add<CustomExceptionFilter>();
                option.Filters.Add<CustomActionFilter>();
            });
        }
    }
}
