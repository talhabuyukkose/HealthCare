using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace HealthCare.Core
{
    public static class ConfigureServices
    {
        public static void AddCoreConfigureServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);

            services.AddMediatR(assembly);
        }
    }
}
