using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace phemon.Persistence.message
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MessageDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Net6WebApiConnection"),
                b => b.MigrationsAssembly(typeof(MessageDbContext).Assembly.FullName))
                .LogTo(Console.WriteLine, LogLevel.Information)); // disable for production;

            services.AddScoped<IMessageDbContext>(provider =>
                provider.GetService<MessageDbContext>());

            return services;
        }
    }
}
