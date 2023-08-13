using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace phemon.Application.message
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // Register Application Health Checks
            services
                .AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("Net6WebApiConnection"));

            services.AddHealthChecksUI()
                .AddInMemoryStorage();

            // Register MediatR Services
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
